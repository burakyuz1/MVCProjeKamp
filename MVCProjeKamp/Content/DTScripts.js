$(document).ready(function () {

    $('.MyDataTable').DataTable({
        "lengthMenu": [[7, 14, 21, -1], [7, 14, 21, "All"]],
        pageLength: 7,
        columnDefs: [
            {
                targets: ["nosort"],
                orderable: false,
                searchable: false,
            }
        ],
        language: { search: '', searchPlaceholder: "Search..." }


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
