export function setSchemaAttributes() {
    const html = document.documentElement;

    html.setAttribute("itemscope", "");
    html.setAttribute("itemtype", "https://schema.org/FAQPage");
}

export function removeSchemaAttributes() {
    const html = document.documentElement;

    html.removeAttribute("itemscope");
    html.removeAttribute("itemtype");
}
