


function ProjectsByCategory(mycategory) {
	
	
	actionMethod = "GET"
	actionUrl = "/ApiProject/Category/"+mycategory
	


	console.log("prin to ajax")

	$.ajax({
		url: actionUrl,
		//dataType: 'json',
		type: actionMethod,
		//data: JSON.stringify(sendData),
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			document.getElementById("test").innerHTML = "ola kala"
			console.log("ola kala")
			console.log(data)

		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			console.log("lathos")
			document.getElementById("test").innerHTML = "egine malakia"
		}
	});
}



//function ready(callback) {
//	// in case the document is already rendered
//	if (document.readyState != 'loading') callback();
//	// modern browsers
//	else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
//	// IE <= 8
//	else document.attachEvent('onreadystatechange', function () {
//		if (document.readyState == 'complete') callback();
//	});
//}


x = document.getElementById("cat").innerHTML
ProjectsByCategory(x)

//ready(function () {
//	// do something
	
//});