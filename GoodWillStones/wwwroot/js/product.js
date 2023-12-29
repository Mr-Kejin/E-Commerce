$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    DataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/Product/GetAll'},
        "columns": [
            { data: 'sProductName', "width": "15%" },
            { data: 'listPrice', "width": "15%" },
            { data: 'category.sDescription', "width": "15%" },
            {
                data: 'Product_ID',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/Admin/Product/UpsertProduct?Product_ID=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square" ></i > EDIT </a>
                    <a class="btn btn-danger mx-2"> <i class="bi bi-trash-fill" ></i > Delete</a>
                    </div>`               
                },
                "width": "15%"
            }
            


        ]
    });
}
