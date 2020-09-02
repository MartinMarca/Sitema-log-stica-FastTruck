<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AltaCiudad.aspx.vb" Inherits="SistemaLogisticaFastTruck.AltaCiudad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="container">
        <form id="Form_AltaCiudad" runat="server">
            <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>             

                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <asp:Label ID="Lb_Ciudad" runat="server" Text="Ciudad:"></asp:Label><br />
                    <asp:TextBox class="form-control" ID="Txt_Ciudad" ValidationGroup="alta" runat="server"></asp:TextBox><br /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="alta" runat="server" ErrorMessage="requerido" ControlToValidate="Txt_Ciudad"></asp:RequiredFieldValidator>
                    <asp:DropDownList class="form-control" ID="DrpDw_Provincias" runat="server"></asp:DropDownList>
                    <asp:Label ID="Lb_InfoProvincia" runat="server" Text="La provincia no se encuentra en la lista?"></asp:Label><br /><br />
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarProvincia" runat="server" Text="Agregar nueva provincia" /><br />
                    
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarCiudad" ValidationGroup="alta" runat="server" Text="Agregar ciudad" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>

                
            </div>
        </form>
    </div>
     <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
