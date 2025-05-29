var dataTable;
$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblSliders").DataTable({
        "ajax": {
            "url": "/admin/Sliders/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "7%" },
            { "data": "nombre", "width": "20%" },
            {
                "data": "estado",
                "width": "15%",
                "render": function (estadoActual) {
                    return estadoActual ? "Activo" : "Inactivo";
                }
            },
            {
                "data": "urlImagen",
                "width": "18%",
                "render": function (imagen) {
                    return `<img src="../${imagen}" alt="Imagen del Slider" style="width:100px;  object-fit:cover; border-radius:4px;" />`;
                }
            },
            {
                "data": "id",
                "width": "30%",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Sliders/Edit/${data}" class="btn btn-success btn-sm" style= "width:140px">
                            <i class="fa-solid fa-edit"></i>
                            Editar
                        </a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Sliders/Delete/${data}')" class="btn btn-danger btn-sm" style="cursor: pointer; width:140px">
                            <i class="fa-solid fa-trash"></i>
                            Borrar
                        </a>
                    </div>`;
                }
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, borrar!",
        cancelButtonText: "Cancelar",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            },
            error: function () {
                toastr.error("Error al eliminar el registro");
            }
        });
    });
}