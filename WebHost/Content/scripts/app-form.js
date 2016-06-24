//# Remove error messages when form elements are changed.
$("input,select,textarea").change(function () {
    var field = $(this).attr("name");
    $('div[name=' + field + ']').hide();
});


$('form').on('reset', function () {

    var $form = $(this).closest("form");

    $('div.error', $form).hide();

    setTimeout(function () {
        $('select', $form).each(
            function () {
                $(this).select2('val', $(this).find('option:selected').val());
            });
    });

    return true;
});


$('.form-submit').on('click', function () {

    var $form = $(this).closest("form");
    var data = $form.serialize();
    var navigateUrl = $form.attr("action");

    var request = $.ajax({
        type: "post",
        data: data,
        url: navigateUrl,
    });

    request.fail(function (xhr) {
        var response;

        //# Hide all error messages.
        $('div.error').hide();

        if (xhr.status === 400) {

            $('div.summary-error').show();

            if (xhr.responseText) {
                response = JSON.parse(xhr.responseText);
                var fields = Object.keys(response);

                fields.forEach(function (field) {
                    if (response[field].Errors && response[field].Errors.length > 0) {
                        $('div[name=' + field + ']')
                            .text(response[field].Errors[0].ErrorMessage)
                            .show();
                    }
                });
            }
        }
    });

    request.success(function (data) {

        //# Hide all error messages.
        $('div.error').hide();

        if ((data.redirect !== null) && (data.redirect !== undefined)) {
            window.location.href = data.redirect;
        }
        else {
            var closeButton = $('.modal-close[data-dismiss="modal"]', $form);

            if ((closeButton !== null) || (closeButton !== undefined)) {
                closeButton.trigger('click');
            }
        }
    });

    return false;
});



$(document).unbind('click').on('click', '.cart-submit', function (e) {

    var $form = $(this).closest("form");
    var data = $form.serialize();
    var navigateUrl = $form.attr("action");

    var request = $.ajax({
        type: "post",
        data: data,
        url: navigateUrl,
    });

    request.success(function (data) {

        $("#cart-content").html(data);
    });

    return false;
});