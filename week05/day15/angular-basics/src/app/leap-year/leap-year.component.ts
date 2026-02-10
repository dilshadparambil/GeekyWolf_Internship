import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-leap-year',
  imports: [],
  templateUrl: './leap-year.component.html',
  styleUrl: './leap-year.component.scss'
})
export class LeapYearComponent implements OnInit {

  ngOnInit(): void {
    this.leapyear()
  }

  leapyear() :void{
    // 1. Prompt the user for a year
    const yearString = window.prompt("Enter the year to check if it's a leap year:");

    if (yearString === null || yearString.trim() === "") {
      console.log("No year entered. Cancelling check.");
    } else {
      const yearNumber = parseInt(yearString, 10);
      const result = this.isLeapYear(yearNumber);
      console.log(result);
    }
  }

  private isLeapYear(year: number): string {
    if (isNaN(year)) {
      return "That's not a valid number. Please enter a year like 2024.";
    }

    if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {
      return `${year} is a Leap Year`;
    } else {
      return `${year} is not a Leap Year`;
    }
  }

}
