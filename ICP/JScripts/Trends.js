///////// PPM ////////
$(document).on("click", ".open-1Domestic", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Supplier PPM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_SupplierPPM', Year, Month, 'Domestic', '1Domestic', '<', 1, 0, true, 0);
});


$(document).on("click", ".open-1US", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Supplier PPM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_SupplierPPM', Year, Month, 'US', '1US', '<', 1, 0, true, 0);
});

$(document).on("click", ".open-1Tata", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Supplier PPM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_SupplierPPM', Year, Month, 'Tata', '1Tata', '<', 1, 0, true, 0);
});
///////// PPM ////////
///////// GM /////////
$(document).on("click", ".open-2USDOEM", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "GM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_GMPerSegment', Year, Month, 'OEM USD', '2USDOEM', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-2MXNOEM", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "GM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_GMPerSegment', Year, Month, 'OEM MXN', '2MXNOEM', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-2USDMetalbuilding", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "GM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    //// $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_GMPerSegment', Year, Month, 'Metalbuilding USD', '2USDMetalbuilding', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-2MXNMetalbuilding", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "GM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_GMPerSegment', Year, Month, 'Metalbuilding MXN', '2MXNMetalbuilding', '>=', 1, 2, false, 0);
});
///////// GM /////////

$(document).on("click", ".open-3Ton_ShippedGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Cost of Wood Used In Shipments";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_CostofWood', Year, Month, 'Ton_Shipped', '3Ton_ShippedGeneral', '<', 1, 3, false, 0);
});

$(document).on("click", ".open-4DaysGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Delivery Evaluation Score";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'spKPIdsH_SupDeliveryEvScore', Year, Month, 'Days', '4DaysGeneral', '>=', 1, 2, true, 0);
});

$(document).on("click", ".open-5DaysGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Effectiveness on RM Delivery";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'spKPIdsH_EffectRM', Year, Month, 'Days', '5DaysGeneral', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-6NTGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "External COPQ";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ExtCOPQ', Year, Month, 'NT', '6NTGeneral', '<=', 1, 2, false, 0);
});

$(document).on("click", ".open-6NTDetail", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "External COPQ - Detail";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ExtCOPQ', Year, Month, 'NT', '6NTDetail', '<=', 1, 2, false, 0);
});

$(document).on("click", ".open-6NTTemper", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "External COPQ - Detail - Temper";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ExtCOPQ', Year, Month, 'NT', '6NTTemper', '<=', 1, 2, false, 0);
});

$(document).on("click", ".open-6NTLaser", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "External COPQ - Detail - Laser";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ExtCOPQ', Year, Month, 'NT', '6NTLaser', '<=', 1, 2, false, 0);
});

$(document).on("click", ".open-7Verified", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "AQP Verification";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_AQPVer', Year, Month, '', '7Verified', '=', 1, 2, false, 0);
});


$(document).on("click", ".open-8General", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Production Schedule Compliance";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ProdSchComp', Year, Month, '', '8General', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-8GeneralTemper", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Production Schedule Compliance - Temper";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ProdSchComp', Year, Month, '', '8TemperGeneral', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-8GeneralLaser", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Production Schedule Compliance - Laser";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ProdSchComp', Year, Month, '', '8LaserGeneral', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-9General", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Effective Claim Service";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_ECS', Year, Month, '', '9General', '<=', 1, 2, false, 0);
});

//Inventory Levels
$(document).on("click", ".open-1030_DaysGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "DMR Status";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_IDRMStat', Year, Month, '', '1030_DaysGeneral', '>=', 1, 2, false, 0);
});

// Inventory Levels //

$(document).on("click", ".open-11Finished_Goods", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Inventory Levels - Finished Goods";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_InvLevel', Year, Month, '', '11Finished_Goods', '<', 1, 2, true, 1);
    //AjaxHist('chTrends', 'SPKPIdsh_InvLevel', Year, Month, '', '11Finished_Goods', '<', 1, 2, false);
});

$(document).on("click", ".open-11Raw_Material", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Inventory Levels - Raw Material";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_InvLevel', Year, Month, '', '11Raw_Material', '<', 1, 2, true, 1);
});

$(document).on("click", ".open-11MaterialInv180", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Inventory Levels - Material 180 days";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_InvLevel', Year, Month, 'Material', '11MaterialInv_>_180_Days', '<', 1, 2, true, 1);
});

