/// <reference path="jquery-1.9.1.min.js" />


//Update bookmark item in table through ajax call


    $('td').click(function (e) {

        //var row_index = $(this).parent().index('tr');

        //var col_index = $(this).index('tr:eq(' + row_index + ') td');

        //alert('Row # ' + (row_index) + ' Column # ' + (col_index));
        if ($(this).children('button').attr('class') == 'GyfoBtn GyfoBtn-default') {
            var id = $(this).children('button').attr('data-id');

            var tdElement = $(this).parent();
            var btnElement = $(this).children('button');
            
            $.ajax({
                url: 'Home/AddItemInBookmark',
                data: { 'id' : id },
                type: "post",
                cache: false,
                success: function (savingStatus) {
                    tdElement.addClass('text-muted');
                    btnElement.addClass('GyfoBtn-disabled');
                },
               
            });
           
        }
       
    });
