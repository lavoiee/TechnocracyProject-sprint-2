using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS


        private ConsoleView _gameConsoleView;
        private Adama _sar;
        private Universe _gameUniverse;
        private SpaceTimeLocation _currentLocation;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _sar = new Adama();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_sar, _gameUniverse);
            _playingGame = true;

            //
            // add initial items to the traveler's inventory
            //
            _sar.Inventory.Add(_gameUniverse.GetGameObjectById(8) as TravelerObject);
            _sar.Inventory.Add(_gameUniverse.GetGameObjectById(9) as TravelerObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            AdamaAction travelerActionChoice = AdamaAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetSpaceTimeLocationByID(_sar.SpaceTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the player's menu choice
                //
                switch (travelerActionChoice)
                {
                    case AdamaAction.None:
                        break;

                    case AdamaAction.AdamaInfo:
                        _gameConsoleView.DisplayTravelerInfo(_sar);
                        break;

                    case AdamaAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case AdamaAction.Travel:
                        //
                        // get new location choice and update the current location property
                        //                        
                        _sar.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
                        _currentLocation = _gameUniverse.GetSpaceTimeLocationByID(_sar.SpaceTimeLocationID);

                        //
                        // set the game play screen to the current location info format
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case AdamaAction.AdamaLocationsVisited:
                        //
                        // generate a list of space time locations that have been visited
                        //
                        List<SpaceTimeLocation> visitedSpaceTimeLocations = new List<SpaceTimeLocation>();
                        foreach (int spaceTimeLocationId in _sar.SpaceTimeLocationsVisited)
                        {
                            visitedSpaceTimeLocations.Add(_gameUniverse.GetSpaceTimeLocationByID(spaceTimeLocationId));
                        }

                        _gameConsoleView.DisplayGamePlayScreen("Space-Time Locations Visited", Text.VisitedLocations(visitedSpaceTimeLocations), ActionMenu.MainMenu, "");
                        break;

                    case AdamaAction.LookAt:
                        LookAtAction();
                        break;

                    case AdamaAction.ListSpaceTimeLocations:
                        _gameConsoleView.DisplayListOfSpaceTimeLocations();
                        break;

                    case AdamaAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case AdamaAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        private void InitializeMission()
        {
            Adama sar = _gameConsoleView.GetInitialTravelerInfo();

            _sar.Name = sar.Name;
            _sar.Age = sar.Age;
            _sar.Race = sar.Race;
            _sar.SpaceTimeLocationID = 1;

            _sar.ExperiencePoints = 0;
            _sar.Health = 100;
            _sar.Lives = 3;
        }

        private void UpdateGameStatus()
        {
            if (!_sar.HasVisited(_currentLocation.SpaceTimeLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _sar.SpaceTimeLocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

                //
                // update experience points for visiting locations
                //
                _sar.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in space-time location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }


        /// <summary>
        /// process the Pick Up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of traveler objects in space-time location and get a player choice
            //
            int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravelerObjectToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (travelerObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                TravelerObject travelerObject = _gameUniverse.GetGameObjectById(travelerObjectToPickUpId) as TravelerObject;

                //
                // note: traveler object is added to list and the space-time location is set to 0
                //
                _sar.Inventory.Add(travelerObject);
                travelerObject.SpaceTimeLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
            }
        }

        /// <summary>
        /// process the Put Down action
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of traveler objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            TravelerObject travelerObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as TravelerObject;

            //
            // remove the object from inventory and set the space-time location to the current value
            //
            _sar.Inventory.Remove(travelerObject);
            travelerObject.SpaceTimeLocationId = _sar.SpaceTimeLocationId;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmTravelerObjectRemovedFromInventory(travelerObject);

        }
        #endregion
    }
}
