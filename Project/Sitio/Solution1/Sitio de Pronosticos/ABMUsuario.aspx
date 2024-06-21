<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMUsuario.aspx.cs" Inherits="ABMUsuario" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="auto-style10" style="width: 979px; height: 380px; background-color: #000080; text-align: center;">
        <tr>
            <td colspan="3" style="background-color: #F4FEE0; height: 29px;">
                <asp:Label ID="Label1" runat="server" BorderColor="White" Font-Bold="True" Style="font-family: Gadugi; font-size: 40px;" Text="Mantenimiento Usuario" BackColor="#F4FEE0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 55px;" colspan="3"></td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; width: 313px; height: 29px;">
                <asp:Label ID="Label2" runat="server" Text="Nombre de Usuario" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">
                <asp:TextBox ID="txtNombreU" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">
                <asp:Button ID="BtnBuscar" runat="server" BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  Text="Buscar" Width="104px" OnClick="BtnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 29px;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; width: 313px; height: 29px;">
                <asp:Label ID="Label3" runat="server" Text="Nombre Completo" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">
                <asp:TextBox ID="txtNombreC" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">
                <asp:Button ID="BtnLimpiar" runat="server" BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  Text="Limpiar" Width="104px" OnClick="BtnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 29px;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; width: 313px; height: 29px;">
                <asp:Label ID="Label4" runat="server" Text="Contraseña" Font-Names="Franklin Gothic Medium" Font-Size="Large" BackColor="#F4FEE0"></asp:Label>
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">
                <asp:TextBox ID="txtContraseña" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="30px" Width="215px" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 29px;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 29px;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; width: 313px; height: 29px;">&nbsp;</td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">
                <asp:Button ID="BtnAgregar" runat="server" BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  OnClick="BtnAgregar_Click" Text="Agregar" Width="83px" />
                <asp:Button ID="BtnModificar" runat="server" BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  OnClick="BtnModificar_Click" Text="Modificar" Width="83px" />
                <asp:Button ID="BtnBaja" runat="server" BackColor="#F7F7F7" BorderColor="Gray" BorderStyle="Solid" Font-Bold="True" Font-Italic="false" Font-Strikeout="False" ForeColor="Black" Height="30px"  OnClick="BtnBaja_Click" Text="Eliminar" Width="83px" />
            </td>
            <td style="background-color: #F4FEE0; height: 29px; width: 313px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 30px;" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 30px;" colspan="3">
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Style="font-family:Gadugi; font-size:15px;" BackColor="#F4FEE0" ForeColor="#FF5050"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color: #F4FEE0; height: 30px;" colspan="3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>


