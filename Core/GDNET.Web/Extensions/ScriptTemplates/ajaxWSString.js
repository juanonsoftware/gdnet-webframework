$.ajax({
    cache: __cache,
    timeout: __timeout,
    type: '__type',
    url: '__url',
    data: __data,
    beforeSend: function () {
        $("#__id").text('Loading...');
    },
    success: function (data, status, xhr) {
        $("#__id").text('');
        $("#__id").append($(data).find("string").text());
    },
    error: function (xhr, status) {
    }
});