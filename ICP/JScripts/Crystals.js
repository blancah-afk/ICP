function OpenCrystal(Report, FiscalYear, FiscalPeriod, Currency) {
    //el parametro fOut indica si vamos a detner el efecto de carga en el Modal!
    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/MakeCristal",
        data: "{'Report': '" + Report + "','FiscalYear': '" + FiscalYear + "','FiscalPeriod': '" + FiscalPeriod + "', 'Currency': '" + Currency + "'}",
        //data: "{'Year': " + Year + ",'Month': " + Month + ",'id': '" + id + "','Objetivo': '" + Tipo + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            ////if (result.hasOwnProperty("d")) {
            ////    $('#' + id).html(result.d);
            ////}
            ////else {
            ////    $('#' + id).html(result);
            ////}
            //if (fOut == 1) {
            //    $(".se-pre-PPM").fadeOut("slow");
            //}
            //if (fOut == 0) {
            //    $(".se-pre-Entire").fadeOut("slow");
            //}
        }
    });
}