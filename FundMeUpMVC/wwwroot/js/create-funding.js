function postFunding(bid, pid, rid) {
    //backerid = parseInt(localStorage.getItem("backerId"));
    backerid = parseInt(bid);
    projectid = parseInt(pid);
    fund = parseFloat($('#fund').val()) || 0;
    rewardid = parseInt(rid);

    actionMethod = "POST"
    actionUrl = "/ApiBackerProject/CreateBackerProject"
    sendData = {
        "BackerId": backerid,
        "ProjectId": projectid,
        "Fund": fund,
        "RewardId": rewardid
        //"RewardId": $(".list-group a :active").attr("id")
    }
    alert(JSON.stringify(sendData));
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        //data: sendData,
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            //$('#responseDiv').html(JSON.stringify(data));
            alert(JSON.stringify(data));
            if (data != null)
            {
                //var projectid = parseInt(data["projectId"]);
                //var projectid = JSON.parse(data["projectId"]);
                //$.ajax({
                //    url: "/ApiProject/UpdateBalance",
                //    type: "POST",
                //    contentType: 'application/json',
                //    //data: JSON.stringify({ "id": typeof(+data["projectId"])}),
                //    data: { id: data["projectId"]},
                //    //data: { "id": projectid },
                //    processData: false,
                //    success: function (results) {
                //        window.open(`/Backer/Dashboard`, "_self");
                //    }
                //});
            }
            //window.open(`/Backer/Dashboard/${backerid}`, "_self");
            window.open(`/Backer/Dashboard`, "_self");

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}