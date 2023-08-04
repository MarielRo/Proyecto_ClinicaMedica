<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPaciente.aspx.cs" Inherits="SitioWeb.FrmPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de visualización de Pacientes</title>

    <%--Boostrap--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>

    <style>
        #form2 {
            margin: 10px auto;
            width: 70%;
        }
    </style>
    <script type="text/javascript">
        function mostrarMensaje(mensaje) {
            alert(mensaje);
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container center-container">
            <%--título--%>
            <h1 class="bg-info p-3 text-center"> Pacientes </h1>
            <hr />
            <br />
        </div>
        <div class="container center-container">
            Nombre del Paciente : <asp:TextBox ID="txtNombre" runat="server" Width="385px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-secondary btn-sm" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-secondary btn-sm" OnClick="btnAgregar_Click" />
        </div>
        <%--espacios--%>
        <br /> 
        <br />

        <div class="container center-container">
            <%--datagridview--%>
        <asp:GridView ID="grdPaciente" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No existen registros para mostrar" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdPaciente_PageIndexChanging" PageSize="5" Width="90%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" />
                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Eliminar" OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Modificar" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkHistorial" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Historial" OnCommand="lnkHistorial_Command">Historial</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkCitas" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Citas" OnCommand="lnkCitas_Command">Citas</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPagos" runat="server" CommandArgument='<%# Eval("ID_PACIENTE").ToString() %>' CommandName="Pagos" OnCommand="lnkPagos_Command">Pagos</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>



        <div class="container"> <%--botones agregar,cancelar--%>
            <div class="d-flex justify-content-center mt-5"> 
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar al Inicio" class="btn btn-info" OnClick="btnRegresar_Click" /> <%--ml-2 para separar botones entre si pero no me funciona--%>
            </div>
        </div> <%--fin container de botones--%>

    </form>
</body>

</html>
