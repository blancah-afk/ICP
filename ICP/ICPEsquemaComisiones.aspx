<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ICPEsquemaComisiones.aspx.cs" Inherits="ICP.ICPEsquemaComisiones" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <link href="CSS/ICPEsquemaComisiones.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <!-- Date and time range -->
    <section class="content">
        <div>
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Sales Commission</h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Year</label>
                                        <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control select2" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Month</label>
                                        <asp:DropDownList runat="server" ID="ddlMonth" CssClass="form-control select2" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="false" />
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="SelectedIndexChanged" />
                                <asp:PostBackTrigger ControlID="btnExportXLS" />
                                <asp:PostBackTrigger ControlID="btnExporPDF" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label></label>
                                <asp:Button runat="server" ID="btnProcesar" OnClick="btnProcesar_Click" CssClass="btn btn-block btn-danger" Text="Run" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label></label>
                                <asp:Button runat="server" ID="btnExportXLS" OnClick="btnExportXLS_Click" CssClass="btn btn-block btn-success" Text="Export" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <label></label>
                            <%-- <asp:Button runat="server" ID="btnExportXLS" Width="80px" Font-Size="X-Small" Visible="true" OnClick="btnExportXLS_Click" CssClass="btn btn-block btn-success" Text="Export To Excel" />--%>
                            <asp:Button ToolTip="ExportarPDF"  runat="server" ID="btnExporPDF" Width="80px" Font-Size="X-Small" Visible="false" OnClick="btnExporPDF_Click" CssClass="btn btn-block btn-danger" Text="Export To PDF" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=" row">
            <div class="col-md-12">
                <div class="box box-danger">
                    <div class="box-header with-border">
                        <h3 class="box-title"></h3>

                        <br />
                        <asp:Label runat="server" ID="lblVersion" Text=""></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblAccess" Text="You don't have proper permissions to view this report, please check with your administrator"></asp:Label>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server">

                        <ContentTemplate>
                            <div class="box-body">
                                <div class="divKPIDetail">
                                    <table id="Table1" runat="server" style="width: 100%;">
                                        <tr>
                                            <td>

                                                <table border="1" class="tbDetail">
                                                    <tr>
                                                        <th colspan="4" class="header">TotalGeneral</th>
                                                        <th class="header">
                                                            <asp:Label ID="lblTotalPaymentAmountMXN" runat="server" Text=""></asp:Label>
                                                        </th>
                                                        <th class="header">
                                                            <asp:Label ID="lblTotalPaymentAmountUSD" runat="server" Text=""></asp:Label></th>
                                                        <th class="header">
                                                            <asp:Label runat="server" ID="lblTotalVolumenMT" Text=""></asp:Label></th>
                                                           <th class="header">
                                                            <asp:Label runat="server" ID="lblTotalVolumenMTPaid" Text=""></asp:Label></th>
                                                        <th colspan="3" class="header"></th>
                                                        <th colspan="3" class="headerForecast">Forecast</th>
                                                        <th colspan="5" class="headerMargen">Margen</th>
                                                        <th class="headerInventario">Inv</th>
                                                        <th colspan="2" class="headerTotal"></th>
                                                    </tr>
                                                    <tr>
                                                        <th class="header">No</th>
                                                        <th class="header">Vendedor/DetalleClientes.</th>
                                                        <th class="header">Pagado/Pendiente</th>
                                                        <th class="header">Tipo</th>
                                                        <th class="header">Pagos en MXP</th>
                                                        <th class="header">Pagos en USD</th>
                                                        <th class="header">Volumen MT(Sold)</th>
                                                        <th class="header">Volumen MT(Paid)</th>
                                                        <th class="header">% del Total</th>
                                                        <th class="header">Factor Comisión</th>
                                                        <th class="header">Monto Bruto Comision Generada</th>
                                                        <th class="headerForecast">Goal MT</th>
                                                        <th class="headerForecast">% Cumplimiento</th>
                                                        <th class="headerForecast">50%</th>
                                                        <th class="headerMargen">Margen MXN</th>
                                                        <th class="headerMargen">Margen USD</th>
                                                        <th class="headerMargen">% En MXP</th>
                                                        <th class="headerMargen">% EN USD</th>
                                                        <th class="headerMargen">50%</th>
                                                        <th class="headerInventario">10%</th>
                                                        <th class="headerTotal">Factor Total</th>
                                                        <th class="headerTotal">Comision a Pagar</th>
                                                    </tr>
                                                    <tr>
                                                        <asp:Repeater ID="rptOSR" runat="server" OnItemDataBound="rptOSR_ItemDataBound">
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSalesRepCode" runat="server" Visible="false" Text='<%# Eval("SalesRepCode") %>'></asp:Label>
                                                                <asp:Label ID="lblSalesRep" runat="server" Visible="false" Text='<%# Eval("SalesRep") %>'></asp:Label>
                                                                <tr>

                                                                    <td colspan="4" class="thSubCatSalesRep">
                                                                        <asp:LinkButton CssClass="boton" Font-Size="Large" runat="server" ID="LinkButton1" Text='<%# Eval("SalesRep") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                                                                    </td>


                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblPaymentAmountMXN" Text='<%# Eval("PaymentAmountMXN") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblPaymentAmountUSD" Text='<%# Eval("PaymentAmountUSD") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblVolumenMT" Text='<%# Eval("VolumenMT") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblVolumenMTPaid" Text='<%# Eval("VolumenMTPaid") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblTotalPer" Text='<%# Eval("TotalPer") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblFactorComision" Text=""></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblMontoBrutoComision" Text='<%# Eval("MontoBrutoComision") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblForecastGoalMT" Text='<%# Eval("ForecastGoalMT") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblForecastCumplimientoPer" Text='<%# Eval("ForecastCumplimientoPer") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblForecastComisionEarnedPer" Text='<%# Eval("ForecastComisionEarnedPer") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblTotalMarginMXN" Text='<%# Eval("TotalMarginMXN") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblTotalMarginUSD" Text='<%# Eval("TotalMarginUSD") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblMargenPerMXN" Text='<%# Eval("MargenPerMXN") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblMargenPerUSD" Text='<%# Eval("MargenPerUSD") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblMargenComisionEarnedPer" Text='<%# Eval("MargenComisionEarnedPer") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblInventarioComisionEarnedPer" Text='<%# Eval("InventarioComisionEarnedPer") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblFactorTotal" Text='<%# Eval("FactorTotal") %>'></asp:Label></td>
                                                                    <td class="thSubCat">
                                                                        <asp:Label runat="server" ID="lblComisionAPagar" Text='<%# Eval("ComisionAPagar") %>'></asp:Label></td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="tdDet">
                                                                        <asp:Repeater ID="rptCustomerGroup" OnItemDataBound="rptCustomerGroup_ItemDataBound" runat="server" Visible="true">
                                                                            <HeaderTemplate>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCorporateID" runat="server" Visible="false" Text='<%# Eval("CorporateID") %>'></asp:Label>
                                                                                <asp:Label ID="lblSalesRepCode" runat="server" Visible="false" Text='<%# Eval("SalesRepCode") %>'></asp:Label>
                                                                                <tr runat="server" class="header" id="rowGroup">


                                                                                    <td colspan="4" class="thSubCat2">
                                                                                         <asp:Label runat="server" ID="Label4" Text="Corporativo - "></asp:Label>
                                                                                        <asp:Label runat="server" ID="Label1" Text= ' <%# Eval("CorporateID") %>'></asp:Label></td>


                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblPaymentAmountMXN" Text='<%# Eval("PaymentAmountMXN") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblPaymentAmountUSD" Text='<%# Eval("PaymentAmountUSD") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblVolumenMT" Text='<%# Eval("VolumenMT") %>'></asp:Label></td>
                                                                                     <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblVolumenMTPaid" Text='<%# Eval("VolumenMTPaid") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblTotalPer" Text='<%# Eval("TotalPer") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblFactorComision" Text=""></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblMontoBrutoComision" Text='<%# Eval("MontoBrutoComision") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblForecastGoalMT" Text='<%# Eval("ForecastGoalMT") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblForecastCumplimientoPer" Text='<%# Eval("ForecastCumplimientoPer") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblForecastComisionEarnedPer" Text=""></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblTotalMarginMXN" Text='<%# Eval("TotalMarginMXN") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblTotalMarginUSD" Text='<%# Eval("TotalMarginUSD") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblMargenPerMXN" Text='<%# Eval("MargenPerMXN") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblMargenPerUSD" Text='<%# Eval("MargenPerUSD") %>'></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblMargenComisionEarnedPer" Text=""></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblInventarioComisionEarnedPer" Text=""> </asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblFactorTotal" Text=""></asp:Label></td>
                                                                                    <td class="thSubCat2">
                                                                                        <asp:Label runat="server" ID="lblComisionAPagar" Text=""></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="tdDet">
                                                                                        <asp:Repeater ID="rptCorporate" OnItemDataBound="rptCorporate_ItemDataBound" runat="server" Visible="true">
                                                                                            <HeaderTemplate>
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCorporateID" runat="server" Visible="false" Text='<%# Eval("CorporateID") %>'></asp:Label>
                                                                                                <tr>

                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label></td>
                                                                                                    <td class="tdDetCustName">
                                                                                                        <asp:Label runat="server" ID="lblCustomerName" Text='<%# Eval("CustomerName") %>'></asp:Label></td>
                                                                                                    <td class="tdDetStatus">
                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("StatusComision") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("CustomerType") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblPaymentAmountMXN" Text='<%# Eval("PaymentAmountMXN") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblPaymentAmountUSD" Text='<%# Eval("PaymentAmountUSD") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblVolumenMT" Text='<%# Eval("VolumenMT") %>'></asp:Label></td>
                                                                                                      <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblVolumenMTPaid" Text='<%# Eval("VolumenMTPaid") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblTotalPer" Text='<%# Eval("TotalPer") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblFactorComision" Text='<%# Eval("FactorComision") %>'></asp:Label></td>
                                                                                                    <td class="tdDetCustName">
                                                                                                        <asp:Label runat="server" ID="lblMontoBrutoComision" Text='<%# Eval("MontoBrutoComision") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblForecastGoalMT" Text='<%# Eval("ForecastGoalMT") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblForecastCumplimientoPer" Text='<%# Eval("ForecastCumplimientoPer") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblForecastComisionEarnedPer" Text=""></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblTotalMarginMXN" Text='<%# Eval("TotalMarginMXN") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblTotalMarginUSD" Text='<%# Eval("TotalMarginUSD") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblMargenPerMXN" Text='<%# Eval("MargenPerMXN") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblMargenPerUSD" Text='<%# Eval("MargenPerUSD") %>'></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblMargenComisionEarnedPer" Text=""></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblInventarioComisionEarnedPer" Text=""> </asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblFactorTotal" Text=""></asp:Label></td>
                                                                                                    <td class="tdDet">
                                                                                                        <asp:Label runat="server" ID="lblComisionAPagar" Text=""></asp:Label></td>
                                                                                                </tr>

                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                    </td>
                                                                </tr>




                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                            </td>
                                        </tr>
                                    </table>



                                </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>

    </section>



    <!-- /.form group -->
    <!-- jQuery 2.2.3 -->
    <%--<script src="plugins/jQuery/jquery-2.2.3.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.3/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <%--<script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.0/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>
    <script src="JScripts/KPIReport.js"></script>
</asp:Content>
