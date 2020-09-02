<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportesEnvios.aspx.vb" Inherits="SistemaLogisticaFastTruck.ReportesEnvios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Estilos/Bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="Estilos/css/EstilosCss.css"/>
    <title>Reportes envíos</title>
</head>
<body>
    <div class="container display-3" style="text-align:center">Reportes de envíos</div><br /><br /><br /><br />
    <div class="container">
            <div class="row">
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"></div>
                <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6">
                    <form id="Form_ReportesEnvios" runat="server">

                        <asp:Label style="font-weight:bold" ID="Lb_Filtro" runat="server" Text="Podés filtrar por:"></asp:Label><br /><br />
                        <asp:Label ID="Lb_Clientes" runat="server" Text="Clientes:"></asp:Label><br />
                        <asp:DropDownList class="form-control" ID="DrpDw_Clientes" runat="server"></asp:DropDownList>
                        <asp:Label ID="Lb_Provincias" runat="server" Text="Provincias:"></asp:Label><br />
                        <asp:DropDownList class="form-control" ID="DrpDw_Provincias" AutoPostBack="true" runat="server"></asp:DropDownList>
                        <asp:Label ID="Lb_Ciudades" runat="server" Text="Ciudades:"></asp:Label><br />
                        <asp:DropDownList class="form-control" ID="DrpDw_Ciudades" runat="server"></asp:DropDownList>
                        <asp:Label ID="Lb_Choferes" runat="server" Text="Choferes:"></asp:Label><br />
                        <asp:DropDownList class="form-control" ID="DrpDw_Choferes" runat="server"></asp:DropDownList>
                        <asp:Label ID="Lb_Camiones" runat="server" Text="Camiones"></asp:Label><br />
                        <asp:DropDownList class="form-control" ID="DrpDw_Camiones" runat="server"></asp:DropDownList>
                        <asp:Label ID="Lb_EstadoEntrega" runat="server" Text="Estado entrega:"></asp:Label><br />
                        <asp:DropDownList class="form-control" ID="DrpDw_EstadoEntrega" runat="server"></asp:DropDownList><br /><br />

                        <asp:Label style="font-weight:bold" ID="Lb_FiltroFechas" runat="server" Text="Podés establecer un rango de fechas"></asp:Label><br /><br />
                        <asp:Label ID="Lb_Fecha1" runat="server" Text="Fecha inicial:"></asp:Label>
                        <input id="Fecha1" type="date" runat="server"/>

                        <asp:Label ID="Lb_Fecha2" runat="server" Text="Fecha final:"></asp:Label>
                        <input id="Fecha2" type="date" runat="server"/><br /><br />

                        <asp:Button class="btn btn-dark" ID="Btn_SolicitarReporte" runat="server" Text="Solicitar reporte" />
                        <asp:Button class="btn btn-dark" ID="Btn_LimpiarFiltros" runat="server" Text="Limpiar filtros" />
                        <asp:Button class="btn btn-dark" style="float:right" ID="Btn_Volver" runat="server" Text="Volver" />
                        
                    </form>
                </div>
                <div class="col-sm-0 col-md-0 col-lg-3 col-xl-3"></div>
            </div>
        <br /><br /><br />

        <asp:Repeater ID="Rpt_ReporteEnvio" runat="server">
                    <HeaderTemplate>
                        <table style="font-size:13px">
                            <tr>
                                <th>Detelle envío</th>
                                <th>Información lugar de entrega</th>
                                <th >Información cliente</th>                              
                                <th >Datos camión</th>
                                <th >Datos chofer</th>
                                <th >Estado entrega</th>
                                <th>Fecha y hora del Envio</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.DataItem("detalle")%></td>
                            <td><%#Container.DataItem("direccion")%>, <%#Container.DataItem("nombreCiudad")%>, 
                                <%#Container.DataItem("nombreProvincia")%></td>
                                                 
                            <td><%#Container.DataItem("nombre")%>, <%#Container.DataItem("apellido")%></td>
                            
                            <td><%#Container.DataItem("patente")%>, <%#Container.DataItem("modelo")%></td> 
                            <td><%#Container.DataItem("nombreChofer")%>, <%#Container.DataItem("apellidoChofer")%></td>
                            <td><%#Container.DataItem("confirmacionEntrega")%></td>

                            <td><%#Container.DataItem("fechaEnvio")%></td>
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            
                        </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
        </div>
</body>
</html>
