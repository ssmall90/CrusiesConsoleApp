using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public List<CruiseModel> Cruises { get; set; }

        public UserModel(string displayName)
        {
            DisplayName = displayName;
            Id = "User109";
            Cruises = new List<CruiseModel>();
        }

        public void AddCruise(CruiseModel cruise)
        {
            Cruises.Add(cruise);
        }
    }
}
