export function open() {
    const mobileMenu = document.getElementById('mobile-menu');
    mobileMenu.style.left = '0';

    const overlay = document.getElementById('mobile-menu-overlay');
    overlay.style.display = 'block';
}

export function close() {
    const mobileMenu = document.getElementById('mobile-menu');
    mobileMenu.style.left = '-385px';

    const overlay = document.getElementById('mobile-menu-overlay');
    overlay.style.display = 'none';
}
