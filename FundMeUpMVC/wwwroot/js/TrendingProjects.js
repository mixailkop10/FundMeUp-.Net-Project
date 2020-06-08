


function loadTProjects() {
	actionMethod = "GET"
	actionUrl = "/ApiProject/TrendingProjects"

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {

			for (var i = 0, len = data.length; i < len; i++) {
				
				tr = $('<tr  class="table-info">');
				tr.append("<td>" + data[i]["name"] + "</td>");
				tr.append("<td>" + data[i]["description"] + "</td>");
				tr.append("<td>" + data[i]["category"] + "</td>");
				sum = data[i].budgetGoal - data[i].balance;
				tr.append("<td>" + sum + "</td>");
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
	loadTProjects()
});



