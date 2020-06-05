
// .click() vs .on('click')

/* -------- Issue - Click doesn’t work after AJAX load -------------
 * Delegated events have the advantage that they can process events
 * from descendant elements that are added to the document at a later time
 */
$(document).on('click', "#btnCheckDates", function () {
    var dateTo = $('#dateTo').val();
    var dateFrom = $('#dateFrom').val();

    if (dateFrom >= dateTo) {
        alert("Oop! dateTo must be later than dateFrom.");
    }
    else {
        //location.href = '/ProjectCreator/Dashboard';
        actionMethod = "POST"
        actionUrl = "/ProjectCreator/Dashboard"
        sendData = {
            "SearchStartDate": dateFrom,
            "SearchEndDate": dateTo
        }
        alert(JSON.stringify(sendData))
        $.ajax({
            url: actionUrl,
            //dataType: 'json',
            type: actionMethod,
            data: JSON.stringify(sendData),

            contentType: 'application/json; charset=utf-8',
            processData: false,
            async: true,
            success: function (data, textStatus, jQxhr) {
                //var newTarget = $("#acceptedBP").html(data)
                //$("#acceptedBP").html(newTarget);
                $("#content").html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    }
});