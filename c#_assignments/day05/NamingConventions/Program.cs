
public class Employee // emp -> Employee. Class names should use PascalCase and be descriptive.
{
    public string name; // n -> Name. Public field renamed for clarity; PascalCase for public members.
    public int age; // a -> Age. Descriptive, meaningful name replacing vague single letter.
    public double salary; // s -> Salary. Clarifies what the number represents (employee’s pay).
    public void CalculateSalary()
    // calc() -> CalculateSalary(). Method names use PascalCase and verbs; describes what the method does.
    {
        double increment = salary * 0.1;// x -> increment. Local variable renamed for meaning; camelCase for locals.
        double totalSalary = salary + increment;// y -> totalSalary. Descriptive variable name showing purpose; camelCase for locals.
    }
}