  $('#loginvalidate').click(function () {
        var data = {
            "username": $("#username").val(),
            "password": $("#password").val()
        };
        $.ajax({
            url: "/Home/validateuser",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                
                if (response.Success) {
                    Swal.fire({
                        icon: 'Success',
                        title: 'Success',
                        text: 'Login Successfully!',
                        timer: 3000,
                        timerProgressBar: true,
                        showConfirmButton: false
                    }).then(() => {
                        window.location.href = "/Employee/Index";
                    });
                }
                else {
                    Swal.fire({
                        icon: 'Failed',
                        title: 'Failed',
                        text: 'Invalid Username Password!',
                        timer: 3000,
                        timerProgressBar: true,
                        showConfirmButton: false
                    }).then(() => {
                        
                    });
                }
            },
            error: function (e) {
                Swal.fire({
                    icon: 'Failed',
                    title: 'Failed',
                    text: 'Invalid Username Password!',
                    timer: 3000,
                    timerProgressBar: true,
                    showConfirmButton: false
                }).then(() => {

                });
            }
        });

  });



function EmpDelete(id) {
    
    $.ajax({
        url: "/Employee/Delete",
        type: "POST",
        data: { id: id },
        success: function (response) {
            if (response) {
                Swal.fire({
                    icon: 'Delete',
                    title: 'Delete',
                    text: 'Employee Detail Deleted Successfully!',
                    timer: 3000,
                    timerProgressBar: true,
                    showConfirmButton: false
                }).then(() => {
                    window.location.href = "/Employee/Index";
                });
            }
        },
        error: function (e) {
            window.location.href = "/Employee/Index";
        }
    });
}
function EditEmployee(id) {
    debugger;
    var EmpID=id;
    var EmployeeName = $("#EmployeeName").val();
    var PhoneNumber = $("#PhoneNumber").val();
    var Description = $("#Description").val();
    var EmailID = $("#EmailID").val();
    var UserID = $("#UserID").val();
    var Pwd = $("#Pwd").val();
    var EmpRank = $("#EmpRank").val();


    if (EmployeeName == "" || EmployeeName == "undefined") {
        $("#EmployeeName").focus();
        return false;
    }
    if (UserID == "" || UserID == "undefined") {
        $("#UserID").focus();
        return false;
    }
    if (Pwd == "" || Pwd == "undefined") {
        $("#Pwd").focus();
        return false;
    }

    var data = {

        "EmpID": EmpID,
        "EmployeeName": EmployeeName,
        "PhoneNumber": PhoneNumber,
        "Description": Description,
        "EmailID": EmailID,
        "UserID": UserID,
        "Pwd": Pwd,
        "EmpRank": EmpRank,

    };
    $.ajax({
        url: "/Employee/EditEmployee",
        type: "POST",
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            if (response) {
                console.log(response);
                Swal.fire({
                    icon: 'success',
                    title: 'Saved',
                    text: 'Employee has been saved successfully',
                    timer: 3000,
                    timerProgressBar: true,
                    showConfirmButton: false
                }).then(() => {
                    window.location.href = "/Employee/Index";
                });
            }

        },
        error: function (e) {
            Swal.fire({
                icon: 'Failed',
                title: 'Failed',
                text: 'Employee Details Saved Failed',
                timer: 3000,
                timerProgressBar: true,
                showConfirmButton: false
            }).then(() => {
                window.location.href = "/Employee/Index";
            });
        }
    });




  
}


$(document).ready(function () {
    $('#PhoneNumber').on('input', function () {
        var phone = $(this).val();
        if (phone.length > 10 || isNaN(phone)) {
            $(this).val('');
        }
    });
});


function validateEmail() {
    var email = document.getElementById("EmailID").value;
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(email)) {
        alert("Invalid email format.");
        return false;
    }
    return true;
}



$('#SaveEmployee').click(function () {

  
    var EmployeeName = $("#EmployeeName").val();   
    var PhoneNumber = $("#PhoneNumber").val();
    var Description = $("#Description").val();
    var EmailID = $("#EmailID").val();
    var UserID = $("#UserID").val();
    var Pwd = $("#Pwd").val();
    var EmpRank = $("#EmpRank").val();
   

    if (EmployeeName == "" || EmployeeName == "undefined") {
        $("#EmployeeName").focus();
        return false;
    }
    if (UserID == "" || UserID == "undefined") {
        $("#UserID").focus();
        return false;
    }
    if (Pwd == "" || Pwd == "undefined") {
        $("#Pwd").focus();
        return false;
    }
    
    var data = {
        "EmployeeName": EmployeeName,
        "PhoneNumber": PhoneNumber,
        "Description": Description,
        "EmailID": EmailID,
        "UserID": UserID,
        "Pwd": Pwd,
        "EmpRank": EmpRank,
        
    };
    $.ajax({
        url: "/Employee/InsertData",
        type: "POST",
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            if (response) {
                console.log(response);
                Swal.fire({
                    icon: 'success',
                    title: 'Saved',
                    text: 'Employee has been saved successfully',
                    timer: 3000,
                    timerProgressBar: true,
                    showConfirmButton: false
                }).then(() => {
                    window.location.href = "/Employee/Index";
                });
            }

        },
        error: function (e) {
            Swal.fire({
                icon: 'Failed',
                title: 'Failed',
                text: 'Employee Details Saved Failed',
                timer: 3000,
                timerProgressBar: true,
                showConfirmButton: false
            }).then(() => {
                window.location.href = "/Employee/Index";
            });
        }
    });
});

