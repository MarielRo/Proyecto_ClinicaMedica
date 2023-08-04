<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPagos.aspx.cs" Inherits="SitioWeb.FrmPagos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title> <%--Boostrap--%>
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
       <div class="container center-container" >
            <div>
                <h1 class="bg-info p-3 text-center"">Pagos</h1>
                <hr />
                <br />
                <br />
            </div>

            <div class="row">

                 <div class="col-4">
                    <asp:Label ID="lblPagos" runat="server" Text="Id Historial :"></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtPagos" runat="server"
                        ReadOnly="True" Width="167px" Enabled="False"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:Label ID="lblId" runat="server" Text="Id Paciente :"></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtId" runat="server"
                        ReadOnly="True" Width="167px" Enabled="False"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--nombre--%>Nombre:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtNombre" runat="server" Width="400px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--Apellido--%>Apellido:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtApellido" runat="server" Width="400px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--fecha--%>Fecha:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtFecha" runat="server" Height="25px" Width="400px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--monto--%>Monto:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtMonto" runat="server" Height="24px" Width="395px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--detalle--%>Detalle:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtDetalle" runat="server" Height="66px" Width="395px"></asp:TextBox>
                </div>
                <br />
                
            </div>
            <!--fin row-->

        </div>
        <%--Fin de container--%>

        <div class="container"> <%--botones agregar,cancelar--%>
            <div class="d-flex justify-content-center mt-5">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success " OnClick="btnGuardar_Click" /> 
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click"  />
            </div>
        </div> <%--fin container de botones--%>
       
    </form>
</body>
</html>

