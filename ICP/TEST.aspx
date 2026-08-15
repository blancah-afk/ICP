<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="TEST.aspx.cs" Inherits="ICP.TEST" %>

<%@ Register Src="~/Control/DateTimePickers.ascx" TagName="DateTimePicker" TagPrefix="DateTime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>

    <script>
        $(function () {
            $.datepicker.setDefaults($.datepicker.regional["es"]);
            $("#dt").datepicker({
                firstDay: 1
            });
        });
    </script>

    <input  type="text" id="dt" />
</asp:Content>
