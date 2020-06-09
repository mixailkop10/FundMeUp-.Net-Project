function Project() {

	actionMethod = "GET"
	actionUrl = `/ApiProject/Project/${x}`

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			
			document.getElementById("Name").innerHTML = data["name"]
			document.getElementById("Description").innerHTML = data["description"]
			document.getElementById("StatusUpdate").innerHTML = data["statusUpdate"]
			document.getElementById("TotalFund").innerHTML = `Total Fund : ${data["balance"]} € `
			document.getElementById("BudgetGoal").innerHTML = `BudgetGoal : ${data["budgetGoal"]} €`
			document.getElementById("MyImage").src = data["fileName"]
			
			console.log(data)

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
let x = params[params.length - 1]

ready(function () {
	// do something
	Project()
});