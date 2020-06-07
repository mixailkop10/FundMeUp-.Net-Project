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
            //alert(JSON.stringify(data));
            //if (data != null)
            //{
            //    ///////// Prospatheia klisis ajax mesa se ajax /////////
            //    console.log(data);
            //    //x = parseInt(data.ProjectId);
            //    //var projectid = JSON.parse(data);
            //    $.ajax({
            //        url: "/ApiProject/UpdateBalance",
            //        type: "POST",
            //        //datatype: 'json',
            //        //contentType: 'application/json',
            //        contentType: 'application/x-www-form-urlencoded',  //paizei an fygei to [FromBody] apo ton ApiProjectController
            //        //data: JSON.stringify({ "id": typeof(+data["projectId"])}),
            //        //data: { "id": projectid },
            //        data: data.ProjectId,
            //        processData: false,
            //        success: function (results) {
            //            window.open(`/Backer/Dashboard`, "_self");
            //        }
            //    });
            //}
            window.open(`/Backer/Dashboard/${backerid}`, "_self");
            //window.open(`/Backer/Dashboard`, "_self");

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}