<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SSPES.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <title>SSPES</title>
    <link rel="shortcut icon" href="Imagenes/SSPES.png" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="keywords" />
    <meta content="" name="description" />

    <%--<meta property="og:title" content="" />
    <meta property="og:image" content="" />
    <meta property="og:url" content="" />
    <meta property="og:site_name" content="" />
    <meta property="og:description" content="" />--%>

    <meta name="twitter:card" content="summary" />
    <meta name="twitter:site" content="" />
    <meta name="twitter:title" content="" />
    <meta name="twitter:description" content="" />
    <meta name="twitter:image" content="" />

    <link href="favicon.ico" rel="shortcut icon" />

    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Raleway:300,400,500,700,800" rel="stylesheet" />
    <link href="public/Inicio/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="public/Inicio/lib/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="public/Inicio/lib/animate-css/animate.min.css" rel="stylesheet" />
    <link href="public/Inicio/css/style.css" rel="stylesheet" />
</head>
<body>
    <div id="preloader"></div>
    <header id="header">
        <div class="container">
            <div id="logo" class="pull-left">
                <h1>SSPES</h1>
            </div>

            <nav id="nav-menu-container">
                <ul class="nav-menu">
                    <li class="menu-active"><a href="#hero">Inicio</a></li>
                    <li><a href="#about">A cerca de</a></li>
                    <li><a href="#services">Servicios</a></li>
                    <li><a href="#team">Equipo</a></li>
                    <li><a href="#contact">Contacto</a></li>
                    <li><a href="Login.aspx">Ingresar</a></li>
                </ul>
            </nav>
        </div>
    </header>
    <!--==========================
      Hero Section
    ============================-->
    <section id="hero">
        <div class="hero-container">
            <div class="wow fadeIn">
                <div class="row">
                    <div class="col-lg-4"></div>
                    <div class="col-lg-4">
                        <img src="Imagenes/SSPES.png" class="img-responsive" />
                        <h2>Plataforma <span class="rotating">Segura,Practica,Innovadora</span></h2>
                        <div class="actions">
                            <a href="Login.aspx" class="btn-services">Ingresar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <!--==========================
  About Section
============================-->
    <section id="about">
        <div class="container wow fadeInUp">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="section-title">a cerca de </h3>
                    <div class="section-title-divider"></div>
                    <h4 class="section-description">Software para la sistematización en los drocesos de estudios de suelos </h4>
                </div>
            </div>
        </div>
        <div class="container about-container wow fadeInUp">
            <div class="row">
                <div class="col-md-6 about-content">
                    <img src="public/Inicio/img/SSPES.png" class="img-responsive" />
                </div>
                <div class="col-md-6 about-content">
                    <h2 class="about-title section-description">Sobre que trata el software</h2>
                    <h4 class="about-text">
                        SSPES es una idea innovadora desarrollada por tres estudiantes de la Univerdad de la Amazonia, y es pensada para los investigadores dedicados a la captura de datos cuantitavos que desarrollan investigaciones en gran escala, esta plataforma permite la gestión de la información de los proyectos de investigación. 
                    </h4>
                    <h4 class="about-text">
                        Así mismo el director de las investigaciones podrá asociar investigadores a cada uno de sus proyectos, en este sentido les otorgará permisos para contribuir en el registro de nuevas muestra a sus proyectos en tiempo real.                                                                                         
                    </h4>
                    <h4 class="about-text">
                        A futuro se busca que el aplicativo web le permita al director la gestion de actividades por proyecto y de igual manera un procesamiento matématico de los datos una vez haya finalizado el proceso de recolección en cada proyecto.
                    </h4>
                </div>
            </div>
        </div>
    </section>

    <!--==========================
  Services Section
============================-->
    <section id="services">
        <div class="container wow fadeInUp">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="section-title">Servicios</h3>
                    <div class="section-title-divider"></div>
                    <h4 class="section-description">Estos son los servicios que brinda el aplicativo web</h4>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 service-item">
                    <div class="service-icon"><i class="fa fa-desktop"></i></div>
                    <h4 class="service-title"><a>Gestión de información</a></h4>
                    <h4 class="service-description">La plataforma de forma segura permite administrar contenidos asociados a un proyecto de investigación en tiempo real.</h4>
                </div>
                <div class="col-md-4 service-item">
                    <div class="service-icon"><i class="fa fa-bar-chart"></i></div>
                    <h4 class="service-title"><a>Trazabilidad</a></h4>
                    <h4 class="service-description">La plataforma llevará un registro minucioso de cada proyecto, evaluando constantemente el estado en el cúal se encuentra.</h4>
                 </div>
                <div class="col-md-4 service-item">
                    <div class="service-icon"><i class="fa fa fa-database"></i></div>
                    <h4 class="service-title"><a>Seguridad en información</a></h4>
                    <h4 class="service-description">La plataforma cuanta con altos estadares de seguridad, debido a la sencibilidad de la información tratada.</h4>
                </div>
            </div>
        </div>
    </section>

    <!--==========================
  Subscrbe Section
