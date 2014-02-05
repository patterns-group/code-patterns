function resizeDynamicContent() {
    var iframe = document.getElementById('sourceViewer');
    iframe.style.height = "20px";

    var height = document.getElementById('frameDiv').clientHeight;
    
    iframe.style.height = height + "px";
};