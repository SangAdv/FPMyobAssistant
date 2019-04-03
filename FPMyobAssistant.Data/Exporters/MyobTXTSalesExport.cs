using System;
using System.Collections.Generic;
using System.IO;

namespace FPMyobAssistant
{
    public class MyobTXTSalesExport<T>
    {
        #region Variables

        internal readonly List<T> DataItems = new List<T>();
        internal List<string> FileItems = new List<string>();

        #endregion Variables

        #region Properties

        public int DataCount => DataItems.Count;
        public bool HasError { get; internal set; }

        #endregion Properties

        #region Constructor

        public MyobTXTSalesExport()
        {
            FileItems.Clear();
        }

        #endregion

        #region Methods

        public void Add(T item)
        {
            DataItems.Add(item);
        }

        public string Save(string exportFilename)
        {
            try
            {
                exportFilename = exportFilename.Trim();
                if (File.Exists(exportFilename)) File.Delete(exportFilename);
                File.WriteAllLines(exportFilename, FileItems);
                return $"{exportFilename} saved.";
            }
            catch (Exception ex)
            {
                return $"Error: Could not save file. Original error: {ex.Message}";
            }
        }

        internal void AddEntryLine()
        {
            FileItems.Add(string.Empty);
        }
        #endregion Methods
    }
}