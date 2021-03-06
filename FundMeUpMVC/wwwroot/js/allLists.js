﻿function loadProjects() {
	actionMethod = "GET"
	actionUrl = "/ApiProject/AllProjects"

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
				tr.append("<td>" + data[i]["budgetGoal"] + "</td>");
				tr.append("<td>" + data[i]["balance"] + "</td>");
				tr.append("<td>" + data[i]["statusUpdate"] + "</td>");
				tr.append("<td>" + data[i]["available"] + "</td>");
				tr.append("<td>" + data[i]["funded"] + "</td>");
				tr.append("<td>" + "<a class='btn-sm btn-secondary' href='/Project/Project/" + data[i]["id"] + "' ><span><i class='fa fa-list-alt'></i></span></a>  <a class='btn-sm btn-warning' href = '/Project/ProjectPage/" + data[i]["id"] + "' ><span><i class='fa fa-edit'></i></span></a> "+ "</td > ");
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

function readyP(callback) {
    // in case the document is already rendered
    if (document.readyState != 'loading') callback();
    // modern browsers
    else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
    // IE <= 8
    else document.attachEvent('onreadystatechange', function () {
        if (document.readyState == 'complete') callback();
    });
}

readyP(function () {
	// do something
	loadProjects()
});

function loadBackers() {
	actionMethod = "GET"
	actionUrl = "/ApiBacker/AllBackers"

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {

			for (var i = 0, len = data.length; i < len; i++) {

				tr = $('<tr>');
				tr.append("<td>" + data[i]["firstName"] + "</td>");
				tr.append("<td>" + data[i]["lastName"] + "</td>");
				tr.append("<td>" + data[i]["profession"] + "</td>");
				tr.append("<td>" + data[i]["address"] + "</td>");
				tr.append("<td>" + data[i]["email"] + "</td>");
				tr.append("<td>" + "<a class='btn-sm btn-warning' href = '/Backer/BackerPage/" + data[i]["id"] + "' >< span > <i class='fa fa-edit'></i></span ></a > " + "</td > ");
				tr.append('</tr>');
				$('#resultTable').append(tr);
			}
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
		}
	});
}

function readyB(callback) {
	// in case the document is already rendered
	if (document.readyState != 'loading') callback();
	// modern browsers
	else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
	// IE <= 8
	else document.attachEvent('onreadystatechange', function () {
		if (document.readyState == 'complete') callback();
	});
}

readyB(function () {
	// do something
	loadBackers()
});

function loadProjectCreators() {
	actionMethod = "GET"
	actionUrl = "/ApiProjectCreator/AllProjectCreators"

	$.ajax({
		url: actionUrl,
		type: actionMethod,
		contentType: 'application/json',
		processData: false,
		success: function (data, textStatus, jQxhr) {

			for (var i = 0, len = data.length; i < len; i++) {

				tr = $('<tr>');
				tr.append("<td>" + data[i]["firstName"] + "</td>");
				tr.append("<td>" + data[i]["lastName"] + "</td>");
				tr.append("<td>" + data[i]["address"] + "</td>");
				tr.append("<td>" + data[i]["email"] + "</td>");
				tr.append("<td>" + "<a class='btn-sm btn-warning' href = '/ProjectCreator/ProjectCreatorPage/" + data[i]["id"] + "' >< span > <i class='fa fa-edit'></i></span ></a > " + "</td > ");
				tr.append('</tr>');
				$('#resultTable').append(tr);
			}
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
		}
	});
}

function readyPC(callback) {
	// in case the document is already rendered
	if (document.readyState != 'loading') callback();
	// modern browsers
	else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
	// IE <= 8
	else document.attachEvent('onreadystatechange', function () {
		if (document.readyState == 'complete') callback();
	});
}

readyPC(function () {
	// do something
	loadProjectCreators()
});



