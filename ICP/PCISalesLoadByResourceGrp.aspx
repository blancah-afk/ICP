<%@ Page Language="C#" MasterPageFile="~/Principal.Master"   AutoEventWireup="true" CodeBehind="PCISalesLoadByResourceGrp.aspx.cs" Inherits="ICP.PCISalesLoadByResourceGrp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
                        <div class="box-body">
                            <div class="box box-default">

                                <table>
                                    <tr>

                                        <td style="width: 650px; height: 50%;">
                                            <div class="box-header with-border">
                                                <div class="box box-danger">
                                                    <h3 class="box-title">Corte de Rollo a Hoja</h3>
                                                    <div class="box-body">
                                                        <div class="col-xs-12">
                                                            <div id="div0001" style="height: 350px"></div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 650px; height: 50%;">
                                            <div class="box-header with-border">
                                                <div class="box box-danger">


                                                    <h3 class="box-title">Corte Oxy-Plasma HD</h3>

                                                    <div class="box-body">


                                                        <div class="col-xs-12">
                                                            <div id="divPLA01" style="height: 350px"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 650px; height: 50%;">
                                            <div class="box-header with-border">
                                                <div class="box box-danger">
                                                    <h3 class="box-title">Corte de Hoja</h3>
                                                    <div class="box-body">
                                                        <div class="col-xs-12">
                                                            <div id="div0002" style="height: 350px"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 650px; height: 50%;">
                                            <div class="box-header with-border">
                                                <div class="box box-danger">
                                                    <h3 class="box-title">Laser 1</h3>
                                                    <div class="box-body">
                                                        <div class="col-xs-12">
                                                            <div id="divLSR1" style="height: 350px"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 650px; height: 50%;">
                                            <div class="box-header with-border">
                                                <div class="box box-danger">


                                                    <h3 class="box-title">Laser 2</h3>

                                                    <div class="box-body">


                                                        <div class="col-xs-12">
                                                            <div id="divLSR2" style="height: 350px"></div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                        <td style="width: 650px; height: 50%;">
                                            <div class="box-header with-border">
                                                <div class="box box-danger">
                                                    <h3 class="box-title">Laser 3</h3>

                                                    <div class="box-body">
                                                        <div class="col-xs-12">
                                                            <div id="divLSR3" style="height: 350px"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>


                                </table>

                            </div>
                        </div>
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
    <%--<script src="JScripts/Prueba.js"></script>--%>
    <script src="JScripts/PCISales.js"></script>
</asp:Content>
