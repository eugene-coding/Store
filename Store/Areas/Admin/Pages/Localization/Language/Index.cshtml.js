/**
 * Modal window.
 */
let modal;

/**
 * Modal window title.
 */
let modalTitle;

/**
 * Modal window content.
 */
let modalContent;

document.addEventListener("DOMContentLoaded", () => {
    updateList();
    setupCheckboxes();
    setModalVariables();
    addOpenAddFormEventListener();
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
 * Sets the modal window and its elements to variables.
 */
function setModalVariables() {
    modal = getModal();

    modalTitle = document.getElementById(variables.ModalTitleId);
    modalContent = document.getElementById(variables.ModalContentId);
}

/**
 * Updates the list of languages.
 */
function updateList() {
    fetch(location.href + "?handler=" + variables.UpdateListHandler)
        .then(response => response.text())
        .then(data => document.getElementById(variables.ListParentId).innerHTML = data)
        .then(() => addOpenEditFormEventListener());
}

/**
 * Adds events to the add button to open add form on click.
 */
function addOpenAddFormEventListener() {
    document.getElementById(variables.AddLanguageButtonId).addEventListener("click", () => {
        openAddForm();
    })
}

/**
 * Opens the add language form.
 */
function openAddForm() {
    openModal(addText);

    fetch(location.href + "?handler=" + variables.OpenAddFormHandler)
        .then(response => response.text())
        .then(data => {
            modalContent.innerHTML = data;
            configureAddFormSubmit();
        })
}

/**
 * Configures form submission when adding a language.
 */
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

/**
 * Adds a new language.
 */
function addLanguage() {
    return submitForm(variables.AddLanguageHandler);
}

/**
 * Adds events to language edit buttons to open edit form on click.
 */
function addOpenEditFormEventListener() {
    const editButtons = document.getElementsByName(variables.EditLanguageButtonName);

    editButtons.forEach(editButton => {
        const id = editButton.dataset.id;

        editButton.addEventListener("click", () => openEditForm(id));
    })
}

/**
 * Opens the edit language form.
 * @param {number} id The ID of the entity to be edited.
 */
function openEditForm(id) {
    openModal(editText);

    fetch(location.href + "?handler=" + variables.OpenEditFormHandler + "&id=" + id)
        .then(response => response.text())
        .then(data => {
            modalContent.innerHTML = data;
            configureEditFormSubmit();
        })
}

/**
 * Configures form submission when editing a language.
 */
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
 * Updates the language.
 */
function updateLanguage() {
    return submitForm(variables.UpdateLanguageHandler);
}

/**
 * Creates the instance of the modal window.
 * @returns {bootstrap.Modal} Modal window.
 */
function getModal() {
    const element = document.getElementById(variables.ModalId);
    return new bootstrap.Modal(element);
}

/**
 * Opens the modal window.
 * @param {string} title
 */
function openModal(title) {
    modalTitle.innerHTML = title;
    modal.show(title);
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
