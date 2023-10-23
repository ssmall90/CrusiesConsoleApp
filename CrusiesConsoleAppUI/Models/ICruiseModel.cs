namespace CrusiesConsoleAppUI.Models
{
    public interface ICruiseModel
    {
        string CruiseIdentifier { get; set; }
        string CruiseName { get; set; }
        List<PassengerModel> Passengers { get; set; }
        List<PortModel> Ports { get; set; }

        void AddPassenger(PassengerModel passenger);
        void AddPort(PortModel port);
        void RemovePassenger(PassengerModel passenger);
        void RemovePort(PortModel port);
    }
}