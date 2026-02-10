console.log(a);
console.log(b);
console.log(c);

var a = 5;
let b = 10;
const c = 15;

// script.js:1 undefined
// script.js:2 Uncaught ReferenceError: Cannot access 'b' before initialization
//     at script.js:2:13

// var is hoisted and initialized as undefined
// let and const are hoisted but not initialized So accessing b or c before they are declared throws an error.