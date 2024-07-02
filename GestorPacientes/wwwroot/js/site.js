// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function filterByCedula() {
    var filtroCedula = document.getElementById('CedulaFilter').value.toLowerCase();

    var rows = document.getElementsByClassName('rowlist');

    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        var cedula = row.querySelector('.Cedula').textContent.toLowerCase();

        var estado = cedula.includes(filtroCedula);

        if (estado) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    }
}