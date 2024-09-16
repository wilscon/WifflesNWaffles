// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var elements = {

    
    viewAttendees: $('[data-selector="viewAttendees"]'),
    eventDetailsButton: $('[data-selector="eventDetailsButton"]'),

}


const initialize = function () {

    elements.viewAttendees.click(viewAttendees);
    elements.eventDetailsButton.click(viewEvent);


}

const viewAttendees = function () {
    alert('viewAttendees clicked')
    document.location.href = "home/attendees";
}

const viewEvent = function () {

    //alert('view event details clicked');
    document.location.href = "home/event";

}


initialize();
