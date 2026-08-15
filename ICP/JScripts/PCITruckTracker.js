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


    $.ajaxSetup({
        cache: false
    });

    var d = new Date();
    var n = d.getMonth() + 2;

    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    var today = (mm < 10 ? '0' + mm : '' + mm) + '' + (dd < 10 ? '0' + dd : '' + dd) + '' + yyyy;

    var isMobile = false;
    // device detection
    if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
        || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) isMobile = true;

    var table = $('#tbTruckTracker').DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14],
                },
                title: today + 'KPI'
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: ':visible',
                },
                title: today + 'KPI'
            }
        ],
        responsive: true,
        "ordering": false,
        "info": false,
        "bScrollCollapse": false,
        "paging": false,
        "autoWidth": false,
        "pageLength": 25,
        "sAjaxSource": "ICPWebService/WsICPTruckTracker.asmx/getTruckTracker",
        "fnServerData": function (sSource, aoData, fnCallback) {
            $.ajax({
                "dataType": 'json',
                "contentType": "application/json; charset=utf-8",
                "type": "POST",
                "url": sSource,
                "data": "",
                "success": function (msg) {
                    var json = jQuery.parseJSON(msg.d);
                    fnCallback(json);
                    $("#tbTruckTracker").show();
                },
                error: function (xhr, textStatus, error) {
                    if (typeof console == "object") {
                        console.log(xhr.status + "," + xhr.responseText + "," + textStatus + "," + error);
                    }
                }
            });
        },
        "columnDefs": [
            {
                "targets": [0],
                "searchable": true,
                responsivePriority: 1
            }
           
        ],
        fnDrawCallback: function () {
            $('.image-details').bind("click", showDetails);
        }
        //,
        //fnRowCallback: function (nRow, aData, iDisplayIndex) {
        //    decorateRow(nRow, aData);
        //    return nRow;
        //}
    });

}

//function decorateRow(row, dat) {
//    //Indica las columnas que hay a la izquierda antes de
//    //Comenzar a mostrar los meses :D
//    var TabJump = 3;
//    var TabStop = TabJump + 12;

//    if (dat[TabStop + 1] == "<") {
//        for (var ii = TabJump; ii < TabStop; ii++) {
//            var Curr = dat[ii];
//            var Goal = dat[TabStop];
//            Goals = dat[TabStop].split('|');
//            if (Goals != null && Goals.length > 1) {
//                Goal = Goals[ii - TabJump];
//            }

//            if (parseFloat(Curr) >= parseFloat(Goal)) {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#ea6153");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");

//            } else {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#2ecc71");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            }
//        }
//    }
//    if (dat[TabStop + 1] == "<=") {
//        for (var ii = TabJump; ii < TabStop; ii++) {
//            var Curr = dat[ii];
//            var Goal = dat[TabStop];
//            Goals = dat[TabStop].split('|');
//            if (Goals != null && Goals.length > 1) {
//                Goal = Goals[ii - TabJump];
//            }

//            if (parseFloat(Curr) > parseFloat(Goal)) {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#ea6153");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            } else {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#2ecc71");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            }
//        }
//    }
//    if (dat[TabStop + 1] == ">") {
//        for (var ii = TabJump; ii < TabStop; ii++) {

//            var Curr = dat[ii];
//            var Goal = dat[TabStop];
//            Goals = dat[TabStop].split('|');
//            if (Goals != null && Goals.length > 1) {
//                Goal = Goals[ii - TabJump];
//            }

//            if (parseFloat(Curr) <= parseFloat(Goal)) {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#ea6153");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            } else {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#2ecc71");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            }
//        }
//    }
//    if (dat[TabStop + 1] == ">=") {
//        for (var ii = TabJump; ii < TabStop; ii++) {
//            var Curr = dat[ii];
//            var Goal = dat[TabStop];
//            Goals = dat[TabStop].split('|');
//            if (Goals != null && Goals.length > 1) {
//                Goal = Goals[ii - TabJump];
//            }

//            if (parseFloat(Curr) < parseFloat(Goal)) {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#ea6153");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            } else {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#2ecc71");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            }
//        }
//    }

//    if (dat[TabStop + 1] == "=") {
//        for (var ii = TabJump; ii < TabStop; ii++) {
//            var Curr = dat[ii];
//            var Goal = dat[TabStop];
//            Goals = dat[TabStop].split('|');
//            if (Goals != null && Goals.length > 1) {
//                Goal = Goals[ii - TabJump];
//            }

//            if (parseFloat(Curr) != parseFloat(Goal)) {
//                $('td', row).eq(ii).css("background-color", "#ea6153");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("text-align", "right");
//            } else {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#2ecc71");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            }
//        }
//    }

//    if (dat[TabStop + 1] == "") {
//        for (var ii = TabJump; ii < TabStop; ii++) {
//            var Curr = dat[ii];
//            var Goal = dat[TabStop];
//            Goals = dat[TabStop].split('|');
//            if (Goals != null && Goals.length > 1) {
//                Goal = Goals[ii - TabJump];
//            }

//            if (parseFloat(Curr) != parseFloat(Goal)) {
//                $('td', row).eq(ii).css("background-color", "#ea6153");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("text-align", "right");
//            } else {
//                $('td', row).eq(ii).css("color", "#ecf0f1");
//                $('td', row).eq(ii).css("background-color", "#2ecc71");
//                $('td', row).eq(ii).css("font-weight", "bold");
//                $('td', row).eq(ii).css("text-align", "right");
//            }
//        }
//    }
//}

function showDetails() {
    //so something funky with the data
}

