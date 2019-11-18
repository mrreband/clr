-- custom function to call three CLR functions in sequence
CREATE FUNCTION dbo.GetUniqueConsonants
(
	@TextString VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS BEGIN
    DECLARE @result VARCHAR(MAX);
    SELECT  @result = dbo.SortChars(dbo.DistinctChars(dbo.RegexReplace(UPPER(@TextString), '[AEIOU\s]', '')));
    RETURN  @result;
END;
GO
