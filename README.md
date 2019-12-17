# clr
Safe assembly CLR database project with some basic text functions

---

### CLR Scalar-Valued Functions for Regular Expressions

`regex.Replace (@TextString, @RegexPattern, @ReplaceString)`

```sql
SELECT regex.Replace('This     is   a     test', '\s+', ' ') as Result
```

|      Result     |
| --------------- |
| This is a test  |

---

`regex.IsMatch (@TextString, @RegexPattern)`

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

### CLR Tabled-Valued Functions for Regular Expressions

---

`regex.Matches (@TextString, @RegexPattern)`

```sql
SELECT idx, value FROM dbo.RegexMatches('This is a test', '[\w]+')
```

| idx | value |
| --- | ----- |
| 0   | This  |
| 5   | is    |
| 8   | a     |
| 10  | test  |
