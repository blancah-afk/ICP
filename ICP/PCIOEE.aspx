<%@ Page Language="C#"  MasterPageFile="~/Principal.Master"  AutoEventWireup="true" CodeBehind="PCIOEE.aspx.cs" Inherits="ICP.PCIOEE" %>

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


                        <%-- <br />--%>
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
                            <div class="col-xs-12">

                                <div id="divOEE" style="height: 800px"></div>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="tRefreshInfo" EventName="Tick"></asp:AsyncPostBackTrigger>
                <%--    <asp:AsyncPostBackTrigger ControlID="btnPause" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnPlay" EventName="Click"></asp:AsyncPostBackTrigger>--%>
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

    <%--    <script src="JScripts/Prueba.js"></script>--%>
    <script src="JScripts/PCIOEE.js"></script>
</asp:Content>

