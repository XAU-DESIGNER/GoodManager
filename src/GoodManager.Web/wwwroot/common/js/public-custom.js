"use strict";

$(async function () {
    await convertToIranianPriceWithTomanFormat();
    await convertToPriceWithDollarFormat();
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

$(document).on('reset', '[addForm]', async function (e) {
    $('.formBtns').hide();
})

$(document).on('submit', '[addForm]', async function (e) {
    e.preventDefault();

    let form = $(this);
    let formData = new FormData(form[0]);

    const url = $(this).attr('action');
    const method = $(this).attr('method');

    const successCallBack = $(this).attr('afterSuccess');
    const errorCallBack = $(this).attr('afterError');
    const isSwal = $(this).attr('isSwal') || false;

    const formId = $(this).attr('id');
    const showSuccessAlert = $(this).attr('showSuccessAlert') || true;
    const showErrorAlert = $(this).attr('showErrorAlert') || true;

    await $.ajax({
        url: url,
        type: method || 'POST',
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
            } else{
                $(this).trigger('reset');
            }

            if (showSuccessAlert === true) {
                await showSuccessToasterSWAL(message);
            }
        },
        error: async (result) => {
            await hideLoading(`#${formId}`);

            if (errorCallBack) {
                await errorCallBack();
            }

            if (showErrorAlert === true) {
                if (isSwal === true) {
                    SWAL.showValidationMessage(result.responseText);
                } else {
                    await showErrorToasterSWAL(result.responseText);
                }
            }
        }
    });
})

$('[addForm] input').on('input', async function (e) {
    $('.formBtns').fadeIn();
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

    const showSuccessAlert = $(this).attr('showSuccessAlert') || true;
    const showErrorAlert = $(this).attr('showErrorAlert') || true;

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
            }

            if (showSuccessAlert === true) {
                await showSuccessToasterSWAL(message);
            }

        }, error: async (result) => {
            await hideLoading(`#${formId}`);

            if (errorCallBack) {
                await errorCallBack();
            }

            if (showErrorAlert === true) {
                if (isSwal === true) {
                    SWAL.showValidationMessage(result.responseText);
                } else {
                    await showErrorToasterSWAL(result.responseText);
                }
            }

            console.log(result.responseText);
        }
    });
})

$('[editForm] input').on('input', function () {
    $('.formBtns').fadeIn();
})

$('[editForm]').on('reset', function (e) {
    $('.formBtns').hide();
})

// input events
$(document).on('input', '[priceInput]', async function () {
    let value = $(this).val().replace(/,/g, '');
    let hiddenInputId = $(this).attr('hiddenInputId') || $(this).attr('id');

    if (!isNaN(parseFloat(value)) && isFinite(value)) {
        $(this).val(Number(value).toLocaleString());

        $(`#${hiddenInputId}`).val(value);
    }
})

// step forms
$(document).on('change', '#currentStep', async function () {
    let currentStep = $(this).val();
    let stepLis = $('#steps-graph li')
    //let currentStepLi = $('#steps-graph').find(`[data-step-number='${currentStep}']`);

    stepLis.each(function (index, element) {
        let elementStep = $(this).data('step-number');
        let elementIcon = $(this).find('.step-header');

        if (elementStep <= currentStep) {
            elementIcon.removeClass();

            elementIcon.addClass('step-header mask is-hexagon bg-primary text-white dark:bg-accent');
        } else {
            elementIcon.removeClass();

            elementIcon.addClass('step-header mask is-hexagon bg-slate-200 text-slate-500 dark:bg-navy-500 dark:text-navy-100');
        }
    })
})

// common functions

async function fillPageId(id) {
    $("#CurrentPage").val(id);
    $("#filter-search").trigger("submit");
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

async function showErrorToasterSWAL(message, position = "bottom-end") {
    await swal.fire({
        timer: 2500,
        toast: true,
        position: position,
        timerProgressBar: true,
        showConfirmButton: false,
        icon: "error",
        title: message || 'عملیات شـکست خورد'
    });
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

    if (htmlContent) {
        await element.html(htmlContent);

        await convertToIranianPriceWithTomanFormat();
        await convertToPriceWithDollarFormat();
    }
}

async function convertToIranianPriceWithTomanFormat() {
    const priceTomanFormats = $('[priceTomanFormat]');
    $.each(priceTomanFormats, function (index, value) {
        let columnValue = $(this).text().replace(/,/g, '');

        if (!isNaN(parseFloat(columnValue)) && isFinite(columnValue)) {
            $(this).text(`${Number(columnValue).toLocaleString()} تومـان`);
        }
    });
}

async function convertToPriceWithDollarFormat() {
    const priceTomanFormats = $('[priceDollarFormat]');
    $.each(priceTomanFormats, function (index, value) {
        let columnValue = $(this).text().replace(/,/g, '');

        if (!isNaN(parseFloat(columnValue)) && isFinite(columnValue)) {
            $(this).text(`${Number(columnValue).toLocaleString()} دلار`);
        }
    });
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

// common data
function getAllYearMonthsName() {
    return ["فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "ابان", "آذر", "دی", "بهمن", "اسفند"];
}