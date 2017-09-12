$(function () {

    $('div#loading').hide();

    var _inCallback = false;
    var page = 1;
    function loadItems() {
        TotalPages = $('input#TotalPages').val() || 1;
        page = $('input#CurrentPage').val() || 1;
        if (page < TotalPages && !_inCallback) {
            _inCallback = true;
            var genre = $('input#CurrentGenre').val() || null;
            var data = JSON.stringify({ genre: genre });
            page++;
            $('input#CurrentPage').val(page) || 1;
            $('div#loading').show();

            $.ajax({
                type: 'GET',
                url: '/Start/_Books/' + page,
                data: data,
                success: function (data, textstatus) {
                    if (data !== '') {
                        $("#scrolList").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                    $("div#loading").hide();
                }
            });
        }
    }
    // обработка события скроллинга
    $(window).scroll(function () {
        if ($(window).scrollTop() === $(document).height() - $(window).height()) {
            loadItems();
        }
    });
});