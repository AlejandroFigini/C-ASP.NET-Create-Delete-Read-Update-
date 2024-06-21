<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrarPronostico.aspx.cs" Inherits="RegistrarPronostico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="auto-style10" style="width: 983px; height: 563px">
    <tr>
        <td colspan="4" style="background-color: #F4FEE0; text-align: center; height: 35px;">
                <asp:Label ID="Label1" runat="server" BorderColor="White" Font-Bold="True" Style="font-family: Gadugi; font-size: 40px;" Text="Registrar Pronostico" BackColor="#F4FEE0"></asp:Label>
            </td>
    </tr>
    <tr>
        <td colspan="4" style="background-color: #F4FEE0; text-align: center; height: 35px;">&nbsp;</td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="2">
            <asp:Label ID="Label12" runat="server" Text="Ciudad" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="2">
            <asp:Label ID="Label13" runat="server" Text="Fecha " Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="2">
            <div style="width: 424px; height: 175px; margin-left: 52px">
                <asp:GridView ID="GvCiudad" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="170px" PageSize="4" Width="424px" style="margin-left: 0px; margin-right: 0px" OnPageIndexChanging="GV_PageIndexChanging" OnSelectedIndexChanged="GvCiudad_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" >
                        <ItemStyle Font-Bold="True" />
                            <ControlStyle BackColor="#FDEED0" BorderColor="Black" Font-Names="Franklin Gothic Medium" Font-Size="Small" />
                        <ItemStyle BackColor="#A55129" Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Pais.Codigo_Pais" HeaderText="Codigo de Pais" >
                        <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                        <ItemStyle Font-Names="Franklin Gothic Medium" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Codigo_Ciudad" HeaderText="Ciudad" SortExpression="Codigo_Ciudad" >
                        <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                        <ItemStyle Font-Names="Franklin Gothic Medium" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" >
                        <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                        <ItemStyle Font-Names="Franklin Gothic Medium" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#DD7604" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </div>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="2">
            <asp:Calendar ID="ClrFecha" runat="server" BackColor="#FFF7E7" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" style="margin-left: 138px" Width="220px">
                <DayHeaderStyle BackColor="#F7DFB5" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#DD7604" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" Font-Size="9pt"  />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
        </td>

    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20" style="background-color: #F4FEE0; text-align: center; width: 245px; height: 35px;">
            <asp:Label ID="Label7" runat="server" Text="Maxima" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; width: 246px; height: 35px;">
            <asp:TextBox ID="txtMaxima" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" MaxLength="2" AutoCompleteType="Disabled"></asp:TextBox>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px; width: 246px;">
            <asp:Label ID="Label5" runat="server" Text="Minima" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px; width: 246px;">
            <asp:TextBox ID="txtMinima" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" MaxLength="2" AutoCompleteType="Disabled"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style20" style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="4">&nbsp;</td>

    </tr>
    <tr>
        <td class="auto-style20" style="background-color: #F4FEE0; text-align: center; width: 245px; height: 35px;">
            <asp:Label ID="Label8" runat="server" Text="Velocidad de Viento" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; width: 246px; height: 35px;">
            <asp:TextBox ID="txtViento" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" MaxLength="2" AutoCompleteType="Disabled"></asp:TextBox>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px; width: 246px;">
            <asp:Label ID="Label10" runat="server" Text="Probabilidad" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px; width: 246px;">
            <asp:TextBox ID="txtProbabilidad" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" MaxLength="2" AutoCompleteType="Disabled"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style20" style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20" style="background-color: #F4FEE0; text-align: center; width: 245px; height: 35px;">
            <asp:Label ID="Label9" runat="server" Text="Hora" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; width: 246px; height: 35px;">
            <asp:DropDownList ID="ddlHora" runat="server">
                <asp:ListItem>00:00</asp:ListItem>
                <asp:ListItem>00:30</asp:ListItem>
                <asp:ListItem>01:00</asp:ListItem>
                <asp:ListItem>01:30</asp:ListItem>
                <asp:ListItem>02:00</asp:ListItem>
                <asp:ListItem>02:30</asp:ListItem>
                <asp:ListItem>03:00</asp:ListItem>
                <asp:ListItem>03:30</asp:ListItem>
                <asp:ListItem>04:00</asp:ListItem>
                <asp:ListItem>04:30</asp:ListItem>
                <asp:ListItem>05:00</asp:ListItem>
                <asp:ListItem>05:30</asp:ListItem>
                <asp:ListItem>06:00</asp:ListItem>
                <asp:ListItem>06:30</asp:ListItem>
                <asp:ListItem>07:30</asp:ListItem>
                <asp:ListItem>08:00</asp:ListItem>
                <asp:ListItem>08:30</asp:ListItem>
                <asp:ListItem>09:00</asp:ListItem>
                <asp:ListItem>09:30</asp:ListItem>
                <asp:ListItem>10:00</asp:ListItem>
                <asp:ListItem>10:30</asp:ListItem>
                <asp:ListItem>11:00</asp:ListItem>
                <asp:ListItem>11:30</asp:ListItem>
                <asp:ListItem>12:00</asp:ListItem>
                <asp:ListItem>12:30</asp:ListItem>
                <asp:ListItem>13:00</asp:ListItem>
                <asp:ListItem>13:30</asp:ListItem>
                 <asp:ListItem>14:00</asp:ListItem>
                <asp:ListItem>14:30</asp:ListItem>
                <asp:ListItem>15:00</asp:ListItem>
                <asp:ListItem>15:30</asp:ListItem>
                <asp:ListItem>16:00</asp:ListItem>
                <asp:ListItem>16:30</asp:ListItem>
                <asp:ListItem>17:00</asp:ListItem>
                <asp:ListItem>17:30</asp:ListItem>
                <asp:ListItem>18:00</asp:ListItem>
                <asp:ListItem>18:30</asp:ListItem>
                <asp:ListItem>19:00</asp:ListItem>
                <asp:ListItem>19:30</asp:ListItem>
                <asp:ListItem>20:00</asp:ListItem>
                <asp:ListItem>20:30</asp:ListItem>
                <asp:ListItem>21:00</asp:ListItem>
                <asp:ListItem>21:30</asp:ListItem>
                <asp:ListItem>22:00</asp:ListItem>
                <asp:ListItem>22:30</asp:ListItem>
                <asp:ListItem>23:00</asp:ListItem>
                 <asp:ListItem>23:30</asp:ListItem>

            </asp:DropDownList>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px; width: 246px;">
            <asp:Label ID="Label11" runat="server" Text="Tipo de Cielo" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
        </td>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px; width: 246px;">
            <asp:DropDownList ID="ddlTipoCielo" runat="server">
                <asp:ListItem Value="Despejado">Despejado</asp:ListItem>
                <asp:ListItem Value="Parcialmente Nuboso">Parcialmente Nuboso</asp:ListItem>
                <asp:ListItem Value="Nuboso">Nuboso</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style20" style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="4">&nbsp;</td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="4">&nbsp;</td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 35px;" colspan="4">
                <asp:Button ID="BtnAlta" runat="server" Text="Alta" OnClick="BtnAlta_Click"  BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  Width="104px" style="margin-left: 0px; margin-bottom: 0px; margin-right: 39px;"/>
                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar"   BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  Width="104px" style="margin-left: 0px; margin-bottom: 0px;" OnClick="BtnLimpiar_Click"/>
            </td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 36px;" colspan="4">&nbsp;</td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 36px;" colspan="4">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Style="font-family:Gadugi; font-size:15px;" BackColor="#F4FEE0" ForeColor="#FF5050"></asp:Label>
            </td>
    </tr>
    <tr>
        <td style="background-color: #F4FEE0; text-align: center; height: 36px;" colspan="4">&nbsp;</td>
    </tr>
</table>
</asp:Content>

