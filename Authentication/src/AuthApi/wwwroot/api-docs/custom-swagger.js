(function($=window.jQuery) {
    var headerTitle = `
    <h2 id="customSwaggerUiHeader" class="microservices-custom-Header">
        <span>Taylor </span>
        <span>DiGITAL</span>
        <span style="">
            UI By
            <a href="http://swagger.io" class="custom-color">
                swagger
            </a>
        </span>
    </h2>`;
    $("#logo").parent().prepend(headerTitle);
    var customHeader = $("#logo").parent();
    $("#logo").remove();
    $(customHeader).fadeIn(2000);
})();