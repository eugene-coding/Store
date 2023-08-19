using Newtonsoft.Json;

namespace Store.Areas.Admin.Pages.Localization.Language;

[Serializable]
public class JavascriptVariables
{
    private JavascriptVariables()
    {
    }

    public static JavascriptVariables Instance { get; } = new();

    public string UpdateListHandler => "List";
    public string OpenAddFormHandler => "AddForm";
    public string OpenEditFormHandler => "EditForm";
    public string OpenDeleteConfirmationHandler => "DeleteConfirmation";
    public string AddLanguageHandler => "AddLanguage";
    public string UpdateLanguageHandler => "UpdateLanguage";

    public string FormId => "language";
    public string AddLanguageButtonId => "add-language";
    public string EditLanguageButtonName => "edit-language";
    public string DeleteLanguageButtonName => "delete-language";
    public string CheckboxName => "checkbox";
    public string MainCheckboxId => "main-checkbox";
    public string ListParentId => "languages-list";

    public string ModalId => "modal";
    public string DeleteConfirmationModalId => "delete-confirmation";
    public string ModalContentId => "modal-content";
    public string ModalTitleId => "modal-title";

    public static string Serialize()
    {
        return JsonConvert.SerializeObject(Instance);
    }
}
