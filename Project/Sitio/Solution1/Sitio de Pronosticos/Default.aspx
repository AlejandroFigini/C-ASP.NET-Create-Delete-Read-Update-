<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
            height: 376px;
        }
        .auto-style17 {
            box-shadow: -44px 28px 79px -12px rgba(0,0,0,0.51);
            width: 983px;
        }
        .auto-style19 {
            width: 100%;
            height: 398px;
        }
        .auto-style22 {
            background-color: #F4FEE0;
            text-align: center;
            height: 100px;
        }
        .auto-style23 {
            background-color: #F4FEE0;
            text-align: center;
            height: 207px;
        }
        .auto-style24 {
            background-color: #F4FEE0;
            text-align: center;
            width: 962px;
            height: 184px;
            margin-left: 11px;
        }
        .auto-style25 {
            margin-left: 0px;
            margin-bottom: 11px;
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
                <td>&nbsp;</td>
                <td class="auto-style17" style="background-color: #FFFFFF">
                    <table cellpadding="0" cellspacing="0" class="auto-style19">
                        <tr>
                            <td class="auto-style22" style="background-color: #F4FEE0">
                    <asp:Label ID="Label3" runat="server" Text="Pronósticos para el día de hoy: " Style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:30px;" BorderColor="White" Font-Bold="True" BackColor="#F4FEE0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23" style="background-color: #F4FEE0">
                                <div class="auto-style24" style="background-color: #F4FEE0">
                                    <asp:ListBox ID="LstPronosticos" runat="server" Height="186px" Width="963px" CssClass="auto-style25"></asp:ListBox>
                                    <br />
                                <asp:Label ID="LblError" runat="server" Font-Bold="True" Style="font-family:Gadugi; font-size:15px;" BackColor="#F4FEE0" ForeColor="#FF5050"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        </table>
                    </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
