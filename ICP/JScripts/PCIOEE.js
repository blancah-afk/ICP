var min = 2;
var sec = 0;
var f = new Date();
var _nextURL
var _DisplayName
var tim2;

var refreshSec;

function refresh() {

    if (parseInt(refreshSec) > 0) {
        refreshSec = parseInt(refreshSec) - 1;
        document.getElementById("refreshIn").innerHTML =
             "Refreshing in: " + refreshSec + " Seconds ";
        tim2 = setTimeout("refresh()", 1000);

    }
    else {
        if (parseInt(refreshSec) == 0) {
            refreshMin = parseInt(refreshMin) - 1;
            if (parseInt(refreshMin) == -1) {
                clearTimeout(tim2);

            }
            else {
                refreshSec = 60;
                document.getElementById("refreshIn").innerHTML =
                     "Refreshing in: " + refreshSec + " Seconds";
                tim2 = setTimeout("refresh()", 1000);
            }
        }

    }
}

function f1(ruta, DisplayName) {

    _nextURL = ruta;
    _DisplayName = DisplayName;
    f2();

}

function f2() {
    if (parseInt(sec) > 0) {
        sec = parseInt(sec) - 1;
        document.getElementById("showtime").innerHTML =
             "Moving to  " + _DisplayName + " in: " + min + " Minutes ," + sec + " Seconds";
        tim = setTimeout("f2()", 1000);

    }
    else {
        if (parseInt(sec) == 0) {
            min = parseInt(min) - 1;
            if (parseInt(min) == -1) {
                clearTimeout(tim);
                location.href = _nextURL;
            }
            else {
                sec = 60;
                document.getElementById("showtime").innerHTML =
                     "Moving to  " + _DisplayName + " in: " + min + " Minutes ," + sec + " Seconds";
                tim = setTimeout("f2()", 1000);
            }
        }

    }
}


function RunGrahp(nextURL, DisplayName, refreshInfo) {
    var id = "divOEE";

    clearTimeout(tim2);
    refreshSec = 31;
    refresh();

    if (!refreshInfo) {
        f1(nextURL, DisplayName, refreshInfo);
    }



    $.ajax({
        type: "POST",
        url: "ICPWebService/WsICPOEE.asmx/getGraph_OEE",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
        }
    });

}


function Pause()
{
    clearTimeout(tim2);
    refreshSec = 31;
    refresh();
}