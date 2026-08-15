<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="KPIReport.aspx.cs" Inherits="ICP.KPIReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <link href="CSS/KPIReport.css" rel="stylesheet" />
    <link href="CSS/sweetalert2.min.css" rel="stylesheet" />
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <!-- Date and time range -->
    <section class="content">
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Year</label>
                                        <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control select2 year" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                                 <div class="col-md-2">
                                     <div class="form-group">
                                         <label>Month</label>
                                         <asp:DropDownList runat="server" ID="ddlMonth" CssClass="form-control select2 month" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true" />
                                     </div>
                                 </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="btnProcesar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnSendEmail" EventName="Click" />
                                <asp:PostBackTrigger ControlID="btnExportXLS" />
                                <asp:PostBackTrigger ControlID="btnExporPDF" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Process</label>
                                <asp:Button runat="server" ID="btnProcesar" OnClick="btnProcesar_Click" CssClass="btn btn-block btn-danger" Text="Process" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <label>Export</label>
                            <asp:Button runat="server" ID="btnExportXLS" Width="80px" Font-Size="X-Small" Visible="true" OnClick="btnExportXLS_Click" CssClass="btn btn-block btn-danger" Text="Export To Excel" />
                            <asp:Button runat="server" ID="btnExporPDF" Width="80px" Font-Size="X-Small" Visible="true" OnClick="btnExporPDF_Click" CssClass="btn btn-block btn-danger" Text="Export To PDF" />
                        </div>
                         <div class="col-md-2"></div>
                         <div class="col-md-2">
                             <div class="form-group">
                                 <br />
                                 <asp:Button runat="server" ID="btnSendEmail"  CssClass="btn btn-block btn-primary send" Text="Send Email" />
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
                        <h3 class="box-title">Key Performance Indicator (KPI) Report SteelWarehouse</h3>

                        <br />
                        <asp:Label runat="server" Text="(**Indicator calculated automatically)"></asp:Label>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server">

                        <ContentTemplate>
                            <div class="box-body">
                                <asp:Repeater ID="rptKPICategory" runat="server" OnItemDataBound="rptKPICategory_ItemDataBound">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <asp:Label ID="lblIDCategory" runat="server" Visible="false" Text='<%# Eval("IDCategory") %>'></asp:Label>
                                        <asp:Label ID="lblCategory" runat="server" Visible="false" Text='<%# Eval("Category") %>'></asp:Label>
                                        <table border="0" class="tbCat">

                                            <tr>
                                                <td class="thSubCat">
                                                    <asp:LinkButton CssClass="boton" Font-Size="Large" Width="20%" runat="server" ID="lnkCategory" Text='<%# Eval("Category") %>' OnClick="lnkCategory_Click"></asp:LinkButton>
                                                </td>
                                                <td class="thSubCat2">

                                                    <asp:LinkButton CssClass="boton1" runat="server" ID="lnkColapse" Text='- ' OnClick="lnkColapse_Click"></asp:LinkButton>
                                                </td>


                                            </tr>
                                            <tr>
                                                <td colspan="2" class="thSubCat">
                                                    <asp:Repeater ID="rptSubCategory" OnItemDataBound="rptSubCategory_ItemDataBound" runat="server" Visible="true">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>

                                                        <ItemTemplate>
                                                            <asp:Label ID="IDCategory" runat="server" Visible="false" Text='<%# Eval("IDCategory") %>'></asp:Label>
                                                            <asp:Label ID="lblIDSubCategory" runat="server" Visible="false" Text='<%# Eval("IDSubCategory") %>'></asp:Label>
                                                            <asp:Label ID="Label4" ForeColor="White" runat="server" Visible="true" Text='<%# Eval("SubCategory") %>'></asp:Label>

                                                            <table id="tabla" runat="server" style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <div class="divKPIDetail">
                                                                            <table border="1" class="tbDetail">
                                                                                <tr>
                                                                                    <th class="header">No.</th>
                                                                                    <th class="header">Measure</th>
                                                                                    <th class="header" hidden="hidden">Tipo de Dato</th>
                                                                                    <th class="header">
                                                                                        <asp:Label ID="lblPastYear" runat="server" Visible="true" Text=""> A</asp:Label></th>
                                                                                    <th class="header">
                                                                                        <asp:Label ID="lblCurrentYear" runat="server" Visible="true" Text=""></asp:Label>
                                                                                        Goal / Aim </th>
                                                                                    <th class="header">P/A</th>
                                                                                    <th class="header">Jan</th>
                                                                                    <th class="header">Feb</th>
                                                                                    <th class="header">Mar</th>
                                                                                    <th class="header">Apr</th>
                                                                                    <th class="header">May</th>
                                                                                    <th class="header">Jun</th>
                                                                                    <th class="header">July</th>
                                                                                    <th class="header">Aug</th>
                                                                                    <th class="header">Sep</th>
                                                                                    <th class="header">Oct</th>
                                                                                    <th class="header">Nov</th>
                                                                                    <th class="header">Dec</th>
                                                                                    <th class="header">Tgt/YTD</th>
                                                                                </tr>
                                                                                <asp:Repeater ID="rptKPIDet" OnItemDataBound="rptKPIDet_ItemDataBound" runat="server" Visible="true">
                                                                                    <HeaderTemplate>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>

                                                                                        <tr>
                                                                                            <th rowspan="2" class="tdDetID">
                                                                                                <asp:Label runat="server" ID="Label2" Text='<%# Eval("OrderColumn") %>'></asp:Label></td></th>
                                                                                            <th rowspan="2" class="thDet">
                                                                                                <asp:Label runat="server" ID="lblID" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIName" Text='<%# Eval("Name") %>'></asp:Label>
                                                                                                <asp:Label runat="server" Visible="false" ID="lblKPIUpdateMethod" Text='<%# Eval("KPIUpdateMethod") %>'></asp:Label>
                                                                                                <asp:Label runat="server" Visible="false" ID="lblSubCategory" Text='<%# Eval("SubCategory") %>'></asp:Label>
                                                                                                </td>

                                                                                            </th>
                                                                                            <th rowspan="2" class="thDet" hidden="hidden">
                                                                                                <asp:Label runat="server" ID="lblDataType" Text='<%# Eval("DataType") %>'></asp:Label></td></th>

                                                                                            <th rowspan="2" class="tdDet">

                                                                                                <asp:Label runat="server" ID="lblPrevYearResult" Text='<%# Eval("PrevYearResult") %>'></asp:Label></td></th>
                                                                                            <th rowspan="2" runat="server" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblCurrentYearGoal" Text='<%# Eval("CurrentYearGoal") %>'></asp:Label></td></th>

                                                                                            <th class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPrior" Text=""></asp:Label></th>
                                                                                            <td id="tdPJan" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning1" Text='<%# Eval("Planning1") %>'></asp:Label></td>
                                                                                            <td id="tdPFeb" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning2" Text='<%# Eval("Planning2") %>'></asp:Label></td>
                                                                                            <td id="tdPMar" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning3" Text='<%# Eval("Planning3") %>'></asp:Label></td>
                                                                                            <td id="tdPApr" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning4" Text='<%# Eval("Planning4") %>'></asp:Label></td>
                                                                                            <td id="tdPMay" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning5" Text='<%# Eval("Planning5") %>'></asp:Label></td>
                                                                                            <td id="tdPJun" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning6" Text='<%# Eval("Planning6") %>'></asp:Label></td>
                                                                                            <td id="tdPJul" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning7" Text='<%# Eval("Planning7") %>'></asp:Label></td>
                                                                                            <td id="tdPAug" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning8" Text='<%# Eval("Planning8") %>'></asp:Label></td>
                                                                                            <td id="tdPSep" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning9" Text='<%# Eval("Planning9") %>'></asp:Label></td>
                                                                                            <td id="tdPOct" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning10" Text='<%# Eval("Planning10") %>'></asp:Label></td>
                                                                                            <td id="tdPNov" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning11" Text='<%# Eval("Planning11") %>'></asp:Label></td>
                                                                                            <td id="tdPDec" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblPlanning12" Text='<%# Eval("Planning12") %>'></asp:Label></td>
                                                                                            <td id="tdPTgtYTD" class="tdDet">

                                                                                                <asp:Label ToolTip='<%# Eval("ToolTipPlan") %>' runat="server" ID="PTgtYTD" Text='<%# Eval("PTgtYTD") %>'></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th class="tdDet">Actual</th>
                                                                                            <td id="tdAJan" runat="server" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual1" Text='<%# Eval("Actual1") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange1" Text='<%# Eval("KPIRange1") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod1" Text='<%# Eval("UpdateMethod1") %>' Visible="false"></asp:Label></td>
                                                                                            <td id="tdAFeb" runat="server" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual2" Text='<%# Eval("Actual2") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange2" Text='<%# Eval("KPIRange2") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod2" Text='<%# Eval("UpdateMethod2") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAMar" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual3" Text='<%# Eval("Actual3") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange3" Text='<%# Eval("KPIRange3") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod3" Text='<%# Eval("UpdateMethod3") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAApr" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual4" Text='<%# Eval("Actual4") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange4" Text='<%# Eval("KPIRange4") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod4" Text='<%# Eval("UpdateMethod4") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAMay" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual5" Text='<%# Eval("Actual5") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange5" Text='<%# Eval("KPIRange5") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod5" Text='<%# Eval("UpdateMethod5") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAJune" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual6" Text='<%# Eval("Actual6") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange6" Text='<%# Eval("KPIRange6") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod6" Text='<%# Eval("UpdateMethod6") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAJuly" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual7" Text='<%# Eval("Actual7") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange7" Text='<%# Eval("KPIRange7") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod7" Text='<%# Eval("UpdateMethod7") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAAug" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual8" Text='<%# Eval("Actual8") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange8" Text='<%# Eval("KPIRange8") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod8" Text='<%# Eval("UpdateMethod8") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdASep" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual9" Text='<%# Eval("Actual9") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange9" Text='<%# Eval("KPIRange9") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod9" Text='<%# Eval("UpdateMethod9") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdAOct" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual10" Text='<%# Eval("Actual10") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange10" Text='<%# Eval("KPIRange10") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod10" Text='<%# Eval("UpdateMethod10") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdANov" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual11" Text='<%# Eval("Actual11") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange11" Text='<%# Eval("KPIRange11") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod11" Text='<%# Eval("UpdateMethod11") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdADec" class="tdDet">
                                                                                                <asp:Label runat="server" ID="lblActual12" Text='<%# Eval("Actual12") %>'></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblKPIRange12" Text='<%# Eval("KPIRange12") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label runat="server" ID="lblUpdMethod12" Text='<%# Eval("UpdateMethod12") %>' Visible="false"></asp:Label></td>
                                                                                            </td>
                                                                                            <td runat="server" id="tdATgtYTD" class="tdDet">
                                                                                                <asp:Label ToolTip='<%# Eval("ToolTipActual") %>' runat="server" ID="Label1"></asp:Label>
                                                                                                <asp:Label ToolTip='<%# Eval("ToolTipActual") %>' runat="server" ID="ATgtYTD" Text='<%# Eval("ATgtYTD") %>'>
                                                                                     
                                                                                                </asp:Label></td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </table>
                                                                    </td>
                                                                </tr>
                                                            </table>


                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>

                                        </table>

                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>

        <div class=" row">
            <div class="col-md-12">
                <div class="box box-danger">
                    <div class="box-header with-border">
                        <h3 class="box-title"></h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="box-header with-border">
                                <h3 class="box-title">Explanation of Performance Gaps and Activities to Close Gaps</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">
                                <table width="100%" align="center">
                                    <tr>
                                        <td>
                                            <asp:Button Text="January" BorderStyle="None" ID="Ene" CssClass="Initial" runat="server"
                                                OnClick="Ene_Click" />
                                            <asp:Button Text="February" BorderStyle="None" ID="February" CssClass="Initial" runat="server"
                                                OnClick="February_Click" />
                                            <asp:Button Text="March" BorderStyle="None" ID="March" CssClass="Initial" runat="server"
                                                OnClick="March_Click" />
                                            <asp:Button Text="April" BorderStyle="None" ID="April" CssClass="Initial" runat="server"
                                                OnClick="April_Click" />
                                            <asp:Button Text="May" BorderStyle="None" ID="May" CssClass="Initial" runat="server"
                                                OnClick="May_Click" />
                                            <asp:Button Text="June" BorderStyle="None" ID="June" CssClass="Initial" runat="server"
                                                OnClick="June_Click" />
                                            <asp:Button Text="July" BorderStyle="None" ID="July" CssClass="Initial" runat="server"
                                                OnClick="July_Click" />
                                            <asp:Button Text="August" BorderStyle="None" ID="August" CssClass="Initial" runat="server"
                                                OnClick="August_Click" />
                                            <asp:Button Text="September" BorderStyle="None" ID="September" CssClass="Initial" runat="server"
                                                OnClick="September_Click" />
                                            <asp:Button Text="October" BorderStyle="None" ID="October" CssClass="Initial" runat="server"
                                                OnClick="October_Click" />
                                            <asp:Button Text="November" BorderStyle="None" ID="November" CssClass="Initial" runat="server"
                                                OnClick="November_Click" />
                                            <asp:Button Text="December" BorderStyle="None" ID="December" CssClass="Initial" runat="server"
                                                OnClick="December_Click" />

                                            <asp:MultiView ID="MainView" runat="server">
                                                <asp:View ID="View1" runat="server">
                                                    <table class="tbCat" style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <h3>
                                                                    <span>
                                                                        <table style="width: 10%;" border="0" class="tbCat">
                                                                            <div class=" row">
                                                                                <div class="col-md-12">
                                                                                    <div class="box box-danger">


                                                                                        <asp:Repeater ID="rptExpCategory" runat="server" OnItemDataBound="rptExpCategory_ItemDataBound">
                                                                                            <HeaderTemplate>
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>

                                                                                                <asp:Label ID="lblIDCategory" runat="server" Visible="false" Text='<%# Eval("IDCategory") %>'></asp:Label>
                                                                                                <asp:Label ID="lblCategory" runat="server" Visible="false" Text='<%# Eval("Category") %>'></asp:Label>

                                                                                                <table border="0" class="tbCat">

                                                                                                    <tr>
                                                                                                        <td class="thSubCat">
                                                                                                            <asp:LinkButton CssClass="boton" Font-Size="Large" Width="20%" runat="server" ID="lnkCategory" Text='<%# Eval("Category") %>' OnClick="lnkCategory_Click"></asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td class="thSubCat2">

                                                                                                            <asp:LinkButton CssClass="boton1" runat="server" ID="lnkColapse" Text='- ' OnClick="lnkColapse_Click"></asp:LinkButton>
                                                                                                        </td>


                                                                                                    </tr>

                                                                                                    <tr>

                                                                                                        <td colspan="2" class="thSubCat">
                                                                                                            <asp:Repeater ID="rptExpSubCategory" OnItemDataBound="rptExpSubCategory_ItemDataBound" runat="server" Visible="true">
                                                                                                                <HeaderTemplate>
                                                                                                                </HeaderTemplate>

                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="IDCategory" runat="server" Visible="false" Text='<%# Eval("IDCategory") %>'></asp:Label>
                                                                                                                    <asp:Label ID="lblIDSubCategory" runat="server" Visible="false" Text='<%# Eval("IDSubCategory") %>'></asp:Label>
                                                                                                                    <asp:Label ID="Label4" ForeColor="White" Font-Size="Small" runat="server" Visible="true" Text='<%# Eval("SubCategory") %>'></asp:Label>

                                                                                                                    <table id="tabla" runat="server" style="width: 100%;">
                                                                                                                        <tr>
                                                                                                                            <td>
                                                                                                                                <div class="divKPIDetail">
                                                                                                                                    <table border="1" class="tbDetail">
                                                                                                                                        <tr>
                                                                                                                                            <th class="header">
                                                                                                                                                <asp:Label runat="server" ID="lblHead1" Text="Explanation of Performance Gaps"></asp:Label></th>
                                                                                                                                            <th class="header">
                                                                                                                                                <asp:Label runat="server" ID="lblHead2" Text="Activities to Close Gaps"></asp:Label></th>
                                                                                                                                        </tr>
                                                                                                                                        <asp:Repeater ID="rptExpDet" OnItemDataBound="rptExpDet_ItemDataBound" runat="server" Visible="true">
                                                                                                                                            <HeaderTemplate>
                                                                                                                                            </HeaderTemplate>
                                                                                                                                            <ItemTemplate>

                                                                                                                                                <tr>
                                                                                                                                                    <th colspan="2" class="tdDetID">
                                                                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("Name") %>'></asp:Label></td></th>
                                                                                                                                                </tr>
                                                                                                                                                <tr>

                                                                                                                                                    <td id="tdPJan" class="tdDet">
                                                                                                                                                        <asp:Label runat="server" ID="PJan" Text='<%# Eval("ExplanationOfPerformanceGaps") %>'></asp:Label></td>
                                                                                                                                                    <td id="tdPFeb" class="tdDet">
                                                                                                                                                        <asp:Label runat="server" ID="PFeb" Text='<%# Eval("ActivitiesToCloseGaps") %>'></asp:Label></td>
                                                                                                                                                </tr>




                                                                                                                                            </ItemTemplate>
                                                                                                                                        </asp:Repeater>
                                                                                                                                    </table>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>


                                                                                                                </ItemTemplate>
                                                                                                            </asp:Repeater>
                                                                                                        </td>
                                                                                                    </tr>

                                                                                                </table>

                                                                                                <br />
                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>

                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </table>
                                                                        <asp:Repeater ID="rptAdditionalComment" runat="server">
                                                                            <HeaderTemplate>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblIDCategory" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                                                <asp:Label ID="lblCategory" runat="server" Visible="false" Text='<%# Eval("Sequence") %>'></asp:Label>
                                                                                <table border="0" class="tbCat">
                                                                                    <tr>
                                                                                        <td class="thSubCat">
                                                                                            <asp:LinkButton CssClass="boton" Font-Size="Large" Width="30%" runat="server" ID="lnkCategory" Text='<%# Eval("Description") %>' OnClick="lnkCategory_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td class="thSubCat2">
                                                                                            <asp:LinkButton CssClass="boton1" runat="server" ID="lnkColapse" Text='- ' OnClick="lnkColapse_Click"></asp:LinkButton>
                                                                                        </td>

                                                                                    </tr>
                                                                                </table>

                                                                                <div class="divKPIDetail">
                                                                                    <table border="1" class="tbDetail">
                                                                                        <tr>
                                                                                            <td class="tdDet" style="font-size: small; width: 50%;">
                                                                                                <asp:Label ID="lblGoodComment" runat="server" Visible="true" Text='<%# Eval("Comments") %>'></asp:Label></td>

                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                                <br />
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                        <asp:Repeater ID="rptComment1" runat="server">
                                                                            <HeaderTemplate>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>

                                                                                <asp:Label ID="lblIDCategory" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                                                <asp:Label ID="lblCategory" runat="server" Visible="false" Text='<%# Eval("IDArea") %>'></asp:Label>
                                                                                <table border="0" class="tbCat">
                                                                                    <tr>
                                                                                        <td class="thSubCat">
                                                                                            <asp:LinkButton CssClass="boton" Font-Size="Large" Width="50%" runat="server" ID="lnkCategory" Text='<%# Eval("Name") %>' OnClick="lnkCategory_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td class="thSubCat2">
                                                                                            <asp:LinkButton CssClass="boton1" runat="server" ID="lnkColapse" Text='- ' OnClick="lnkColapse_Click"></asp:LinkButton>
                                                                                        </td>

                                                                                    </tr>
                                                                                </table>

                                                                                <div class="divKPIDetail">
                                                                                    <table border="1" class="tbDetail">
                                                                                        <tr>
                                                                                            <th class="header" style="font-size: small">Good</th>
                                                                                            <th class="header" style="font-size: small">Bad</th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="tdDet" style="font-size: small; width: 50%;">
                                                                                                <asp:Label ID="lblGoodComment" runat="server" Visible="true" Text='<%# Eval("CommentaryGood") %>'></asp:Label></td>
                                                                                            <td class="tdDet" style="font-size: small; width: 50%;">
                                                                                                <asp:Label ID="lblBadCommen" runat="server" Visible="true" Text='<%# Eval("CommentaryBad") %>'></asp:Label></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                                <br />
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>
                                                                        <table style="width: 100%;" border="1" class="tbCat">
                                                                            <tr>
                                                                                <td colspan="4" class="thSubCat">
                                                                                    <asp:Repeater ID="rptTopFive" OnItemDataBound="rptTopFive_ItemDataBound" runat="server" Visible="true">
                                                                                        <HeaderTemplate>
                                                                                        </HeaderTemplate>

                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="IDCategory" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                                                            <asp:Label ID="lblIDSubCategory" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                                                            <asp:Label ID="Label4" ForeColor="White" Font-Size="18px" runat="server" Visible="true" Text='<%# Eval("Name") %>'></asp:Label>

                                                                                            <table id="tabla" runat="server" style="width: 100%;">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <div class="divKPIDetail">
                                                                                                            <table border="1" class="tbDetail">
                                                                                                                <tr>
                                                                                                                    <th class="header">Customer</th>
                                                                                                                    <th class="header">CM %</th>
                                                                                                                    <th class="header">Tons</th>
                                                                                                                    <th class="header" colspan="2">Comments</th>
                                                                                                                </tr>
                                                                                                                <asp:Repeater ID="rptTopFiveDtl" runat="server" Visible="true">
                                                                                                                    <HeaderTemplate>
                                                                                                                    </HeaderTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <tr>
                                                                                                                            <td id="tdPJan" class="tdDet">
                                                                                                                                <asp:Label runat="server" ID="PJan" Text='<%# Eval("Customer") %>'></asp:Label></td>
                                                                                                                            <td id="tdPFeb" class="tdDet">
                                                                                                                                <asp:Label runat="server" ID="PFeb" Text='<%# Eval("CMPercentage") %>'></asp:Label></td>
                                                                                                                            <td id="Tons" class="tdDet">
                                                                                                                                <asp:Label runat="server" ID="PMar" Text='<%# Eval("Tons") %>'></asp:Label></td>
                                                                                                                            <td id="td" class="tdDet" colspan="2">
                                                                                                                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("Comments") %>'></asp:Label></td>
                                                                                                                        </tr>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:Repeater>
                                                                                                            </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>


                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                        <br />


                                                                    </span>
                                                                </h3>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>

                                            </asp:MultiView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <%--   <asp:AsyncPostBackTrigger ControlID="lnkColapse" EventName="Click" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="correos" runat="server"  />

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <%--<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>
    <script src="JScripts/sweetalert2.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".send").click(function () {
                var iMonth = $(".month").val();
                    var iYear = $(".year").val();
                var correos = $("#ctl00_Contenedor_correos").val();
                switch (iMonth) {
                                case "1":
                                    strMonth = "January";
                                    break;
                                case "2":
                                    strMonth = "February";
                                    break;
                                case "3":
                                    strMonth = "March";
                                    break;
                                case "4":
                                    strMonth = "April";
                                    break;
                                case "5":
                                    strMonth = "May";
                                    break;
                                case "6":
                                    strMonth = "June";
                                    break;
                                case "7":
                                    strMonth = "July";
                                    break;
                                case "8":
                                    strMonth = "August";
                                    break;
                                case "9":
                                    strMonth = "September";
                                    break;
                                case "10":
                                    strMonth = "October";
                                    break;
                                case "11":
                                    strMonth = "November";
                                    break;
                                case "12":
                                    strMonth = "December";
                                    break;
                            }
                    swal.fire({
                        title: "Are you sure?",
                        text: "Send the report for the " + strMonth + " " + iYear + " period to the following emails ?\n" + correos,
                         showCancelButton: true,
                                confirmButtonText: "Confirm",
                                denyButtonText: "Cancel"
                    })
                    .then((result) => {
                        if (result.isConfirmed) {
                            EnvioCorreos("true").then((result2,reject) => {
                                
                                if (result2.d = 1) {
                                    Swal.fire("Success", "Operation Success", "info");
                                }
                            })
                        }
                        if (!result.isConfirmed) {
                            Swal.fire("Cancel", "Operation cancelled.", "error");
                        }
                    })

           });
        });
        

     

        function EnvioCorreos(confirmacion) {
            var iMonth = $(".month").val();
            var iYear = $(".year").val();
            var confirm = "false";
            debugger;
            if (confirmacion) { confirm = "true"; }
            var param = iYear + "," + iMonth + "," + confirm;
            debugger;
            return new Promise(function (resolve, reject) {
                $.ajax({
                    type: "POST",
                    url: "KPIReport.aspx/SendToEmail",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({ param: param }),
                    success: function (response) {
                        debugger;
                        resolve(response.d);
                       

                    },
                    error: function (xhr, status, error) {
                        Swal.fire("Cancel", "Error: " + error, "error");
                        reject("Error: " + error);

                    }

                });
            });

        };


        
        
    </script> 

</asp:Content>

