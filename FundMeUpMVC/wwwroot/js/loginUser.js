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
                    backerId = data["id"]
                    ln=data["lastname"]
                    localStorage.setItem("userId", backerId)
                    document.getElementById("userlog").value= `${ln}(LogOut)`;
                    window.open(`/Backer/Dashboard/${backerId}`,"_self")
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
                    creatorId = data["id"]
                    ln = data["lastname"]
                    localStorage.setItem("userId", creatorId)
                    document.getElementById("userlog").value = `${ln}(LogOut)`;
                    window.open(`/ProjectCreator/Dashboard/${creatorId}`, "_self")
                }
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })
    };