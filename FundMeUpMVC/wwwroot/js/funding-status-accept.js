function postStatus(fundingId) {
    actionMethod = "POST"
    actionUrl = "/BackerProject/PostStatus",
        sendData = {
            "id": fundingId,
            "accept": $('#accept').val()
        }

    //alert(JSON.stringify(sendData))
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: sendData,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        //data: JSON.stringify(sendData),
        //contentType: 'application/json',
        //processData: false,
        //async: false
        success:
            function (link) {
                //alert("!!!!!")
                window.location.href = link;
            },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}