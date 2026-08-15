
$(document).ready(function () {

    $(".iframeVertical").colorbox({ iframe: true, width: "92%", height: "95%" });
    $(".iframeVertical2").colorbox({ iframe: true, width: "95%", height: "95%" });
    $(".iframeHorizontal").colorbox({ iframe: true, width: "75%", height: "95%" });
    $(".iframeDetail").colorbox({ iframe: true, width: "900px", height: "620px" });
});

$(function () {
    //$(".iframeVertical").colorbox({ iframe: true, width: "92%", height: "95%" });
    var gg1;

    var isMobile = false;
    // device detection
    if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
        || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) isMobile = true;

    if (isMobile === true) {
        //alert("Esta funcion no esta disponible para dispositivos moviles")
        //return;
    }

    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    ////Estos 4 compis quedan independientes porque tienen Zoom
    AjaxPPM("chPPM", Year, Month, "US", 0);
    AjaxGM("chGM1", Year, Month, "OEM", "MXN", "0", 0);
    AjaxGM("chGM2", Year, Month, "OEM", "USD", "0", 0);
    AjaxGM("chGM3", Year, Month, "Metalbuilding", "MXN", "0", 0);
    AjaxGM("chGM4", Year, Month, "Metalbuilding", "USD", "0", 0);


    AjaxInv("chInvLev", Year, Month, "Summary", "", "0", 0);
    AjaxInv("chInvLev180", Year, Month, "Inv_>_180_Days", "", "0", 0);
    AjaxFor("chForeComp", Year, Month, "General", "Actual", "0", 0);
    //Metodos Genericos
    AjaxVeloz("chWoodShip", Year, Month, "GetCostOfWood", "General", "Ton_Shipped", "0", 0);
    AjaxVeloz('chDelEv', Year, Month, "GetDeliveryEvScore", "General", "Days", "0", 0);
    AjaxVeloz('chEffRMD', Year, Month, "GetEffectRM", "General", "Days", "0", 0);
    AjaxVeloz('chExtCOPQ', Year, Month, "GetExtCOPQ", "General", "NT", "0", 0);
    AjaxVeloz('chExtCOPQd', Year, Month, "GetExtCOPQ", "Detail", "NT", "0", 0);

    AjaxVeloz('chExtCOPQd1', Year, Month, "GetExtCOPQ", "Temper", "NT", "0", 0);
    AjaxVeloz('chExtCOPQd2', Year, Month, "GetExtCOPQ", "Laser", "NT", "0", 0);

    AjaxVeloz('chAQPVer', Year, Month, "GetAQPVer", "Verified", "", "0", 0);
    AjaxVeloz('chProdSch', Year, Month, "GetProdSchComp", "General", "", "0", 0);
    AjaxVeloz('chProdSch1', Year, Month, "GetProdSchComp", "General", "Temper", "0", 0);
    AjaxVeloz('chProdSch2', Year, Month, "GetProdSchComp", "General", "Laser", "0", 0);
    AjaxVeloz('chEffCla', Year, Month, "GetECS", "General", "", "0", 0);
    AjaxVeloz('chDMRSt', Year, Month, "GetDRMStatus", "General", "30_Days", "0", 0);
    AjaxVeloz('chCusGM', Year, Month, "GetCustomerGM", "General", "NT", "0", 0);

    AjaxVeloz('chOrgGrow', Year, Month, "GetOrganicGrowth", "General", "Offset_NT", "0", 0);
    AjaxVeloz('chOurAVGPr', Year, Month, "GetAVGPrice", "General-USD", "NT", "0", 0);
    AjaxVeloz('chOurAVGPr2', Year, Month, "GetAVGPrice", "General-MXN", "NT", "0", 0);

    AjaxVeloz('chIntCOPQd', Year, Month, "GetIntCOPQ", "Detail", "NT", "0", 0);
    AjaxVeloz('chIntCOPQd1', Year, Month, "GetIntCOPQ", "Temper", "NT", "0", 0);
    AjaxVeloz('chIntCOPQd2', Year, Month, "GetIntCOPQ", "Laser", "NT", "0", 0);

});

