using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    public static class ActionMenu
    {
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, AdamaAction>()
                    {
                        { ' ', AdamaAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, AdamaAction>()
                {
                    { '1', AdamaAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, AdamaAction>()
            {
                { '1', AdamaAction.AdamaInfo },
                { '2', AdamaAction.LookAround },
                { '3', AdamaAction.Travel },
                { '4', AdamaAction.AdamaLocationsVisited },
                { '5', AdamaAction.ListSpaceTimeLocations },
                { '6', AdamaAction.Exit }
            }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Adama",
        //    MenuChoices = new Dictionary<char, AdamaAction>()
        //            {
        //                AdamaAction.MissionSetup,
        //                AdamaAction.AdamaInfo,
        //                AdamaAction.Exit
        //            }
        //};
    }
}
