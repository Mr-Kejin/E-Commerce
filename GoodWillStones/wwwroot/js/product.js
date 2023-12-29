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
            
        ]
    });
}
