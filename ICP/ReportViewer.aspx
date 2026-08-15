<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="ICP.ReportViewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <!-- jQuery 2.2.3 -->
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>

    <section class="content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <div class="box box-default">
                        <div class="box-header with-border">

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
                                        <label>Export</label>
                                        <asp:Button runat="server" ID="btnPrint" OnClick="btnPrint_Click" CssClass="btn btn-block btn-danger" Text="Print PDF" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=" row">
                    <div class="col-md-12">
                        <div class="box box-danger">
                            <div class="box-header with-border">

                                <br />

                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>

                                </div>
                            </div>

                            <div style="width: 100%; overflow-x: auto; margin-left: 15px; margin-right: 10px;">

                                <CR:CrystalReportViewer ID="CRVReporte" runat="server" ToolPanelView="None" />
                            </div>


                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
               
            </Triggers>
        </asp:UpdatePanel>

    </section>

</asp:Content>
