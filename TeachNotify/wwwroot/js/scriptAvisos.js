    loadChat();
    loadAlumno();
    loadDocente();
    function myFunction() {
        var input, filter, section, div, p, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    section = document.getElementById("mySection");
    div = section.getElementsByTagName("div");
    for (i = 0; i < div.length; i++) {
        p = div[i].getElementsByTagName("p")[0];
    if (p) {
                var palabrasEnFiltro = filter.split(' ');
    var hallado = 0;
    for (var filtro of palabrasEnFiltro) {
                    if (p.innerHTML.toUpperCase().indexOf(filtro) > -1) {
        hallado++;
                    }
                }
    if (hallado === palabrasEnFiltro.length) {
        div[i].style.display = "";
                } else {
        div[i].style.display = "none";
                }
            }
        }
    }

    async function loadChat() {
        var result = await fetch("https://teachnotifyme.itesrc.net/api/Mensaje")
    let datos = await result.json();
    miMetodo(datos);
    console.log(datos);
    }
    var tabla = document.getElementById("contenedor");
    var plantilla = document.getElementById("plantilla");
    function miMetodo(datos){
        let cantidad = datos.length;
        if (cantidad > tabla.children.length) {
        let n = cantidad - tabla.children.length;
    for (var x = 0; x < n; x++) {
        let clon = plantilla.content.children[0].cloneNode(true);
    tabla.append(clon);
            }
        }
    else if (cantidad < tabla.children.length) {
        let n = tabla.children.length - cantidad;
    for (var x = 0; x < n; x++) {
        tabla.lastChild.remove();
            }
        }
       
         datos.forEach((o, i) => {
        let tr = tabla.children[i];
    tr.cells[0].innerHTML = o.idMensajes;
    tr.cells[1].innerHTML = o.nombreAlumno;
    tr.cells[2].innerHTML = o.nombreDocente;
    tr.cells[3].innerHTML = o.mensajes;
    tr.cells[4].children[0].setAttribute("data-id", o.idMensajes);
    tr.cells[5].children[0].setAttribute("data-id", o.idMensajes);
   
        }); 
    }
    async function loadDocente() {
        var result = await fetch("https://teachnotifyme.itesrc.net/api/Docente")
    let datos = await result.json();
    //metodoDocente(datos);
    console.log(datos);
    let select = document.getElementById("idDocente");
        datos.forEach(x => {
            var noDocentes = document.createElement("option");
    noDocentes.value = x.idDocente;
    noDocentes.innerHTML = x.nombreDocente;
    select.options.add(noDocentes);
        });
    }
    async function loadAlumno() {
        var result = await fetch("https://teachnotifyme.itesrc.net/api/Alumno")
    let datos = await result.json();
    //meotodoAlumno(datos);
    console.log(datos);
    let select = document.getElementById("idAlumno");
        datos.forEach(x => {
          var noAlumnos = document.createElement("option");
    noAlumnos.value = x.idAlumno;
    noAlumnos.innerHTML = x.nombreAlumno;
    select.options.add(noAlumnos);
        });
    }

    document.addEventListener("click", async function (event) {
    if (event.target.dataset.modal) {
        let modal = document.getElementById(event.target.dataset.modal)
    let editar = event.target.dataset.modal.includes("ModalEditar");
    var Msjs = event.target.dataset.id;
    if (editar) {
        let res = await fetch(API + "/Mensajes/GetById/" + Msjs);
    if (res.ok) {
        let mensaje = await res.json();
    let form = modal.querySelector("Form");
                //form.elements[0].value = mensaje["mensaje"];
            }
        }
    modal.style.display = "grid";
    return;
    }
    if (event.target.dataset.cancel) {
        event.target.closest(".modal").style.display = "none";
    }
});

    function getDateTime() {
  const now = new Date();
    return {
    year: now.getFullYear(),
    month: now.getMonth() + 1,
    day: now.getDate(),
    hour: now.getHours(),
    minute: now.getMinutes(),
    second: now.getSeconds()
  };
}


    document.addEventListener("submit", async function (event)
    {
     event.preventDefault();
    let form = event.target;
    if (form.dataset.action === "AgregarMensaje") {
        let json = Object.fromEntries(new FormData(form));
    var metodo = "post";
    json["fecha"] = getDateTime();
    let resp = await fetch("https://teachnotifyme.itesrc.net/api/Mensaje/AgregarMensaje",
    {method: metodo,
    body: JSON.stringify(json), headers: {"content-type": "application/json"}
                })
    if (resp.ok) {
        form.reset();
    form.closest(".modal").style.display = "none";
                }
        }
    //else (form.dataset.action === "EditarMensaje")
    //let json = Object.fromEntries(new FormData(form));
    //var metodo = "post";
    //json["fecha"] = getDateTime();
    //let resp = await fetch("https://teachnotifyme.itesrc.net/api/Mensaje/EditarMensaje",
    //{method: metodo,
    //body: JSON.stringify(json), headers: {"content-type": "application/json"}
    //            })
       });



