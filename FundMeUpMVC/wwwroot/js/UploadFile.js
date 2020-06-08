
  async function AJAXSubmit(oFormElement) {
    var resultElement = oFormElement.elements.namedItem("result");
    const formData = new FormData(oFormElement);

    try {
      const response = await fetch(oFormElement.action, {
    method: 'POST',
        body: formData
      });

      if (response.ok)
      {
        window.location.href = '/';
      }

      resultElement.value = 'Result: ' + response.status + ' ' +
        response.statusText;
    } catch (error) {
    console.error('Error:', error);
    }
  }


function douUpload() {

  actionMethod = "POST"
  actionUrl = "/home/CreateUsingAjaX"

  var formData = new FormData();
  alert("Gotya");
  for (var i = 0; i < $('#MyImage').length; i++) {
    formData.append("MyImage", $('#MyImage')[0].files[i]);
  }


  //alert(JSON.stringify(Object.fromEntries(formData)))

  $.ajax({
    url: actionUrl,
    dataType: 'json',

    type: actionMethod,
    data: formData,

    contentType: false,  // important when sending formData
    processData: false,
    success: function (data) {
      $('#responseDiv').html("The update has been made successfully " + data["returnValue"]);

    },
    error: function (jqXhr, textStatus, errorThrown) {
      console.log(errorThrown);
    }
  });


}