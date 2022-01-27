////const swalWithBootstrapButtons = Swal.mixin({
////    customClass: {
////        confirmButton: 'btn btn-success',
////        cancelButton: 'btn btn-danger'
////    },
////    buttonsStyling: false
////})

AjaxGet = url => {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $("#productModal .modal-body").html(res)
            $("#productModal").modal('show')
        }
        /*        ,error: function (res) { swalWithBootstrapButtons.fire('Getire bilmedi', `${err.status} - ${err.statusText}`, 'error') }*/
    })
}


AjaxPost = form => {
    try {
        console.log("Ajaxa geldik");
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            dataType: "json",
            contentType: false,
            processData: false,
            success: function (res) {
                $("#productModal").modal('hide')
                //location.reload();
            },
            error: function (err) {
                console.log("Ajaxdan error geldi" + err)
                //swalWithBootstrapButtons.fire('Xeta bas verdi', `${err.status} - ${err.statusText}`, 'error')
            }
        })
    }
    catch (ex) {
        //swalWithBootstrapButtons.fire('Try Catch xetasi', `${ex}`, 'error')
    }
    //to prevent default form submit event
    return false;
}





