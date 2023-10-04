<template>
<!--<head>
    <meta charset="utf-8" />
    <title>TU PERFIL</title>
    
    <link href="../registrosCSS/PerComprador.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/7c61ac1c1a.js" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>-->

<body style="background-color: #2A2A2A; ">
    <!--Navbar Inicio-->
    <header>
        <div class="navbar">
            <div class="logo">
                <img src="../../RECURSOS/LOGO NEGRO.png" />
            </div>
            <div class="button">
                <a style="font-family: 'Genera-grotesk-heavy'; text-decoration: none; color: #FFFCED; background-color: transparent; border: none;"
                   href="#">
                    Regresar

                </a>
            </div>
        </div>
    </header>
    <!--Navbar Fin-->
    <!--EDICIÓN DEL PERFIL INICIO-->
    <section>
        <div class="container light-style flex-grow-1 container-p-y">
            <h4 style="color: #BF9004;font-size:40px" class=" py-3 mb-4">
                Configura tu cuenta
            </h4>
            <div style="border-radius:30px" class="card overflow-hidden">
                <div class="row no-gutters row-bordered row-border-light">
                    <!--oPCIONES INICIO-->
                    <div class="col-md-3 pt-0">
                        <div class="list-group list-group-flush account-settings-links">
                            <a class="list-group-item list-group-item-action active" data-toggle="list"
                               href="#account-general">General</a>
                            <a class="list-group-item list-group-item-action" data-toggle="list"
                               href="#account-change-password">Cambiar contraseña</a>
                            <a class="list-group-item list-group-item-action" data-toggle="list"
                               href="#account-info">Datos de recibo</a>
                            <a class="list-group-item list-group-item-action" data-toggle="list"
                               href="#account-social-links">Social Media</a>

                            <a class="list-group-item list-group-item-action" data-toggle="list"
                               href="#account-notifications">Notificaciones</a>
                        </div>
                    </div>
                    <!--oPCIONES FIN-->

                    <div class="col-md-9">
                        <div class="tab-content">
                            <div class="tab-pane fade active show" id="account-general">
                                <!--FOTO DE PERFIL INICIO-->
                                <div class="card-body media align-items-center">
                                    <img src="../../RECURSOS/Patocuchillo.jpg" 
                                         class="d-block ui-w-80">

                                    <div class="media-body ml-4">
                                        <label style="border-color: #2A2A2A; background: #BF9004 " class="btn btn-outline">

                                            Cambia tu foto
                                            <input type="file" class="account-settings-fileinput">
                                        </label> &nbsp;

                                        <div class="text-light small mt-1">Permite archivos JPG y PNG</div>
                                    </div>
                                </div>
                                <!--FOTO DE PERFIL FIN-->
                                <hr class="border-light m-0">
                                <!--GENERAL INICIO-->
                                <div class="card-body">
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Usuario Empresa</label>
                                        <input type="text" class="form-control mb-1" value="Llajuas">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Nombre de la Empresa</label>
                                        <input type="text" class="form-control" value="Alejandra">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">E-mail de la empresa</label>
                                        <input type="text" class="form-control mb-1" value="alejandraapazacor@gmail.com">
                                        <div style="background:#F0E6DA; border:none;" class="alert alert-warning mt-3">
                                            Tu email no esta confirmado, por favor revisa tus mensajes.<br>
                                            <a style="color:#BF9004" href="javascript:void(0)">Reenviar confirmación</a>
                                        </div>
                                    </div>
                                    <h6 style="font-family:'Genera Grotesk';color:#2A2A2A; font-size:25px" class="mb-4">Empleados</h6>
                                    <h6 style="font-family:'Genera Grotesk';color:#2A2A2A; font-size:18px" class="mb-4">Empleado 1</h6>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Nombre</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Apellidos</label>
                                        <input type="text" class="form-control" value="">
                                    </div>

                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Fecha de cumpleaños</label>
                                        <input type="date" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">NIT</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Celular</label>
                                        <input type="text" class="form-control" value="">
                                    </div>


                                    <h6 style="font-family:'Genera Grotesk';color:#2A2A2A; font-size:18px" class="mb-4">Empleado 2</h6>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Nombre</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Apellidos</label>
                                        <input type="text" class="form-control" value="">
                                    </div>

                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Fecha de cumpleaños</label>
                                        <input type="date" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">NIT(</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Celular</label>
                                        <input type="text" class="form-control" value="">
                                    </div>


                                    <h6 style="font-family:'Genera Grotesk';color:#2A2A2A; font-size:18px" class="mb-4">Empleado 3</h6>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Nombre</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Apellidos</label>
                                        <input type="text" class="form-control" value="">
                                    </div>

                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Fecha de cumpleaños</label>
                                        <input type="date" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">NIT</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Celular</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                </div>
                                <!--GENERAL FIN-->
                            </div>
                            <!--CAMBIAR DE CONTRASEÑÁ INICIO-->
                            <div class="tab-pane fade" id="account-change-password">
                                <div class="card-body pb-2">
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Contraseña actual</label>
                                        <input type="password" class="form-control">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Nueva contraseña</label>
                                        <input type="password" class="form-control">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Repetir contraseña</label>
                                        <input type="password" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <!--CAMBIAR DE CONTRASEÑÁ FIN-->
                            <!--DATOS DE RECIBO INICIO-->
                            <div class="tab-pane fade" id="account-info">
                                <div class="card-body pb-2">
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">NIT de la empresa (Opcional)</label>
                                        <input type="text" class="form-control" value="">
                                    </div>

                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Dirección</label>
                                        <input type="text" class="form-control" value="">
                                    </div>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Departamento</label>
                                        <select class="custom-select">
                                            <option selected>La Paz</option>
                                            <option>Cochabamba</option>
                                            <option>Santa Cruz</option>
                                            <option>Oruro</option>
                                            <option>Potosí</option>
                                            <option>Chuquisaca</option>
                                            <option>Tarija</option>
                                            <option>Beni</option>
                                            <option>Pando</option>
                                        </select>
                                    </div>
                                </div>
                                <hr class="border-light m-0">
                                <div class="card-body pb-2">
                                    <h6 style="font-family:'Genera Grotesk';color:#2A2A2A; font-size:25px" class="mb-4">Contactos</h6>
                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Celular</label>
                                        <input type="text" class="form-control" value="+591 60577712">
                                    </div>

                                </div>
                            </div>
                            <!--DATOS DE RECIBO FIN-->
                            <!--REDES SOCIALES INICIO -->
                            <div class="tab-pane fade" id="account-social-links">
                                <div class="card-body pb-2">

                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Facebook</label>
                                        <input type="text" class="form-control" value="https://www.facebook.com/user">
                                    </div>

                                    <div class="form-group">
                                        <label style="font-family:'Genera Grotesk';color:#BF9004" class="form-label">Instagram</label>
                                        <input type="text" class="form-control" value="https://www.instagram.com/user">
                                    </div>
                                </div>
                            </div>
                            <!--REDES SOCIALES FIN-->
                            <!--NOTIFICACIONES INICIO-->
                            <div class="tab-pane fade" id="account-notifications">
                                <div class="card-body pb-2">
                                    <h6 style="font-family:'Genera Grotesk';color:#BF9004" class="mb-4">Actividad</h6>
                                    <div class="form-group">
                                        <label class="switcher">
                                            <input type="checkbox" class="switcher-input " checked>
                                            <span class="switcher-indicator">
                                                <span class="switcher-yes"></span>
                                                <span class="switcher-no"></span>
                                            </span>
                                            <span class="switcher-label">Mándame un email cuando existan irregularidades con la cuenta</span>
                                        </label>
                                    </div>


                                </div>
                                <hr class="border-light m-0">
                                <div class="card-body pb-2">
                                    <h6 style="font-family:'Genera Grotesk';color:#BF9004" class="mb-4">De la web</h6>
                                    <div class="form-group">
                                        <label class="switcher">
                                            <input type="checkbox" class="switcher-input" checked>
                                            <span class="switcher-indicator">
                                                <span class="switcher-yes"></span>
                                                <span class="switcher-no"></span>
                                            </span>
                                            <span class="switcher-label">Noticias y anuncios</span>
                                        </label>
                                    </div>

                                </div>
                            </div>
                            <!--NOTIFICACIONES FIN-->
                        </div>
                    </div>
                </div>
            </div>
            <div class="text-right mt-3">
                <button style="border-color: #F0E6DA; background: #BF9004; margin-bottom:20px" type="button" class="btn btn-primary">Guardar cambios</button>&nbsp;
                <button type="button" style="color: #F0E6DA; margin-bottom: 20px" class="btn btn-default">Cancelar</button>
            </div>
        </div>
        <script data-cfasync="false" src="/cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script>
        <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.0/dist/js/bootstrap.bundle.min.js"></script>
        <script type="text/javascript">

        </script>
    </section>
    <!--EDICIÓN DEL PERFIL FIN-->
