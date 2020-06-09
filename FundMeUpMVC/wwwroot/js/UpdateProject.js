
function Project() {

	actionMethod = "GET"
	actionUrl = `/ApiProject/Project/${id}`

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr)
		{
			$("#NameAhead").html(data["name"])
			document.getElementById("Name").value = data["name"]
			document.getElementById("Description").value=data["description"]
			document.getElementById("Cat").value=data["category"]
			document.getElementById("BudgetGoal").value = data["budgetGoal"]
			document.getElementById("StatusUpdate").value = data["statusUpdate"]
			//document.getElementById("DelButton").value = data["id"]
		
			
			console.log( data)
			
		},

		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("responseDiv").innerHTML = "egine lathos"
		}
	});

}

function Delete() {
	
	actionMethod = "DELETE"
	actionUrl = `/ApiProject/DeleteProject/${id}`
	console.log(actionUrl)
	sendData = {
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
			console.log(data)
			console.log("fwefcacaa")
			window.open("/Project/AllProjects", "_self")
		},

		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("responseDiv").innerHTML = "egine lathos"
		}
	});
}
	

function Update() {
	actionMethod = "PUT"
	actionUrl = `/ApiProject/Project/${id}`
	y = $('#BudgetGoal').val()
	console.log(y)
	w = parseFloat(y)
	console.log(w)



	sendData = {
		"Name": $('#Name').val(),
		"Description": $('#Description').val(),
		"DateOfCreation": $('#DateOfCreation').val(),
		"BudgetGoal": w,
		"Category": $('#Category').val(),
		"StatusUpdate": $('#StatusUpdate').val()
	}

	alert(JSON.stringify(sendData))
	//alert(JSON.stringify(actionUrl))


	$.ajax({
		url: actionUrl,
		dataType: 'json',
		type: actionMethod,
		data: JSON.stringify(sendData),

		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			window.open(`/BackerProject/ProjectFunding/${id}`)
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			$('#responseDiv').html("lathos ");
		}
	});

}

function CreatePackage()
{
	actionMethod = "POST"
	actionUrl = `/ApiReward/AddReward`
	y = $('#Price').val()
	console.log(y)
	x = parseFloat(y)
	console.log(x)
	ProjId = parseInt(id)


	sendData = {
		"Name":"den exei" ,
		"Description": $('#RewardDescription').val(),
		"ProjectId": ProjId,
		"Price": x,
	
	}

	alert(JSON.stringify(sendData))
	


	$.ajax({
		url: actionUrl,
		dataType: 'json',
		type: actionMethod,
		data: JSON.stringify(sendData),

		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			$('#responseDiv').html(JSON.stringify(data));
			window.open(`/Project/Project/${id}`, "_self")
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log("lathos");
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
console.log(typeof(id))


    ready(function () {
		// do something
		Project()
	});

