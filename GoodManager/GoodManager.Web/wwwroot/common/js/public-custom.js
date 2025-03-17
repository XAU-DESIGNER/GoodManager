"use strict";

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
    })

    $('[editForm] input').on('input', function () {
        $('.formBtns').fadeIn();
    })

    $('[editForm]').on('reset', function (e) {
        $('.formBtns').hide();
    })
});

// list actions btns
$(document).on('click', '[showModalBySwal]', async function (e) {
    e.preventDefault();
    const url = $(this).attr('href');

    $.ajax({
        type: 'GET',
        url: url,
        success: result => {
            let isDarkTheme = document.documentElement.classList.contains('dark');

            Swal.fire({
                html: result,
                width: 900,
                background: isDarkTheme ? "#26334d" : "#ffffff",
                color: isDarkTheme ? "#ffffff" : "#000000",
                showConfirmButton: false
            });

        }, error: () => {
            console.log("failed");
        }
    })
})

$(document).on('click', '[deleteBtn]', async function (e) {
    e.preventDefault();

    const url = $(this).attr('href');

    await swal.fire({
        icon: 'warning',
        title: 'آیا از حذف اطمینان دارید؟',
        showDenyButton: true,
        denyButtonText: 'لغو',
        confirmButtonText: 'تایید',
        preConfirm: async function () {
            await $.ajax({
                url: url,
                type: 'POST',
                success: async function (result) {
                    $('#filter-search').trigger('submit');

                    await showSuccessToasterSWAL(result.responseText);
                }, error: async function (result) {
                    await showErrorToasterSWAL(result.responseText);
                }
            })
        }
    })
})

// form events
$(document).on('submit', '[addForm]', async function (e) {
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
            $('#filter-search').trigger('submit');

            if (successCallBack && typeof successCallBack === 'function') {
                await successCallBack();
            }

            if (showSuccessAlert === true) {
                await showSuccessToasterSWAL(message);
            }
        },
        error: async (result) => {
            await hideLoading(`#${formId}`);

            await Swal.showValidationMessage(result.responseText);
        }
    });
})

$(document).on('submit', '[editForm]', async function (e) {
    e.preventDefault();

    let form = $(this);
    let formData = new FormData(form[0]);
    const url = $(this).attr('action');
    const type = $(this).attr('method');
    const successCallBack = $(this).attr('afterSuccess');
    const errorCallBack = $(this).attr('afterError');
    const formId = $(this).attr('id');
    const isSwal = $(this).attr('isSwal') || false;

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
            $('#filter-search').trigger('submit');

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

            if (isSwal) {
                await Swal.showValidationMessage(result.responseText);
            }
        }
    });
})

$(document).on('reset', '[addForm]', async function (e) {
    $('.formBtns').hide();
})

$(document).on('input', '[addForm] input', async function (e) {
    $('.formBtns').fadeIn();
})

// common functions

async function showErrorToasterSWAL(message, position = "bottom-end") {
    await swal.fire({
        timer: 2500,
        toast: true,
        position: position,
        timerProgressBar: true,
        showConfirmButton: false,
        icon: "error",
        title: message || 'نا موفق'
    });
}

async function showSuccessToasterSWAL(message, position = "bottom-end") {
    await swal.fire({
        timer: 2500,
        toast: true,
        position: position,
        timerProgressBar: true,
        showConfirmButton: false,
        icon: "success",
        title: message || 'با موفقیت انجام شد !'
    });
}

function FillPageId(id) {
    $("#CurrentPage").val(id);
    $("#filter-search").trigger("submit");
}

async function handleAJAXResponse(response, options) {
    const defaultOptions = {
        onSuccessCallback: null,
        onErrorCallback: null,
        showSuccessAlert: true,
        showErrorAlert: true
    };
    options = { ...defaultOptions, ...options };

    if (response.IsSuccess) {
        if (options.showSuccessAlert) {
            await showSuccessToasterSWAL(response.Message);
        }
        if (options.onSuccessCallback) {
            await options.onSuccessCallback(response.Data, response.MetaData);
        }
    } else {
        if (options.showErrorAlert) {
            await showErrorToasterSWAL(response.Message);
        }
        if (options.onErrorCallback) {
            await options.onErrorCallback(response.Message, response.StatusCode);
        }
    }
}

async function replaceHtmlContentWithSelector(selector, htmlContent) {
    let element = $(`${selector}`);
    element.empty();

    if (htmlContent)
        element.html(htmlContent);
}

async function displayLoading(selector, effect = 'bounce') {
    let element = $(selector);
    await element.waitMe({
        effect: effect,
        textPos: 'vertical',
        bg: 'rgba(33, 46, 72, 0.63)',
        onClose: function () { }

    });
    if (element && $('html').hasClass('dark')) {
        await element.waitMe({
            effect: effect,
            textPos: 'vertical',
            bg: 'rgba(33, 46, 72, 0.63)',
            onClose: function () { }

        });
    } else if (element) {
        await element.waitMe({
            effect: effect,
            textPos: 'vertical',
            onClose: function () { }
        });
    }
}

async function hideLoading(selector) {
    let element = $(`${selector}`);

    if (!element) return;

    element.waitMe("hide");
}