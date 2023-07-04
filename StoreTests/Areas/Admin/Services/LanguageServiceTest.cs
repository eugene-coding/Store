using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Store.Data;
using Store.Data.Models;

namespace Store.Areas.Admin.Services.Tests;

[TestClass]
public class LanguageServiceTest
{
    private readonly static Language _language = new("eu");

    private readonly ApplicationDbContext _context;
    private readonly LanguageService _service;

    public LanguageServiceTest()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _service = new LanguageService(_context);
    }

    [TestMethod]
    public async Task AddNewLanguage()
    {
        await _service.AddAsync(_language);
        var exists = await _context.Languages.AnyAsync(l => l == _language);

        Assert.IsTrue(exists);
    }

    [TestMethod]
    public async Task AddExistingLanguage()
    {
        await _context.Languages.AddAsync(_language);
        await _context.SaveChangesAsync();

        await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _service.AddAsync(_language));
    }

    [TestMethod]
    public async Task ExistsFoundLanguage()
    {
        await _context.Languages.AddAsync(_language);
        await _context.SaveChangesAsync();

        var exists = await _service.ExistsAsync(_language.Code);

        Assert.IsTrue(exists);
    }

    [TestMethod]
    public async Task ExistsNotFoundLanguage()
    {
        var exists = await _service.ExistsAsync(_language.Code);

        Assert.IsFalse(exists);
    }

    [TestMethod]
    public async Task GetCountAsyncTest()
    {
        await _context.Languages.AddAsync(_language);
        await _context.SaveChangesAsync();

        var count = await _service.GetCountAsync();

        Assert.AreEqual(1, count);
    }

    [TestCleanup]
    public async Task Cleanup()
    {
        await _context.DisposeAsync();
    }
}
