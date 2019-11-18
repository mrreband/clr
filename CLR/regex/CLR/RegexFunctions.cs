using System;
using System.Linq;
using System.Collections;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction]
    public static SqlString RegexReplace(SqlString TextString, SqlString RegexPattern, SqlString ReplaceString)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var regexPattern = (TextString.IsNull) ? "" : RegexPattern.ToString();
        var replaceString = (ReplaceString.IsNull) ? "" : ReplaceString.ToString();

        var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
        var replacedText = regex.Replace(textString, replaceString);
        return new SqlString(replacedText);
    }

    [SqlFunction]
    public static bool RegexIsMatch(SqlString TextString, SqlString RegexPattern)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var regexPattern = (TextString.IsNull) ? "" : RegexPattern.ToString();

        Regex r1 = new Regex(regexPattern.TrimEnd(null));
        return r1.Match(textString.TrimEnd(null)).Success;
    }

    [SqlFunction(FillRowMethodName = "FillRegexMatches", TableDefinition = "value nvarchar(1000)")]
    public static IEnumerable RegexMatch(SqlString TextString, SqlString RegexPattern)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var regexPattern = (TextString.IsNull) ? "" : RegexPattern.ToString();

        Regex r1 = new Regex(regexPattern.TrimEnd(null));

        var matches = r1.Matches(textString.TrimEnd(null));
        if (matches.Count > 0)
        {
            return matches.Cast<Match>().Select(m => m.Value.ToString());
        }
        return matches;
    }

    private static void FillRegexMatches(Object row, out SqlString str)
    {
        str = new SqlString((string)row);
    }
}
