$(document).on('click', 'a[name="page-number"]', function (e) {

    e.preventDefault();

    var target = $(e.target);
    var pageNumber = target.data('page-number');

    $('#pageNumber').val(pageNumber);

    getPaginable();

    return false;
});


$(document).on('change', 'select[name="item-count-per-page"]', function (e) {

    e.preventDefault();

    var target = $(e.target);
    var option = $('option:selected', target);
    var itemCountPerPage = option.val();

    $('#itemCountPerPage').val(itemCountPerPage);

    getPaginable();

    return false;
});


function getPaginable() {

    var data = $('form').serialize();
    var navigateUrl = $('#paginable').data('paginable-url');

    var request = $.ajax(
    {
        url: navigateUrl,
        type: "POST",
        data: data,
        dataType: "html",
        cache: false,
        async: true
    });

    request.done(function (data) {
        $("#paginable-content").html(data);
    });

    return false;
}