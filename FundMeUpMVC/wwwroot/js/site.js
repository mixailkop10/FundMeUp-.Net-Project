function loginButton() {

    var buttons = document.getElementsByClassName("button");
    for (let i = 0, l = buttons.length; i < l; i++) {
        if (i == 1) {
            buttons[i].addEventListener('click', function loginButtonB() {

                actionMethod = "POST"
                actionUrl = "/ApiBacker/Login"
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
                            $('#responseDiv').html("There is no such backer");
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
            });
        }
        else if (i == 2){
            buttons[i].addEventListener('click', function loginButtonPC() {

                actionMethod = "POST"
                actionUrl = "/ApiProjectCreator/Login"
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
                            $('#responseDiv').html("There is no such projectCreator");
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
            });
        }      
    }
}