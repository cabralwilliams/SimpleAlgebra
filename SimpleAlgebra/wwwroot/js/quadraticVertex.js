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
    resetBtn.href = "/Quadratic/Vertex";
    outputDiv.appendChild(resetBtn);
    return outputDiv;
}

function checkAnswers(event) {
    event.preventDefault();
    let correctCount = 0;
    //console.log("Request received!");
    //Retrieve the answers from the hidden div
    const q1Answer = document.querySelector("#q1").textContent;
    const q1Response = studentResponseLS1.value;
    //console.log(q1Answers);
    //console.log(checkMultiple(q1Answers, q1Response));
    const q2Answer = parseInt(document.querySelector("#q2").textContent);
    const q2Response = parseInt(studentResponseLS2.value);
    //console.log(q2Answer);
    const q3AnswersStrs = document.querySelector("#q3").textContent.split(',');
    const q3Answers = q3AnswersStrs.map(ans => parseInt(ans));
    const q3Response1 = parseInt(studentResponseLS3.value);
    const q3Response2 = parseInt(studentResponseLS4.value);
    resultDiv.innerHTML = "";

    const q1Div = createResultDiv(q1Response, [q1Answer], 2, 1);
    const q2Div = createResultDiv(q2Response, [q2Answer], 1, 2);
    const q3Div = createResultDiv([q3Response1,q3Response2], q3Answers, 3, 3);
    resultDiv.append(q1Div, q2Div, q3Div);
    const resetBtn = resetPage();
    resultDiv.append(resetBtn);
    resultDiv.classList.toggle("d-none");
    formDiv.classList.toggle("d-none");
}

//Even if answerList is of length one, it must be converted to array
function checkOne(answerList, response, isNumber = true) {
    if (isNumber) {
        return parseInt(answerList[0]) === parseInt(response);
    }
    return answerList[0].trim() === response.trim();
}

function checkManyMatchAny(answerList, responseList) {
    const matchIndices = { };
    for (let i = 0; i < responseList.length; i++) {
        let madeMatch = false;
        for (let j = 0; j < answerList.length; j++) {
            if (responseList[i] === answerList[j] && !matchIndices[`${answerList[j]}`]) {
                madeMatch = true;
                matchIndices[`${answerList[j]}`] = true;
                break;
            }
        }
        if (!madeMatch) {
            return false;
        }
    }
    return true;
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
        case 2:
            wasCorrect = checkOne(answerList, response, false);
            break;
        case 3:
            wasCorrect = checkManyMatchAny(answerList, response);
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