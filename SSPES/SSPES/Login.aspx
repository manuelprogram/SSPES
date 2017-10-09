<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSPES.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SSPES</title>
    <link rel="shortcut icon" href="Imagenes/SSPES.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <link href="public/Admin/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="public/Admin/vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="public/Admin/dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="public/Admin/vendor/morrisjs/morris.css" rel="stylesheet" />
    <link href="public/Admin/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style>
        .fondo {
            background-image: url("Imagenes/nat.jpg");
            background-repeat: no-repeat;
            background-size: 110% 140%;
        }
    </style>

</head>
<body class="fondo">
    <form id="form1" runat="server">
        <div class="col-md-12 col-md-offset-0">
            <br />
            <br />
            <div class="col-md-4 col-md-offset-4 text-center">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <header>
                            <div style="color: forestgreen">
                                <img src="Imagenes/SSPES.png" width="150" height="130" />
                            </div>
                        </header>
                    </div>
                    <div class="panel-body">
                        <fieldset>
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox ID="TUsuario" CssClass="form-control" runat="server" required="true" pattern="[A-Z a-z 0-9 .]*" title="Formato no coincide"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label id="msj" runat="server">Contraseña</label>
                                <asp:TextBox ID="TContrasenia" TextMode="Password" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="BIniciarSesion" runat="server" CssClass="btn btn-success btn-block" Text="Iniciar sesión" OnClick="BIniciarSesion_Click" />
                            </div>

                        </fieldset>
                        <div class="row">
                            <div class="col-lg-4">
                                <a href="Default.aspx">¿Volver a inicio?</a>
                            </div>
                            <div class="col-lg-2"></div>
                            <div class="col-lg-6">
                                <a href="Default.aspx">¿Recordar contraseña?</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="public/Admin/vendor/jquery/jquery.min.js"></script>
        <script src="public/Admin/vendor/bootstrap/js/bootstrap.min.js"></script>
        <script src="public/Admin/vendor/metisMenu/metisMenu.min.js"></script>
        <script src="public/Admin/vendor/raphael/raphael.min.js"></script>
        <script src="public/Admin/vendor/morrisjs/morris.min.js"></script>
        <script src="public/Admin/data/morris-data.js"></script>
        <script src="public/Admin/dist/js/sb-admin-2.js"></script>
    </form>
</body>
</html>
