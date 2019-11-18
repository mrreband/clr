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

    [SqlFunction]
    public static SqlString RegexMatch(SqlString TextString, SqlString RegexPattern)
    {
        var textString = (TextString.IsNull) ? "" : TextString.ToString();
        var regexPattern = (TextString.IsNull) ? "" : RegexPattern.ToString();

        Regex r1 = new Regex(regexPattern.TrimEnd(null));
        var match = r1.Match(textString.TrimEnd(null)).Value;
        return (match == "") ? (SqlString)null : match;
    }
}
