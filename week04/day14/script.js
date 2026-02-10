// students
const students = [
  { FirstName: "John", LastName: "Doe", Age: 20, Department: "Computer Science" },
  { FirstName: "Jane", LastName: "Smith", Age: 22, Department: "Physics" },
  { FirstName: "Michael", LastName: "Johnson", Age: 21, Department: "Mathematics" },
  { FirstName: "Sarah", LastName: "Williams", Age: 19, Department: "Computer Science" },
  { FirstName: "Robert", LastName: "Brown", Age: 23, Department: "Mathematics" },
  { FirstName: "Emily", LastName: "Davis", Age: 20, Department: "Computer Science" }
];

// q1
const csStudents = students.filter(s => s.Department === "Computer Science");
console.log("1. Computer Science Students:", csStudents);

// q2
const above21 = students.filter(s => s.Age > 21).map(s => s.FirstName);
console.log("2. Students above 21:", above21);

// q3
const isRobert = students.some(s => s.FirstName === "Robert" && s.Department === "Computer Science");
console.log("3. Is Robert in CS?", isRobert);

// q4
const mathStudent = students.some(s => s.Age > 23 && s.Department === "Mathematics");
console.log("4. Any Math student older than 23?", mathStudent);

// q5
const above18 = students.every(s => s.Age > 18);
console.log("5. All above 18?", above18);

// q6
const johnDept = students.find(s => s.FirstName === "John")?.Department;
console.log("6. John's Department:", johnDept);




// movies
let movies = [
  { MovieName: "The Great Adventure", ActorName: "John Smith", ReleaseDate: "2023-01-15" },
  { MovieName: "Mystery in the Woods", ActorName: "Emily Johnson", ReleaseDate: "2022-09-28" },
  { MovieName: "Love and Destiny", ActorName: "Michael Brown", ReleaseDate: "2023-05-02" },
  { MovieName: "City of Shadows", ActorName: "Sophia Williams", ReleaseDate: "2023-03-12" },
  { MovieName: "The Last Stand", ActorName: "William Davis", ReleaseDate: "2022-11-07" },
  { MovieName: "Echoes of Time", ActorName: "Olivia Wilson", ReleaseDate: "2022-12-19" }
];

// q1
const movies2022 = movies
  .filter(m => m.ReleaseDate.startsWith("2022"))
  .map(m => ({ MovieName: m.MovieName, ActorName: m.ActorName }));
console.log("1. 2022 Movies:", movies2022);

// q2
const davisMovies2023 = movies
  .filter(m => m.ReleaseDate.startsWith("2023") && m.ActorName === "William Davis")
  .map(m => m.MovieName);
console.log("2. 2023 Movies with William Davis:", davisMovies2023);

// q3
const lastStandInfo = movies.find(m => m.MovieName === "The Last Stand");
console.log("3. The Last Stand Info:", lastStandInfo ? { Actor: lastStandInfo.ActorName, ReleaseDate: lastStandInfo.ReleaseDate } : "Not Found");

// q4
const hasJohnDoe = movies.some(m => m.ActorName === "John Doe");
console.log("4. Has John Doe?", hasJohnDoe);

// q5
const sophiaCount = movies.filter(m => m.ActorName === "Sophia Williams").length;
console.log("5. Sophia Williams Movie Count:", sophiaCount);

// q6
movies.push({
  MovieName: "The Final Stage",
  ActorName: "John Doe",
  ReleaseDate: "2022-08-11"
});
console.log("6. After Adding Final Stage:", movies);

// q7
const movieNames = movies.map(m => m.MovieName);
const hasDuplicates = movieNames.some((name, i) => movieNames.indexOf(name) !== i);
console.log("7. Has duplicate movie names?", hasDuplicates);

// q8
const cityIndex = movies.findIndex(m => m.MovieName === "City of Shadows");
const fromCity = movies.slice(cityIndex);
console.log("8. Movies from 'City of Shadows':", fromCity);

// q9
const distinctActors = [...new Set(movies.map(m => m.ActorName))];
console.log("9. Distinct Actors:", distinctActors);

// q10
const loveIndex = movies.findIndex(m => m.MovieName === "Love and Destiny");
movies.splice(loveIndex + 1, 0, {
  MovieName: "Rich & Poor",
  ActorName: "Johnie Walker",
  ReleaseDate: "2023-08-11"
});
console.log("10. After inserting Rich & Poor:", movies);

// q11
console.log("11. Count of distinct actors:", distinctActors.length);

// q12
movies = movies.filter(m => m.MovieName !== "The Last Stand");
console.log("12. After removing 'The Last Stand':", movies);

// q13
const allAfter2021 = movies.every(m => new Date(m.ReleaseDate) > new Date("2021-12-31"));
console.log("13. All movies released after 2021?", allAfter2021);

// q14
const cityMovie = movies.find(m => m.MovieName === "City of Shadows");
if (cityMovie) cityMovie.ReleaseDate = "2023-03-13";
console.log("14. Updated 'City of Shadows':", cityMovie);

// q15
const longNameMovies = movies.filter(m => m.MovieName.length > 10).map(m => m.MovieName);
console.log("15. Movies with long names:", longNameMovies);
