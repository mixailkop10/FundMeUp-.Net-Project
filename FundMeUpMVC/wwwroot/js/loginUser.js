    function loginButtonB() {

        actionMethod = "POST"
        actionUrl = "/ApiBacker/LoginBacker"
        sendData = {
            "Email": $('#Email').val(),
            "Password": $('#Password').val()
        }
        $.ajax({
            url: actionUrl,
            dataType: 'json',
            type: actionMethod,
            data: JSON.stringify(sendData),

            contentType: 'application/json',
            processData: false,
            success: function (data, textStatus, jQxhr) {
                if (data == null) {
                    $('#responseDiv').html("ΛΑΘΟΣ ΑΛΗΘΕΙΑΣ");
                }
                else {
                    //backer = JSON.stringify(data)
                    //ln = data["lastname"];
                    //localStorage.setItem("Backer", backer);
                    //document.getElementById("userlog").value = `${ln}(LogOut)`;
                    //user = JSON.parse(localStorage.getItem('backer'));
                    //dummy comment

                    backerId = data["id"]
                    localStorage.setItem("backerId", backerId)
                    window.open(`/Backer/Dashboard/${backerId}`, "_self")

                   // window.open(`/Backer/Dashboard/${data.id}`, "_self");
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })
    };

    function loginButtonPC() {

        actionMethod = "POST"
        actionUrl = "/ApiProjectCreator/LoginProjectCreator"
        sendData = {
            "Email": $('#EmailC').val(),
            "Password": $('#PasswordC').val()
        }
        $.ajax({
            url: actionUrl,
            dataType: 'json',
            type: actionMethod,
            data: JSON.stringify(sendData),

            contentType: 'application/json',
            processData: false,
            success: function (data, textStatus, jQxhr) {
                if (data == null) {
                    $('#responseDiv').html("ΛΑΘΟΣ ΑΛΗΘΕΙΑΣ");
                }
                else {
                    //creator = JSON.stringify(data)
                    //ln = data["lastname"];
                    //localStorage.setItem("Creator", creator);
                    //document.getElementById("userlog").value = `${ln}(LogOut)`;
                    ////user = JSON.parse(localStorage.getItem('creator'));

                    //window.open(`/ProjectCreator/Dashboard/${data.id}`, "_self");


                    creatorId = data["id"]
                    localStorage.setItem("creatorId", creatorId)
                    window.open(`/ProjectCreator/Dashboard/${creatorId}`, "_self")
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })
};

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
                    if (user == "Backer") { loginButtonB(); }
                    if (user == "Creator") { loginButtonPC(); }
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
