// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function CreateProjectJS() {

    actionMethod = "POST"
    actionUrl = "/ApiProject/CreateProject"
    y = $('#BudgetGoal').val()
    console.log(y)
    x = parseFloat(y)
    console.log(x)

    creatorid = parseInt(localStorage.getItem("creatorId"));
    console.log(creatorid, typeof (creatorid));

  var formData = new FormData();
  for (var i = 0; i < $('#FileUpload_FormFile').length; i++) {
    formData.append("MyImage", $('#FileUpload_FormFile')[0].files[i]);
  }
  formData.append("Name", $('#Name').val());
  formData.append("Description", $('#Description').val());
  formData.append("DoA", $('#DoA').val());
  formData.append("BudgetGoal", x);
  formData.append("Category", $('#Category').val());
  formData.append("StatusUpdate", $('#StatusUpdate').val());
  formData.append("ProjectCreatorId", creatorid);






    $.ajax({
        url: actionUrl,
        dataType: 'json',
      type: actionMethod,
      data: formData,

        contentType: false,
        processData: false,
        success: function (data, textStatus, jQxhr) {
            
               alert(JSON.stringify(data))
               window.open(`/ProjectCreator/IndexDashboard/${creatorid}`, "_self")

            
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
            $('#responseDiv').html("Please complete all the fields");
        }
    });
    
}; 
// Example starter JavaScript for disabling form submissions if there are invalid fields
//(function() {
//        'use strict';
//  window.addEventListener('load', function() {
//    // Fetch all the forms we want to apply custom Bootstrap validation styles to
//    var forms = document.getElementsByClassName('needs-validation');
//    // Loop over them and prevent submission
//    var validation = Array.prototype.filter.call(forms, function(form) {
//        form.addEventListener('submit', function (event) {
//            if (form.checkValidity() === false) {
//                event.preventDefault();
//                event.stopPropagation();
//            }
//            else { CreateProjectJS(); }
//            form.classList.add('was-validated');
           
//        }, false);
//    });
//  }, false);
//})();


