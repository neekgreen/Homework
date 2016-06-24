$(document).on('click', '#filterableRemoveButton', function (e) {

    //# Clear out the filter text, and navigate to page 1.
    $('#filterText').val('');

    getPaginable();

    return true;
});

$(document).on('click', '#filterableSubmitButton', function (e) {

    getFilterable();

    return true;
});

$(document).on('keypress', '#filterText', function (e) {

    var enterKey = 13;
    if (e.which === enterKey) {

        getFilterable();
        return false;
    }

    return true;
});


function getFilterable() {

    //# Move to first page on new filter based search requests.
    $('#pageNumber').val('1');

    getPaginable();

    return false;
}