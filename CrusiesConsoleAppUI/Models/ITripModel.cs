namespace CrusiesConsoleAppUI.Models
{
    public interface ITripModel
    {
        string ActivityId { get; set; }
        int Cost { get; set; }
        string NameOfActivity { get; set; }
        List<PassengerModel> PassengersAttending { get; set; }
    }
}