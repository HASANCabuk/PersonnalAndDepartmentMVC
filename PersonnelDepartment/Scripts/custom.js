$(function () {
    $("#tblDepartments").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/English.json"
        }
    });

    $("#tblDepartments").on("click", ".btnDepartmentDelete", function () {
        var btn = $(this);

        confirm("Are you sure you want to delete department?", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Department/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });
    /*$("#tblDepartments").on("click", ".btnDepartmentUpdate", function () {
        var btn = $(this);

        confirm("Are you sure you want to update department?", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "POST",
                    url: "/Department/Update/" + id,
                    success: function () {
                        btn.parent().parent()
                    }
                });
            }
        });
    });*/
    /*
    $("#tblPersonnels").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/English.json"
        }
    });

    $("#tblPersonnels").on("click", ".btnPersonnelDelete", function () {
        var btn = $(this);
        confirm("Are you sure you want to delete personnel?", function (result) {
            alert(btn.data('id'));
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Personnel/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });*/
});

function CheckDateTypeIsValue(dataElement) {
    var value = $(dataElement).val();
    if (value == '') {
        $(dataElement).valid("false");
    } else {
        $(dataElement).valid();
    }
}