<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmNuevo_Paciente.aspx.cs" Inherits="SitioWeb.FrmNuevo_Paciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mantenimiento de Clientes</title>
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
       <div class="container center-container" >
            <div>
                <h1 class="bg-info p-3 text-center"">Mantenimiento de Pacientes</h1>
                <hr />
                <br />
                <br />
            </div>

            <div class="row">

                <div class="col-4">
                    <asp:Label ID="lblId" runat="server" Text="Id :"></asp:Label>
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
                    <%--teléfono--%>Teléfono:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="400px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--direccion--%>Dirección:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="400px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <%--email--%>Email:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
                </div>
            </div>
            <!--fin row-->

        </div>
        <%--Fin de container--%>

        <div class="container"> <%--botones agregar,cancelar--%>
            <div class="d-flex justify-content-center mt-5">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success mr-2" OnClick="btnGuardar_Click" /> 
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click" /> <%--ml-2 para separar botones entre si pero no me funciona--%>
                <asp:Button ID="btnHistorial" runat="server" Text="Agregar Diagnostico"  class="btn btn-info" OnClick="btnHistorial_Click" />
                <asp:Button ID="btnCitas" runat="server" Text="Citas"   class="btn btn-secondary" OnClick="btnCitas_Click" />
                <asp:Button ID="btnPagos" runat="server" Text="Pagos"  class="btn btn-primary" OnClick="btnPagos_Click" />
            </div>
        </div> <%--fin container de botones--%>
       
    </form>
</body>
</html>
