var dataTable1;
$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    // Destroy the existing DataTable if it's initialized
    if (dataTable1) {
        dataTable1.destroy();
    }
    dataTable1 = $('#tblData1').DataTable({
        "ajax": { url: '/StoreOwner/Book/GetAll'},
        "columns": [
            { data: 'id',"width":"5%" },
            { data: 'title', "width": "10%" },
            { data: 'description', "width": "30%" },
            { data: 'author', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            {

                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/StoreOwner/Book/UpSert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                    <a onClick=Delete('/StoreOwner/Book/Delete/${data}') class="btn btn-delete mx-2"><i class="bi bi-trash3"></i> Delete</a>
                    </div>`
                        
                    
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel!",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable1.ajax.reload();
                    toastr.success(data.message);
                }
            })
            swalWithBootstrapButtons.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire({
                title: "Cancelled",
                text: "Your imaginary file is safe :)",
                icon: "error"
            });
        }
    });
}

