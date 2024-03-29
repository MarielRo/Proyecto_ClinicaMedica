﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmHistorial_Medico.aspx.cs" Inherits="SitioWeb.FrmHistorial_Medico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Historial Médico de los Pacientes</title>
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
                <h1 class="bg-info p-3 text-center"">Historial de Pacientes</h1>
                <hr />
                <br />
                <br />
            </div>

            <div class="row">

                 <div class="col-4">
                    <asp:Label ID="lblHistorial" runat="server" Text="Id Historial :"></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtIdHistorial" runat="server"
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
                    <%--teléfono--%>Diagnosticos:
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtDiagnosticos" runat="server" Height="90px" Width="795px"></asp:TextBox>
                </div>
            </div>
            <!--fin row-->

        </div>
        <%--Fin de container--%>

        <div class="container"> <%--botones agregar,cancelar--%>
            <div class="d-flex justify-content-center mt-5">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success " OnClick="btnGuardar_Click"  /> 
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click" /> <%--ml-2 para separar botones entre si pero no me funciona--%>
            </div>
        </div> <%--fin container de botones--%>
       
    </form>
</body>
</html>
