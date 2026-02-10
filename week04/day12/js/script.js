// 1. Display User Input Type
document.getElementById("checkTypeBtn").addEventListener("click", () => {
  const value = document.getElementById("userInput").value;
  let type;
  if (value.toLowerCase() === "true" || value.toLowerCase() === "false") {
    type = "boolean";
  } else if (!isNaN(value) && value.trim() !== "") {
    type = "number";
  } else {
    type = "string";
  }
  document.getElementById("displayType").textContent = `Value: ${value}, Type: ${type}`;
});

// 2. Sum of Two Numbers
document.getElementById("sumBtn").addEventListener("click", () => {
  const n1 = parseFloat(document.getElementById("num1").value);
  const n2 = parseFloat(document.getElementById("num2").value);
  document.getElementById("sumResult").textContent = `Sum: ${n1 + n2}`;
});

// 3. Boolean Toggle Message
let show = false;
document.getElementById("toggleBtn").addEventListener("click", () => {
  show = !show;
  document.getElementById("message").style.display = show ? "block" : "none";
  document.getElementById("toggleBtn").textContent = show ? "Hide Message" : "Show Message";
});

// 4. Array of Favorite Colors
const colors = [];
document.getElementById("addColorBtn").addEventListener("click", () => {
  const color = document.getElementById("colorInput").value;
  if (color) {
    colors.push(color);
    document.getElementById("colorInput").value = "";
    document.getElementById("colorList").innerHTML = colors.map(c => `<li>${c}</li>`).join("");
  }
});

// 5. Object Display
const student = { name: "John Doe", age: 20, grade: "A" };
document.getElementById("showStudentBtn").addEventListener("click", () => {
  document.getElementById("studentInfo").innerHTML = `
    Name: ${student.name}<br>
    Age: ${student.age}<br>
    Grade: ${student.grade}
  `;
});

// 6. Change Background Color
document.getElementById("redBtn").onclick = () => document.body.style.backgroundColor = "red";
document.getElementById("greenBtn").onclick = () => document.body.style.backgroundColor = "green";
document.getElementById("blueBtn").onclick = () => document.body.style.backgroundColor = "blue";
