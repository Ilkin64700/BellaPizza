////const swalWithBootstrapButtons = Swal.mixin({
////    customClass: {
////        confirmButton: 'btn btn-success',
////        cancelButton: 'btn btn-danger'
////    },
////    buttonsStyling: false
////})

showInPopup = (url, title) => {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res)
            $("#form-modal .modal-title").html(title)
            $("#form-modal").modal('show')            
        }
/*        ,error: function (res) { swalWithBootstrapButtons.fire('Getire bilmedi', `${err.status} - ${err.statusText}`, 'error') }*/
    })
}





