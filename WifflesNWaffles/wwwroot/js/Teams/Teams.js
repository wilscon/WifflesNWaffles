
const elements = {

    generateButton: $('[data-selector="teams"]'),
    teamsDiv: $('[data-selector="teamsDiv"]'),


}


const initialize = function () {

    elements.generateButton.click(generateTeams);

};

const generateTeams = function () {

    elements.teamsDiv.css("display", "");

}


initialize();