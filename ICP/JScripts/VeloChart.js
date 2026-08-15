function AjaxPPM(id, Year, Month, Tipo, IsSub, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetsupplierPPM",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'IsSub': '" + IsSub + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 1) {
                $(".se-pre-PPM").fadeOut("slow");
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxGM(id, Year, Month, Tipo, Base, IsSub, fOut) {
    //el parámetro fOut indica si vamos a detener el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetGMPerSegment",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "', 'IsSub': '" + IsSub + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 1) {
                $(".se-pre-GM").fadeOut("slow");
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxInv(id, Year, Month, Tipo, Base, IsSub, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetInvLevel",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "', 'IsSub': '" + IsSub + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 1) {
                $(".se-pre-Inv").fadeOut("slow");
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxFor(id, Year, Month, Tipo, Base, IsSub, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetSalesForecast",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "', 'IsSub': '" + IsSub + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 1) {
                $(".se-pre-For").fadeOut("slow");
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

/*
function AjaxWood(id, Year, Month, Tipo, Base, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetCostOfWood",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxDeliv(id, Year, Month, Tipo, Base, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetDeliveryEvScore",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxEffectRM(id, Year, Month, Tipo, Base, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetEffectRM",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxExtCOPQ(id, Year, Month, Tipo, Base, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetExtCOPQ",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxAQPVer(id, Year, Month, Tipo, Base, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetAQPVer",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxProdSchComp(id, Year, Month, Tipo, Base, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Details/wsGauge.asmx/GetProdSchComp",
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}
*/

function AjaxVeloz(id, Year, Month, Process, Tipo, Base, IsSub, fOut) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    var pp = "Details/wsGauge.asmx/" + Process
    $.ajax({
        type: "POST",
        //url: "Details/wsGauge.asmx/GetProdSchComp",
        url: pp,
        data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "', 'Base': '" + Base + "', 'IsSub': '" + IsSub + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 0) {
                $(".se-pre-Entire").fadeOut("slow");
            }
        }
    });
}

function AjaxHist(id, Proc, Year, Month, Objetivo, Condicion, Operador, fOut, Decimals, Multiple, Base100) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    var Dat = '';
    var service = '';
    var blBase100 = false;
    if (Base100 == 1) { blBase100 = true; }
    Dat = "{'Year': " + Year + ",'Month': " + Month + ",'sp': '" + Proc + "','id': '" + id + "','Objetivo': '" + Objetivo + "', 'Condicion': '" + Condicion + "','Operador': '" + Operador + "', 'Decimals': '" + Decimals + "', 'base100': " + blBase100 + "}";

    if (Multiple == false) {
        service = "Details/wsGauge.asmx/Historial";
    } else {
        service = "Details/wsGauge.asmx/HistorialMulti";
    }
    $.ajax({
        type: "POST",
        //url: "Details/wsGauge.asmx/Historial",
        url: service,
        //data: "{'Year': " + Year + ",'Month': " + Month + ",'sp': '" + Proc + "','id': '" + id + "','Objetivo': '" + Objetivo + "', 'Condicion': '" + Condicion + "','Operador': '" + Operador + "', 'Decimals': '" + Decimals + "'}",
        data: Dat,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty("d")) {
                $('#' + id).html(result.d);
            }
            else {
                $('#' + id).html(result);
            }
            if (fOut == 1) {
                $(".se-pre-Trend").fadeOut("slow");
            }
        }
    });
}
