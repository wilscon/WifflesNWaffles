
const elements = {    
    eventDetailsButton: $('[data-selector="eventDetailsButton"]'),
}

const initialize = function () {
    elements.eventDetailsButton.click(viewEvent);
}
const viewEvent = function () {
    document.location.href = "home/event";
}

initialize();
