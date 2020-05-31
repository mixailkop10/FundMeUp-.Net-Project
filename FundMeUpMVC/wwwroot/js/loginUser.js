﻿    function loginButtonB() {

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
                    window.open("/Home/CreateProject")
                    //μεχρι να γινει το fundProject
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
                    projectCreatorId = data["id"]
                    window.open("/Home/CreateProject")
                }

            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        })
    };