///////////////// ZOOMs /////////////////
$('#ZoomPPM').on('shown.bs.modal', function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();

    $(".se-pre-PPM").fadeIn();
    $('#chPPMD1').empty();
    $('#chPPMD2').empty();
    $('#chPPMD3').empty();
    AjaxPPM("chPPMD1", Year, Month, "US", "1", 1);
    AjaxPPM("chPPMD2", Year, Month, "Domestic", "1", 1);
    AjaxPPM("chPPMD3", Year, Month, "Tata", "1", 1);
});

$('#ZoomGM').on('shown.bs.modal', function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();

    $(".se-pre-PPM").fadeIn();
    $('#chGM1').empty();
    $('#chGM2').empty();
    $('#chGM3').empty();
    $('#chGM4').empty();
    AjaxGM("chGM1", Year, Month, "OEM", "MXN", "1", 1);
    AjaxGM("chGM2", Year, Month, "OEM", "USD", "1", 1);
    AjaxGM("chGM3", Year, Month, "Metalbuilding", "MXN", "1", 1);
    AjaxGM("chGM4", Year, Month, "Metalbuilding", "USD", "1", 1);
});

$('#ZoomInv').on('shown.bs.modal', function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();

    $(".se-pre-Inv").fadeIn();
    $('#chInv1').empty();
    $('#chInv2').empty();
    $('#chInv3').empty();

    AjaxInv("chInv1", Year, Month, "Finished_Goods", "", "1", 1);
    AjaxInv("chInv2", Year, Month, "Raw_Material", "", "1", 1);
    //AjaxInv("chInv3", Year, Month, "Inv_>_180_Days", "", "1", 1);
});

$('#ZoomInv180').on('shown.bs.modal', function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();

    $(".se-pre-Inv").fadeIn();
    $('#chInv180-1').empty();
    $('#chInv180-2').empty();

    AjaxInv("chInv180_1", Year, Month, "Inv_>_180_Days", "Production", "1", 1);
    AjaxInv("chInv180_2", Year, Month, "Inv_>_180_Days", "Material", "1", 1);
});

$('#ZoomFor').on('shown.bs.modal', function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();

    $(".se-pre-For").fadeIn();
    $('#chFor1').empty();
    $('#chFor2').empty();

    AjaxFor("chFor1", Year, Month, "General", "Base", "1", 1);
    AjaxFor("chFor2", Year, Month, "General", "Actual", "1", 1);
});

$('#vCristal').on('shown.bs.modal', function () {
    $(this).find('.modal-body').css({
        width: 'auto', //probably not needed
        height: 'auto', //probably not needed
        'max-height': '100%'
    });
    //var $modal = $(this),
    //varId = e.relatedTarget.id;
    //VarCurr = 'USD';

    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    //$(".se-pre-For").fadeIn();
    //OpenCrystal(id, Report, FiscalYear, FiscalPeriod, Currency, StartDate, EndDate);
    //OpenCrystal(1, Year, Month, '1');
});


$('#vCrist').on("hidden.bs.modal", function () {
    $(this).find('iframe').attr('src', "")
});
//////////////LLAMADAS A GRAFICAS////////
function OpCrisMod() {
    $(".se-pre-Crys").fadeIn();
    var isMobile = false;
    // device detection
    if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
        || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) isMobile = true;

    if (isMobile === true) {
        alert("Esta función no esta disponible para dispositivos móviles")
        return false;
    } else {
        $('#vCristal').modal();
        return true;
    }
}

function ValidaMobile() {
    var isMobile = false;
    // device detection
    if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
        || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) isMobile = true;

    if (isMobile === true) {
        alert("Esta función no esta diseñada para dispositivos móviles")
        return false;
    } else {
        return true;
    }
}

function OpCrisModOff() {
    $(".se-pre-Crys").fadeOut("slow");
}

function Alertar(Mostrar, Mensaje)
{
    ValidaMobile();
    if (Mostrar == '1') {
        alert(Mensaje);
        return false;
    } else {
        return true;
    }
}

//$("#sAlertar2").click(function () {
//    event.preventDefault();
//    //alert("Venta tio que la baina era aca");
//    $('#mAlertar').modal('show');
//    event.preventDefault();
//    alert("que paso");
//    event.preventDefault();
//});

//////////////LLAMADAS A GRAFICAS////////