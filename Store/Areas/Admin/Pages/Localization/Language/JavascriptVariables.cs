using Newtonsoft.Json;

namespace Store.Areas.Admin.Pages.Localization.Language;

public class JavascriptVariables
{
    public static JavascriptVariables Instance { get; } = new();

    public string FormId => "language";
    public string AddLanguageButtonId => $"add-{FormId}";
    public string EditLanguageName => $"edit-{FormId}";
    public string CheckboxName => "checkbox";
    public string MainCheckboxId => $"main-{CheckboxName}";
    public string TableBodyId => "languages-list";
    public string ModalId => "modal";
    public string ModalContentId => $"{ModalId}-content";
    public string ModalTitleId => $"{ModalId}-title";
    public string ModalSubmitButton => $"{ModalId}-submit";

    private JavascriptVariables()
    {
    }

    public static string Serialize()
    {
        return JsonConvert.SerializeObject(Instance);
    }
}
