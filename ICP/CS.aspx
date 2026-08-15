<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CS.aspx.cs" Inherits="ICP.CS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your Name :
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <input id="btnGetTime" type="button" value="Show Current Time"
                onclick="ShowCurrentTime()" />
        </div>
        <div>
            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
            <script src="JScripts/ReportSalesProfitMaterials.js"></script>
        </div>
        <table>
            <tr style="background-color: red">
                <td>ss</td>
            </tr>
        </table>
        <table style="align-content: center; width: 100%;">
            <tr>
                <td colspan="3" style="font-family: Calibri; text-align: center; width: 100%; font-size: 18px;">Muy buen día:</td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; width: 100%; font-size: 18px; height: 20px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; text-align: center; width: 100%; font-size: 18px;">Anexamos los documentos cuyos complementos de pago no se encuentran en nuestro sistema. Por favor considerar los siguientes puntos para su envío:</td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; width: 100%; font-size: 18px; height: 20px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; text-align: center; width: 100%; font-size: 18px; font-weight: bold;">SWM CORPORATE RESOURCES, S DE RL DE CV</td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; width: 100%; font-size: 18px; height: 20px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; text-align: center; width: 100%; font-size: 18px; font-weight: bold;">Requisitos para envío de facturas y complementos de pago:</td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; width: 100%; font-size: 18px; height: 20px;"></td>
            </tr>
            <tr>
                <td style="font-family: Calibri; text-align: center; width: 20%; font-size: 18px;"></td>
                <td style="font-family: Calibri; text-align: center; border: solid; border-color: #EBEBEB; border-width: 1px; align-content: center; font-size: 18px;">
                    <table>
                        <tr>
                            <td style="font-family: Calibri; text-align: justify; font-size: 16px;">&#x2022;El pdf y el xml deben tener el mismo nombre, ejemplo: 123.pdf  123.xml</td>
                        </tr>
                        <tr>
                            <td style="font-family: Calibri; text-align: justify; font-size: 16px;">&#x2022;El envío de CFDI´s debe hacerse a los siguientes correos:
                                <br />
                                &#8195;SCR070219IY0@buzonfiscal.com;
                                <br />
                                &#8195;gabyl@steelwarehouse.mx</td>
                        </tr>
                        <tr>
                            <td style="font-family: Calibri; text-align: justify; font-size: 16px;">&#x2022;Los archivos NO deben de venir en .zip</td>
                        </tr>
                    </table>
                </td>
                <td style="font-family: Calibri; text-align: center; width: 20%; font-size: 18px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; width: 100%; font-size: 18px; height: 20px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; text-align: center; width: 100%; font-size: 18px;">Muchas gracias!</td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; width: 100%; font-size: 18px; height: 20px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-family: Calibri; text-align: center; width: 100%; font-style: italic; font-size: 16px;">Nota:<br />
                    Por favor, NO responda a este mensaje, ya que es un envío automático y no se da seguimiento a los mensajes de entrada en este correo</td>
            </tr>
        </table>
    </form>
</body>


</html>
