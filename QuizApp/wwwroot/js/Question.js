//$('#tblData').DataTable({
//    "ajax": {
//        url: '/Admin/Question/GetAll',
//        dataSrc: '',
//        error: function (xhr, error, thrown) {
//            console.error("Error fetching data:", error, thrown);
//        }
//    },
//    "columns": [
//        { data: 'srNo', width: "10%" },
//        { data: 'questionText', width: "20%" },
//        { data: 'optionA', width: "10%" },
//        { data: 'optionB', width: "10%" },
//        { data: 'optionC', width: "10%" },
//        { data: 'optionD', width: "10%" },
//        { data: 'correctOption', width: "10%" },
//        { data: 'difficulty', width: "10%" }
//    ]
//});
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/Admin/Question/GetAll'
        },
        "columns": [
            {
                data: null,  // Use null since we are generating the serial number
                render: function (data, type, row, meta) {
                    return meta.row + 1; // Serial number (1-indexed)
                },
                "width": "5%"
            },
            { data: 'questionText', "width": "25%" },
            { data: 'optionA', "width": "20%", orderable: false },  // Disable sorting
            { data: 'optionB', "width": "10%", orderable: false },  // Disable sorting
            { data: 'optionC', "width": "10%", orderable: false },  // Disable sorting
            { data: 'optionD', "width": "10%", orderable: false },  // Disable sorting
            { data: 'correctOption', "width": "10%" },
            { data: 'difficulty', "width": "10%" }

        ]
    });
}