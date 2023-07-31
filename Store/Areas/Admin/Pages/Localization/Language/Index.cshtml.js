/**
 * Sets checkboxes in the table so that when the main checkbox is clicked, 
 * all other checkboxes take on its current state.
 * @param {string} mainCheckboxId Main checkbox ID.
 * @param {string} checkboxName Checkbox name.
 */
function setupCheckboxes(mainCheckboxId, checkboxName) {
    const mainCheckbox = document.getElementById(mainCheckboxId);
    const checkboxes = document.getElementsByName(checkboxName);

    mainCheckbox.addEventListener("change", () => {
        checkboxes.forEach(checkbox => {
            checkbox.checked = mainCheckbox.checked;
        });
    });
}

/**
 * Updates the list of languages.
 * @param {string} handler Handler name.
 * @param {string} listParentId The ID of the parent element within which the list is to be updated.
 */
function updateList(handler, listParentId) {
    fetch(location.href + "?handler=" + handler)
        .then(response => response.text())
        .then(data => {
            document.getElementById(listParentId).innerHTML = data
        });
}

/**
 * Opens a modal window and loads the form for adding a new language.
 * @param {string} handler Handler name.
 * @param {Modal} modal Modal window on which the form is located.
 * @param {string} titleId Modal title ID.
 * @param {string} contentId Modal content ID.
 * @param {string} title Title text.
 */
function openAddForm(handler, modal, titleId, contentId, title) {
    document.getElementById(titleId).innerHTML = title;

    modal.show();

    fetch(location.href + "?handler=" + handler)
        .then(response => response.text())
        .then(data => document.getElementById(contentId).innerHTML = data)
}

function configureEventListenerOnAdd() {
    document.getElementById("@IndexModel.FormId").addEventListener("submit", event => {
        event.preventDefault();
        add();
        getList();
    })
}

// function configureSubmitOnAdd(){
//     document.getElementById("@IndexModel.FormId").addEventListener("submit", event => {
//         event.preventDefault();
//         add();
//         getList();
//     })
// }

/**
 * Adds a new language.
 * @param {any} handler Handler name.
 * @param {any} formId Form ID.
 */
function addLanguage(handler, formId) {
    submitForm(handler, formId);
}

/**
 * Updates the language.
 * @param {any} handler Handler name.
 * @param {any} formId Form ID.
 */
function updateLanguage(handler, formId) {
    submitForm(handler, formId);
}

/**
 * Submits the form.
 * @param {string} handler Handler name.
 * @param {string} formId Form ID.
 * @returns Promise, which is an asynchronous object representing the final state of the request.
 */
function submitForm(handler, formId) {
    return fetch(location.href + "?handler=" + handler, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: convertFormDataToJson(formId)
    });
}

/**
 * Converts form data to JSON.
 * @param {string} formId Form ID.
 * @returns Form data in JSON.
 */
function convertFormDataToJson(formId) {
    const form = document.getElementById(formId);
    const formData = new FormData(form);

    const entity = {};

    for (const key of formData.keys()) {
        entity[camelize(key)] = formData.get(key);
    }

    return JSON.stringify(entity)
}

/**
 * Converts a string to camel case.
 * @param {string} str String to convert.
 * @returns String converted to camel case.
 */
function camelize(str) {
    return str.replace(/(?:^\w|[A-Z]|\b\w)/g, (word, index) => {
        return index === 0 ? word.toLowerCase() : word.toUpperCase();
    }).replace(/\s+/g, '');
}
