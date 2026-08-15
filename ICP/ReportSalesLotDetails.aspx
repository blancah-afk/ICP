<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal.Master" CodeBehind="ReportSalesLotDetails.aspx.cs" Inherits="ICP.ReportSalesLotDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <link href="CSS/KPIReport.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <!-- Date and time range -->
    <section class="content">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
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
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Fiscal Year</label>
                                        <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control select2" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Fiscal Period</label>
                                        <asp:DropDownList runat="server" ID="ddlPeriod" CssClass="form-control select2" OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Execute</label>
                                        <asp:Button runat="server" ID="btnProcesar" OnClick="btnProcesar_Click" CssClass="btn btn-block btn-danger" Text="Execute" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <label>Export</label>
                                    <asp:Button runat="server" ID="btnExportXLS" Width="80px" Font-Size="X-Small" Visible="true" OnClick="btnExportXLS_Click" CssClass="btn btn-block btn-danger" Text="Export To Excel" />
                                    <asp:Button runat="server" ID="btnExporPDF" Width="80px" Font-Size="X-Small" Visible="true" OnClick="btnExporPDF_Click" CssClass="btn btn-block btn-danger" Text="Export To PDF" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box box-default">
                        <div class="box-header with-border">


                            <div class="box-header with-border">
                                <div class="box-header with-border">
                                    <table>

                                        <tr>
                                            <td style="width: 100%">
                                        </tr>

                                    </table>
                                </div>

                                <div class="box-body">

                                    <table id="tbTruckTracker" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th data-dynatable-column='Customer'>Customer</th>
                                                <th data-dynatable-column='InvoiceNum'>InvoiceNum</th>
                                                <th data-dynatable-column='PartNum'>PartNum</th>
                                                <th data-dynatable-column='CustPart'>CustPart</th>
                                                <th data-dynatable-column='LotNum'>LotNum</th>
                                                <th data-dynatable-column='InvoiceThick'>InvoiceThick</th>
                                                <th data-dynatable-column='ThickUOM'>ThickUOM</th>
                                                <th data-dynatable-column='InvoiceWidth'>InvoiceWidth</th>
                                                <th data-dynatable-column='WidthUOM'>WidthUOM</th>
                                                <th data-dynatable-column='InvoiceLength'>InvoiceLength</th>
                                                <th data-dynatable-column='LengthUOM'>LengthUOM</th>
                                                <th data-dynatable-column='Shape'>Shape</th>
                                                <th data-dynatable-column='CustCurr'>CustCurr</th>
                                                <th data-dynatable-column='InvoiceDate'>InvoiceDate</th>
                                                <th data-dynatable-column='BillingQty'>BillingQty</th>
                                                <th data-dynatable-column='BillingUOM'>BillingUOM</th>
                                                <th data-dynatable-column='SalesAmount'>SalesAmount</th>
                                                <th data-dynatable-column='NetSale'>NetSale</th>
                                                <th data-dynatable-column='VAT'>VAT</th>
                                                <th data-dynatable-column='Total'>Total</th>
                                                <th data-dynatable-column='ExchangeRate'>ExchangeRate</th>
                                                <th data-dynatable-column='LegacyManufacturer'>LegacyManufacturer</th>
                                                <th data-dynatable-column='Manufacturer'>Manufacturer</th>
                                                <th data-dynatable-column='Pieces'>Pieces</th>
                                                <th data-dynatable-column='SellingQtyKG'>SellingQtyKG</th>
                                                <th data-dynatable-column='PONum'>PONum</th>
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

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlPeriod" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnProcesar" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnExportXLS" />
                <asp:PostBackTrigger ControlID="btnExporPDF" />
            </Triggers>
        </asp:UpdatePanel>




    </section>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.0/jquery-ui.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.12/js/jquery.dataTables.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.12/js/dataTables.bootstrap.min.js"></script>

    <script src="https://cdn.datatables.net/responsive/2.1.0/js/dataTables.responsive.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.1.0/js/responsive.bootstrap.min.js"></script>
    <%--  COPY, PDF, EXEL BUTTONS--%>
        <script src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <script src="JScripts/ReportBO.js"></script>
</asp:Content>

