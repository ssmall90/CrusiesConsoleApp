namespace CrusiesConsoleAppUI.Models
{
    public interface IPortModel
    {
        int LengthOfStay { get; set; }
        string Name { get; set; }
        int PortId { get; set; }
        List<TripModel> Trips { get; set; }
    }
}