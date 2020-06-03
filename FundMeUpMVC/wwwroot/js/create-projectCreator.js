// Write your JavaScript code.
function submitToServer() {
    actionMethod = "POST"
    actionUrl = "/ApiProjectCreator/CreateProjectCreator"
    sendData = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "Address": $('#Address').val(),
        "Email": $('#Email').val(),
        "Password": $('#Password').val()
    }
    alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

}
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                else { submitToServer(); }
                form.classList.add('was-validated');
                //submitToServer();
            }, false);
        });
    }, false);
})();
//submitToServer();