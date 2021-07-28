$(function () {
    $(".MyDataTable").on("click", "#btnDeleteCategory", function () {
        var btn = $(this);
        var id = $(this).data("id");
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: "GET",
                    url: "/AdminCategory/DeleteCategory/" + id,
                    success: function () {
                        btn.parent().parent().remove()
                    }
                })
                Swal.fire(
                    'Deleted!',
                    'Category has been deleted.',
                    'success'
                )
            }
        })



    })

})

$(function () {
    $("#tblHeadings").on("click", "#btnDeleteHeading", function () {
        var btn = $(this);
        var id = $(this).data("id");
        Swal.fire({
            title: 'Are you sure?',
            text: "This title will be deleted, you can access it from the Passive Titles menu. Do you want to continue?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, go on!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: "GET",
                    url: "/Heading/DeleteHeading/" + id,
                    success: function () {
                        btn.parent().parent().remove()
                    }
                })
                Swal.fire(
                    'Deleted!',
                    'Title has been deleted.',
                    'success'
                )
            }
        })



    })

})

$(function () {
    $("#tblPassiveHeadings").on("click", "#btnUnbanTitle", function () {
        var btn = $(this);
        var id = $(this).data("id");
        Swal.fire({
            title: 'Are you sure?',
            text: "This Title will be Active, writers can entry of it. Do you want to continue?",
            icon: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, go on!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: "GET",
                    url: "/Heading/DeleteHeading/" + id,
                    success: function () {
                        btn.parent().parent().remove()
                    }
                })
                Swal.fire(
                    'Activated!',
                    '',
                    'success'
                )
            }
        })



    })

})