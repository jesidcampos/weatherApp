<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosClimaticos.aspx.cs" Inherits="weatherApp.DatosClimaticos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión Datos Climáticos</title>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery-ui.js"></script>

    <!-- Versión compilada y comprimida del CSS de Bootstrap -->
    <link rel="stylesheet" href="Styles/bootstrap.min.css"/>
 
    <!-- Tema opcional -->
    <link rel="stylesheet" href="Styles/bootstrap-theme.min.css"/>
 
    <!-- Versión compilada y comprimida del JavaScript de Bootstrap -->
    <script src="Scripts/bootstrap.min.js"></script>

    <link href="Styles/Style.css" rel="stylesheet" />

    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31 &&
              (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="margin-top: 50px">
            <div class="row">
                <div class="col-lg-2 text-center">
                    <img alt="" src="Imagenes/Clima.png" style="height: 180px; width: 244px" />
                </div>
                <div class="col-lg-1 text-center">
                </div>
                <div class="col-lg-7">
                    <div class="panel panel-default">
                        <div class="text-center panel-heading-background" style="border-radius: 5px">
                            Datos Climáticos
                        </div>
                        <div class="panel-body" id="Crear" >
                            <div class="row">
                                <div class="col-lg-5" style="font-weight: bold;">
                                    <label for="Temperatura">Temperatura:</label>
                                </div>
                                <div class="col-lg-2 text-center">
                                </div>
                                 <div class="col-lg-5" style="font-weight: bold;">
                                    <label for="Precipita">Precipitación:</label>
                                </div>
                                
                            </div>

                            <div class="row">
                               <div class="col-lg-5">
                                    <input type="text" class="form-control" id="txtTemperatura" runat="server" onkeypress="return isNumberKey(event)"/>
                                </div>
                                <div class="col-lg-2 text-center">
                                    <asp:Label ID="lblidClima" runat="server" Text="" ForeColor="White"></asp:Label>
                                </div>
                                <div class="col-lg-5">
                                    <input type="text" class="form-control" id="txtPrecipita" runat="server" onkeypress="return isNumberKey(event)"/>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-5" style="font-weight: bold;">
                                    <label for="humedad">Humedad:</label>
                                </div>
                                <div class="col-lg-2 text-center">
                                </div>
                                <div class="col-lg-5" style="font-weight: bold;">
                                    <label for="velocidad">Velocidad del Viento:</label>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-lg-5">
                                    <input type="text" class="form-control" id="txthumedad" runat="server" onkeypress="return isNumberKey(event)"/>
                                </div>
                                <div class="col-lg-2 text-center">
                                </div>
                                <div class="col-lg-5">
                                    <input type="text" class="form-control" id="txtvelocidad" runat="server" onkeypress="return isNumberKey(event)"/>
                                </div>
                            </div>
                                    
                        </div>
                    </div>
                </div>
                <div class="col-lg-1 text-center">
                    <div>
                        <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" class="btn btn-success" OnClick="BtnIngresar_Click" style="padding-top: 5px;"/>
                    </div>
                    <br />
                    <div>
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" class="btn btn-info" OnClick="BtnModificar_Click" style="padding-top: 5px;"/>
                    </div>
                    <br />
                    <div>(
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClientClick="return confirm('y/n')" 
                            style="padding-top: 5px;" OnClick="BtnEliminar_Click"/>
                    </div>
                    <br />
                    <asp:Button ID="BtnSalir" runat="server" Text="Salir" class="btn btn-warning" OnClick="BtnSalir_Click" style="padding-top: 5px;"/>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="gvDatpsClimaticos" runat="server" CssClass="table" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvDatpsClimaticos_SelectedIndexChanged" 
                    AutoGenerateSelectButton="true">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
