let empresasReportadas = [
  {
    nombreEmpresa: "Damaroli",
    nombreAdmin: "Rafael",
    pathFotoEmpresa: "imagenes/Damaroli.jpg"
  }
]

function llenarEmpresas(){
    const tablaEmpresas = document.getElementById('reclamosEmpresas');
    empresasReportadas.forEach(empresa => {
        tablaEmpresas.innerHTML += `
            <tr class="empresaRow">
                <td class="empresa"><img src="${empresa.pathFotoEmpresa}"><a href="#">${empresa.nombreEmpresa}</a></td>
                <td class="report" >1</td>
                <td>
                    <label class="switch">
                    <input type="checkbox" id="myToggle">
                    <span class="slider round"></span>
                    </label>
                    <p id="status"></p>
                </td>
                <td><button class="btn-revisar" data-modal-target="#modal${i}">Revisar</button>
                    <div class="modal" id="modal${i}">
                        <div class="modal-header">
                        <div class="empresa"><img src="imagenes/Damaroli.jpg"><h1>${empresa.nombreEmpresa}</h1></div>
                        <button data-close-button class="close-button">&times;</button>
                        </div>
                        <div class="modal-body">
                            <a  href="../USUcomentarios/index.html">Ver Comentarios</a>
                            <form action="" class="caja-com">
                                <div class="usu">
                                    <div class="img"><img src="imagenes/limonagrio.jpg"></div>
                                    <divc class="nombre">${empresa.nombreAdmin}</div>
                                </div>
                                <textarea class="aaa" name="comentario"></textarea>
                                <button class="btn">Enviar</button>
                            </form>
                            <div class="baja">
                                <button class="btn-baja">Dar de baja</button>
                                <button class="btn-baja">Suspender</button>
                            </div>
                        </div>
                    </div>
                    <div id="overlay"></div>
                </td>
            </tr>
            `
    });
}





// axios.get('http://localhost:5132/reclamos_empresa/getReclamos/ADM-001')
// .then((response) => {
//     const tablaEmpresas = document.getElementById('reclamosEmpresas');
//     var empresas = response.data;
//     let i = 6;
//     empresas.forEach(empresa => {
//         tablaEmpresas.innerHTML += `
//                 <tr class="empresaRow">
//                     <td class="empresa"><img src="imagenes/Damaroli.jpg"><a href="#">${empresa.nombreEmpresa}</a></td>
//                     <td class="report" >1</td>
//                     <td>
//                         <label class="switch">
//                         <input type="checkbox" id="myToggle">
//                         <span class="slider round"></span>
//                         </label>
//                         <p id="status"></p>
//                     </td>
//                     <td><button class="btn-revisar" data-modal-target="#modal${i}">Revisar</button>
//                         <div class="modal" id="modal${i}">
//                             <div class="modal-header">
//                             <div class="empresa"><img src="imagenes/Damaroli.jpg"><h1>${empresa.nombreEmpresa}</h1></div>
//                             <button data-close-button class="close-button">&times;</button>
//                             </div>
//                             <div class="modal-body">
//                                 <a  href="../USUcomentarios/index.html">Ver Comentarios</a>
//                                 <form action="" class="caja-com">
//                                     <div class="usu">
//                                         <div class="img"><img src="imagenes/limonagrio.jpg"></div>
//                                         <divc class="nombre">${empresa.nombreAdmin}</div>
//                                     </div>
//                                     <textarea class="aaa" name="comentario"></textarea>
//                                     <button class="btn">Enviar</button>
//                                 </form>
//                                 <div class="baja">
//                                     <button class="btn-baja">Dar de baja</button>
//                                     <button class="btn-baja">Suspender</button>
//                                 </div>
//                             </div>
//                         </div>
//                         <div id="overlay"></div>
//                     </td>
//                 </tr>
//                 `});
//                 i++;
//     console.log(response.data);
// }).catch((error) => {
//     console.log(error);
// });