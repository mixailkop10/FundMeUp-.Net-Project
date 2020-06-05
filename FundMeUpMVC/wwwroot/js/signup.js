// Write your JavaScript code.
function submitToServerBacker() {
    actionMethod = "POST"
    actionUrl = "/ApiBacker/CreateBacker"
    sendData = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "Profession": $('#Profession').val(),
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
            alert("fwfw")
            window.open("/Project/AllProjects", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

}

function submitToServerCreator() {
    actionMethod = "POST"
    actionUrl = "/ApiProjectCreator/CreateProjectCreator"
    sendData = {
        "FirstName": $('#FirstNameC').val(),
        "LastName": $('#LastNameC').val(),
        "Address": $('#AddressC').val(),
        "Email": $('#EmailC').val(),
        "Password": $('#PasswordC').val()
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
            console.log(data)
            
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
    window.open("/Project/AllProjects", "_self")
}


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
                else {
                    if (user == "Backer") { submitToServerBacker(); }
                    else /*(user == "Creator") */{ submitToServerCreator(); }
                }
                form.classList.add('was-validated');
                
            }, false);
        });
    }, false);
})();

function GetUser(id) {
    user = id
    console.log(user)
}

let user = "Backer";
let x;
