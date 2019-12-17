using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction]
    public static SqlString DistinctChars(SqlString TextString)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var datalist = new List<char>();
        datalist.AddRange(textString);
        var deduped = datalist.Distinct().ToList();
        return String.Concat(deduped);
    }

    [SqlFunction]
    public static SqlString SortChars(SqlString TextString)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var datalist = new List<char>();
        datalist.AddRange(textString);
        var sorted = datalist.OrderBy(c => c).ToList();
        return String.Concat(sorted);
    }

    [SqlFunction]
    public static SqlString AlphaChars(SqlString TextString)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var alphas = new String(textString.Where(Char.IsLetter).ToArray());
        return alphas;
    }
}
