using LinqExoticJoins;



List<Number> nums = new() 
{   new(Name: "One", NumID: 001), 
    new("Two", 002), 
    new("Ten", 010)
};

List<Day> days = new()
{   new(Name: "Monday", DayID: 001),
    new("Tuesday", 002),
    new("Wednesday", 003)
};

//https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/perform-left-outer-joins
Console.WriteLine("Left Join");
Console.WriteLine("---------");

var leftjoin =
    from n in nums
    join d in days on n.NumID equals d.DayID into jgr
    from j in jgr.DefaultIfEmpty()
    select new { num = n.Name, day = j?.Name ?? string.Empty };

foreach (var v in leftjoin)
    Console.WriteLine(v.num + "  " + v.day);

Console.WriteLine();

//https://www.c-sharpcorner.com/UploadFile/ff2f08/sql-join-in-linq-linq-to-entity-linq-to-sql/
Console.WriteLine("Full Join");
Console.WriteLine("---------");

var rightjoin =
    from d in days
    join n in nums on d.DayID equals n.NumID into jgr
    from j in jgr.DefaultIfEmpty()
    select new { num = j?.Name ?? string.Empty, 
        day = d.Name };

var fulljoin = leftjoin.Union(rightjoin);

foreach (var v in fulljoin)
    Console.WriteLine(v.num + "  " + v.day);

Console.WriteLine();

//https://stackoverflow.com/questions/28305989/how-to-make-a-join-in-linq-to-sql-equivalent-to-not-equals
Console.WriteLine("Join on non equals");
Console.WriteLine("---------");

var joinenq =
    from n in nums
    from d in days
    where n.NumID != d.DayID
    select new { num = n.Name, day = d.Name };

foreach (var v in joinenq)
    Console.WriteLine(v.num + "  " + v.day);


