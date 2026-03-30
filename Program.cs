class Program
{
    static void Main()
    {
        
        var laptop = new Laptop { Id = 1, Name = "Dell", Ram = 16, Processor = "i7" };
        var camera = new Camera { Id = 2, Name = "Canon", Resolution = 24, HasFlash = true };

        var student = new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski" };
        var employee = new Employee { Id = 2, FirstName = "Anna", LastName = "Nowak" };

        Console.WriteLine($"Test: {employee.LastName}, {employee.Id}, {employee.FirstName}");
        
    }
}