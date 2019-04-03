namespace FPMyobAssistant
{
    //internal class MAReadTXT
    //{
    //    #region Variables

    //    private string mDelimeter = string.Empty;

    //    #endregion Variables

    //    #region Properties

    //    internal Dictionary<int, Dictionary<int, string>> Items = new Dictionary<int, Dictionary<int, string>>();

    //    #endregion Properties

    //    #region Constructor

    //    internal MAReadTXT(string txtFilename, string delimeter = ",")
    //    {
    //        mDelimeter = delimeter;
    //        SplitLines(File.ReadAllLines(txtFilename, Encoding.UTF8));
    //    }

    //    #endregion Constructor

    //    #region Method

    //    internal string GetText(int row, int column)
    //    {
    //        if (!Items.ContainsKey(row)) return string.Empty;

    //        if (!Items[row].ContainsKey(column)) return string.Empty;

    //        var rowData = Items[row];
    //        return rowData[column];
    //    }

    //    internal T Get<T>(int row, int column)
    //    {
    //        if (!Items.ContainsKey(row)) return default(T);

    //        return !Items[row].ContainsKey(column) ? default(T) : Items[row][column].Value<T>();
    //    }

    //    #endregion Method

    //    #region Private Methods

    //    private void SplitLines(string[] dataLines)
    //    {
    //        var rows = 0;
    //        Items.Clear();

    //        foreach (var line in dataLines)
    //        {
    //            Items.Add(rows, GetLineItems(line));
    //            rows++;
    //        }
    //    }

    //    private Dictionary<int, string> GetLineItems(string rawData)
    //    {
    //        var tList = new Dictionary<int, string>();
    //        var columns = 0;

    //        //If the delimeter is not present, add the whole line
    //        if (!rawData.Contains(mDelimeter))
    //        {
    //            tList.Add(columns, rawData);
    //            return tList;
    //        }

    //        var tEscapeStarted = false;
    //        var tBuilder = string.Empty;

    //        foreach (var cc in rawData)
    //        {
    //            //Found a comma
    //            if (cc == ',')
    //            {
    //                if (tEscapeStarted) continue;

    //                tList.Add(columns, tBuilder);
    //                columns++;
    //                tBuilder = string.Empty;
    //            }
    //            //Found a quote
    //            else if (cc.ToString() == "\"")
    //            {
    //                tEscapeStarted = !tEscapeStarted;
    //            }
    //            //Found a character
    //            else tBuilder += cc;
    //        }

    //        tList.Add(columns, tBuilder);

    //        return tList;
    //    }

    //    #endregion Private Methods
    //}
}