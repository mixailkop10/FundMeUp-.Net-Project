function Backer() {

	actionMethod = "GET"
	actionUrl = `/ApiBacker/Backer/${id}`

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			$("#NameAhead").html(data["firstName"] + " " + data["lastName"])
			document.getElementById("FirstName").value = data["firstName"]
			document.getElementById("LastName").value = data["lastName"]
			document.getElementById("Profession").value = data["profession"]
			document.getElementById("Address").value = data["address"]
			document.getElementById("Email").value = data["email"]
			document.getElementById("Password").value = data["password"]

			console.log(data)

		},

		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("responseDiv").innerHTML = "egine lathos"
		}
	});

}

function Update() {
	actionMethod = "PUT"
	actionUrl = `/ApiBacker/EditBacker/${id}`

	sendData = {
		"FirstName": $('#FirstName').val(),
		"LastName": $('#LastName').val(),
		"Profession": $('#Profession').val(),
		"Address": $('#Address').val(),
		"Email": $('#Email').val(),
		"Password": $('#Password').val(),
		"Id": id
	}

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
			$('#responseDiv').html("lathos ");
		}
	});

}

function ready(callback) {
	// in case the document is already rendered
	if (document.readyState != 'loading') callback();
	// modern browsers
	else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
	// IE <= 8
	else document.attachEvent('onreadystatechange', function () {
		if (document.readyState == 'complete') callback();
	});
}

let url = window.location.href;
let params = url.split('/');
let id = params[params.length - 1]
console.log(typeof (id))

ready(function () {
	// do something
	Backer()
});