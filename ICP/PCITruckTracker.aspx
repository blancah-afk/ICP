<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Principal.Master"  CodeBehind="PCITruckTracker.aspx.cs" Inherits="ICP.PCITruckTracker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <!-- jQuery 2.2.3 -->
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

    <section class="content">

        <asp:Timer runat="server" ID="tRefreshInfo" OnTick="tRefreshInfo_Tick" Interval="30000" Enabled="true"></asp:Timer>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <div class="box box-default">
                    
                    <div class="box-header with-border">

                

                        <div class="box-header with-border">
                            <table>

                                <tr>
                                    <td style="width: 100%">
                                        <asp:Label ID="lblLastUpdate" runat="server"></asp:Label></td>
                                    <div id="refreshIn"></div>

                                </tr>

                            </table>
                        </div>
                    </div>
                    <div class="box-body">

                        <table id="tbTruckTracker" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th data-dynatable-column='ShipmentType'>Shipment Type</th>
                                    <th data-dynatable-column='TruckID'>Truck ID</th>
                                    <th data-dynatable-column='CustomerSubcontractSupplier'>Customer/SubcontractSupplier</th>
                                    <th data-dynatable-column='ShipViaDesc'>Ship Via</th>
                                    <th data-dynatable-column='FreightCarrier'>Freight Carrier</th>
                                    <th data-dynatable-column='ShipToCity'>Ship To City</th>
                                    <th data-dynatable-column='ShippedQtyMT'>Shipped Qty MT</th>
                                    <th data-dynatable-column='ShipDateTime'>Ship Date Time</th>
                                    <th data-dynatable-column='RelatedPacks'>Related Packs</th>
                                    <th data-dynatable-column='Status'>Status</th>
                                    <th data-dynatable-column='PlannedShipDate'>Planned ShipDate</th>

                                    <th data-dynatable-column='ShipToName'>Ship To Name</th>
                                    <th data-dynatable-column='Priority'>Priority</th>
                                    <th data-dynatable-column='Capacity'>Capacity</th>
                                    <th data-dynatable-column='TruckComment'>Truck Comment</th>
                                    <th data-dynatable-column='FreitghtOutType'>Freitght Out Type</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="tRefreshInfo" EventName="Tick"></asp:AsyncPostBackTrigger>

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
    <%--    <script src="https://cdn.datatables.net/buttons/1.2.2/js/dataTables.buttons.min.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/pdfmake.min.js"></script>
    <script src="https://cdn.rawgit.com/bpampuch/pdfmake/0.1.18/build/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.2.2/js/buttons.html5.min.js"></script>
    <script src="JScripts/PCITruckTracker.js"></script>
</asp:Content>

