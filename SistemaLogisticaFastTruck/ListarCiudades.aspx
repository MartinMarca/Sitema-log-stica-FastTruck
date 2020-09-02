<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListarCiudades.aspx.vb" Inherits="SistemaLogisticaFastTruck.ListarCiudades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="Estilos/css/EstilosCss.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ciudades</title>
</head>
<body>
    <div class="container">
        <nav class="navbar bg-dark navbar-dark navbar-expand-lg container fuenteNavBar fixed-top">

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <a class="navbar-brand" href="Inicio.aspx">
                <img src="imagenes/logoNavBar.jpg" style="height: 60px" alt="logo"/>
            </a>

            <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
                <ul class="navbar-nav text-center mr-auto ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="Inicio.aspx">Inicio</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ListarPedidos.aspx">Pedidos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ListarEnvios.aspx">Envios</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ListarClientes.aspx">Clientes</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ListarChoferes.aspx">Choferes</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ListarCamiones.aspx">Camiones</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ListarProvincias.aspx">Provincias</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="ListarCiudades.aspx">Ciudades</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Reportes
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" href="ReportesPedidos.aspx">Pedidos</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="ReportesEnvios.aspx">Envíos</a>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    </div>

    <br /><br /><br />

    <div class="container display-1"> Ciudades
        <img style="width:250px" src="imagenes/iconoCiudades.png"/>
    </div>

    <div class="container">
        <form id="Form_ListarCiudades" runat="server">
            <div>
                <asp:Repeater ID="Rpt_Ciudad" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Ciudad</th>
                                <th>Provincia</th>                                 
                                <th>Acciones</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <tr>
                            <td><%#Container.DataItem("nombreCiudad")%></td>
                            <td><%#Container.DataItem("nombreProvincia")%></td>
                            
                                                        
                            <td><a class="btn btn-dark" role="button" href="Baja_ModificacionCiudad.aspx?idparametro=<%#Container.DataItem("idCiudad")%>">modificar</a>
                                <a class="btn btn-dark" role="button" href="Baja_ModificacionCiudad.aspx?idparametro=<%#Container.DataItem("idCiudad")%>">eliminar</a></td>
                            
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <tf></tf>
                        </tr>

                        </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>

        </form>
        <br />

        <div><a class="btn btn-dark btn-lg btn-block" role="button" href="AltaCiudad.aspx">Agregar una nueva ciudad</a></div>
        
        <br /><br />
    </div>
    
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="Estilos/Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
