<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSPES.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar sesión</title>
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
    .fondo{
      background-image: url("Imagenes/images.jpg");
      background-repeat: no-repeat;
      background-size: 100% 200%; 
    }
  </style>

</head>
<body class="fondo"> 
    <form id="form1" runat="server">
        <div class="row">
            <br />
            <br />
            <br />
            <div class="col-md-4 col-md-offset-4 text-center">
                <div class="panel-default">
                    <div class="panel-heading">
                        <h1 class="page-header">Iniciar sesión
                        </h1>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Label ID="LMensaje" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox ID="TUsuario" CssClass="form-control" runat="server" required="true" pattern="[A-Z a-z]*" title="Sólo se aceptan letras"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox ID="TContrasenia" TextMode="Password" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BIniciarSesion" runat="server" CssClass="btn btn-info btn-block" Text="Iniciar sesión" OnClick="BIniciarSesion_Click" />
                        </div>
                    </div>
                    <div class="panel-footer">
                       <br />
                      <br />
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
