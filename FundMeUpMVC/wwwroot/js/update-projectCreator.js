function ProjectCreator(){

	actionMethod = "GET"
	actionUrl = `/ApiProjectCreator/ProjectCreator/${id}`

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			$("#NameAhead").html(data["firstName"] + " " + data["lastName"])
			document.getElementById("FirstName").value = data["firstName"]
			document.getElementById("LastName").value = data["lastName"]
			document.getElementById("Address").value = data["address"]
			document.getElementById("Email").value = data["email"]
			document.getElementById("Password").value = data["password"]

			console.log(data)

		},

		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("responseDiv").innerHTML = "λαθος αληθειας"
		}
	});

}

function UpdatePC() {
	actionMethod = "PUT"
	actionUrl = `/ApiProjectCreator/EditProjectCreator/${id}`

	sendData = {
		"FirstName": $('#FirstName').val(),
		"LastName": $('#LastName').val(),
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
			window.open(`/ProjectCreator/IndexDashboard/${id}`, "_self")
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			$('#responseDiv').html("lathos ");
		}
	});

}

function DeletePC() {

	actionMethod = "DELETE"
	actionUrl = `/ApiProjectCreator/DeleteProjectCreator/${id}`
	console.log(actionUrl)
	sendData = {
		"Id": id
	}
	alert(sendData)
	$.ajax({
		url: actionUrl,
		dataType: 'json',
		type: actionMethod,
		data: JSON.stringify(sendData),


		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			console.log(data)
			console.log("fwefcacaa")
			window.open("/Home/Index", "_self")
		},

		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("responseDiv").innerHTML = "egine lathos"
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
	ProjectCreator()
});