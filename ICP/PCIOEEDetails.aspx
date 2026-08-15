<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Principal.Master"  CodeBehind="PCIOEEDetails.aspx.cs" Inherits="ICP.PCIOEEDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <!-- jQuery 2.2.3 -->
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

    <section class="content">

        <asp:Timer runat="server" ID="tRefreshInfo" OnTick="tRefreshInfo_Tick" Enabled="true"></asp:Timer>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="box box-default">
                   
                    <table style="width: 100%; height: 100%;">
                        <tr>
                            <td style="width: 50%; height: 100%;">

                                <div class="box-header with-border">

                                    <asp:Label ID="lblLastUpdate" runat="server"></asp:Label>
                                    <div id="refreshIn"></div>
                                </div>

                            </td>

                            <td style="width: 50%; height: 50%;">
                                <div class="box-header with-border">

                                    <div id="showtime"></div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; height: 50%;">
                                <div class="box-header with-border">
                                    <div class="box box-danger">
                                        <%--   <div class="col-md-12">--%>
                                        <h3 class="box-title">First Pass Yield</h3>

                                        <div class="box-body">
                                            <div class="col-xs-12">
                                                <div id="divShip" style="height: 350px"></div>
                                            </div>
                                        </div>
                                        <%-- </div>--%>
                                    </div>
                                </div>
                            </td>
                            <td style="width: 50%; height: 50%;">
                                <div class="box-header with-border">
                                    <div class="box box-danger">
                                        <%--       <div class="col-md-12">--%>

                                        <h3 class="box-title">Job Performance</h3>

                                        <div class="box-body">


                                            <div class="col-xs-12">
                                                <div id="divJobPerformance" style="height: 350px"></div>
                                            </div>
                                            <%-- </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; height: 50%;">
                                <div class="box-header with-border">
                                    <div class="box box-danger">
                                        <h3 class="box-title">Equipment Availability</h3>

                                        <div class="box-body">


                                            <div class="col-xs-12">
                                                <div id="divEquipmentAvailability" style="height: 350px"></div>
                                            </div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </td>
                            <td style="width: 50%; height: 50%;">
                                <div class="box-header with-border">
                                    <div class="box box-danger">
                                        <%--  <div class="col-md-12">--%>

                                        <h3 class="box-title">Throughput  in Tons Per Hour</h3>

                                        <div class="box-body">


                                            <div class="col-xs-12">
                                                <div id="divThruput" style="height: 350px"></div>
                                            </div>
                                        </div>
                                        <%-- </div>--%>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>


                </div>
                </div>
                <br />
                </div>
                <div class="col-md-12">
                </div>
            </ContentTemplate>
            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="tRefreshInfo" EventName="Tick"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
    </section>

    <!-- jQuery 2.2.3 -->

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.3/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.0/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>

    <script src="JScripts/PCIProductionStatus.js"></script>
    <%--    <script src="JScripts/Prueba.js"></script>--%>
</asp:Content>

