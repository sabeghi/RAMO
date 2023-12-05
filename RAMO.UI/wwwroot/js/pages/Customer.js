function myclick2() {
    $.ajax({
        type: "GET",
        url: "../api/Customer",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //data: "name=salam",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        success: function (data) {
            //toastr.success(data[0].firstName, "ok")
            data.map((itm) => {
                toastr.success(itm.firstName, "ok from script")
            });
        },
        error: function (error) {
            toastr.error("Error :)", "oops!")
        }
    });
}