﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnocracyProject
{
    /// <summary>
    /// static class to manage the console game theme
    /// </summary>
    public static class ConsoleTheme
    {
        //
        // splash screen colors
        //
        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.Cyan;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.White;

        //
        // console window header colors
        //
        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.Cyan;

        //
        // console window footer colors
        //
        public static ConsoleColor FooterBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor FooterForegroundColor = ConsoleColor.Cyan;

        //
        // menu box colors
        //
        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MenuForegroundColor = ConsoleColor.Cyan;
        public static ConsoleColor MenuBorderColor = ConsoleColor.Gray;

        //
        // message box colors
        //
        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.Cyan;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.DarkCyan;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.Gray;

        //
        // status box colors
        //
        public static ConsoleColor StatusBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor StatusBoxBorderColor = ConsoleColor.DarkRed;
        public static ConsoleColor StatusBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxHeaderForegroundColor = ConsoleColor.Gray;

        //
        // input box colors
        //
        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.Green;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.DarkCyan;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.Cyan;
    }
}
