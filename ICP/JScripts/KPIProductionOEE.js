var StartDate;
var EndDate;

$(function () {
    //Initialize Select2 Elements
    $(".select2").select2();

    //Datemask dd/mm/yyyy
    $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    //Datemask2 mm/dd/yyyy
    $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
    //Money Euro
    $("[data-mask]").inputmask();

    //Date range picker
    $('#reservation').daterangepicker();
    //Date range picker with time picker
    $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
    //Date range as a button
    $('#daterange-btn').daterangepicker(
        {
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
                'Last 2 Month': [moment().subtract(1, 'month').startOf('month'), moment().endOf('month')],
                'Last 3 Month': [moment().subtract(2, 'month').startOf('month'), moment().endOf('month')]
            },
            //startDate: moment().subtract(29, 'days'),
            //endDate: moment(),
            opens: "right",
            autoApply: true,
            showDropdowns: true
        },
        function (start, end) {
            $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            StartDate = start.format('YYYY-MM-DD');
            EndDate = end.format('YYYY-MM-DD');

        }
    );

    //Date picker
    $('#datepicker').datepicker({
        autoclose: true
    });

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    });
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
        checkboxClass: 'icheckbox_minimal-red',
        radioClass: 'iradio_minimal-red'
    });
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    });

});


$(document).ready(function () {

    $('#blockButton').click(function () {
        $('div.test').block({ message: null });
    });

    $('#blockButton2').click(function () {
        $('div.test').block({
            message: '<h1>Processing</h1>',
            css: { border: '3px solid #a00' }
        });
    });

    $('#unblockButton').click(function () {
        $('div.test').unblock();
    });

    $('a.test').click(function () {
        alert('link clicked');
        return false;
    });
});


function RunGrahp() {

    
    var id = "divOEE";

    if (StartDate == null || EndDate == null)
    {
        var id = "openModal";
       
       alert("Se debe seleccionar una fecha para analizar");

    }
    else
    {
        jsShowWindowLoad("Wait while the report is running");
        $.ajax({    
            type: "POST",
            url: "wsKPI/wsKPIProductionOEE.asmx/getOEE",
            data: "{'StartDate': '" + StartDate + "','EndDate': '" + EndDate + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.hasOwnProperty("d")) {
                    jsRemoveWindowLoad();
                    $('#' + id).html(result.d);
                }
                else {
                   
                    $('#' + id).html(result);
                }
            }
        });
    }

  
}

function jsRemoveWindowLoad() {
    // eliminamos el div que bloquea pantalla
    $("#WindowLoad").remove();

}

function jsShowWindowLoad(mensaje) {
    //eliminamos si existe un div ya bloqueando
    jsRemoveWindowLoad();

    //si no enviamos mensaje se pondra este por defecto
    if (mensaje === undefined) mensaje = "Procesando la información&amp;lt;br&amp;gt;Espere por favor";

    //centrar imagen gif
    height = 20;//El div del titulo, para que se vea mas arriba (H)
    var ancho = 0;
    var alto = 0;

    //obtenemos el ancho y alto de la ventana de nuestro navegador, compatible con todos los navegadores
    if (window.innerWidth == undefined) ancho = window.screen.width;
    else ancho = window.innerWidth;
    if (window.innerHeight == undefined) alto = window.screen.height;
    else alto = window.innerHeight;

    //operación necesaria para centrar el div que muestra el mensaje
    var heightdivsito = alto / 2 - parseInt(height) / 2;//Se utiliza en el margen superior, para centrar

    //imagen que aparece mientras nuestro div es mostrado y da apariencia de cargandoC:\Users\BHernandez\Desktop\01Steel\03AppExternas\Ambiente KPI Epicor 10\Ambiente KPI Epicor 10 - PCI\KPIDashboardV2\KPIDashboardV2\imgs/Preloader_3.gif
    imgCentro = "<div style='text-align:center;height:" + alto + "px;'><div  style='color:#000;margin-top:"
        + heightdivsito + "px; font-size:20px;font-weight:bold'>" + mensaje + "</div><img  src='imgs/Preloader_3.gif'></div>";

    //creamos el div que bloquea grande------------------------------------------
    div = document.createElement("div");
    div.id = "WindowLoad"
    div.style.width = ancho + "px";
    div.style.height = alto + "px";
    $("body").append(div);

    //creamos un input text para que el foco se plasme en este y el usuario no pueda escribir en nada de atras
    input = document.createElement("input");
    input.id = "focusInput";
    input.type = "text"

    //asignamos el div que bloquea
    $("#WindowLoad").append(input);

    //asignamos el foco y ocultamos el input text
    $("#focusInput").focus();
    $("#focusInput").hide();

    //centramos el div del texto
    $("#WindowLoad").html(imgCentro);

}

