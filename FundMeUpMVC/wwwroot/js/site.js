

function ProjectsByCategory(category) {
	console.log(category)
	actionMethod = "GET"
	actionUrl = "/ApiProject/Category"
	sendData = { "Category": category }
	alert("prin to ajax")

	$.ajax({
		url: actionUrl,
		dataType: 'json',
		type: actionMethod,
		data: JSON.stringify(sendData),
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			document.getElementById("test").innerHTML = "ola kala"
			console.log(data[1])

		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("test").innerHTML = "egine malakia"
		}
	});
}

