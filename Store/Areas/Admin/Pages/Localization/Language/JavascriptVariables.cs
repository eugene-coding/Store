using Newtonsoft.Json;

namespace Store.Areas.Admin.Pages.Localization.Language;

[Serializable]
public class JavascriptVariables
{
    public static JavascriptVariables Instance { get; } = new();

    public string UpdateListHandler => "List";
    public string OpenAddFormHandler => "AddForm";
    public string OpenEditFormHandler => "EditForm";
    public string AddLanguageHandler => "AddLanguage";
    public string UpdateLanguageHandler => "UpdateLanguage";


    public string FormId => "language";

    public string AddLanguageButtonId = $"add-language";

    public string EditLanguageButtonName => $"edit-language";

    public string CheckboxName => "checkbox";

    public string MainCheckboxId => $"main-checkbox";

    public string ListParentId => "languages-list";

    public string ModalId => "modal";

    public string ModalContentId => $"modal-content";

    public string ModalTitleId => $"modal-title";

    [NonSerialized]
    public string ModalSubmitButton = $"modal-submit";

    private JavascriptVariables()
    {
    }

    public static string Serialize()
    {
        return JsonConvert.SerializeObject(Instance);
    }
}
