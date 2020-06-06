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
    


    sendData = {
        "Name": $('#Name').val(),
        "Description": $('#Description').val(),
        "DoA": $('#DoA').val(),
        "BudgetGoal": x,
        "Category": $('#Category').val(),
        "StatusUpdate": $('#StatusUpdate').val()
    }

    


    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            
               alert(JSON.stringify(data))
               window.open('/Project/AllProjects', "_self")

            
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


