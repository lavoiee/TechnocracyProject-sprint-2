using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject.Assets
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    public static class UniverseObjects
    //the universe is like the "game board"

    //remember, static means you don't have to instantiate it
    {
        public static IEnumerable<SpaceTimeLocation> SpaceTimeLocations = new List<SpaceTimeLocation>()
        {
            new SpaceTimeLocation
            // the SpaceTimeLocation is like the "room" that you have in Clue, or the colorful square on the Candy Land board game
            {
                CommonName = "Imperial Space Station REG:1.618",
                SpaceTimeLocationID = 1,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The imperial space station in orbit around Regulus is a " +
                        "military installation in proximity to the worm hole to the " +
                        "Pegasus galaxy.\n",
                GeneralContents = "The station is a 50km black ring equipped with anti-matter cannons. " +
                        "There are personnel barracks housing 50 imperial legions, and hanger " +
                        "installations for the galactic space forces of the imperium. \n",            
                Accessable = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Station IX A357:6",
                SpaceTimeLocationID = 2,
                UniversalDate = 386759,
                UniversalLocation = "P-2, SS-85, G-2976, LS-3976",
                Description = "Station IX is a scientific outpost in orbit around the blue super " +
                        "giant A357 in the Pegasus galaxy. The station is under the command of the " +
                        "machine race and is developing weapons to be used to overthrow the imperium ",
                GeneralContents = "- Nano particle laboratories and personnel -",
                Accessable = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "worm hole (Regulus side)",
                SpaceTimeLocationID = 3,
                UniversalDate = 386759,
                UniversalLocation = "p-6, ss-3978, g-2976, ls-3976",
                Description = "the worm hole in the Regulus system is owned by the spacing guild " +
                        "transport corporation under imperial charter in perpetuity conditioned upon " +
                        "their neutrality. this hole leads to a357 in the Pegasus galaxy ",
                GeneralContents = "- time -",
                Accessable = true,
                ExperiencePoints = 20
            },

             //not necessarily a space-time location. your player will not actually be here.
             //you just need to inform them with some text that they passes through the worm hole.
             //unless you actually want something to take place while passing through the hole.
            new SpaceTimeLocation
            {
                CommonName = "worm hole (a357 side)",
                SpaceTimeLocationID = 3,
                UniversalDate = 386759,
                UniversalLocation = "p-6, ss-3978, g-2976, ls-3976",
                Description = "the worm hole in the a357 system is owned by the spacing guild " +
                        "transport corporation under imperial charter in perpetuity conditioned upon " +
                        "their neutrality. this hole leads to Regulus in the Atlantis galaxy ",
                GeneralContents = "- time -",
                Accessable = true,
                ExperiencePoints = 20
            },

            new SpaceTimeLocation
            {
                CommonName = "Black Hyper-Sphere",
                SpaceTimeLocationID = 5,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Black Hyper-Sphere is an imperial prison hidden by an artificial " +
                        "black hole that prevents it's location from being known.",
                GeneralContents = "- 1.75 Billion prisoners of various races deported from worlds " +
                        "conquered by the imperium -",
                Accessable = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Corvette",
                SpaceTimeLocationID = 6,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Corvette is a small warp capable starship equipped with laser cannons",
                GeneralContents = "- Small crew of 500 imperial space force officers and 150 special " +
                        "operators",
                Accessable = true,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "Regulus",
                SpaceTimeLocationID = 7,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "Regulus is a blue-white main sequence star under control of the imperium ",
                GeneralContents = "- Hydrogen, Helium, and other elements. ",
                Accessable = false,
                ExperiencePoints = 10
            },

            new SpaceTimeLocation
            {
                CommonName = "A357",
                SpaceTimeLocationID = 8,
                UniversalDate = 386759,
                UniversalLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "A357 is a blue main sequence star under the control of the machine race. ",
                GeneralContents = "- Hydrogen, Helium, and other elements. ",
                Accessable = false,
                ExperiencePoints = 10
            }
        };
    }
}
