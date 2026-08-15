<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal.Master" CodeBehind="ReportSalesProfitMaterials.aspx.cs" Inherits="ICP.ReportSalesProfitMaterials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <!-- Date and time range -->
    <section class="content">

        <div>

            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Select Period</h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-1">
                            <div class="form-group">
                            </div>
                        </div>
                        <%--  <table>

                            <tr>
                                <td>
                                    <label>Start Date:</label><br />
                                    <input type="date" name="dtStartDate" id="StartDate" /></td>
                                <td>
                                    <label>End Date:</label><br />
                                    <input type="date" name="dtEndDate" id="EndDate" /></td>

                                <td>
                                    <label></label>
                                    <input type="button" class="btn btn-block btn-danger" onclick="RunGrahp()" value="Run" />
                                </td>

                                <td>
                                    <label></label>
                                    <asp:Button runat="server" ID="btnExportXLS" OnClick="btnExportXLS_Click" CssClass="btn btn-block btn-success" Text="Export to Excel" /></td>
                            </tr>
                        </table>--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Start Date:</label> 
                                <input type="date" name="dtStartDate" id="StartDate" /> 
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>End Date:</label> 
                                <input type="date" name="dtEndDate" id="EndDate" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label></label>
                                <input type="button" class="btn btn-block btn-danger" onclick="RunGrahp()" value="Run" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label></label>
                                <asp:Button runat="server" ID="btnExportXLS" OnClick="btnExportXLS_Click" CssClass="btn btn-block btn-success" Text="Export to Excel" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class=" row">
            <div class="col-md-12">



                <div class="box box-default">
                    <div class="box-header with-border">


                        <div class="box-header with-border">


                            <div class="box-body">

                                <table id="tbTruckTracker" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                                    <thead>
                                        <tr>
                                            <th data-dynatable-column='FiscalYear'>FiscalYear</th>
                                            <th data-dynatable-column='FiscalPeriod'>FiscalPeriod</th>
                                            <th data-dynatable-column='CreditMemo'>CreditMemo</th>
                                            <th data-dynatable-column='InvoiceNum'>InvoiceNum</th>
                                            <th data-dynatable-column='InvoiceDate'>InvoiceDate</th>
                                            <th data-dynatable-column='InvoiceLine'>InvoiceLine</th>
                                            <th data-dynatable-column='CurrencyCode'>CurrencyCode</th>
                                            <th data-dynatable-column='CustID'>CustID</th>
                                            <th data-dynatable-column='Customer'>Customer</th>
                                            <th data-dynatable-column='OrderNum'>OrderNum</th>
                                            <th data-dynatable-column='PONumCustomer'>PONumCustomer</th>
                                            <th data-dynatable-column='PartNumCustomer'>PartNumCustomer</th>
                                            <th data-dynatable-column='InvoiceRef'>InvoiceRef</th>
                                            <th data-dynatable-column='InvoiceLineRef'>InvoiceLineRef</th>
                                            <th data-dynatable-column='GroupDesc'>GroupDesc</th>
                                            <th data-dynatable-column='IndustryClassType'>IndustryClassType</th>
                                            <th data-dynatable-column='IndustryClass'>IndustryClass</th>
                                            <th data-dynatable-column='ICCode'>ICCode</th>
                                            <th data-dynatable-column='SalesRep'>SalesRep</th>
                                            <th data-dynatable-column='PartNum'>PartNum</th>
                                            <th data-dynatable-column='LineDesc'>LineDesc</th>
                                            <th data-dynatable-column='LotNum'>LotNum</th>
                                            <th data-dynatable-column='LotFirstRefDate'>LotFirstRefDate</th>
                                            <th data-dynatable-column='MtlPOInfo'>MtlPOInfo</th>
                                            <th data-dynatable-column='ConsolidatedLot'>ConsolidatedLot</th>
                                            <th data-dynatable-column='ConvFactor'>ConvFactor</th>
                                            <th data-dynatable-column='ProdCode'>ProdCode</th>
                                            <th data-dynatable-column='ProdGroup'>ProdGroup</th>
                                            <th data-dynatable-column='SellingShipQty'>SellingShipQty</th>
                                            <th data-dynatable-column='SalesUM'>SalesUM</th>
                                            <th data-dynatable-column='OurShipQty'>OurShipQty</th>
                                            <th data-dynatable-column='IUM'>IUM</th>
                                            <th data-dynatable-column='SellingQtyKG'>SellingQtyKG</th>
                                            <th data-dynatable-column='Shape'>Shape</th>
                                            <th data-dynatable-column='ExchangeRateMaterial'>ExchangeRateMaterial</th>
                                            <th data-dynatable-column='ExchangeRateProd'>ExchangeRateProd</th>
                                            <th data-dynatable-column='ExchangeRateSale'>ExchangeRateSale</th>
                                            <th data-dynatable-column='LaborMXN'>LaborMXN</th>
                                            <th data-dynatable-column='BurdenMXN'>BurdenMXN</th>
                                            <th data-dynatable-column='MaterialMXN'>MaterialMXN</th>
                                            <th data-dynatable-column='SubContractMXN'>SubContractMXN</th>
                                            <th data-dynatable-column='MtlBurdenMXN'>MtlBurdenMXN</th>
                                            <th data-dynatable-column='LbrUnitCostMXN'>LbrUnitCostMXN</th>
                                            <th data-dynatable-column='BurUnitCostMXN'>BurUnitCostMXN</th>
                                            <th data-dynatable-column='MtlUnitCostMXN'>MtlUnitCostMXN</th>
                                            <th data-dynatable-column='SubUnitCostMXN'>SubUnitCostMXN</th>
                                            <th data-dynatable-column='MtlBurUnitCostMXN'>MtlBurUnitCostMXN</th>
                                            <th data-dynatable-column='LaborUSD'>LaborUSD</th>
                                            <th data-dynatable-column='BurdenUSD'>BurdenUSD</th>
                                            <th data-dynatable-column='MaterialUSD'>MaterialUSD</th>
                                            <th data-dynatable-column='SubContractUSD'>SubContractUSD</th>
                                            <th data-dynatable-column='MtlBurdenUSD'>MtlBurdenUSD</th>
                                            <th data-dynatable-column='LbrUnitCostUSD'>LbrUnitCostUSD</th>
                                            <th data-dynatable-column='BurUnitCostUSD'>BurUnitCostUSD</th>
                                            <th data-dynatable-column='MtlUnitCostUSD'>MtlUnitCostUSD</th>
                                            <th data-dynatable-column='SubUnitCostUSD'>SubUnitCostUSD</th>
                                            <th data-dynatable-column='MtlBurUnitCostUSD'>MtlBurUnitCostUSD</th>
                                            <th data-dynatable-column='TotalPriceMXN'>TotalPriceMXN</th>
                                            <th data-dynatable-column='SaleUnitPriceMXN'>SaleUnitPriceMXN</th>
                                            <th data-dynatable-column='TotalPriceUSD'>TotalPriceUSD</th>
                                            <th data-dynatable-column='SaleUnitPriceUSD'>SaleUnitPriceUSD</th>
                                            <th data-dynatable-column='QtyMT'>QtyMT</th>
                                            <th data-dynatable-column='CalcUnitPriceMXN'>CalcUnitPriceMXN</th>
                                            <th data-dynatable-column='TotalCostMXN'>TotalCostMXN</th>
                                            <th data-dynatable-column='TotalCostMXNLandedCost'>TotalCostMXNLandedCost</th>
                                            <th data-dynatable-column='UnitCostMXN'>UnitCostMXN</th>
                                            <th data-dynatable-column='MarginPercentMXN'>MarginPercentMXN</th>
                                            <th data-dynatable-column='MarginMXN'>MarginMXN</th>
                                            <th data-dynatable-column='MarginMXNLandedCost'>MarginMXNLandedCost</th>
                                            <th data-dynatable-column='CalcUnitPriceUSD'>CalcUnitPriceUSD</th>
                                            <th data-dynatable-column='TotalCostUSD'>TotalCostUSD</th>
                                            <th data-dynatable-column='TotalCostUSDLandedCost'>TotalCostUSDLandedCost</th>
                                            <th data-dynatable-column='UnitCostUSD'>UnitCostUSD</th>
                                            <th data-dynatable-column='MarginPercentUSD'>MarginPercentUSD</th>
                                            <th data-dynatable-column='MarginUSD'>MarginUSD</th>
                                            <th data-dynatable-column='MarginUSDLandedCost'>MarginUSDLandedCost</th>
                                            <th data-dynatable-column='SourcePartNum'>SourcePartNum</th>
                                            <th data-dynatable-column='SourceLotNum'>SourceLotNum</th>
                                            <th data-dynatable-column='SourceLotFirstTranDate'>SourceLotFirstTranDate</th>
                                            <th data-dynatable-column='MtlExchangeRate'>MtlExchangeRate</th>
                                            <th data-dynatable-column='CostInfoObtainedFrom'>CostInfoObtainedFrom</th>
                                            <th data-dynatable-column='StandardMtlUnitCostMXN'>StandardMtlUnitCostMXN</th>
                                            <th data-dynatable-column='StandardMtlBurUnitCostMXN'>StandardMtlBurUnitCostMXN</th>
                                            <th data-dynatable-column='StandardMtlUnitCostUSD'>StandardMtlUnitCostUSD</th>
                                            <th data-dynatable-column='StandardMtlBurUnitCostUSD'>StandardMtlBurUnitCostUSD</th>
                                            <th data-dynatable-column='StandardTotalMXNLandedCost'>StandardTotalMXNLandedCost</th>
                                            <th data-dynatable-column='StandardTotalUSDLandedCost'>StandardTotalUSDLandedCost</th>
                                            <th data-dynatable-column='StandardMarginMXNLandedCost'>StandardMarginMXNLandedCost</th>
                                            <th data-dynatable-column='StandardMarginUSDLandedCost'>StandardMarginUSDLandedCost</th>
                                            <th data-dynatable-column='CostPer'>CostPer</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label runat="server" ID="lblEndDate" Visible="true"></asp:Label>
        <label id="stDate" for="sreport" runat="server"></label>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="btnExportXLS" />

            </Triggers>
        </asp:UpdatePanel>
    </section>



    <!-- /.form group -->
    <!-- jQuery 2.2.3 -->
    <%--<script src="plugins/jQuery/jquery-2.2.3.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.3/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <%--<script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.0/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <%--  <script>$.widget.bridge('uibutton', $.ui.button);</script>--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script src="JScripts/ReportSalesProfitMaterials.js"></script>
</asp:Content>
