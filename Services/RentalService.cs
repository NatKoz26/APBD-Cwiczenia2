public class RentalService
{
    private List<Rental> rentals = new List<Rental>();

    public void RentEquipment(User user, Equipment equipment)
    {
        if (!equipment.IsAvailable)
            throw new Exception("Sprzęt niedostępny");

        int active = rentals.Count(r => r.User == user && !r.IsReturned);

        if (active >= user.MaxRentals)
            throw new Exception("Limit przekroczony");

        var rental = new Rental
        {
            User = user,
            Equipment = equipment,
            RentDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(7)
        };

        equipment.IsAvailable = false;
        rentals.Add(rental);
    }

    public void ReturnEquipment(Equipment equipment)
    {
        var rental = rentals.First(r => r.Equipment == equipment && !r.IsReturned);

        rental.ReturnDate = DateTime.Now;
        equipment.IsAvailable = true;

        if (rental.ReturnDate > rental.DueDate)
        {
            int days = (rental.ReturnDate.Value - rental.DueDate).Days;
            Console.WriteLine($"Kara: {days * 10} zł");
        }
    }

    public void ShowActiveRentals()
    {
        foreach (var r in rentals.Where(r => !r.IsReturned))
        {
            Console.WriteLine($"{r.User.FirstName} ma {r.Equipment.Name}");
        }
    }
}