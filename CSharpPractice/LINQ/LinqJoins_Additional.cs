using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPractice.LINQ;

[PracticeProgram("LINQ", "Additional join examples")]
public class LinqJoins
{
    public static void Demo()
    {
        List<string> list1 = new List<string>();
        list1.Add("A");
        list1.Add("B");
        list1.Add("C");

        List<string> list2 = new List<string>();
        list2.Add("C");
        list2.Add("D");

        // ============================================================
        // 1. INNER JOIN
        // Returns only values that exist in BOTH lists.
        // Result: C - C
        // ============================================================

        // Query Syntax
        var innerJoinQuery =
            (from l1 in list1
             join l2 in list2
                 on l1 equals l2
             select new
             {
                 Left = l1,
                 Right = l2
             }).ToList();

        // Method Syntax
        var innerJoinMethod = list1
            .Join(
                list2,
                l1 => l1,               // Key from list1
                l2 => l2,               // Key from list2
                (l1, l2) => new
                {
                    Left = l1,
                    Right = l2
                })
            .ToList();


        // ============================================================
        // 2. LEFT OUTER JOIN
        // Returns ALL values from list1.
        // Matching values from list2 are included.
        // If there is no match, Right will be null.
        //
        // Result:
        // A - null
        // B - null
        // C - C
        // ============================================================

        // Query Syntax
        var leftJoinQuery =
            (from l1 in list1
             join l2 in list2 on l1 equals l2
                 into l2JoinList
             from l2 in l2JoinList.DefaultIfEmpty()
             select new
             {
                 Left = l1,
                 Right = l2
             }).ToList();

        // Method Syntax
        // GroupJoin + SelectMany + DefaultIfEmpty = Left Join
        var leftJoinMethod = list1
            .GroupJoin(
                list2,
                l1 => l1,
                l2 => l2,
                (l1, matches) => new
                {
                    Left = l1,
                    Matches = matches
                })
            .SelectMany(
                x => x.Matches.DefaultIfEmpty(),
                (x, l2) => new
                {
                    Left = x.Left,
                    Right = l2
                })
            .ToList();


        // ============================================================
        // 3. RIGHT OUTER JOIN
        // LINQ has no direct RightJoin in older/common LINQ APIs.
        //
        // Swap the collections and perform a Left Join.
        // Returns ALL values from list2.
        //
        // Result:
        // C    - C
        // null - D
        // ============================================================

        // Query Syntax
        var rightJoinQuery =
            (from l2 in list2
             join l1 in list1
                 on l2 equals l1
                 into l1JoinList
             from l1 in l1JoinList.DefaultIfEmpty()
             select new
             {
                 Left = l1,
                 Right = l2
             }).ToList();

        // Method Syntax
        var rightJoinMethod = list2
            .GroupJoin(
                list1,
                l2 => l2,
                l1 => l1,
                (l2, matches) => new
                {
                    Right = l2,
                    Matches = matches
                })
            .SelectMany(
                x => x.Matches.DefaultIfEmpty(),
                (x, l1) => new
                {
                    Left = l1,
                    Right = x.Right
                })
            .ToList();


        // ============================================================
        // 4. FULL OUTER JOIN
        // LINQ has no traditional "full join" query keyword.
        //
        // Full Join = Left Join + unmatched records from Right Join
        //
        // Result:
        // A    - null
        // B    - null
        // C    - C
        // null - D
        // ============================================================

        // Query Syntax
        var fullJoinQueryLeft =
            from l1 in list1
            join l2 in list2
                on l1 equals l2
                into l2JoinList
            from l2 in l2JoinList.DefaultIfEmpty()
            select new
            {
                Left = l1,
                Right = l2
            };

        var fullJoinQueryRight =
            from l2 in list2
            join l1 in list1
                on l2 equals l1
                into l1JoinList
            from l1 in l1JoinList.DefaultIfEmpty()
            where l1 == null
            select new
            {
                Left = l1,
                Right = l2
            };

        var fullJoinQuery = fullJoinQueryLeft
            .Concat(fullJoinQueryRight)
            .ToList();


        // Method Syntax
        var fullJoinMethodLeft = list1
            .GroupJoin(
                list2,
                l1 => l1,
                l2 => l2,
                (l1, matches) => new
                {
                    Left = l1,
                    Matches = matches
                })
            .SelectMany(
                x => x.Matches.DefaultIfEmpty(),
                (x, l2) => new
                {
                    Left = x.Left,
                    Right = l2
                });

        var fullJoinMethodRight = list2
            .GroupJoin(
                list1,
                l2 => l2,
                l1 => l1,
                (l2, matches) => new
                {
                    Right = l2,
                    Matches = matches
                })
            .SelectMany(
                x => x.Matches.DefaultIfEmpty(),
                (x, l1) => new
                {
                    Left = l1,
                    Right = x.Right
                })
            // Add only records that were NOT found by the left join.
            .Where(x => x.Left == null);

        var fullJoinMethod = fullJoinMethodLeft
            .Concat(fullJoinMethodRight)
            .ToList();


        // ============================================================
        // 5. CROSS JOIN / CARTESIAN JOIN
        // Every item in list1 is combined with every item in list2.
        //
        // 3 items x 2 items = 6 results
        //
        // A - C
        // A - D
        // B - C
        // B - D
        // C - C
        // C - D
        // ============================================================

        // Query Syntax
        var crossJoinQuery =
            (from l1 in list1
             from l2 in list2
             select new
             {
                 Left = l1,
                 Right = l2
             }).ToList();

        // Method Syntax
        // SelectMany is used to produce the Cartesian product.
        var crossJoinMethod = list1
            .SelectMany(
                l1 => list2,
                (l1, l2) => new
                {
                    Left = l1,
                    Right = l2
                })
            .ToList();


        // ============================================================
        // 6. GROUP JOIN
        // Similar to SQL LEFT JOIN conceptually, but instead of
        // flattening the matches, each left item gets a collection
        // containing all matching right-side items.
        //
        // A -> []
        // B -> []
        // C -> [C]
        // ============================================================

        // Query Syntax
        var groupJoinQuery =
            (from l1 in list1
             join l2 in list2
                 on l1 equals l2
                 into matches
             select new
             {
                 Left = l1,
                 Matches = matches.ToList()
             }).ToList();

        // Method Syntax
        var groupJoinMethod = list1
            .GroupJoin(
                list2,
                l1 => l1,
                l2 => l2,
                (l1, matches) => new
                {
                    Left = l1,
                    Matches = matches.ToList()
                })
            .ToList();


        // ============================================================
        // 7. LEFT ANTI JOIN
        // Returns values from list1 that DO NOT exist in list2.
        //
        // Result:
        // A
        // B
        // ============================================================

        // Query Syntax
        var leftAntiJoinQuery =
            (from l1 in list1
             join l2 in list2
                 on l1 equals l2
                 into matches
             from l2 in matches.DefaultIfEmpty()
             where l2 == null
             select l1)
            .ToList();

        // Method Syntax
        var leftAntiJoinMethod = list1
            .GroupJoin(
                list2,
                l1 => l1,
                l2 => l2,
                (l1, matches) => new
                {
                    Left = l1,
                    Matches = matches
                })
            .Where(x => !x.Matches.Any())
            .Select(x => x.Left)
            .ToList();


        // ============================================================
        // 8. RIGHT ANTI JOIN
        // Returns values from list2 that DO NOT exist in list1.
        //
        // Result:
        // D
        // ============================================================

        // Query Syntax
        var rightAntiJoinQuery =
            (from l2 in list2
             join l1 in list1
                 on l2 equals l1
                 into matches
             from l1 in matches.DefaultIfEmpty()
             where l1 == null
             select l2)
            .ToList();

        // Method Syntax
        var rightAntiJoinMethod = list2
            .GroupJoin(
                list1,
                l2 => l2,
                l1 => l1,
                (l2, matches) => new
                {
                    Right = l2,
                    Matches = matches
                })
            .Where(x => !x.Matches.Any())
            .Select(x => x.Right)
            .ToList();


        // ============================================================
        // 9. FULL ANTI JOIN / SYMMETRIC DIFFERENCE
        // Returns records that exist on ONLY ONE side.
        // Matching records are excluded.
        //
        // Result:
        // A
        // B
        // D
        // ============================================================

        // Query Syntax
        var fullAntiJoinQuery = leftAntiJoinQuery
            .Concat(rightAntiJoinQuery)
            .ToList();

        // Method Syntax
        var fullAntiJoinMethod = leftAntiJoinMethod
            .Concat(rightAntiJoinMethod)
            .ToList();


        // ============================================================
        // PRINT SOME RESULTS
        // ============================================================

        Console.WriteLine("INNER JOIN:");
        foreach (var item in innerJoinQuery)
        {
            Console.WriteLine($"{item.Left} - {item.Right}");
        }

        Console.WriteLine("\nLEFT JOIN:");
        foreach (var item in leftJoinQuery)
        {
            Console.WriteLine(
                $"{item.Left ?? "null"} - {item.Right ?? "null"}");
        }

        Console.WriteLine("\nRIGHT JOIN:");
        foreach (var item in rightJoinQuery)
        {
            Console.WriteLine(
                $"{item.Left ?? "null"} - {item.Right ?? "null"}");
        }

        Console.WriteLine("\nFULL OUTER JOIN:");
        foreach (var item in fullJoinQuery)
        {
            Console.WriteLine(
                $"{item.Left ?? "null"} - {item.Right ?? "null"}");
        }

        Console.WriteLine("\nCROSS JOIN:");
        foreach (var item in crossJoinQuery)
        {
            Console.WriteLine($"{item.Left} - {item.Right}");
        }

        Console.WriteLine("\nLEFT ANTI JOIN:");
        foreach (var item in leftAntiJoinQuery)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nRIGHT ANTI JOIN:");
        foreach (var item in rightAntiJoinQuery)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nFULL ANTI JOIN:");
        foreach (var item in fullAntiJoinQuery)
        {
            Console.WriteLine(item);
        }
    }
}
