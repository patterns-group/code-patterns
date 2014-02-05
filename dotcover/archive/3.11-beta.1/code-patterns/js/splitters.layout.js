$(document).ready(function() {
    if (!$.browser.webkit)
        initSplittersLayout();
});

$(window).load(function() {
    if ($.browser.webkit)
        initSplittersLayout();
});

function initSplittersLayout() {
    var myLayout = $('#splitters').layout({
        onresize: resizeDynamicContent,
        south__closable: false,
        south__resizable: false,
        south__spacing_open: 0,
        north__closable: false,
        north__resizable: false,
        north__spacing_open: 0
    });

    var width = $('body')[0].clientWidth - 350;
    if (width > 0)
        myLayout.sizePane("east", $('body')[0].clientWidth - 350);

    resizeDynamicContent();
}