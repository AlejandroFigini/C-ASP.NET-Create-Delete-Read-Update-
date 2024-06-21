<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        * { 
            background-color: rgb(234, 239, 245);
              margin: 0px;
              padding: 0px;
              box-sizing: border-box;
           }

        .auto-style7 {
            background-color: rgb(43, 201, 201);
            height: 77px;
            width: 108px;
        }
        .auto-style2 {
            background-color: rgb(43, 201, 201);
            height: 77px;
        }

        .auto-style10 {
            width: 100%;
        }
        .auto-style12 {
            width: 100%;
            height: 73px;
        }
        .auto-style13 {
            background-color: rgb(43, 201, 201);
            height: 77px;
            width: 1354px;
        }
        .auto-style16 {
            width: 100%;
            height: 346px;
        }
        .auto-style17 {
            box-shadow: -44px 28px 79px -12px rgba(0,0,0,0.51);
            width: 669px;
        }
        .auto-style18 {
            width: 270px;
        }
        .auto-style20 {
            height: 19px;
        }
        .auto-style21 {
            text-align:center;
            width: 100%;
            height: 346px;
            margin-top: 0px;
        }
        .auto-style22 {
            width: 634px;
        }
        .auto-style23 {
            width: 232px;
        }
        .auto-style24 {
            height: 82px;
        }
        .auto-style25 {
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" class="auto-style12">
                <tr>
                    <td class="auto-style7" >
                        &nbsp;</td>
                    <td class="auto-style13" >
                    <asp:Label ID="Label1" runat="server" Text="Sitio de Pronosticos" Style="font-family:Corbel; font-size:40px;" BorderColor="White" Font-Bold="True" BackColor="#2BC9C9" Font-Names="Bahnschrift SemiBold"></asp:Label>
                    </td>
                    <td class="auto-style2" >
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Logueo.aspx" BackColor="#2BC9C9" BorderStyle="None" Font-Bold="True" Font-Italic="False" Font-Names="Bahnschrift Light" Font-Overline="False"  >Pagina de Logueo
                    </asp:LinkButton>
                    </td>
                </tr>
                </table>
        </div>
        <table class="auto-style10">
            <tr>
                <td>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="auto-style16">
            <tr>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style17" style="background-color: #FFFFFF">
                    <table cellpadding="0" cellspacing="0" class="auto-style21">
                        <tr>
                            <td colspan="2" style="background-color: #F4FEE0">
                                <asp:Label ID="Label4" runat="server" BorderColor="White" Font-Bold="True" Style="font-family:Gadugi; font-size:40px;" Text="Login" BackColor="#F4FEE0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #F4FEE0" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style18" style="background-color: #F4FEE0">
                                <asp:Label ID="Label2" runat="server" Style="font-family:Gadugi; font-size:35px;" Text="Usuario" BackColor="#F4FEE0"></asp:Label>
                            </td>
                            <td class="auto-style23" style="background-color: #F4FEE0">
                                <asp:TextBox ID="txtUsuario" runat="server" BackColor="White" BorderColor="Gray" BorderStyle="Ridge" Height="32px" Width="215px" AutoCompleteType="Disabled"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18" style="background-color: #F4FEE0">
                                <asp:Label ID="Label3" runat="server" Style="font-family:Gadugi; font-size:35px;" Text="Contraseña:" BackColor="#F4FEE0"></asp:Label>
                            </td>
                            <td class="auto-style23" style="background-color: #F4FEE0">
                                <asp:TextBox ID="txtContraseña" runat="server" BackColor="White" BorderColor="Gray" BorderStyle="Ridge" Height="32px" Width="215px" AutoCompleteType="Disabled" Font-Names="Marlett" Font-Strikeout="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #F4FEE0" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="background-color: #F4FEE0" class="auto-style24">
                                <asp:Button ID="BtnIngresar" runat="server" BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="47px"  Text="Ingresar" Width="102px" OnClick="BtnIngresar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style25" colspan="2" style="background-color: #F4FEE0">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Style="font-family:Gadugi; font-size:15px;" BackColor="#F4FEE0" ForeColor="#FF5050"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20" colspan="2" style="background-color: #F4FEE0">
                                &nbsp;</td>
                        </tr>
                    </table>
                    </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
