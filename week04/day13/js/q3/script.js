
var x = 10;
x = 20;          
var x = 30;      
console.log("var x =", x); //30


let y = 10;
y = 20;          
//let y = 30;   //script.js:10 Uncaught SyntaxError: Identifier 'y' has already been declared (at script.js:10:5)
console.log("let y =", y);//20

// const
const z = 10;
//z = 20;       //script.js:15 Uncaught TypeError: Assignment to constant variable.at script.js:15:3
//const z = 30;  //script.js:16 Uncaught SyntaxError: Identifier 'z' has already been declared (at script.js:16:7)
console.log("const z =", z);


// var doesnt have problems reassigning or redclaring
// let allows to reassign but no redeclaring
// const does not allow to either reassign or redeclare