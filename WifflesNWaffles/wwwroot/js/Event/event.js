const elements = {
    RSVPButton: $('[data-selector="RSVP"]'),
}
const initialize = function () {
    elements.RSVPButton.click(RSVP);
}
const RSVP = function () {
    document.location.href = "/home/RSVP";
}

initialize();