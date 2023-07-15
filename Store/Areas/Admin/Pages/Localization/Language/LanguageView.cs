using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Admin.Pages.Localization.Language;

/// <summary>
/// Model for <see cref="Data.Models.Language"/> display.
/// </summary>
public class LanguageView
{
    /// <inheritdoc cref="Data.Models.Language.Id"/>
    [HiddenInput]
    public int Id { get; set; }

    /// <inheritdoc cref="Data.Models.Language.Name"/>
    [Display(Name = nameof(Name))]
    [MaxLength(24)]
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc cref="Data.Models.Language.Code"/>
    [Display(Name = nameof(Code))]
    [MaxLength(5)]
    public string Code { get; set; } = string.Empty;

    /// <inheritdoc cref="Data.Models.Language.SortOrder/>
    [Display(Name = nameof(SortOrder))]
    public int SortOrder { get; set; }

    /// <inheritdoc cref="Data.Models.Language.Enabled"/>
    [Display(Name = nameof(Enabled))]
    public bool Enabled { get; set; }

    public static implicit operator Data.Models.Language(LanguageView language)
    {
        return new Data.Models.Language
        {
            Id = language.Id,
            Name = language.Name,
            Code = language.Code,
            SortOrder = language.SortOrder,
            Enabled = language.Enabled
        };
    }

    public static explicit operator LanguageView(Data.Models.Language language)
    {
        return new LanguageView
        {
            Id = language.Id,
            Name = language.Name,
            Code = language.Code,
            SortOrder = language.SortOrder,
            Enabled = language.Enabled
        };
    }
}
