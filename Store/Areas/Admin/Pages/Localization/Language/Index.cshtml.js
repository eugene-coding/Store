let modal;
let modalTitle;
let modalContent;

document.addEventListener("DOMContentLoaded", () => {
    updateList();
    setupCheckboxes();

    modal = getModal();

    modalTitle = document.getElementById(variables.ModalTitleId);
    modalContent = document.getElementById(variables.ModalContentId);
})

/**
 * Sets checkboxes in the table so that when the main checkbox is clicked, 
 * all other checkboxes take on its current state.
 */
function setupCheckboxes() {
    const mainCheckbox = document.getElementById(variables.MainCheckboxId);
    const checkboxes = document.getElementsByName(variables.CheckboxName);

    mainCheckbox.addEventListener("change", () => {
        checkboxes.forEach(checkbox => {
            checkbox.checked = mainCheckbox.checked;
        });
    });
}

/**
 * Updates the list of languages.
 */
function updateList() {
    fetch(location.href + "?handler=" + variables.UpdateListHandler)
        .then(response => response.text())
        .then(data => document.getElementById(variables.ListParentId).innerHTML = data);
}

function getModal() {
    const element = document.getElementById(variables.ModalId);
    return new bootstrap.Modal(element);
}

function addOpenAddFormEventListener(modalTitle) {
    document.getElementById(variables.AddLanguageButtonId).addEventListener("click", event => {
        openAddForm(modalTitle);
    })
}

function addOpenEditFormEventListener(modalTitle) {
    document.getElementsByName(variables.EditLanguageButtonName).addEventListener("click", event => {
        openEditForm(modalTitle);
    })
}

/**
 * Opens a modal window and loads the form for adding a new language.
 * @param {string} title Title text.
 */
function openAddForm(title) {
    openModal(title);

    fetch(location.href + "?handler=" + variables.OpenAddFormHandler)
        .then(response => response.text())
        .then(data => {
            modalContent.innerHTML = data;
            configureAddFormSubmit();
        })
}

function openEditForm(title) {
    openModal(title);

    fetch(location.href + "?handler=" + variables.OpenEditFormHandler)
        .then(response => response.text())
        .then(data => {
            modalContent.innerHTML = data;
            configureEditFormSubmit();
        })
}

function openModal(title) {
    modalTitle.innerHTML = title;
    modal.show(title);
}

function configureAddFormSubmit() {
    const form = document.getElementById(variables.FormId);

    form.addEventListener("submit", event => {
        event.preventDefault();

        addLanguage()
            .then(() => {
                modal.hide();
                updateList();
            })
            .catch(alert("Что-то пошло не так"));
    })
}

function configureEditFormSubmit() {
    const form = document.getElementById(variables.FormId);

    form.addEventListener("submit", event => {
        event.preventDefault();

        updateLanguage()
            .then(() => {
                modal.hide();
                updateList();
            })
            .catch(alert("Что-то пошло не так"));;
    });
}

/**
 * Adds a new language.
 */
function addLanguage() {
    return submitForm(variables.AddLanguageHandler);
}

/**
 * Updates the language.
 */
function updateLanguage() {
    // Дописать параметры 
    return submitForm(variables.UpdateLanguageHandler);
}

/**
 * Submits the form.
 * @param {string} handler Handler name.
 * @returns Promise, which is an asynchronous object representing the final state of the request.
 */
function submitForm(handler) {
    return fetch(location.href + "?handler=" + handler, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: convertFormDataToJson()
    });
}

/**
 * Converts form data to JSON.
 * @returns Form data in JSON.
 */
function convertFormDataToJson() {
    const form = document.getElementById(variables.FormId);
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
