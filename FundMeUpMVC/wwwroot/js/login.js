$('#loginButton').click(
    function () {

        actionMethod = "POST"
        actionUrl = "/ApiBacker/Login"
        sendData = {
            "Email": $('#Email').val()
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
                    $('#responseDiv').html("There is no such backer");
                }
                else {
                    backerId = data["id"]
                    window.open("/Home/CreateProject")
                }

            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })
    }
    );