<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SitioWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Página de Menú</title>

    <%--Formato de Boostrap--%>
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
            <h1 class="bg-info p-3 text-center">Clínica El Buen Vivir</h1>
            <hr />
            <br />
        </div>

        <div class="container"> <%--botones--%>
           
            <div class="row justify-content-center mt-5">  <%--Primer botón--%> 
                <div class="col-auto">
                    <asp:Button ID="btnPacientes" runat="server" Text="Pacientes" Width="285px" class="btn btn-outline-secondary" OnClick="btnPacientes_Click" />
                </div>
            </div>

            <div class="row justify-content-center mt-3"> <%--Segundo botón --%> 
                <div class="col-auto">
                    <asp:Button ID="btnDoctores" runat="server" Text="Médicos" Width="285px" class="btn btn-outline-secondary" OnClick="btnDoctores_Click" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
