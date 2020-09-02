<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InicioSesion.aspx.vb" Inherits="SistemaLogisticaFastTruck.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
    <title>Inicio de sesión</title>
</head>
<body>
    <form id="Form_InicioSesion" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-4 col-xl-4"></div>
                <div class="col-sm-12 col-md-12 col-lg-4 col-xl-4">
                    <div class="display-3">Iniciar Sesión</div><br /><br />

                    <asp:Label ID="Lb_NombreUsuario" runat="server" Text="Nombre de usuario:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_NombreUsuario" runat="server" required></asp:TextBox><br />
  
                    <asp:Label ID="Lb_Password" runat="server" Text="Contraseña:"></asp:Label><br />
                    <input class="form-control" id="Imp_Password" type="password" runat="server" required/><br />

                    <asp:Button class="btn btn-dark btn-block btn-lg" ID="Btn_Ingresar" runat="server" Text="Ingresar" /><br />
                    <asp:Label style="color:#E12A2A; font-weight:bold; font-size:18px" ID="Lb_InfoAlUsuario" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-0 col-md-0 col-lg-4 col-xl-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
