<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal.Master" CodeBehind="KPIExtendedGraphs.aspx.cs" Inherits="ICP.KPIExtendedGraphs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
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
                        <h3 class="box-title">Shippments</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
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
                        <div class="col-xs-12">
                            <div id="divShip"></div>
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

  <script>
        var StartDate;
        var EndDate;

        $(function () {
            //Initialize Select2 Elements
            $(".select2").select2();

            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
            //Money Euro
            $("[data-mask]").inputmask();

            //Date range picker
            $('#reservation').daterangepicker();
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
            //Date range as a button
            $('#daterange-btn').daterangepicker(
                {
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
                        'Last 2 Month': [moment().subtract(1, 'month').startOf('month'), moment().endOf('month')],
                        'Last 3 Month': [moment().subtract(2, 'month').startOf('month'), moment().endOf('month')]
                    },
                    //startDate: moment().subtract(29, 'days'),
                    //endDate: moment(),
                    opens: "right",
                    autoApply: true,
                    showDropdowns: true
                },
                function (start, end) {
                    $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
                    StartDate = start.format('YYYY-MM-DD');
                    EndDate = end.format('YYYY-MM-DD');

                }
            );

            //Date picker
            $('#datepicker').datepicker({
                autoclose: true
            });

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            });
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            });
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });

        });

        function RunGrahp() {
            var id = "divShip";
            if (StartDate == null || EndDate == null) {
                alert("Se debe seleccionar una fecha para analizar");
            } else {
                $.ajax({
                    type: "POST",
                    url: "Details/wsGraphExtend.asmx/getShippments",
                    data: "{'StartDate': '" + StartDate + "','EndDate': '" + EndDate + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        if (result.hasOwnProperty("d")) {
                            $('#' + id).html(result.d);
                        }
                        else {
                            $('#' + id).html(result);
                        }
                    }
                });
            }
        }
    </script>

</asp:Content>
