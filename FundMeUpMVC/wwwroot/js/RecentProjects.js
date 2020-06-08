
function loadRProjects() {
	actionMethod = "GET"
	actionUrl = "/ApiProject/RecentProjects"

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {
			console.log(JSON.stringify(data))
			for (var i = 0, len = data.length; i < len; i++) {

				tr = $('<tr  class="table-info">');
				tr.append("<td>" + data[i]["name"] + "</td>");
				tr.append("<td>" + data[i]["description"] + "</td>");
				tr.append("<td>" + data[i]["category"] + "</td>");
				tr.append("<td>" + data[i]["budgetGoal"] + "</td>");
				tr.append("<td>" + data[i]["balance"] + "</td>");
				tr.append("<td>" + data[i]["statusUpdate"] + "</td>");
				tr.append("<td>" + data[i]["available"] + "</td>");
				tr.append("<td>" + data[i]["funded"] + "</td>");
				mydate = data[i]["doA"].substring(0, 10);
				tr.append("<td>" + mydate + "</td>");
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

ready(function () {
	// do something
	loadRProjects()
});



