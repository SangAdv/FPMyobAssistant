using System;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    internal class MAFileSelection
    {
        #region Properties

        internal static string ErrorMessage { get; private set; } = string.Empty;
        internal static bool HasError => !string.IsNullOrEmpty(ErrorMessage);
        internal static bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);

        #endregion Properties

        #region Methods

        internal static string SelectFile(MAFileType fileType, bool checkIfFileExists)
        {
            ErrorMessage = string.Empty;
            var tFilter = string.Empty;

            switch (fileType)
            {
                case MAFileType.CSV:
                    tFilter = "csv files (*.csv)|*.csv";
                    break;

                case MAFileType.TXT:
                    tFilter = "txt files (*.txt)|*.txt";
                    break;

                case MAFileType.XLSX:
                    tFilter = "xlsx files (*.xlsx)|*.xlsx";
                    break;
            }

            var openFileDialog1 = new OpenFileDialog()
            {
                Filter = tFilter,
                Multiselect = false,
                FilterIndex = 2,
                RestoreDirectory = true,
                CheckFileExists = checkIfFileExists
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    return openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error: Could not read file from disk. Original error: {ex.Message}";
                }

            return string.Empty;
        }

        #endregion Methods
    }
}