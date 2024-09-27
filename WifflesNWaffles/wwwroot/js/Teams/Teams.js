
const elements = {

    generateButton: $('[data-selector="teams"]'),
    teamsDiv: $('[data-selector="teamsDiv"]'),
}
const initialize = function () {

    elements.generateButton.click(generateTeams);

};

const generateTeams = function () {

    elements.generateButton.css("display", "none");
    elements.teamsDiv.css("display", "");

}


initialize();