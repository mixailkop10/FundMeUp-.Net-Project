
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

function deleteProjectCreator(projectCreatorId) {
    actionMethod = "DELETE"
    actionUrl = "/ApiProjectCreator/DeleteProjectCreator"
    sendData = { "Id": projectCreatorId }
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            if (data == null) {
                $('#responseDiv').html("There is no such projectCreator");
            }
            else {
                //to do
                $('#cusTable' + projectCreatorId).remove()
                //     window.open("/Home/Customer", "_self")
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}