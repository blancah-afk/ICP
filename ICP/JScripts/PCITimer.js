var tim;

var min = 0;
var sec = 30;
var f = new Date();
var ruta;
var rutaOriginal

function f1(ruta, DisplayName) {

    rutaOriginal = ruta;
    displayName = DisplayName;
    f2();



}

function f2() {
    if (parseInt(sec) > 0) {
        sec = parseInt(sec) - 1;
        document.getElementById("showtime").innerHTML =
              "Moving to  " + displayName + " in: " + min + " Minutes ," + sec + " Seconds";
        tim = setTimeout("f2()", 1000);

    }
    else {
        if (parseInt(sec) == 0) {
            min = parseInt(min) - 1;
            if (parseInt(min) == -1) {
                clearTimeout(tim);
                location.href = rutaOriginal;
            }
            else {
                sec = 60;
                document.getElementById("showtime").innerHTML =
                      "Moving to  " + displayName + " in: " + min + " Minutes ," + sec + " Seconds";
                tim = setTimeout("f2()", 1000);
            }
        }

    }
}