============================-->
    <section id="subscribe">
        <div class="container wow fadeInUp">
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-md-8 ">
                    <h3 class="subscribe-title">Adquierelo Ya!</h3>
                    <p class="subscribe-text">Cientos de investigadores al rededor del mundo lo usan  <br />¿ Qué esperas ?</p>
                </div>
                <div class="col-lg-4"></div>

                <div class="col-md-4 subscribe-btn-container">
                    <a class="subscribe-btn" href="#contact">Contactar</a>
                </div>
            </div>
        </div>
    </section>
    <!--==========================
      Team Section
    ============================-->
    <section id="team">
        <div class="container wow fadeInUp">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="section-title">Equipo de Trabajo</h3>
                    <div class="section-title-divider"></div>
                    <p class="section-description">La plataforma esta desarrollada por Ingenieros de sistemas de la Universidad de la Amazonia</p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="member">
                        <div class="pic">
                            <img src="public/Inicio/img/team-1.jpg" alt="" />
                        </div>
                        <h4>Manuel Hernandez</h4>
                        <span>Desarrollador Software</span>
                        <div class="social">
                            <a href=" https://www.facebook.com/manuel.hernandz.5" target="_blank"><i class="fa fa-facebook"></i></a>
                            <a href="https://github.com/manuelstuner" target="_blank"><i class="fa fa-github"></i></a>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="member">
                        <div class="pic">
                            <img src="public/Inicio/img/team-2.jpg" alt="" />
                        </div>
                        <h4>Valentina Rios</h4>
                        <span>Desarrolladora Software</span>
                        <div class="social">
                            <a href="https://www.facebook.com/juanavalentina.serna" target="_blank"><i class="fa fa-facebook"></i></a>
                            <a href="https://github.com/ValentinaRiA" target="_blank"><i class="fa fa-github"></i></a>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="member">
                        <div class="pic">
                            <img src="public/Inicio/img/team-3.jpg" alt="" />
                        </div>
                        <h4>Wilmer Castrillon</h4>
                        <span>Desarrollador Software</span>
                        <div class="social">

                            <a href="https://www.facebook.com/wilmeremiro.castrilloncalderon" target="_blank"><i class="fa fa-facebook"></i></a>
                            <a href="https://github.com/wilmercastrillon" target="_blank"><i class="fa fa-github"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!--==========================
  Contact Section
============================-->
    <section id="contact">
        <div class="container wow fadeInUp">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="section-title">Contactanos</h3>
                    <div class="section-title-divider"></div>
                    <p class="section-description">Si quieres hacer uso de esta plataforma innovadora, simplemente envianos tu información</p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 col-md-push-2">
                    <div class="info">
                        <div>
                            <i class="fa fa-map-marker"></i>
                            <p>
                                Campus Porvenir Uniamazonia
                                <br />
                                Florencia - Caquetá
                            </p>
                        </div>

                        <div>
                            <i class="fa fa-envelope"></i>
                            <p>programacion@udla.edu.co</p>
                        </div>

                        <div>
                            <i class="fa fa-phone"></i>
                            <p>+57 321-266-37702</p>
                        </div>

                    </div>
                </div>

                <div class="col-md-5 col-md-push-2">
                    <div class="form">
                        <div id="sendmessage">Your message has been sent. Thank you!</div>
                        <div id="errormessage"></div>
                        <form action="" method="post" role="form" class="contactForm">
                            <div class="form-group">
                                <input type="text" name="name" class="form-control" id="name" placeholder="Su Nombre" data-rule="minlen:4" data-msg="Please enter at least 4 chars" />
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <input type="email" class="form-control" name="email" id="email" placeholder="Su Correo" data-rule="email" data-msg="Please enter a valid email" />
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <input type="number" class="form-control" name="telefono" id="telefono" placeholder="Telefono" data-rule="minlen:4" data-msg="Please enter at least 8 chars of subject" />
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <textarea class="form-control" name="message" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="Mensaje"></textarea>
                                <div class="validation"></div>
                            </div>
                            <div class="text-center">
                                <button type="submit">Enviar Mensaje</button>
                            </div>
                        </form>
                    </div>
                </div>

            </div>
        </div>
    </section>

    <!--==========================
  Footer
============================-->
    <footer id="footer">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="copyright">
                        &copy; Copyright <strong>Universidad de la Amazonia</strong>. Derechos Reservados
                    </div>
                    <div class="credits">
                        <a href="https://uniamazonia.edu.co/">Uniamazoia</a>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!-- #footer -->

    <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>

    <!-- Required JavaScript Libraries -->
    <script src="public/Inicio/lib/jquery/jquery.min.js"></script>
    <script src="public/Inicio/lib/bootstrap/js/bootstrap.min.js"></script>
    <script src="public/Inicio/lib/superfish/hoverIntent.js"></script>
    <script src="public/Inicio/lib/superfish/superfish.min.js"></script>
    <script src="public/Inicio/lib/morphext/morphext.min.js"></script>
    <script src="public/Inicio/lib/wow/wow.min.js"></script>
    <script src="public/Inicio/lib/stickyjs/sticky.js"></script>
    <script src="public/Inicio/lib/easing/easing.js"></script>

    <!-- Template Specisifc Custom Javascript File -->
    <script src="public/Inicio/js/custom.js"></script>

    <script src="public/Inicio/contactform/contactform.js"></script>

</body>
</html>
