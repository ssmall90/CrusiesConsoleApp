using System.Collections.Generic;

namespace CrusiesConsoleAppUI.Models
{
    public interface IUserModel
    {
        List<CruiseModel> Cruises { get; set; }
        string DisplayName { get; set; }
        string Id { get; set; }

        void AddCruise(CruiseModel cruise);
        void RemoveCruise(CruiseModel cruise);
    }
}