$('input[name="sample"]').change(function () {
    var result = $(this).val();

    console.log(result);
})

$(function () {
    $('.js-favoriteButton').click(function () {
        // いいねしたメッセージのidを取得する
        var id = $(this).data('message_id');

        // Ajax通信
        $.ajax({
            headers: {
                // csrf対策
                'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
            },
            url: '/favorite/' + id, // アクセスするURL
            type: 'GET', // POSTかGETか
            id: id, // わからん
            success: function () {
                //通信が成功した場合の処理をここに書く
            },
            error: function () {
                //通信が失敗した場合の処理をここに書く
            }
        });
    });
});