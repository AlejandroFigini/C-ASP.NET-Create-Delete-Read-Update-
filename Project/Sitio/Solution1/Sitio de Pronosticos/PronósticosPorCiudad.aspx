<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PronósticosPorCiudad.aspx.cs" Inherits="PronósticosPorCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <table cellpadding="0" cellspacing="0" class="auto-style10" style="text-align: center; width: 1134px;">
        <tr>
            <td style="background-color: #F4FEE0">
                <asp:Label ID="Label3" runat="server" Text="Listado de Pronósticos por Ciudad" BorderColor="White" Font-Bold="True" Style="font-family: Gadugi; font-size: 40px;"  BackColor="#F4FEE0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0;">&nbsp;</td>
        </tr>
        </table>
    <table cellpadding="0" cellspacing="0" class="auto-style10" style="text-align: center; width: 1137px; height: 601px;">
        <tr>
            <td style="background-color: #F4FEE0; height: 13px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="width: 568px; background-color: #F4FEE0; height: 15px;">
                <asp:Label ID="Label2" runat="server" Text="Pais" Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" BackColor="#F4FEE0"></asp:Label>
                <asp:DropDownList ID="ddlPais" runat="server" BackColor="White" Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="Medium" ForeColor="Black" Height="20px" style="margin-bottom: 0px; margin-left: 65px; margin-right: 36px;">
                </asp:DropDownList>
            </td>
            <td style="background-color: #F4FEE0; height: 15px; width: 569px;">
                <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="BtnListar_Click"  BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  Width="104px" style="margin-left: 0px; margin-bottom: 0px;"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #F4FEE0; height: 36px;">
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudades"  Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" BackColor="#F4FEE0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #F4FEE0; height: 201px;">
                <div style="border: medium none #008000; width: 438px; height: 193px; margin-left: 342px; background-color: #F4FEE0;">
                <asp:GridView ID="GvCiudad" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="190px" PageSize="4" Width="436px" style="margin-left: 0px; margin-right: 0px" OnPageIndexChanging="GvCiudad_PageIndexChanging" OnSelectedIndexChanged="GvCiudad_SelectedIndexChanged">
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
        </tr>
        <tr>
            <td style="background-color: #F4FEE0;" colspan="2">
                <asp:Label ID="lblPronostico" runat="server" Text="Pronosticos"  Font-Bold="False" Font-Names="Franklin Gothic Medium" Font-Size="X-Large" BackColor="#F4FEE0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #F4FEE0">
                <div style="width: 1096px; height: 179px; margin-left: 19px; background-color: #F4FEE0;">
                    <asp:GridView ID="GvPronostico" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnPageIndexChanging="GvPronostico_PageIndexChanging" PageSize="4" Width="1093px">
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
            <td style="background-color: #F4FEE0;" colspan="2">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Style="font-family:Gadugi; font-size:15px;" BackColor="#F4FEE0" ForeColor="#FF5050"></asp:Label>
                            </td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0;" colspan="2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

