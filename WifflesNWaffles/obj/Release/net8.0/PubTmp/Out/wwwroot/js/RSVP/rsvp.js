// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var elements = {

    form: $('#RSVP'),
    firstname: $('#firstname'),
    lastname: $('#lastname'),
    email: $('#email'),
    phone: $('#phone'),
    topping: $('#topping'),
    attendance: $('#attendance'),
    successMessage: $('#RSVPSuccessMessage'),
    attendeesButton: $('#attendeesButton'),
    

}


const initialize = function () {

    elements.attendeesButton.click(viewAttendees);
    


}

const viewAttendees = function () {
    
    document.location.href = "/home/attendees";
}



document.getElementById("RSVP").addEventListener("submit", function (event) {
    event.preventDefault();

    alert("form submitted");

    var firstname = elements.firstname.val();
    var lastname = elements.lastname.val();
    var email = elements.email.val();
    var phone = elements.phone.val();
    var topping = elements.topping.val();
    var attendance = elements.attendance.val();

    let formData = {

        firstname: firstname,
        lastname: lastname,
        email: email,
        phoneNumber: phone,
        topping: topping,
        attendance: Number(attendance),

    }

    $.ajax({
        url: '/Home/Submit', // Replace with your actual action method URL
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(formData),
        success: function (response) {
            if (response.success) {
                elements.successMessage.css("display", "");
                elements.attendeesButton.css("display", "");
                elements.form[0].reset();

                elements.form.css("display", "none");
                

            } else {
                alert("Failed to submit contact information.");
            }
        },
        error: function (xhr, status, error) {
            alert("An error occurred: " + error);
        }
    });

});


initialize();
