
const elements = {
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
    elements.form.on("submit", submit);
}

const viewAttendees = function () {   
    document.location.href = "/home/attendees";
}

const submit = function (event) {

    event.preventDefault();

    let firstname = elements.firstname.val();
    let lastname = elements.lastname.val();
    let email = elements.email.val();
    let phone = elements.phone.val();
    let topping = elements.topping.val();
    let attendance = elements.attendance.val();

    let formData = {
        firstname: firstname,
        lastname: lastname,
        email: email,
        phoneNumber: phone,
        topping: topping,
        attendance: Number(attendance),
    }

    $.ajax({
        url: '/Home/Submit',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(formData),
        success: function (response) {
            if (response.success) {
                window.scrollTo({
                    top: 0,
                    behavior: 'smooth'
                });
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
   
}

initialize();