</body>

</template>

<style>
@font-face {
    font-family: 'genera-grotesk-heavy';
    src: url('../../tipografias/genera-grotesk-heavy.ttf') format('truetype');
}
@font-face {
    font-family: 'hanken-book';
    src: url('../../tipografias/hanken-book.ttf') format('truetype');
}
@font-face {
    font-family: 'hanken-light';
    src: url('../../tipografias/hanken-light.ttf') format('truetype');
}
/*scrollbar ESTILO INICIO*/
::-webkit-scrollbar {
    width: 5px;
}

::-webkit-scrollbar-track {
    background: rgba(241,229,199,1);
}

::-webkit-scrollbar-thumb {
    background: #BF9004;
    border-radius: 10px;
}

/*scrollbar ESTILO FIN*/
*{
    margin:0;
    padding:0;
    box-sizing:border-box;
    font-family:hanken-book;
}
body {
    background: #F0E6DA;
    margin-top: 20px;
    
}

h4{
    font-family:genera-grotesk-heavy;
}
.ui-w-80 {
    width : 80px !important;
    height: auto;
}

.btn-default {
    border-color: rgba(24, 28, 33, 0.1);
    background  : rgba(0, 0, 0, 0);
    color       : #4E5155;
}

label.btn {
    margin-bottom: 0;
}


