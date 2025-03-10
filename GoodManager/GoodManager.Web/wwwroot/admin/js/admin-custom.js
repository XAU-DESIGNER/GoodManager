'use strict';

$(async function () {

    $('[ajax-filter-form]').on('submit', async function (e) {
        e.preventDefault();

        const url = $(this).attr('action');
        const type = $(this).attr('method');
        let boxToReplace = $(this).data('replace');

        let formData = new FormData(this);

        await $.ajax({
            url: url,
            data: formData,
            type: type,
            contentType: false,
            processData: false,
            beforeSend: async () => {
                await displayLoading(boxToReplace);
            },
            success: async function (result) {
                replaceHtmlContentWithSelector(boxToReplace, result);
            },
            error: async (message) => {
                await console.log(message);
            }
        });
    });

    $('[editForm] input').on('input', function () {
        $('.formBtns').fadeIn();
    });

    $('[editForm]').on('submit', async function (e) {
        e.preventDefault();

        let form = $(this);
        let formData = new FormData(form[0]);
        const url = $(this).attr('action');
        const type = $(this).attr('method');
        const successCallBack = $(this).attr('afterSuccess');
        const errorCallBack = $(this).attr('afterError');
        const formId = $(this).attr('id');


        await $.ajax({
            url: url,
            type: type || 'POST',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            beforeSend: async () => {
                await displayLoading(`#${formId}`);
            },
            success: async (message) => {
                await hideLoading(`#${formId}`);
                $('.formBtns').hide();

                if (successCallBack) {
                    await successCallBack();
                } else {
                    await showSuccessToasterSWAL(message);
                }

            }, error: async (result) => {
                await hideLoading(`#${formId}`);

                if (errorCallBack) {
                    await errorCallBack();
                } else {
                    console.log(result.responseText);
                }
            }
        });
    });

    $('[editForm]').on('reset', function (e) {
        $('.formBtns').hide();
    });

    $('[addForm] input').on('input', function () {
        $('.formBtns').fadeIn();
    })

    $('[addForm]').on('submit', async function (e) {
        e.preventDefault();

        let form = $(this);
        let formData = new FormData(form[0]);
        const url = $(this).attr('action');
        const type = $(this).attr('method');
        const successCallBack = window[$(this).attr('afterSuccess')];
        const errorCallBack = window[$(this).attr('afterError')];
        const formId = $(this).attr('id');
        const showSuccessAlert = $(this).attr('showSuccessAlert') ?? true;

        await $.ajax({
            url: url,
            type: type || 'POST',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            beforeSend: async () => {
                await displayLoading(`#${formId}`);
            },
            success: async (message) => {
                await hideLoading(`#${formId}`);
                $('.formBtns').hide();

                if (successCallBack && typeof successCallBack === 'function') {
                    await successCallBack();
                }

                if (showSuccessAlert === true) {
                    await showSuccessToasterSWAL(message);
                    $('#filter-search').trigger('submit');
                }
            },
            error: async (result) => {
                await hideLoading(`#${formId}`);

                if (errorCallBack && typeof errorCallBack === 'function') {
                    await errorCallBack();
                } else {
                    console.log(result.responseText);
                }
            }
        });
    });

    $('[addForm]').on('reset', function (e) {
        $('.formBtns').hide();
    });

    $('[showModalForAdd]').on('click', function (e) {
        e.preventDefault();
        const url = $(this).attr('href');

        $.ajax({
            type: 'GET',
            url: url,
            success: result => {
                swal.fire({
                    html: result,
                    width: 900,
                    showConfirmButton: false
                });

                $('[addForm] input').on('input', function () {
                    $('.formBtns').fadeIn();
                })

                $('[addForm]').on('submit', async function (e) {
                    e.preventDefault();
                    
                    let form = $(this);
                    let formData = new FormData(form[0]);
                    const url = $(this).attr('action');
                    const type = $(this).attr('method');
                    const successCallBack = window[$(this).attr('afterSuccess')];
                    const errorCallBack = window[$(this).attr('afterError')];
                    const formId = $(this).attr('id');
                    const showSuccessAlert = $(this).attr('showSuccessAlert') ?? true;

                    console.log(formId);

                    await $.ajax({
                        url: url,
                        type: type || 'POST',
                        data: formData,
                        cache: false,
                        contentType: false,
                        processData: false,
                        beforeSend: async () => {
                            await displayLoading(`#${formId}`);
                        },
                        success: async (message) => {
                            await hideLoading(`#${formId}`);
                            $('.formBtns').hide();

                            if (successCallBack && typeof successCallBack === 'function') {
                                await successCallBack();
                            }

                            if (showSuccessAlert === true) {
                                $('#filter-search').trigger('submit');
                                await showSuccessToasterSWAL(message);
                            }
                        },
                        error: async (result) => {
                            await hideLoading(`#${formId}`);

                            await Swal.showValidationMessage(result.responseText);
                        }
                    });
                });

                $('[addForm]').on('reset', function (e) {
                    $('.formBtns').hide();
                });
            }, error: () => {
                console.log("failed");
            }
        })


    })
});