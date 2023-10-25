namespace CrusiesConsoleAppUI.Models
{
    public interface IPortModel
    {
        int LengthOfStay { get; set; }
        string Name { get; set; }
        int PortId { get; set; }
        List<TripModel> Trips { get; set; }

        void AddTrip(TripModel trip);
        void RemoveTrip(TripModel trip);
        string ToString();
    }
}