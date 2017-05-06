/// <reference path="Customscript.js" />
/// <reference path="jquery-1.9.1.min.js" />


//saving postback data(last tab pressed) in the form of cookie.
//So that data would be available for next redirected page.

    $('#navv li a').click(function (e) {

       // $('#tab1').removeClass('ActiveTab');
       
        var $parent = $(this).parent();
        document.cookie = eraseCookie("tab");
        document.cookie = createCookie("tab", $parent.attr('id'), 0);
        
        //if (!$parent.hasClass('ActiveTab')) {
        //    $parent.addClass('ActiveTab');
        //}
        // e.preventDefault();
    });


//script for holding the tab active when user clicked to side bar

    $().ready(function () {
        var $activeTab = readCookie("tab");
        if (!$activeTab =="") {
            $('#tab1').removeClass('ActiveTab');
        }
      
        //alert($activeTab.toString());
       
        $('#' + $activeTab).addClass('ActiveTab');
        document.cookie = eraseCookie("tab");
        sortTable($('#product-table'), 'asc');
    });



//script for ajax call for search data with given string in serachbox
//Caling search action method to return the matched key word.
          
    $('#searchbutton').on('click', function (evnt) {
        var arg = $("#ssearchText").val();
        //$.get('Home/Search', { searchText : arg } , function (data) {
        //    $('.result').html(data);
        //});

        $.ajax({
            url: 'Home/Search',
            data: { 'searchText': arg },
            type: "post",
            cache: false,
            success: function (savingData) {
                $('.result').html(savingData);
                $.getScript('Scripts/Customscript.js');
                $.getScript('Scripts/IndexPageScript.js');
            }
        });
    });

function scroll() {
    window.location ="#location"
   
}

//changing the icon when key is pressed to that icon for modern checkbox item

$('#checkChangeBtn').children('button').on('click', function () {
   // alert('ds');
    if ($('#checkChange').attr('class') =='glyphicon glyphicon-minus')
        {
        $('#checkChange').removeClass('glyphicon glyphicon-minus');
        $('#checkChange').addClass('glyphicon glyphicon-plus');
    }
    else {
        $('#checkChange').removeClass('glyphicon glyphicon-plus');
        $('#checkChange').addClass('glyphicon glyphicon-minus');
    }
});


//Creating cookie script

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";

    document.cookie = name + "=" + value + expires + "; path=/";
}

//Read existing cookie

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

//Erase existing cookie

function eraseCookie(name) {
    createCookie(name, "", -1);
}



$('#sort-Table').on('click', function () {
    var glfoDirection = $(this).children('span').attr('class');
    if (glfoDirection == 'glyphicon glyphicon-chevron-down') {
        $(this).children('span').removeClass('glyphicon glyphicon-chevron-down');
        $(this).children('span').addClass('glyphicon glyphicon-chevron-up');
    }

    else {
        $(this).children('span').removeClass('glyphicon glyphicon-chevron-up');
        $(this).children('span').addClass('glyphicon glyphicon-chevron-down');
    }
    var gyfoDirection = $(this).children('span').attr('class');

    if (gyfoDirection == 'glyphicon glyphicon-chevron-down') {
        sortTable($('#product-table'), 'asc');

    }
    else {
        sortTable($('#product-table'), 'dsc');
    }


});



//Table sorting data script
function sortTable(table, order) {
    var asc = order === 'asc',
        tbody = table.find('tbody');

    tbody.find('tr').sort(function (a, b) {
        if (asc) {
            return $('td:first', a).text().localeCompare($('td:first', b).text());
        } else {
            return $('td:first', b).text().localeCompare($('td:first', a).text());
        }
    }).appendTo(tbody);
}




