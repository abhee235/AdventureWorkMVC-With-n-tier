/// <reference path="jquery-1.9.1.min.js" />


$(document).on('click','td',function (e) {
    
       var id = $(this).children('button').attr('data-id');

       var tdElement = $(this).parent();

        $.ajax({
            url: 'RemoveItemFromBookmark',
            data: { 'id': id },
            type: "post",
            cache: false,
            success: function (savingStatus) {
                $(tdElement).fadeOut('slow');
            }
        });
});
