/// <reference path="jquery-1.9.1.js" />

$("document").ready(function () {
    var p = $('#bookmark');
    var position = p.position();
    $(window).scrollTop(position.top - 100);
    
});