<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AltaChofer.aspx.vb" Inherits="SistemaLogisticaFastTruck.AltaChofer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="container">

        <form id="Form_AltaChofer" runat="server">
        <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>             

                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <asp:Label ID="Lb_NombreChofer" runat="server" Text="Nombre chofer:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_NombreChofer" ValidationGroup="alta" runat="server"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="alta" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_NombreChofer"></asp:RequiredFieldValidator>
                    <asp:Label ID="Lb_ApellidoChofer" runat="server" Text="Apellido chofer:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_ApellidoChofer" ValidationGroup="alta" runat="server"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="alta" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_ApellidoChofer"></asp:RequiredFieldValidator>
                    <asp:Label ID="Lb_DniChofer" runat="server" Text="Dni chofer:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_DniChofer" ValidationGroup="alta" runat="server"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="alta" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_DniChofer"></asp:RequiredFieldValidator>
                    
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarChofer" ValidationGroup="alta" runat="server" Text="Agregar chofer" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>

                
            </div>
    </form>

    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="Estilos/Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
