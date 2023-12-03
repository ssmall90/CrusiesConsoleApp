namespace CrusiesConsoleAppUI.Models
{
    public interface IUserModel
    {
        List<CruiseModel> Cruises { get; set; }
        string DisplayName { get; set; }
        string Id { get; set; }
        List<string> PassportNumbers { get; set; }

        void AddCruise(CruiseModel cruise);
        void RemoveCruise(CruiseModel cruise);
    }
}