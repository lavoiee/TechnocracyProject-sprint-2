using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    public enum AdamaAction
    {
        None,
        MissionSetup,
        LookAround,
        Travel,

        TravelerMenu,
        AdamaInfo,
        Inventory,
        AdamaLocationsVisited,

        ObjectMenu,
        LookAt,
        PickUp,
        PutDown,

        NonplayerCharacterMenu,
        TalkTo,

        AdminMenu,
        ListSpaceTimeLocations,
        ListGameObjects,
        ListNonplayerCharacters,

        ReturnToMainMenu,
        Exit
    }
}
