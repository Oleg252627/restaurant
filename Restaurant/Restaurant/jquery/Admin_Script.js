$(function() {
    $(".ajax_check").on('click',
        function() {
            $('#more').text("");
        });
});

function ShowImagePreview(imageUploader,previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        let reader = new FileReader();
        reader.onload = function(e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function jQueryPost(form) {
    $.validator.unobtrusive.parse(form);
    if ((form).valid()) {
        let config = {
            type: "POST",
            url: form.action,
            data: new FormData(form),
            success: function(response) {

            }
        }
        if ($(form).attr('enctype') == 'multipart/form-data') {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);
    } else {
        return false;
    }
}

