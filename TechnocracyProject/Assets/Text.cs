using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Intergalatic Technocracy" };
        public static List<string> FooterText = new List<string>() { "Newspeak, 2017" };

        public static string MissionIntro()
        {
            string messageBoxText =
                "A major scientific breakthrough has just occurred on station IX in " +
                "orbit around the blue super giant A357. The imperial council has " +
                "ordered us to transport you and your team to the station on the " +
                "next ship passing through the artificial black holes connecting " +
                "these two space-times.\n" +
                "\n" +
                "You will seize the technology being developed on station IX, " +
                "take the scientific team into imperial custody, and transport them to the " +
                "the black hyper-sphere orbiting Regulus. " +
                "Before you leave A357, you will set the controls of station IX to " +
                "the core of the star. There must be no evidence remaining once you " +
                "leave that system.\n" +
                "\n" +
                "You have one hour to prepare your team.\n" +
                "Press any key to begin\n";
            
            return messageBoxText;
        }

        public static string CurrentLocationInfo(SpaceTimeLocation spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.Description;

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin the mission we need vital information.\n" +
                " \n" +
                "Enter the information as you are prompted.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerName()
        {
            string messageBoxText =
                "Enter your name as provided by the imperium.\n" +
                " \n" +
                "This will be your official name during the mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Adama gameTraveler)
        {
            string messageBoxText =
                $"Thank you {gameTraveler.Name}, Please continue...\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n" +
                "Please use the galactic year as your reference.";

            return messageBoxText;
        }

        public static string InitializeMissionGetHomeWorld(Adama gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your Home Planet on this mission.\n" +
                " \n" +
                "Enter your Home Planet below.\n" +
                " \n" +
                "Please select from the Planets listed below." +
                " \n";

            string planetList = null;

            foreach (Adama.Planet HomePlanet in Enum.GetValues(typeof(Adama.Planet)))
            {
                if (HomePlanet != Adama.Planet.None)
                {
                    planetList += $"\t{HomePlanet}\n";
                }
            }

            messageBoxText += planetList;

            return messageBoxText;
        }

        public static string InitializeMissionGetHomeGalaxy(Adama gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your Home Galaxy on this mission.\n" +
                " \n" +
                "Enter your Home Galaxy below.\n" +
                " \n" +
                "Please select from the Galaxies listed below." +
                " \n";

            string galaxyList = null;

            foreach (Adama.Galaxy HomeGalaxy in Enum.GetValues(typeof(Adama.Galaxy)))
            {
                if (HomeGalaxy != Adama.Galaxy.None)
                {
                    galaxyList += $"\t{HomeGalaxy}\n";
                }
            }

            messageBoxText += galaxyList;

            return messageBoxText;
        }

        public static string InitializeMissionGetHomeDimension(Adama gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your Home Dimension on this mission.\n" +
                " \n" +
                "Enter your Home Dimension below.\n" +
                " \n" +
                "Please use the universal Dimension classifications below." +
                " \n";

            string dimensionList = null;

            foreach (Adama.Dimension HomeDimension in Enum.GetValues(typeof(Adama.Dimension)))
            {
                if (HomeDimension != Adama.Dimension.None)
                {
                    dimensionList += $"\t{HomeDimension}\n";
                }
            }

            messageBoxText += dimensionList;

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerRace(Adama gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your genetic type on this mission.\n" +
                " \n" +
                "Enter your genetic type below.\n" +
                " \n" +
                "Please use the genetic type classifications below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoTravelerInfo(Adama gameTraveler)
        {
            string messageBoxText =
                $"Thank you {gameTraveler.Name}.\n" +
                " \n" +
                "We have logged your vital information. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tTraveler Name: {gameTraveler.Name}\n" +
                $"\tTraveler Age: {gameTraveler.Age}\n" +
                $"\tTraveler Race: {gameTraveler.Race}\n" +
                $"\tTraveler home world: {gameTraveler.HomeWorld}\n" +
                $"\tTraveler home galaxy: {gameTraveler.HomeGalaxy}\n" +
                $"\tTraveler home dimension: {gameTraveler.HomeDimension}\n" +
                " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        public static string LookAround(SpaceTimeLocation spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.GeneralContents;

            return messageBoxText;
        }

        public static string Travel(Adama gametraveler, List<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                $"{gametraveler.Name}, The imperial council will need to know the name of the new location.\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except the current location
            //
            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                if (spaceTimeLocation.SpaceTimeLocationID != gametraveler.SpaceTimeLocationID)
                {
                    spaceTimeLocationList +=
                        $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                        $"{spaceTimeLocation.CommonName}".PadRight(30) +
                        $"{spaceTimeLocation.Accessable}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }
         
        public static string VisitedLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Space-Time Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                spaceTimeLocationList +=
                    $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                    $"{spaceTimeLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        public static string ListSpaceTimeLocations(IEnumerable<SpaceTimeLocation> spaceTimeLocations)
        {
            string messageBoxText =
                "Space-Time Locations\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string spaceTimeLocationList = null;
            foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
            {
                spaceTimeLocationList +=
                    $"{spaceTimeLocation.SpaceTimeLocationID}".PadRight(10) +
                    $"{spaceTimeLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        public static List<string> StatusBox(Adama traveler, Universe universe)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {traveler.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {traveler.Health}\n");
            statusBoxText.Add($"Lives: {traveler.Lives}\n");

            return statusBoxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Space-Time Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.SpaceTimeLocationId}".PadRight(10) +
                    Environment.NewLine;
            }
            messageBoxText += gameObjectRows;
            return messageBoxText;
        }
        #endregion
    }
}