$(document).on("click", ".open-11ProductionInv180", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Inventory Levels - Production 180 days";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_InvLevel', Year, Month, 'Production', '11ProductionInv_>_180_Days', '<', 1, 2, true, 1);
});



$(document).on("click", ".open-11Inv180", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Inventory Levels";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsh_InvLevel', Year, Month, '', '11Inv_>_180_Days', '<', 1, 2, false, 1);
});
// Inventory Levels //

$(document).on("click", ".open-12NTGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Customer GM";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_CustomerGM', Year, Month, 'NT', '12NTGeneral', '>=', 1, 0, false, 0);
});


////// Forecast //////

$(document).on("click", ".open-13OriginalGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Forecast Compliance";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_SalesForecast', Year, Month, '', '13BaseGeneral', '>=', 1, 2, false, 0);
});

$(document).on("click", ".open-13ActualGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Forecast Compliance";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_SalesForecast', Year, Month, '', '13ActualGeneral', '>=', 1, 2, false, 0);
});

////// Forecast //////

$(document).on("click", ".open-14Offset_NTGeneral", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Organic Growth 123";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsH_OrganicGrowth', Year, Month, 'Offset_NT', '14Offset_NTGeneral', '>=', 1, 0, false, 0);
});


$(document).on("click", ".open-15NTGeneralUSD", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Our AVG Price Vs Market - USD";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_AVGPrice', Year, Month, 'NT', '15NTGeneral-USD', '<=', 1, 3, true, 0);
});

$(document).on("click", ".open-15NTGeneralMXN", function () {
    var Year = $("[id*=ddlYear]").val();
    var Month = $("[id*=ddlMonth]").val();
    $(".se-pre-Trend").fadeIn();
    TrendName.innerText = "Our AVG Price Vs Market - MXN";
    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
    AjaxHist('chTrends', 'SPKPIdsHSup_AVGPrice', Year, Month, 'NT', '15NTGeneral-MXN', '<=', 1, 3, true, 0);
});

//$(document).on("click", ".open-16NTGeneral", function () {
//    var Year = $("[id*=ddlYear]").val();
//    var Month = $("[id*=ddlMonth]").val();
//    $(".se-pre-Trend").fadeIn();
//    TrendName.innerText = "Internal COPQ";
//    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
//    AjaxHist('chTrends', 'SPKPIdsH_IntCOPQ', Year, Month, 'NT', '16NTGeneral', '<=', 1, 2, false, 0);
//});


$(document).on("click", ".open-16NTDetail", function () {
	var Year = $("[id*=ddlYear]").val();
	var Month = $("[id*=ddlMonth]").val();
	$(".se-pre-Trend").fadeIn();
	TrendName.innerText = "Internal COPQ - Detail";
	// $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
	AjaxHist('chTrends', 'SPKPIdsH_IntCOPQ', Year, Month, 'NT', '16NTDetail', '<=', 1, 2, false, 0);
});

$(document).on("click", ".open-16NTTemper", function () {
	var Year = $("[id*=ddlYear]").val();
	var Month = $("[id*=ddlMonth]").val();
	$(".se-pre-Trend").fadeIn();
	TrendName.innerText = "Internal COPQ - Detail - Temper";
	// $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
	AjaxHist('chTrends', 'SPKPIdsH_IntCOPQ', Year, Month, 'NT', '16NTTemper', '<=', 1, 2, false, 0);
});

$(document).on("click", ".open-16NTLaser", function () {
	var Year = $("[id*=ddlYear]").val();
	var Month = $("[id*=ddlMonth]").val();
	$(".se-pre-Trend").fadeIn();
	TrendName.innerText = "Internal COPQ - Detail - Laser";
	// $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
	AjaxHist('chTrends', 'SPKPIdsH_IntCOPQ', Year, Month, 'NT', '16NTLaser', '<=', 1, 2, false, 0);
});


//$(document).on("click", ".open-15NTGeneral", function () {
//    var Year = $("[id*=ddlYear]").val();
//    var Month = $("[id*=ddlMonth]").val();
//    $(".se-pre-Trend").fadeIn();
//    TrendName.innerText = "Our AVG Price Vs Domestic";
//    // $('#chTrends').replaceWith('<canvas id="chTrends"></canvas>');
//    AjaxHist('chTrends', 'SPKPIdsH_AVGPrice', Year, Month, 'NT', '15NTGeneral', '<=', 1, 3, false);
//});