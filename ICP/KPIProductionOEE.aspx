<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPIProductionOEE.aspx.cs" MasterPageFile="~/Principal.Master" Inherits="ICP.KPIProductionOEE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
<link href="CSS/KPIProductionOEE.css" rel="stylesheet" />
    
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <!-- Date and time range -->
    <div>
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Seleccion de Periodo</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Date range button:</label>

                        <div class="input-group">
                            <button type="button" class="btn btn-default pull-right" id="daterange-btn">
                                <span>
                                    <i class="fa fa-calendar"></i>Select a Date
                                </span>
                                <i class="fa fa-caret-down"></i>
                            </button>
                        </div>

                    </div>
                </div>

                <div class="col-sm-2">
                    <div class="form-group">
                        <input type="button" class="btn btn-block btn-danger" onclick="RunGrahp()" value="Ejecutar Reporte" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <section class="content">
        <div class=" row">
            <div class="col-md-12">
                <div class="box box-danger">
                    <div class="box-header with-border">
                        <h3 class="box-title">OEE</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">

                        <hr />
                        <div class="col-xs-12">
                            <div id="divShip"></div>
                        </div>
                        <div class="box-body">
                            <div class="col-xs-12">
                                <div class="box-body">

                                    <table id="example" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                                    </table>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      <div class=" row">
            <div class="col-md-12">
                <div class="box box-danger">
                    <div class="box-header with-border">
                        <h3 class="box-title">Graph OEE</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="box-body">

                        <hr />
                        <div class="col-xs-12">
                            <div id="divShip"></div>
                        </div>
                        <div class="box-body">
                            <div class="col-xs-12">
                               
                                <div id="divOEE" style="height: 800px"></div>
                            </div>
                        </div>
                    </div>
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

    <script src="JScripts/KPIProductionOEE.js"></script>
    <%--<script src="JScripts/jqBlockUI.js"></script>--%>
    
    <%-- <script src="JScripts/Prueba.js"></script>--%>
</asp:Content>
