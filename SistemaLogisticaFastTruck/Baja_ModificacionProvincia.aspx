<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baja_ModificacionProvincia.aspx.vb" Inherits="SistemaLogisticaFastTruck.Baja_ModificacionProvincia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <div class=" display-3">Modificar - Eliminar provincia</div><br /><br />
    <div class="container">
        <div class="row">
            <div class="col-sm- col-md-0 col-lg-3 col-xl-3"></div>
            <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                <form id="Form_Baja_Modificacion_Provincia" runat="server">
                    <asp:TextBox ID="Txt_id" ReadOnly="true" runat="server" style="display:none"></asp:TextBox><br />
                    <asp:Label ID="Lb_Provincia" runat="server" Text="Provincia:"></asp:Label><br />
                    <asp:DropDownList class="form-control" ID="DrpDw_Provincia" runat="server"></asp:DropDownList>

                    <asp:Button class="btn btn-dark" ID="Btn_ModificarProvincia" runat="server" Text="Modificar provincia" />
                    <asp:Button class="btn btn-dark" ID="Btn_Eliminar" runat="server" Text="Eliminar provincia" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </form>
            </div>
            <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"></div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="Estilos/Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
