$('#__id').autocomplete({
    minLength: __minLength,
    source: function (request, response) {
        $.ajax({
            cache: __cache,
            timeout: __timeout,
            type: '__type',
            url: '__url',
            contentType: '__contentType',
            data: __data,
            beforeSend: function () {
                $('#__log').text('Loading...');
            },
            success: function (data, status, xhr) {
                $('#__log').text('');
                response($.map(data.d, function (item) {
                    return {
                        value: item.Label,
                        label: item.Label,
                        id: item.Id
                    };
                }));
            },
            error: function (xhr, status) {
                $('#__log').text(status.toString());
            }
        });
    },
    select: function (event, ui) {
        __select
    },
    open: function () {
        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
    },
    close: function () {
        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
    }
});