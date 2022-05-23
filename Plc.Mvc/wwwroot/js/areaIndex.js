$(document).ready(function () {
    $('#areasTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd"
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                    /*  alert('Ekle Butonuna Basıldı');*/
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    /*alert('Yenile Butonuna Basıldı');*/
                    $.ajax({
                        type: 'GET',
                        /*   url: '@Url.Action("GetAllArea", "Area")',*/
                        url: '/Admin/Area/GetAllArea/',
                        contentType: "application/json",
                        //beforeSend işlemi ajax işlemini yapmadan önce yapıcaklarımızı belirttiğimiz bölüm
                        beforeSend: function () {
                            $('#areasTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const areaListDto = jQuery.parseJSON(data);
                            if (areaListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(areaListDto.Areas.$values,
                                    function (index, area) {
                                        tableBody += `
                                        <tr>
                                            <td>${area.Id}</td>
                                            <td>${area.Name}</td>
                                             <td>
                                                <button class="btn btn-info btn-sm btn-update" data-id="${area.Id}"><span class="fas fa-edit"></span>Update</button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${area.Id}"><span class="fas fa-minus-circle"></span>Delete</button>
                                            </td>
                                         </tr>`;
                                    });
                                $('#areasTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#areasTable').show();
                            } else {
                                toastr.error(`${areaListDto.Message}`, 'Exception');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#areasTable').fadeIn(1000);
                            toastr.error(`${err.statusText}`, 'Exception');
                        }
                    });
                }
            }
        ]
    });

    /* Data table bitiş */
    /* ModalPlaceHolder div oluşturup placeHolderDiv içerisine attık.Data table üzerindeki btnAdd butonuna basılırsa
    içerisinde JQUERY AJAX get işlemi başlat ajax url'de verilen actiona gidecek partialView alıcak ve data içerisinde
    bize getirecek placeHolderDiv.html'i data ile doldurur' */

    $(function () {
        /*       const url = '@Url.Action("Add", "Area")';*/
        const url = '/Admin/Area/Add/';
        const placeHolderDiv = $('#modelPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });
        ////////
        //div üzerinde bizim eklediğimiz event çalıştırıldığında yapılacak işlemleri yazmamızı sağlıyor   (52)

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault(); //butonun kendi click işlemini engellemiş oluyoruz.
                const form = $('#form-area-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();//form içerisindeki veriler areaAddDto şeklinde alındı.
                $.post(actionUrl, dataToSend).done(function (data) {
                    const areaAddAjaxModel = jQuery.parseJSON(data);
                    const newFromBody = $('.modal-body', areaAddAjaxModel.AreaAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFromBody);
                    const isValid = newFromBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                         <tr name="${areaAddAjaxModel.AreaDto.Area.Id}">
                                            <td>${areaAddAjaxModel.AreaDto.Area.Id}</td>
                                            <td>${areaAddAjaxModel.AreaDto.Area.Name}</td>
                                            <td>
                                                <button class="btn btn-info btn-sm btn-update" data-id="${areaAddAjaxModel.AreaDto.Area.Id}"><span class="fas fa-edit"></span>Update</button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${areaAddAjaxModel.AreaDto.Area.Id}"><span class="fas fa-minus-circle"></span>Delete</button>
                                            </td>
                                         </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#areasTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(2000);
                        toastr.success(`${areaAddAjaxModel.AreaDto.Message}`, 'Başarılı İşlem');
                    } //``
                    else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    $(document).on('click',
        '.btn-delete',
        function (event) { //sayfa üzerinde tıklama yakalıyoruz
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { areaId: id },
                        /* url: '@Url.Action("Delete", "Area")',*/
                        url: '/Admin/Area/Delete/',
                        success: function (data) {
                            const result = jQuery.parseJSON(data);
                            if (result.ResultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    'Your file has been deleted.',
                                    'success'
                                );

                                tableRow.fadeOut(2000);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops',
                                    text: `${result.Message}`
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, 'Exception');
                        }
                    });
                }
            });
        });

    $(function () {
        const url = '/Admin/Area/Update/';
        const placeHolderDiv = $('#modelPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { areaId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Exception");
                });
            });

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();
                const form = $('#form-area-update');
                /* const actionUrl = form.attr('action');*/
                const dataToSend = form.serialize();
                $.post('/Admin/Area/Update/', dataToSend).done(function (data) {
                    const areaUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(areaUpdateAjaxModel);
                    const newFormBody = $('.modal-body', areaUpdateAjaxModel.AreaUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                         <tr name="${areaUpdateAjaxModel.AreaDto.Area.Id}">
                                            <td>${areaUpdateAjaxModel.AreaDto.Area.Id}</td>
                                            <td>${areaUpdateAjaxModel.AreaDto.Area.Name}</td>
                                            <td>
                                                <button class="btn btn-info btn-sm btn-update" data-id="${areaUpdateAjaxModel.AreaDto.Area.Id}"><span class="fas fa-edit"></span>Update</button>
                                                <button class="btn btn-danger btn-sm btn-delete" data-id="${areaUpdateAjaxModel.AreaDto.Area.Id}"><span class="fas fa-minus-circle"></span>Delete</button>
                                            </td>
                                         </tr>`;
                        const newTableRowObject = $(newTableRow);
                        const areaTableRow = $(`[name="${areaUpdateAjaxModel.AreaDto.Area.Id}"]`);
                        /*  areaTableRow.replaceWith(newTableRowObject);*/
                        newTableRowObject.hide();
                        areaTableRow.replaceWith(newTableRowObject);
                        newTableRowObject.fadeIn(2000);
                        toastr.success(`${areaUpdateAjaxModel.AreaDto.Message}`, "Success");
                    } else {
                        let summaryText = "";
                        $('#validation-summary>ul>li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function (response) {
                    console.log(response);
                });
            });
    });


});