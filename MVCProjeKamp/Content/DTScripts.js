$(document).ready(function () {

    $('.MyDataTable').DataTable({
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        pageLength: 10,
        columnDefs: [
            {
                targets: ["nosort"],
                orderable: false,
                searchable: false,
            }
        ],
  
        language: { search: '', searchPlaceholder: "Search..." },
        "dom": '<"top"Bf>t<"bottom"ilp>',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]


    })


    $('.tblMessageBox').DataTable({
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        pageLength: 10,
        columnDefs: [
            {
                targets: ["nosort"],
                orderable: false,
                searchable: false,
            }
        ],
        language: { search: '', searchPlaceholder: "Search..." },
     
    })
    $('.dataTables_filter label input').addClass('form-control')

});
