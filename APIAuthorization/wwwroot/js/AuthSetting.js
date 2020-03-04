//var dataTable;

//$(document).ready(function () {
//    loadDataTable = $('#DT_load').DataTable({
//        "ajax": {
//            "url": "/api/AuthSetting",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "KEY", "width": "30%" },
//            { "data": "VALUE", "width": "30%" },
//            {
//                "data": "KEY",
//                "render": function (data) {
//                    return `<div class="text-center">
//                        <a href="/AuthSetting/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
//                            Edit
//                        </a>
//                        &nbsp
//                        <a class= 'btn btn-danger text-white' style='cursor:pointer; width:100px;'>
//                            Delete
//                        </a>
//                        </div>`
//                }, "width": "100%"
//            }
//        ],
//        "language": {
//            "emptyTable": "no data found"
//        },
//        "width": "100%"
//    });
//}