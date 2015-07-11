/*
 * Script que contém Binding Handler do KnockoutJS para ser usado nas telas.
*/

// Efeito de FadeIn/FadeOut do jQuery associado ao data-bind 'fadeVisible'
ko.bindingHandlers.fadeVisible = {
    init: function (element, valueAccessor) {
        // Initially set the element to be instantly visible/hidden depending on the value
        var value = valueAccessor();
        $(element).toggle(ko.unwrap(value)); // Use "unwrapObservable" so we can handle values that may or may not be observable
    },
    update: function (element, valueAccessor) {
        // Whenever the value subsequently changes, slowly fade the element in or out
        var value = valueAccessor();
        ko.unwrap(value) ? $(element).fadeIn() : $(element).fadeOut();
    }
};

// Fade + Slide
$.fn.slideDownFadeIn = function (speed) {
    return this.stop(true, true).fadeIn({ duration: speed, queue: false }).css('display', 'none').slideDown(speed);
};
$.fn.slideUpFadeOut = function (speed) {
    return this.stop(true, true).slideUp({ duration: speed, queue: false }).fadeOut(speed);
};