.btn {
    cursor: pointer;
    
}

.text-light {
    color: #babbbc !important;
}





.card {
    background-clip: padding-box;
    box-shadow     : 0 1px 4px rgba(24, 28, 33, 0.012);
}

.row-bordered {
    overflow: hidden;
}

.account-settings-fileinput {
    position  : absolute;
    visibility: hidden;
    width     : 1px;
    height    : 1px;
    opacity   : 0;
}

.account-settings-links .list-group-item.active {
    font-weight: bold !important;
}

html:not(.dark-style) .account-settings-links .list-group-item.active {
    background: transparent !important;
}

.account-settings-multiselect~.select2-container {
    width: 100% !important;
}

.light-style .account-settings-links .list-group-item {
    padding     : 0.85rem 1.5rem;
    border-color: rgba(24, 28, 33, 0.03) !important;
}

.light-style .account-settings-links .list-group-item.active {
    color: #4e5155 !important;
}

.material-style .account-settings-links .list-group-item {
    padding     : 0.85rem 1.5rem;
    border-color: rgba(24, 28, 33, 0.03) !important;
}

.material-style .account-settings-links .list-group-item.active {
    color: #4e5155 !important;
}

.dark-style .account-settings-links .list-group-item {
    padding     : 0.85rem 1.5rem;
    border-color: rgba(255, 255, 255, 0.03) !important;
}

.dark-style .account-settings-links .list-group-item.active {
    color: #fff !important;
}

.light-style .account-settings-links .list-group-item.active {
    color: #4E5155 !important;
}

.light-style .account-settings-links .list-group-item {
    padding     : 0.85rem 1.5rem;
    border-color: rgba(24, 28, 33, 0.03) !important;
}
img{
    border-radius:50px;
}
header {
    position: relative;
    padding: 0.8rem;
    background: rgba(241,229,199,1);
}

.navbar {
    transform: translateY(-20%);
    position: relative;
    width: 100%;
    height: 50px;
    max-width: 1400px;
    margin: 0 auto;
    display: flex;
    align-items: center;
    justify-content: space-between;
}

    .navbar .logo img {
        width: auto;
        height: 30px;
        
        border-radius:0px;
    }

    .navbar .button {
        --bg: #FFFCED;
        --hover-bg: #D9A714;
        border: 1px solid var(--bg);
        border-radius: 4px;
        padding: 0.8em 2em;
        background: #BF9004;
        transition: 0.2s;
    }

        .navbar .button:hover {
            transform: translate(-0.25rem,-0.25rem);
            background: var(--hover-bg);
            box-shadow: 0.25rem 0.25rem #2A2A2A;
        }

        .navbar .button:active {
            transform: translate(0);
            box-shadow: none;
        }

        .navbar .button a {
            font-family: 'Genera-grotesk-heavy';
            text-decoration: none;
            color: #FFFCED;
            background-color: transparent;
            border: none;
        }</style>