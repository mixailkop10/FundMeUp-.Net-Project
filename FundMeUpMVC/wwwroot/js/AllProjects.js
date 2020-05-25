


function loadProjects() {
	actionMethod = "GET"
	actionUrl = "/ApiProject/AllProjects"

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {

			for (var i = 0, len = data.length; i < len; i++) {

				tr = $('<tr>');
				tr.append("<td>" + data[i]["name"] + "</td>");
				tr.append("<td>" + data[i]["description"] + "</td>");
				tr.append("<td>" + data[i]["category"] + "</td>");
				tr.append("<td>" + data[i]["budgetGoal"] + "</td>");
				tr.append("<td>" + data[i]["balance"] + "</td>");
				tr.append("<td>" + data[i]["statusUpdate"] + "</td>");
				tr.append("<td>" + data[i]["available"] + "</td>");
				tr.append("<td>" + data[i]["funded"] + "</td>");
				tr.append("<td>" + "<a href='/Project/ProjectPage/" + data[i]["id"]+"' >Edit</a>" + "</td>");
				tr.append('</tr>');
				$('#resultTable').append(tr);
				console.log(i,len,data)
			}



		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
			document.getElementById("test").innerHTML="egine malakia"
		}
	});

}

