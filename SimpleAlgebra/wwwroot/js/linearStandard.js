
const answerForm = document.querySelector("#answerForm"); //Actual answer form
const formDiv = document.querySelector("#formDiv"); //Div holding the form
const resultDiv = document.querySelector("#resultDiv"); //Div holding the results
const studentResponseLS1 = document.querySelector("#studentResponseLS1");
const studentResponseLS2 = document.querySelector("#studentResponseLS2");
const studentResponseLS3 = document.querySelector("#studentResponseLS3");
const studentResponseLS4 = document.querySelector("#studentResponseLS4");

const resetPage = () => {
    const outputDiv = document.createElement("div");
    outputDiv.className = "d-flex flex-column col-12 col-md-4";
    const resetBtn = document.createElement("a");
    resetBtn.className = "btn btn-primary";
    resetBtn.textContent = "Reset";
    resetBtn.href = "/Linear/Standard";
    outputDiv.appendChild(resetBtn);
    return outputDiv;
}

function checkAnswers(event) {
    event.preventDefault();
    let correctCount = 0;
    //console.log("Request received!");
    //Retrieve the answers from the hidden div
    const q1Answers = document.querySelector("#q1").textContent.split("|");
    const q1Response = studentResponseLS1.value.trim();
    //console.log(q1Answers);
    //console.log(checkMultiple(q1Answers, q1Response));
    const q2Answer = parseInt(document.querySelector("#q2").textContent);
    const q2Response = parseInt(studentResponseLS2.value);
    //console.log(q2Answer);
    const q3Answer = parseInt(document.querySelector("#q3").textContent);
    const q3Response = parseInt(studentResponseLS3.value);

    const q4Answer = parseInt(document.querySelector("#q4").textContent);
    const q4Response = parseInt(studentResponseLS4.value);
    resultDiv.innerHTML = "";

    const q1Div = createResultDiv(q1Response, q1Answers, 0, 1);
    const q2Div = createResultDiv(q2Response, [q2Answer], 1, 2);
    const q3Div = createResultDiv(q3Response, [q3Answer], 1, 3);
    const q4Div = createResultDiv(q4Response, [q4Answer], 1, 4);
    resultDiv.append(q1Div, q2Div, q3Div, q4Div);
    const resetBtn = resetPage();
    resultDiv.append(resetBtn);
    resultDiv.classList.toggle("d-none");
    formDiv.classList.toggle("d-none");
}

function checkMultiple(answerList, response) {
    for (let i = 0; i < answerList.length; i++) {
        if (response === answerList[i]) {
            return true;
        }
    }
    return false;
}

//Even if answerList is of length one, it must be converted to array
function checkOne(answerList, response, isNumber = true) {
    if (isNumber) {
        return parseInt(answerList[0]) === parseInt(response);
    }
    return answerList[0].trim() === response.trim();
}

function createResultDiv(response, answerList, qType, qNumber) {
    const outputDiv = document.createElement("div");
    outputDiv.className = "d-flex flex-column";
    const questionH = document.createElement("h3");
    questionH.textContent = `Question ${qNumber}`;
    let wasCorrect;
    switch (qType) {
        case 0:
            wasCorrect = checkMultiple(answerList, response);
            break;
        case 1:
            wasCorrect = checkOne(answerList, response, true);
            break;
        default:
            wasCorrect = checkMultiple(answerList, response);
            break;
    }
    if (wasCorrect) {
        questionH.className = "text-success";
    } else {
        questionH.className = "text-danger";
    }
    const responseDiv = document.createElement("div");
    responseDiv.textContent = `Your Answer: ${response}`;
    const answersDiv = document.createElement("div");
    answersDiv.textContent = `Correct Answer(s): ${answerList.join(', ')}`;
    const statusDiv = document.createElement("div");
    statusDiv.textContent = wasCorrect ? `Correct!` : `Incorrect`;
    if (wasCorrect) {
        statusDiv.className = "text-success";
    } else {
        statusDiv.className = "text-danger";
    }
    outputDiv.append(questionH, responseDiv, answersDiv, statusDiv);
    return outputDiv;
}

answerForm.addEventListener("submit", checkAnswers);