﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PokemonEncCalc
{

    static class Program
    {

        internal const string VERSION = "5.11";
        internal const Version STARTING_VERSION = Version.Gold;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.Language == 0)
                detectSystemLanguage();

            // Load data
            PokemonTables.PopulatePokemonTables();
            Utils.loadEncounterSlotData();
            Utils.initializeMoves();

            Application.Run(new frmMainPage());
        }

        static void detectSystemLanguage()
        {
            if (CultureInfo.CurrentUICulture.Name.StartsWith("fr"))
                Properties.Settings.Default.Language = 2;
            else
                Properties.Settings.Default.Language = 1;
        }

    }
}
