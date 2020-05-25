
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
				tr.append('</tr>');
				$('#resultTable').append(tr);

			}
		},
		error: function (jqXhr, textStatus, errorThrown) {
			console.log(errorThrown);
		}
	});

}