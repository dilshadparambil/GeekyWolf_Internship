function showAlert() {
    alert('Hello World');
}




function isLeapYear(year) {
    if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {
        return `${year} is a Leap Year`;
    } else {
        return `${year} is not a Leap Year`;
    }
}

let year = window.prompt("enter the year to check if its leap year?");
console.log(isLeapYear(year));