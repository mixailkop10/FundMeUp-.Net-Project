
function Project() {

	actionMethod = "GET"
	actionUrl = `/ApiProject/Project/${x}`

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
			document.getElementById("BudgetGoal").value=data["budgetGoal"]
		
			//tr.append("<td>" + data[i]["name"] + "</td>");
			//tr.append("<td>" + data[i]["description"] + "</td>");
			//tr.append("<td>" + data[i]["category"] + "</td>");
			//tr.append("<td>" + data[i]["budgetGoal"] + "</td>");
			//tr.append("<td>" + data[i]["balance"] + "</td>");
			//tr.append("<td>" + data[i]["statusUpdate"] + "</td>");
			//tr.append("<td>" + data[i]["available"] + "</td>");
			//tr.append("<td>" + data[i]["funded"] + "</td>");
			//tr.append("<td>" + "<a href='/Project/ProjectPage/" + data[i]["id"] + "' >Edit</a>" + "</td>");
			//tr.append('</tr>');
			//$('#resultTable').append(tr);
			console.log( data)
			
		},

		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("test").innerHTML = "egine malakia"
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

function submitToServer() {
	actionMethod = "PUT"
	actionUrl = `/ApiProject/Project/${x}`
	y = $('#BudgetGoal').val()
	console.log(y)
	x = parseFloat(y)
	console.log(x)



	sendData = {
		"Name": $('#Name').val(),
		"Description": $('#Description').val(),
		"DoA": $('#DoA').val(),
		"BudgetGoal": x,
		"Category": $('#Category').val(),
		"StatusUpdate": $('#StatusUpdate').val()
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
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
		}
	});

}

	let url = window.location.href;
	let params = url.split('/');
	let x = params[params.length - 1]

    ready(function () {
		// do something
		Project()
	});

