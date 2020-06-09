
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

//function ready(callback) {
//    // in case the document is already rendered
//    if (document.readyState != 'loading') callback();
//    // modern browsers
//    else if (document.addEventListener) document.addEventListener('DOMContentLoaded', callback);
//    // IE <= 8
//    else document.attachEvent('onreadystatechange', function () {
//        if (document.readyState == 'complete') callback();
//    });
//}

//ready(function () {
//    // do something
//    loadBackers()
//});
function deleteBacker(backerId) {
    actionMethod = "DELETE"
    actionUrl = "/ApiBacker/DeleteBacker"
    sendData = { "Id": backerId }
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            if (data == null) {
                $('#responseDiv').html("There is no such backer");
            }
            else {
                //to do
                $('#cusTable' + backerId).remove()
                //     window.open("/Home/Customer", "_self")
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}