<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="weatherApp.Access" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Clima</title>

    <script src="Scripts/jquery.min.js"></script>

    <!-- Versión compilada y comprimida del CSS de Bootstrap -->
    <link rel="stylesheet" href="Styles/bootstrap.min.css">

    <!-- Tema opcional -->
    <link rel="stylesheet" href="Styles/bootstrap-theme.min.css">

    <!-- Versión compilada y comprimida del JavaScript de Bootstrap -->
    <script src="Scripts/bootstrap.min.js"></script>

    <link href="Styles/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="margin-top: 50px">
            <div class="row">
                <div class="col-lg-4">
                    <div class="panel panel-default">
                        <div class="text-center panel-heading-background" style="color: white;">
                            Datos Climáticos
                        </div>
                        <div class="panel-body">
                            <asp:Image ID="Image2" runat="server" Height="249px"
                                ImageUrl="~/Imagenes/Clima.png" Width="320px"
                                Style="text-align: center" />
                            <div class="row separador" style="height: 18px;">
                                <asp:Label ID="LblError" runat="server"></asp:Label>
                            </div>

                            <div class="row" style="padding: 5px;">
                                <div class="col-lg-4">
                                    Email:
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="usuario@proveedor.xxx"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row" style="padding: 5px;">
                                <div class="col-lg-4">
                                    Contraseña:
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="padding: 5px;">
                                <div class="col-lg-4">
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-warning" CommandName="Login"
                                        OnClick="LoginButton_Click" Text="Ingresar" ValidationGroup="Login1" Font-Bold="True" />
                                </div>
                            </div>
                            <div class="row separador" style="height: 18px;">
                                <div class="col-lg-2">
                                </div>
                                <div class="col-lg-5">
                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CambiarContrasena.aspx" Style="color: white; font-weight: bold;">
                                        Cambiar Contraseña
                                    </asp:HyperLink>--%>
                                </div>
                                <div class="col-lg-5">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        <div class="text-center panel-heading-background" style="color: white;">
                            Datos flash!!!
                        </div>
                        <div class="panel-body panel_Body_App">
                            <asp:Image ID="Image1" runat="server" Height="170px"
                                ImageUrl="~/Imagenes/flash.png" Width="720px"
                                Style="text-align: center" />
                        </div>

                    </div>

                </div>
                <div class="row">
                    <div class="col-lg-7">
                        <div class="panel panel-default">
                            <div class="text-center panel-heading-background" style="color: white;">
                                Datos históricos
                            </div>
                            <div class="panel-body">
                                <asp:Image ID="Image3" runat="server" Height="249px"
                                ImageUrl="~/Imagenes/historia.png" Width="700px"
                                Style="text-align: center" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
