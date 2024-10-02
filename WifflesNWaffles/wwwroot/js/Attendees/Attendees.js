const elements = {

   yearDropdown: $('#yearDropdown'),

}

const initialize = function () {

    elements.yearDropdown.on("change", changeYear);

}

const changeYear = function () {

    let year = $('#yearDropdown').val();

    $.ajax({
        url: '/Home/ChangeYear',
        type: 'GET',
        data: {year: year},
        success: function (partialViewResult) {
          

                $('#attendeesContainer').html(partialViewResult); 
        },
        error: function (xhr, status, error) {
            alert("An error occurred: " + error);
        }
    });
}

initialize();