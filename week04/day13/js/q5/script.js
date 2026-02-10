const numbers = [2, 5, 8, 11, 14];


const doubled = numbers.map(num => num * 2);
console.log("Doubled:", doubled);// Doubled: [ 4, 10, 16, 22, 28 ]


const evens = numbers.filter(num => num % 2 === 0);
console.log("Even Numbers:", evens);// Even Numbers: [ 2, 8, 14 ]


const sum = numbers.reduce((total, num) => total + num, 0);
console.log("Sum:", sum);// Sum: 40
