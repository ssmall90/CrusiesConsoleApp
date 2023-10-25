namespace CrusiesConsoleAppUI.Models
{
    public interface IPassengerModel
    {
        string FirstName { get; }
        string LastName { get; }
        string PassportNumber { get; }

        string ToString();
    }
}