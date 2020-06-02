using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

    [SqlFunction]
    public static SqlString Spoonerize(SqlString TextString)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var word1 = Regex.Replace(textString.Split(' ')[0].Trim(), @"[^\w]", "");
        var word2 = Regex.Replace(textString.Split(' ')[1].Trim(), @"[^\w]", "");

        var consonants1 = Regex.Match(word1, @"^[bcdfghjklmnpqrstvwxyz]+", RegexOptions.IgnoreCase);
        var consonants2 = Regex.Match(word2, @"^[bcdfghjklmnpqrstvwxyz]+", RegexOptions.IgnoreCase);

        var spoon1start = consonants2.Value;
        var spoon1end = (consonants1.Success) ? word1.Substring(consonants1.Index + 1) : word1;

        var spoon2start = (consonants1.Success) ? consonants1.Value : "";
        var spoon2end = (consonants2.Success) ? word2.Substring(consonants2.Index + 1) : word2;

        var spoon1 = spoon1start + spoon1end;
        var spoon2 = spoon2start + spoon2end;

        var spoonerized = spoon1 + " " + spoon2;
        return spoonerized;
    }
}
