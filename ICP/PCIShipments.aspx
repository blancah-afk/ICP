<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Principal.Master"  CodeBehind="PCIShipments.aspx.cs" Inherits="ICP.PCIShipments" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <section class="content">

        <asp:Timer runat="server" ID="tRefreshInfo" OnTick="tRefreshInfo_Tick" Interval="30000" Enabled="true"></asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="box box-default">
                   
                    <div class="box-header with-border">
                        
                        <%--<br />--%>
                       
                        <div class="box-header with-border">
                            <table>

                                <tr>
                                    <td style="width: 100%">
                                        <asp:Label ID="lblLastUpdate" runat="server"></asp:Label></td>
                                     <div id ="refreshIn"></div>
                                </tr>

                            </table>
                        </div>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-xs-3">
                                    <p><b>Sum MT</b></p>
                                    <div id="SumMT" class="form-control text-right"></div>
                                </div>
                                <div class="col-xs-3">
                                    <p><b>Average MT</b></p>
                                    <div id="AvgMT" class="form-control text-right"></div>
                                </div>
                                <div class="col-xs-3">
                                    <p><b>Sum Demand</b></p>
                                    <div id="SumDemand" class="form-control text-right"></div>
                                </div>

                            </div>
                            <hr />
                             <div id="divShip" style="height:700px"></div>
                        </div>
                       <%-- <div class="col-xs-12">--%>
                           
                       <%-- </div>--%>
                    </div>
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

    <script src="JScripts/PCIShippments.js"></script>
    <%--<script src="JScripts/Prueba.js"></script>--%>
</asp:Content>
