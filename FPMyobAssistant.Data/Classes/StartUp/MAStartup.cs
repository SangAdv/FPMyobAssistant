﻿using SangAdv.Common;
using System.IO;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MAStartup : ASAObjectFile<MAStartupItems>
    {
        #region Variables

        private static string mFilename = Path.Combine(Application.StartupPath, "startup.suf");

        #endregion Variables

        #region Properties

        public MAStartupItems Items => Data;

        #endregion Properties

        #region Constructor

        internal MAStartup() : base(mFilename, "secret")
        {
            PrepareDefaults();
        }

        #endregion Constructor

        #region Private Methods

        private void PrepareDefaults()
        {
            if (!File.Exists(mFilename))
            {
                Reset();
                SaveObjectFile();
            }
            LoadObjectFile();
        }

        #endregion Private Methods
    }

    public class MAStartupItems
    {
        public string CurrentVersion { get; set; } = string.Empty;
        public bool RememberUser { get; set; } = false;
        public string User { get; set; } = string.Empty;
    }
}