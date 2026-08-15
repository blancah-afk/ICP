<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="ICP.Test2" %>


<%@ Register Src="~/Control/DateTimePickers.ascx" TagName="DateTimePicker" TagPrefix="DateTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenedor" runat="server">
    <asp:ScriptManager runat="server" ID="sm" EnablePartialRendering="true"></asp:ScriptManager>
    <link href="CSS/bootstrap-combined.min.css" rel="stylesheet" />
    <link href="CSS/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="JScripts/jquery-1.10.2.min.js"></script>
    <script src="JScripts/bootstrap.min.js"></script>
    <script src="JScripts/bootstrap-datetimepicker.min.js"></script>
    <script src="JScripts/bootstrap-datetimepicker.pt-BR.js"></script>
    <div>
       
            <table>
                <tr>
                    <td>Select DateTime
                        </td>
                    <td>
                        <DateTime:DateTimePicker ID="DateTimePicker" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Style="color: Red;" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>
