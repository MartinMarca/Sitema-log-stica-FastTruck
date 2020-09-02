<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AltaProvincia.aspx.vb" Inherits="SistemaLogisticaFastTruck.AltaProvincia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="Form_AltaProvincia" runat="server">
        <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>
                

                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <asp:Label ID="Lb_Provincia" runat="server" Text="Provincia:"></asp:Label><br />
                    <asp:DropDownList class="form-control" ID="DrpDw_Provincia" runat="server"></asp:DropDownList>

                    
                    <asp:Button class="btn btn-dark" ID="Btn_AgregarProvincia" runat="server" Text="Agregar provincia" />
                    <asp:Button class="btn btn-dark" ID="Btn_Cancelar" runat="server" Text="Cancelar" />
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"> </div>

                
            </div>
    </form>

     <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
