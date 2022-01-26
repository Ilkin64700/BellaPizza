
const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
    },
    buttonsStyling: false
})

showInPopup = (url, title, action) => {

    let SelectedRow = $('#Etable').bootstrapTable('getSelections')[0];

    if (SelectedRow === undefined && action == 'Edit') {
        swalWithBootstrapButtons.fire('Hec bir melumat secilmeyib', `Bri setir secin !`, 'error')
    }
    else {
        if (action == 'Edit') {
            url = `${url}/${SelectedRow.Id}`;
        }

        $.ajax({
            type: 'GET',
            url: url,
            success: function (res) {
                $("#form-modal .modal-body").html(res)
                $("#form-modal .modal-title").html(title)
                $("#form-modal").modal('show')
                if (action == 'Edit') {
                    let imageElement = $.parseHTML(SelectedRow.ImagePath);
                    let url = $(imageElement).css("background-image");
                    url = url.replace(/(url\(|\)|")/g, '');
                    $('#news-image').attr('src', `${url}`);
                }
            },
            error: function (res) { swalWithBootstrapButtons.fire('Getire bilmedi', `${err.status} - ${err.statusText}`, 'error') }
        })
    }
}



FormPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            dataType: "json",
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');

                    window.location.href = ''
                }
                else {
                    swalWithBootstrapButtons.fire('Valid deyil', `Melumatlari Duzgun formatda daxil edin`, 'error')
                }
            },
            error: function (err) {
                swalWithBootstrapButtons.fire('Xeta bas verdi', `${err.status} - ${err.statusText}`, 'error')
            }
        })
    }
    catch (ex) {
        swalWithBootstrapButtons.fire('Try Catch xetasi', `${ex}`, 'error')
    }
    //to prevent default form submit event
    return false;
}


jQueryAjaxDelete = form => {

    let SelectedRows = $('#Etable').bootstrapTable('getSelections');

    if (SelectedRows[0] === undefined) {
        swalWithBootstrapButtons.fire('Hec bir melumat secilmeyib', `Bri setir secin !`, 'error')
    }
    else {
        var selectRowsArr = []
        for (let SelectedRow of SelectedRows) {
            selectRowsArr.push(parseInt(SelectedRow.Id))
        }

        Swal.fire({
            title: "Eminmisiniz?",
            text: `${Object.keys(selectRowsArr).length} element silinecek !`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Beli, Sil!'
        }).then((result) => {
            if (result.value) {
                try {
                    $.ajax({
                        type: 'POST',
                        url: form.action,
                        data: { selectRowsArr: selectRowsArr },
                        datatype: "json",
                        traditional: true,
                        success: function (res) {
                            if (res.isValid) {
                                for (let SelectedRow of SelectedRows) {
                                    $('#Etable').bootstrapTable('removeByUniqueId', SelectedRow.Id)
                                }
                                Swal.fire('Silindi!', `${Object.keys(selectRowsArr).length} element silindi !`, 'success')
                            }
                            else { swalWithBootstrapButtons.fire('Siline bilmedi', `Admin ile elaqe saxlayin`, 'error') }
                        },
                        error: function (err) { swalWithBootstrapButtons.fire('Siline bilmedi', `${err.status} - ${err.statusText}`, 'error') }
                    })
                } catch (ex) { swalWithBootstrapButtons.fire('Siline bilmedi', `${ex}`, 'error') }
            }
        })
    }
    //prevent default form submit event
    return false;
}


$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

//image chooser
var readURL = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#news-image').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

var removePhoto = function () {
    document.getElementById('mediaUrl').value = '';
    document.getElementById('news-image').src = '';
}
//image chooser end

// active navbar show 
if (Math.max(document.documentElement.clientWidth, window.innerWidth) > 768) {
document.getElementsByClassName("active")[0].closest(".collapse").classList.add("show");
    document.getElementsByClassName("active")[0].closest(".nav-item").querySelector(".nav-link").classList.remove("collapsed");
}
//active navbar show end