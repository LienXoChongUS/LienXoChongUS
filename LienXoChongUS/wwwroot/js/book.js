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
            { data: 'author', "width": "5%" },
            { data: 'price', "width": "5%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/Admin/Book/UpSert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                    <a asp-controller="Book" asp-action="Delete" asp-route-id="@obj.Id" class="btn btn-delete mx-2"><i class="bi bi-trash3"></i> Delete</a>
                    </div>`
                        
                    
                },
                "width": "30%"
            }
        ]
    });
}

