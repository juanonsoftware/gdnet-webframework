$.ajax({
    cache: __cache,
    timeout: __timeout,
    type: '__type',
    url: '__url',
    data: __data,
    beforeSend: function () {
        __beforeSend
    },
    success: function (data, status, xhr) {
        __success
    },
    error: function (xhr, status) {
        __error
    }
});