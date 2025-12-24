// small theme helpers: enable bootstrap tooltips and adjust focus outlines
document.addEventListener('DOMContentLoaded', function () {
    // enable bootstrap tooltips where used
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.forEach(function (el) {
        new bootstrap.Tooltip(el);
    });

    // subtle focus outline for accessibility
    document.querySelectorAll('a, button, input, textarea, select').forEach(el => {
        el.addEventListener('focus', () => el.classList.add('focused'));
        el.addEventListener('blur', () => el.classList.remove('focused'));
    });
});