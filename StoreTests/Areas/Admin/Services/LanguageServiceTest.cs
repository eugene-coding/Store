using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Store.Data;
using Store.Data.Models;

namespace Store.Areas.Admin.Services.Tests;

[TestClass]
public class LanguageServiceTest
{
    private readonly static Language _language = new() { Code = "eu" };

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
        await AddLanguage();

        await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _service.AddAsync(_language));
    }

    [TestMethod]
    public async Task DeleteExistingLanguage()
    {
        await AddLanguage();

        var language = await _context.Languages.FindAsync(1);
        Assert.IsNotNull(language);

        await _service.DeleteAsync(1);
        language = await _context.Languages.FindAsync(1);

        Assert.IsNull(language);
    }

    [TestMethod]
    public async Task DeleteNonExistentLanguage()
    {
        await _service.DeleteAsync(1);
        var language = await _context.Languages.FindAsync(1);

        Assert.IsNull(language);
    }

    [TestMethod]
    public async Task GetLanguages()
    {
        await AddLanguage();

        var languages = await _service.GetAsync();

        Assert.AreEqual(1, languages.Count);
    }

    [TestMethod]
    public async Task ExistsFoundLanguage()
    {
        await AddLanguage();

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
        await AddLanguage();

        var count = await _service.GetCountAsync();

        Assert.AreEqual(1, count);
    }

    [TestCleanup]
    public async Task Cleanup()
    {
        await _context.DisposeAsync();
    }

    private async Task AddLanguage()
    {
        await _context.Languages.AddAsync(_language);
        await _context.SaveChangesAsync();
    }
}
