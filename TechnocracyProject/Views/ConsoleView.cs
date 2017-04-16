using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS
        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }
        #endregion

        #region FIELDS

        //
        // declare a Adama object for the ConsoleView object to use.
        // These are temporary and are used to pass the object reference back.
        //
        Adama _gameTraveler;
        Universe _gameUniverse;

        ViewStatus _viewStatus;
        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Adama gameTraveler, Universe gameUniverse)
        {
            _gameTraveler = gameTraveler;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.TravelerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public AdamaAction GetActionMenuChoice(Menu menu)
        {
            AdamaAction choosenAction = AdamaAction.None;

            //
            // Handles exception in case user presses a key other than
            // one of the keys related to menu choices
            bool validKeyStroke = false;
            while (!validKeyStroke)
            {
                try
                {
                    ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                    char keyPressed = keyPressedInfo.KeyChar;
                    choosenAction = menu.MenuChoices[keyPressed];
                }
                catch (KeyNotFoundException)
                {
                    DisplayInputBoxPrompt("Invalid keystroke! Please enter a menu choice by using 1, 2 ... etc.");
                    continue;
                }
                validKeyStroke = true;
            }

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>

        //TODO: Finish writing the methods ClearInputBox() and DisplayInputErrorMessages()
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue & integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }
            return true;
        }

        //public static T ValidateItem<T>(T eEnumItem)
        //{
        //    if (Enum.IsDefined(typeof(T), eEnumItem) == true)
        //        return eEnumItem;
        //    else
        //        return default(T);
        //}

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        public Adama.Planet GetHomeWorld()
        {
            Adama.Planet homeWorld;       
            Enum.TryParse<Adama.Planet>(Console.ReadLine(), out homeWorld);
            return homeWorld;
        }

        public Adama.Galaxy GetHomeGalaxy()
        {
            Adama.Galaxy homeGalaxy;
            Enum.TryParse<Adama.Galaxy>(Console.ReadLine(), out homeGalaxy);
            return homeGalaxy;
        }

        public Adama.Dimension GetHomeDimension()
        {
            Adama.Dimension dimension;
            Enum.TryParse<Adama.Dimension>(Console.ReadLine(), out dimension);
            return dimension;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);

            Console.WriteLine(tabSpace + @" _______ _______ _______ _     _ __   _  _____  _______  ______ _______ _______ __   __");
            Console.WriteLine(tabSpace + @"    |    |______ |       |_____| | \  | |     | |       |_____/ |_____| |         \_/ ");
            Console.WriteLine(tabSpace + @"    |    |______ |_____  |     | |  \_| |_____| |_____  |    \_ |     | |_____     |  "); 
                                                                                       

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Technocracy Project";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, AdamaAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != AdamaAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Database", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTraveler, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        public Adama GetInitialTravelerInfo()
        {
            Adama sar = new Adama();

            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's name
            //
            DisplayGamePlayScreen("Mission Initialization - Name", Text.InitializeMissionGetTravelerName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            sar.Name = GetString();

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetTravelerAge(sar), ActionMenu.MissionIntro, "");
            int gameAdamaAge;
            GetInteger($"Enter your age {sar.Name}: ", 0, 1000000, out gameAdamaAge);
            sar.Age = gameAdamaAge;

            //
            // get traveler's race
            //
            DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetTravelerRace(sar), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your race {sar.Name}: ");
            sar.Race = GetRace();

            //
            // get traveler's home world
            //
            DisplayGamePlayScreen("Mission Initialization - Home World", Text.InitializeMissionGetHomeWorld(sar), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your home world {sar.Name}: ");
            sar.HomeWorld = GetHomeWorld();

            //
            // get traveler's home galaxy
            //
            DisplayGamePlayScreen("Mission Initialization - Home Galaxy", Text.InitializeMissionGetHomeGalaxy(sar), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your home galaxy {sar.Name}: ");
            sar.HomeGalaxy = GetHomeGalaxy();

            //
            // get traveler's home dimension
            //
            DisplayGamePlayScreen("Mission Initialization - Home dimension", Text.InitializeMissionGetHomeDimension(sar), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your home dimension {sar.Name}: ");
            //
            sar.HomeDimension = GetHomeDimension();

            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(sar), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return sar;
        }


        public void DisplayTravelerInfo(Adama gameTraveler)
        {
            DisplayGamePlayScreen($"Vital Information for {gameTraveler.Name}", Text.InitializeMissionEchoTravelerInfo(_gameTraveler), ActionMenu.MainMenu, "");
            GetContinueKey();
        }

        public void DisplayLookAround()
        {
            SpaceTimeLocation currentSpaceTimeLocation = _gameUniverse.GetSpaceTimeLocationByID(_gameTraveler.SpaceTimeLocationID);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentSpaceTimeLocation), ActionMenu.MainMenu, "");
        }

        public int DisplayGetNextSpaceTimeLocation()
        {
            int spaceTimeLocationId = 0;
            bool validSpaceTimeLocationId = false;

            DisplayGamePlayScreen("Travel to a New Space-Time Location", Text.Travel(_gameTraveler, _gameUniverse.SpaceTimeLocations), ActionMenu.MainMenu, "");

            while (!validSpaceTimeLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gameTraveler.Name}: ", 1, _gameUniverse.GetMaxSpaceTimeLocationId(), out spaceTimeLocationId);

                //
                // validate integer as a valid space-time location id and determine accessibility
                //
                if (_gameUniverse.IsValidSpaceTimeLocationId(spaceTimeLocationId))
                {
                    if (_gameUniverse.GetSpaceTimeLocationByID(spaceTimeLocationId).Accessable)
                    {
                        validSpaceTimeLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid Space-Time location id. Please try again.");
                }
            }

            return spaceTimeLocationId;
        }

        public void DisplayListOfSpaceTimeLocations()
        {
            DisplayGamePlayScreen("List: Space-Time Locations", Text.ListSpaceTimeLocations(_gameUniverse.SpaceTimeLocations), ActionMenu.MainMenu, "");
        }

        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Object", Text.ListAllGameObjects(_gameUniverse.GameObjects), ActionMenu.MainMenu, "");
        }
        #endregion
    }
}
