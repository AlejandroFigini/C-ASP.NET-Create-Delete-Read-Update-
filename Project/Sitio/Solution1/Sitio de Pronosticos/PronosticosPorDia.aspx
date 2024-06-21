<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PronosticosPorDia.aspx.cs" Inherits="PronosticosPorDia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="auto-style10" style="height: 522px; background-color: #FF00FF; text-align: center; width: 1091px;">
        <tr>
            <td colspan="3" style="text-align: center; background-color: #F4FEE0">
                <asp:Label ID="Label2" runat="server" Text=" Listado Pronósticos para el día" BorderColor="White" Font-Bold="True" Style="font-family: Gadugi; font-size: 40px;"  BackColor="#F4FEE0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; " colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; " colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; width: 352px;">
                <asp:Label ID="Label3" runat="server" Text="Fecha de Pronostico" Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" BackColor="#F4FEE0"></asp:Label>
            </td>
            <td style="text-align: center; background-color: #F4FEE0">
            <asp:Calendar ID="ClrFecha" runat="server" BackColor="#FFF7E7" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" style="margin-left: 73px" Width="220px">
                <DayHeaderStyle BackColor="#F7DFB5" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#DD7604" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" Font-Size="9pt"  />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            </td>
            <td style="text-align: center; background-color: #F4FEE0; width: 273px;">
                <asp:Button ID="BtnListar" runat="server" Text="Listar" OnClick="BtnListar_Click"  BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  Width="104px" style="margin-left: 0px; margin-bottom: 0px; margin-top: 0px;"/>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; height: 76px;" colspan="3"></td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; height: 40px;" colspan="3">
                <asp:Label ID="lblPronostico" runat="server" Text="Pronosticos"  Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" BackColor="#F4FEE0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; height: 25px;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; " colspan="3">
                <div style="height: 171px; width: 1037px; margin-left: 28px">
                    <asp:GridView ID="GvPronostico" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnPageIndexChanging="GvPronostico_PageIndexChanging" PageSize="4" Height="42px" Width="1034px">
                        <Columns>
                            <asp:BoundField DataField="Codigo_Interno" HeaderText="Codigo Interno" SortExpression="Codigo_Interno">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Usuario.Nombre_Completo" HeaderText="Usuario" SortExpression="Usuario.Nombre_Completo">
                            <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Ciudad.Codigo_Ciudad" HeaderText="Ciudad" SortExpression="Ciudad.Codigo_Ciudad">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Pais.Codigo_Pais" HeaderText="Pais" SortExpression="Pais.Codigo_Pais">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Maxima" HeaderText="Maxima C°" SortExpression="Maxima">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Minima" HeaderText="Minima C°" SortExpression="Minima">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha_Hora" HeaderText="Fecha y Hora" SortExpression="Fecha_Hora">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VelViento" HeaderText="Velocidad de Viento Km/h" SortExpression="VelViento">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Probabilidad" HeaderText="Probabilidad de Lluvias %" SortExpression="Probabilidad">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo_Cielo" HeaderText="Tipo de Cielo" SortExpression="Tipo_Cielo">
                                <HeaderStyle Font-Bold="True" Font-Names="Franklin Gothic Medium" />
                                 <ItemStyle Font-Names="Franklin Gothic Medium" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; " colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; " colspan="3">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Style="font-family:Gadugi; font-size:15px;" BackColor="#F4FEE0" ForeColor="#FF5050"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="text-align: center; background-color: #F4FEE0; " colspan="3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

