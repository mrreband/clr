# clr
Safe assembly CLR database project with some basic text functions

---

### CLR Scalar-Valued Functions for Regular Expressions

`regex.Replace (@TextString, @RegexPattern, @ReplaceString)`
- returns a new string with the matched pattern replaced

```sql
SELECT regex.Replace('This     is   a     test', '\s+', ' ') as Result
```

|      Result     |
| --------------- |
| This is a test  |

---

`regex.IsMatch (@TextString, @RegexPattern)`
- returns `True` if a match is found, else `False`

```sql
SELECT regex.IsMatch('This is a test', '[\w]+') AS Result
UNION ALL 
SELECT regex.IsMatch('This is a test', '[\d]+')
```
| Result |
| ------ |
| 1      |
| 0      |

---

`regex.Match (@TextString, @RegexPattern)` 
- returns the first match if any, otherwise `NULL`

```sql
SELECT regex.Match('This is a test', '[\w]+') AS Result
UNION ALL 
SELECT regex.Match('This is a test', '[\d]+')
```
| Result |
| ------ |
| This   |
| NULL   |

---

### CLR Tabled-Valued Functions for Regular Expressions

---

`regex.Matches (@TextString, @RegexPattern)`
- returns all matches 
  - idx = position in string
  - value = matched string

```sql
SELECT idx, value FROM dbo.RegexMatches('This is a test', '[\w]+')
```

| idx | value |
| --- | ----- |
| 0   | This  |
| 5   | is    |
| 8   | a     |
| 10  | test  |
