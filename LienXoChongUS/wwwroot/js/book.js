$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/Book/GetAll'},
        "columns": [
            { data: 'id',"width":"5%" },
            { data: 'title', "width": "10%" },
            { data: 'description', "width": "30%" },
            { data: 'author', "width": "10%" },
            { data: 'price', "width": "5%" },
            { data: 'category.name', "width": "10%" }
            
        ]
    });
}

