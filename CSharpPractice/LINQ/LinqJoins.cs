namespace CSharpPractice.LINQ
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int DeptId { get; set; }
        public decimal Salary { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    public class LinqJoins2
    {
        public static void Start()
        {
            var departments = new List<Department>
            {
                new() { Id = 1, Name = "IT" },
                new() { Id = 2, Name = "HR" },
                new() { Id = 3, Name = "Finance" },
                new() { Id = 4, Name = "Sales" },
                new() { Id = 5, Name = "Legal" } // No employees
            };

            var employees = new List<Employee>
            {
                new() { Id = 1, Name = "Amit",   DeptId = 1,  Salary = 80000 },
                new() { Id = 2, Name = "Neha",   DeptId = 1,  Salary = 95000 },
                new() { Id = 3, Name = "Rahul",  DeptId = 2,  Salary = 60000 },
                new() { Id = 4, Name = "Priya",  DeptId = 2,  Salary = 70000 },
                new() { Id = 5, Name = "Karan",  DeptId = 3,  Salary = 90000 },
                new() { Id = 6, Name = "Sneha",  DeptId = 3,  Salary = 85000 },
                new() { Id = 7, Name = "Vikram", DeptId = 4,  Salary = 75000 },
                new() { Id = 8, Name = "Anjali", DeptId = 4,  Salary = 65000 },

                // Department 99 doesn't exist.
                new() { Id = 9, Name = "Rohan", DeptId = 99, Salary = 55000 }
            };

            // ============================================================
            // 1. INNER JOIN
            // Query syntax: join
            // Method syntax: Join()
            // ============================================================
            PrintTitle("1. INNER JOIN");

            var innerJoinQuery =
                (from emp in employees
                 join dept in departments
                     on emp.DeptId equals dept.Id
                 select new
                 {
                     EmpName = emp.Name,
                     DeptName = dept.Name
                 }).ToList();

            var innerJoinMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new
                    {
                        EmpName = emp.Name,
                        DeptName = dept.Name
                    })
                .ToList();

            PrintRows("QUERY SYNTAX", innerJoinQuery,
                x => $"{x.EmpName,-10} {x.DeptName}");
            PrintRows("METHOD SYNTAX", innerJoinMethod,
                x => $"{x.EmpName,-10} {x.DeptName}");

            // ============================================================
            // 2. LEFT OUTER JOIN
            // Query syntax: group join + DefaultIfEmpty()
            // Method syntax: GroupJoin() + SelectMany() + DefaultIfEmpty()
            // ============================================================
            PrintTitle("2. LEFT OUTER JOIN");

            var leftJoinQuery =
                (from emp in employees
                 join dept in departments
                     on emp.DeptId equals dept.Id into deptJoin
                 from dept in deptJoin.DefaultIfEmpty()
                 select new
                 {
                     EmpName = emp.Name,
                     DeptName = dept?.Name ?? "NO DEPARTMENT"
                 }).ToList();

            var leftJoinMethod = employees
                .GroupJoin(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, deptJoin) => new { emp, deptJoin })
                .SelectMany(
                    x => x.deptJoin.DefaultIfEmpty(),
                    (x, dept) => new
                    {
                        EmpName = x.emp.Name,
                        DeptName = dept?.Name ?? "NO DEPARTMENT"
                    })
                .ToList();

            PrintRows("QUERY SYNTAX", leftJoinQuery,
                x => $"{x.EmpName,-10} {x.DeptName}");
            PrintRows("METHOD SYNTAX", leftJoinMethod,
                x => $"{x.EmpName,-10} {x.DeptName}");

            // ============================================================
            // 3. RIGHT JOIN EQUIVALENT
            // LINQ has no right-join keyword/method.
            // Reverse the tables and perform a left outer join.
            // ============================================================
            PrintTitle("3. RIGHT JOIN EQUIVALENT");

            var rightJoinQuery =
                (from dept in departments
                 join emp in employees
                     on dept.Id equals emp.DeptId into empJoin
                 from emp in empJoin.DefaultIfEmpty()
                 select new
                 {
                     EmpName = emp?.Name ?? "NO EMPLOYEE",
                     DeptName = dept.Name
                 }).ToList();

            var rightJoinMethod = departments
                .GroupJoin(
                    employees,
                    dept => dept.Id,
                    emp => emp.DeptId,
                    (dept, empJoin) => new { dept, empJoin })
                .SelectMany(
                    x => x.empJoin.DefaultIfEmpty(),
                    (x, emp) => new
                    {
                        EmpName = emp?.Name ?? "NO EMPLOYEE",
                        DeptName = x.dept.Name
                    })
                .ToList();

            PrintRows("QUERY SYNTAX", rightJoinQuery,
                x => $"{x.EmpName,-15} {x.DeptName}");
            PrintRows("METHOD SYNTAX", rightJoinMethod,
                x => $"{x.EmpName,-15} {x.DeptName}");

            // ============================================================
            // 4. CROSS JOIN
            // Query syntax: multiple from clauses
            // Method syntax: SelectMany()
            // ============================================================
            PrintTitle("4. CROSS JOIN");

            var crossJoinQuery =
                (from emp in employees
                 from dept in departments
                 select new
                 {
                     EmpName = emp.Name,
                     DeptName = dept.Name
                 }).ToList();

            var crossJoinMethod = employees
                .SelectMany(
                    emp => departments,
                    (emp, dept) => new
                    {
                        EmpName = emp.Name,
                        DeptName = dept.Name
                    })
                .ToList();

            PrintRows("QUERY SYNTAX", crossJoinQuery,
                x => $"{x.EmpName,-10} {x.DeptName}");
            Console.WriteLine($"Query total combinations: {crossJoinQuery.Count}");

            PrintRows("METHOD SYNTAX", crossJoinMethod,
                x => $"{x.EmpName,-10} {x.DeptName}");
            Console.WriteLine($"Method total combinations: {crossJoinMethod.Count}");

            // ============================================================
            // 5. FULL OUTER JOIN
            // No direct LINQ operator.
            // Build LEFT JOIN + unmatched right-side records, then Concat().
            // ============================================================
            PrintTitle("5. FULL OUTER JOIN");

            var fullLeftQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id into deptJoin
                from dept in deptJoin.DefaultIfEmpty()
                select new
                {
                    EmpName = (string?)emp.Name,
                    DeptName = dept?.Name
                };

            var unmatchedDepartmentsQuery =
                from dept in departments
                join emp in employees
                    on dept.Id equals emp.DeptId into empJoin
                from emp in empJoin.DefaultIfEmpty()
                where emp == null
                select new
                {
                    EmpName = (string?)null,
                    DeptName = (string?)dept.Name
                };

            var fullOuterJoinQuery = fullLeftQuery
                .Concat(unmatchedDepartmentsQuery)
                .ToList();

            var fullLeftMethod = employees
                .GroupJoin(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, deptJoin) => new { emp, deptJoin })
                .SelectMany(
                    x => x.deptJoin.DefaultIfEmpty(),
                    (x, dept) => new
                    {
                        EmpName = (string?)x.emp.Name,
                        DeptName = dept?.Name
                    });

            var unmatchedDepartmentsMethod = departments
                .GroupJoin(
                    employees,
                    dept => dept.Id,
                    emp => emp.DeptId,
                    (dept, empJoin) => new { dept, empJoin })
                .Where(x => !x.empJoin.Any())
                .Select(x => new
                {
                    EmpName = (string?)null,
                    DeptName = (string?)x.dept.Name
                });

            var fullOuterJoinMethod = fullLeftMethod
                .Concat(unmatchedDepartmentsMethod)
                .ToList();

            PrintRows("QUERY SYNTAX", fullOuterJoinQuery,
                x => $"{x.EmpName ?? "NO EMPLOYEE",-15} {x.DeptName ?? "NO DEPARTMENT"}");
            PrintRows("METHOD SYNTAX", fullOuterJoinMethod,
                x => $"{x.EmpName ?? "NO EMPLOYEE",-15} {x.DeptName ?? "NO DEPARTMENT"}");

            // ============================================================
            // 6. GROUP BY DEPARTMENT ID
            // Query syntax: group ... by
            // Method syntax: GroupBy()
            // Group key is DeptId; each group still contains full Employee objects.
            // ============================================================
            PrintTitle("6. GROUP BY DEPARTMENT");

            var groupedQuery =
                from emp in employees
                group emp by emp.DeptId into g
                select g;

            var groupedMethod = employees
                .GroupBy(emp => emp.DeptId);

            PrintEmployeeGroups("QUERY SYNTAX", groupedQuery);
            PrintEmployeeGroups("METHOD SYNTAX", groupedMethod);

            // ============================================================
            // 7. EMPLOYEE COUNT PER DEPARTMENT
            // Inner join first => only departments with matching employees.
            // ============================================================
            PrintTitle("7. EMPLOYEE COUNT PER DEPARTMENT");

            var deptCountQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id
                group emp by new { dept.Id, dept.Name } into g
                select new
                {
                    DeptId = g.Key.Id,
                    DeptName = g.Key.Name,
                    Count = g.Count()
                };

            var deptCountMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new { emp, dept })
                .GroupBy(x => new { x.dept.Id, x.dept.Name })
                .Select(g => new
                {
                    DeptId = g.Key.Id,
                    DeptName = g.Key.Name,
                    Count = g.Count()
                });

            PrintRows("QUERY SYNTAX", deptCountQuery,
                x => $"{x.DeptId,-3} {x.DeptName,-10} {x.Count}");
            PrintRows("METHOD SYNTAX", deptCountMethod,
                x => $"{x.DeptId,-3} {x.DeptName,-10} {x.Count}");

            // ============================================================
            // 8. DEPARTMENT COUNT INCLUDING ZERO EMPLOYEES
            // GroupJoin keeps every outer Department.
            // ============================================================
            PrintTitle("8. COUNT INCLUDING ZERO EMPLOYEES");

            var deptCountIncludingZeroQuery =
                from dept in departments
                join emp in employees
                    on dept.Id equals emp.DeptId into empGroup
                select new
                {
                    DeptName = dept.Name,
                    Count = empGroup.Count()
                };

            var deptCountIncludingZeroMethod = departments
                .GroupJoin(
                    employees,
                    dept => dept.Id,
                    emp => emp.DeptId,
                    (dept, empGroup) => new
                    {
                        DeptName = dept.Name,
                        Count = empGroup.Count()
                    });

            PrintRows("QUERY SYNTAX", deptCountIncludingZeroQuery,
                x => $"{x.DeptName,-10} {x.Count}");
            PrintRows("METHOD SYNTAX", deptCountIncludingZeroMethod,
                x => $"{x.DeptName,-10} {x.Count}");

            // ============================================================
            // 9. DEPARTMENTS HAVING MORE THAN 1 EMPLOYEE
            // Query "where" after grouping is conceptually SQL HAVING.
            // ============================================================
            PrintTitle("9. DEPARTMENTS HAVING > 1 EMPLOYEE");

            var departmentsHavingQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id
                group emp by dept.Name into g
                where g.Count() > 1
                select new
                {
                    DeptName = g.Key,
                    Count = g.Count()
                };

            var departmentsHavingMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new { emp, dept })
                .GroupBy(x => x.dept.Name, x => x.emp)
                .Where(g => g.Count() > 1)
                .Select(g => new
                {
                    DeptName = g.Key,
                    Count = g.Count()
                });

            PrintRows("QUERY SYNTAX", departmentsHavingQuery,
                x => $"{x.DeptName,-10} {x.Count}");
            PrintRows("METHOD SYNTAX", departmentsHavingMethod,
                x => $"{x.DeptName,-10} {x.Count}");

            // ============================================================
            // 10. EMPLOYEES WITHOUT VALID DEPARTMENT
            // Left join + null filter.
            // ============================================================
            PrintTitle("10. EMPLOYEES WITHOUT DEPARTMENT");

            var employeesWithoutDeptQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id into deptJoin
                from dept in deptJoin.DefaultIfEmpty()
                where dept == null
                select emp;

            var employeesWithoutDeptMethod = employees
                .GroupJoin(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, deptJoin) => new { emp, deptJoin })
                .Where(x => !x.deptJoin.Any())
                .Select(x => x.emp);

            PrintRows("QUERY SYNTAX", employeesWithoutDeptQuery,
                emp => $"{emp.Name} - DeptId: {emp.DeptId}");
            PrintRows("METHOD SYNTAX", employeesWithoutDeptMethod,
                emp => $"{emp.Name} - DeptId: {emp.DeptId}");

            // ============================================================
            // 11. DEPARTMENTS WITHOUT EMPLOYEES
            // Query syntax uses where, but Any() itself has no query keyword.
            // ============================================================
            PrintTitle("11. DEPARTMENTS WITHOUT EMPLOYEES");

            var departmentsWithoutEmployeesQuery =
                from dept in departments
                where !employees.Any(emp => emp.DeptId == dept.Id)
                select dept;

            var departmentsWithoutEmployeesMethod = departments
                .Where(dept => !employees.Any(emp => emp.DeptId == dept.Id));

            PrintRows("QUERY SYNTAX", departmentsWithoutEmployeesQuery,
                dept => dept.Name);
            PrintRows("METHOD SYNTAX", departmentsWithoutEmployeesMethod,
                dept => dept.Name);

            // ============================================================
            // 12. HIGHEST PAID EMPLOYEE
            // OrderByDescending/FirstOrDefault have no dedicated query keyword
            // for "first", so method syntax is the natural form.
            // ============================================================
            PrintTitle("12. HIGHEST PAID EMPLOYEE");

            var highestPaid = employees
                .OrderByDescending(x => x.Salary)
                .FirstOrDefault();

            Console.WriteLine(highestPaid == null
                ? "Not Found"
                : $"{highestPaid.Name} - {highestPaid.Salary}");

            // ============================================================
            // 13. SECOND HIGHEST DISTINCT SALARY
            // Distinct/Skip/FirstOrDefault have no direct query keywords.
            // ============================================================
            PrintTitle("13. SECOND HIGHEST SALARY");

            var secondHighestSalary = employees
                .Select(x => x.Salary)
                .Distinct()
                .OrderByDescending(x => x)
                .Skip(1)
                .FirstOrDefault();

            Console.WriteLine($"Second Highest: {secondHighestSalary}");

            var secondHighestEmployeesQuery =
                from emp in employees
                where emp.Salary == secondHighestSalary
                select emp;

            var secondHighestEmployeesMethod = employees
                .Where(emp => emp.Salary == secondHighestSalary);

            PrintRows("QUERY SYNTAX - EMPLOYEES", secondHighestEmployeesQuery,
                emp => $"{emp.Name} - {emp.Salary}");
            PrintRows("METHOD SYNTAX - EMPLOYEES", secondHighestEmployeesMethod,
                emp => $"{emp.Name} - {emp.Salary}");

            // ============================================================
            // 14. THIRD HIGHEST DISTINCT SALARY
            // ============================================================
            PrintTitle("14. THIRD HIGHEST SALARY");

            var thirdHighestSalary = employees
                .Select(x => x.Salary)
                .Distinct()
                .OrderByDescending(x => x)
                .Skip(2)
                .FirstOrDefault();

            Console.WriteLine($"Third Highest: {thirdHighestSalary}");

            // ============================================================
            // 15. NTH HIGHEST DISTINCT SALARY
            // ============================================================
            PrintTitle("15. NTH HIGHEST SALARY");

            int n = 3;

            var nthHighestSalary = employees
                .Select(x => x.Salary)
                .Distinct()
                .OrderByDescending(x => x)
                .Skip(n - 1)
                .FirstOrDefault();

            Console.WriteLine($"{n}th Highest Salary: {nthHighestSalary}");

            // ============================================================
            // 16. MAX SALARY PER DEPARTMENT
            // ============================================================
            PrintTitle("16. MAX SALARY PER DEPARTMENT");

            var maxSalaryPerDeptQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id
                group emp by dept.Name into g
                select new
                {
                    DeptName = g.Key,
                    MaxSalary = g.Max(x => x.Salary)
                };

            var maxSalaryPerDeptMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new { emp, dept })
                .GroupBy(x => x.dept.Name, x => x.emp)
                .Select(g => new
                {
                    DeptName = g.Key,
                    MaxSalary = g.Max(x => x.Salary)
                });

            PrintRows("QUERY SYNTAX", maxSalaryPerDeptQuery,
                x => $"{x.DeptName,-10} {x.MaxSalary}");
            PrintRows("METHOD SYNTAX", maxSalaryPerDeptMethod,
                x => $"{x.DeptName,-10} {x.MaxSalary}");

            // ============================================================
            // 17. HIGHEST PAID EMPLOYEE PER DEPARTMENT
            // Query syntax demonstrates let.
            // let carries an intermediate calculated value forward.
            // ============================================================
            PrintTitle("17. HIGHEST PAID EMPLOYEE PER DEPARTMENT");

            var highestPaidPerDeptQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id
                group emp by dept.Name into g
                let highest = g
                    .OrderByDescending(x => x.Salary)
                    .First()
                select new
                {
                    DeptName = g.Key,
                    Employee = highest.Name,
                    Salary = highest.Salary
                };

            var highestPaidPerDeptMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new { emp, dept })
                .GroupBy(x => x.dept.Name, x => x.emp)
                .Select(g =>
                {
                    var highest = g
                        .OrderByDescending(x => x.Salary)
                        .First();

                    return new
                    {
                        DeptName = g.Key,
                        Employee = highest.Name,
                        Salary = highest.Salary
                    };
                });

            PrintRows("QUERY SYNTAX", highestPaidPerDeptQuery,
                x => $"{x.DeptName,-10} {x.Employee,-10} {x.Salary}");
            PrintRows("METHOD SYNTAX", highestPaidPerDeptMethod,
                x => $"{x.DeptName,-10} {x.Employee,-10} {x.Salary}");

            // ============================================================
            // 18. AVERAGE SALARY PER DEPARTMENT
            // ============================================================
            PrintTitle("18. AVERAGE SALARY PER DEPARTMENT");

            var averageSalaryPerDeptQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id
                group emp by dept.Name into g
                select new
                {
                    DeptName = g.Key,
                    AverageSalary = g.Average(x => x.Salary)
                };

            var averageSalaryPerDeptMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new { emp, dept })
                .GroupBy(x => x.dept.Name, x => x.emp)
                .Select(g => new
                {
                    DeptName = g.Key,
                    AverageSalary = g.Average(x => x.Salary)
                });

            PrintRows("QUERY SYNTAX", averageSalaryPerDeptQuery,
                x => $"{x.DeptName,-10} {x.AverageSalary}");
            PrintRows("METHOD SYNTAX", averageSalaryPerDeptMethod,
                x => $"{x.DeptName,-10} {x.AverageSalary}");

            // ============================================================
            // 19. TOTAL SALARY PER DEPARTMENT
            // ============================================================
            PrintTitle("19. TOTAL SALARY PER DEPARTMENT");

            var totalSalaryPerDeptQuery =
                from emp in employees
                join dept in departments
                    on emp.DeptId equals dept.Id
                group emp by dept.Name into g
                select new
                {
                    DeptName = g.Key,
                    TotalSalary = g.Sum(x => x.Salary)
                };

            var totalSalaryPerDeptMethod = employees
                .Join(
                    departments,
                    emp => emp.DeptId,
                    dept => dept.Id,
                    (emp, dept) => new { emp, dept })
                .GroupBy(x => x.dept.Name, x => x.emp)
                .Select(g => new
                {
                    DeptName = g.Key,
                    TotalSalary = g.Sum(x => x.Salary)
                });

            PrintRows("QUERY SYNTAX", totalSalaryPerDeptQuery,
                x => $"{x.DeptName,-10} {x.TotalSalary}");
            PrintRows("METHOD SYNTAX", totalSalaryPerDeptMethod,
                x => $"{x.DeptName,-10} {x.TotalSalary}");

            // ============================================================
            // 20. EMPLOYEES ABOVE COMPANY AVERAGE SALARY
            // Average() is method-only; filtering can be query or method syntax.
            // ============================================================
            PrintTitle("20. EMPLOYEES ABOVE COMPANY AVERAGE");

            var companyAverage = employees.Average(x => x.Salary);

            var aboveAverageQuery =
                (from emp in employees
                 where emp.Salary > companyAverage
                 select emp).ToList();

            var aboveAverageMethod = employees
                .Where(emp => emp.Salary > companyAverage)
                .ToList();

            Console.WriteLine($"Company Average: {companyAverage}");
            PrintRows("QUERY SYNTAX", aboveAverageQuery,
                emp => $"{emp.Name,-10} {emp.Salary}");
            PrintRows("METHOD SYNTAX", aboveAverageMethod,
                emp => $"{emp.Name,-10} {emp.Salary}");

            // ============================================================
            // 21. EMPLOYEE > DEPARTMENT AVERAGE
            // Query syntax demonstrates let.
            // ============================================================
            PrintTitle("21. EMPLOYEES ABOVE DEPARTMENT AVERAGE");

            var aboveDeptAverageQuery =
                from emp in employees
                let deptAverage = employees
                    .Where(x => x.DeptId == emp.DeptId)
                    .Average(x => x.Salary)
                where emp.Salary > deptAverage
                select new
                {
                    emp.Name,
                    emp.DeptId,
                    emp.Salary,
                    DeptAverage = deptAverage
                };

            var aboveDeptAverageMethod = employees
                .Select(emp => new
                {
                    emp,
                    DeptAverage = employees
                        .Where(x => x.DeptId == emp.DeptId)
                        .Average(x => x.Salary)
                })
                .Where(x => x.emp.Salary > x.DeptAverage)
                .Select(x => new
                {
                    x.emp.Name,
                    x.emp.DeptId,
                    x.emp.Salary,
                    x.DeptAverage
                });

            PrintRows("QUERY SYNTAX", aboveDeptAverageQuery,
                x => $"{x.Name,-10} Dept:{x.DeptId,-3} Salary:{x.Salary,-10} Avg:{x.DeptAverage}");
            PrintRows("METHOD SYNTAX", aboveDeptAverageMethod,
                x => $"{x.Name,-10} Dept:{x.DeptId,-3} Salary:{x.Salary,-10} Avg:{x.DeptAverage}");

            // ============================================================
            // 22. TOP 3 HIGHEST PAID EMPLOYEES
            // Query syntax supports orderby, but Take() is still a method call.
            // ============================================================
            PrintTitle("22. TOP 3 HIGHEST PAID");

            var top3Query =
                (from emp in employees
                 orderby emp.Salary descending
                 select emp)
                .Take(3)
                .ToList();

            var top3Method = employees
                .OrderByDescending(x => x.Salary)
                .Take(3)
                .ToList();

            PrintRows("QUERY SYNTAX", top3Query,
                emp => $"{emp.Name,-10} {emp.Salary}");
            PrintRows("METHOD SYNTAX", top3Method,
                emp => $"{emp.Name,-10} {emp.Salary}");

            // ============================================================
            // 23. TOP 2 EMPLOYEES PER VALID DEPARTMENT
            // SelectMany flattens each department group back to employees.
            // ============================================================
            PrintTitle("23. TOP 2 EMPLOYEES PER DEPARTMENT");

            var top2PerDeptQuery =
                (from emp in employees
                 where departments.Any(d => d.Id == emp.DeptId)
                 group emp by emp.DeptId into g
                 from emp in g
                     .OrderByDescending(x => x.Salary)
                     .Take(2)
                 select emp)
                .ToList();

            var top2PerDeptMethod = employees
                .Where(emp => departments.Any(d => d.Id == emp.DeptId))
                .GroupBy(x => x.DeptId)
                .SelectMany(g => g
                    .OrderByDescending(x => x.Salary)
                    .Take(2))
                .ToList();

            PrintTopEmployees("QUERY SYNTAX", top2PerDeptQuery, departments);
            PrintTopEmployees("METHOD SYNTAX", top2PerDeptMethod, departments);

            // ============================================================
            // 24. ORDER BY DEPARTMENT, THEN SALARY DESC
            // Query: orderby key1, key2 descending
            // Method: OrderBy().ThenByDescending()
            // ============================================================
            PrintTitle("24. MULTIPLE ORDERING");

            var orderedQuery =
                (from emp in employees
                 orderby emp.DeptId, emp.Salary descending
                 select emp)
                .ToList();

            var orderedMethod = employees
                .OrderBy(x => x.DeptId)
                .ThenByDescending(x => x.Salary)
                .ToList();

            PrintRows("QUERY SYNTAX", orderedQuery,
                emp => $"Dept:{emp.DeptId,-3} {emp.Name,-10} {emp.Salary}");
            PrintRows("METHOD SYNTAX", orderedMethod,
                emp => $"Dept:{emp.DeptId,-3} {emp.Name,-10} {emp.Salary}");

            // ============================================================
            // 25. ANY
            // No direct query-syntax keyword.
            // true if at least one element satisfies the condition.
            // ============================================================
            PrintTitle("25. ANY");

            bool anyAbove90000 = employees.Any(x => x.Salary > 90000);
            Console.WriteLine($"Any employee salary > 90000: {anyAbove90000}");

            // ============================================================
            // 26. ALL
            // No direct query-syntax keyword.
            // true only if every element satisfies the condition.
            // ============================================================
            PrintTitle("26. ALL");

            bool allAbove50000 = employees.All(x => x.Salary > 50000);
            Console.WriteLine($"All salaries > 50000: {allAbove50000}");

            // ============================================================
            // 27. CONTAINS
            // No direct query-syntax keyword.
            // Commonly used inside Where().
            // ============================================================
            PrintTitle("27. CONTAINS");

            var selectedIds = new List<int> { 1, 3, 5 };

            var selectedEmployeesQuery =
                (from emp in employees
                 where selectedIds.Contains(emp.Id)
                 select emp)
                .ToList();

            var selectedEmployeesMethod = employees
                .Where(emp => selectedIds.Contains(emp.Id))
                .ToList();

            PrintRows("QUERY SYNTAX", selectedEmployeesQuery, emp => emp.Name);
            PrintRows("METHOD SYNTAX", selectedEmployeesMethod, emp => emp.Name);

            // ============================================================
            // 28. DISTINCT DEPARTMENT IDs
            // Distinct() has no query keyword.
            // ============================================================
            PrintTitle("28. DISTINCT DEPARTMENT IDs");

            var distinctDepartments = employees
                .Select(x => x.DeptId)
                .Distinct()
                .ToList();

            foreach (var deptId in distinctDepartments)
                Console.WriteLine(deptId);

            // ============================================================
            // 29. WHERE + SELECT
            // Direct equivalents exist in both syntaxes.
            // ============================================================
            PrintTitle("29. WHERE + SELECT");

            var salaryFilterQuery =
                (from emp in employees
                 where emp.Salary > 70000
                 select new
                 {
                     emp.Name,
                     emp.Salary
                 })
                .ToList();

            var salaryFilterMethod = employees
                .Where(x => x.Salary > 70000)
                .Select(x => new
                {
                    x.Name,
                    x.Salary
                })
                .ToList();

            PrintRows("QUERY SYNTAX", salaryFilterQuery,
                x => $"{x.Name,-10} {x.Salary}");
            PrintRows("METHOD SYNTAX", salaryFilterMethod,
                x => $"{x.Name,-10} {x.Salary}");

            // ============================================================
            // 30. PAGINATION - SKIP + TAKE
            // Skip/Take have no query keywords.
            // Query syntax can still be used for the ordering/projection part.
            // ============================================================
            PrintTitle("30. PAGINATION");

            int pageNumber = 2;
            int pageSize = 3;

            var pageQuery =
                (from emp in employees
                 orderby emp.Id
                 select emp)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pageMethod = employees
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            PrintRows("QUERY SYNTAX", pageQuery,
                emp => $"{emp.Id} - {emp.Name}");
            PrintRows("METHOD SYNTAX", pageMethod,
                emp => $"{emp.Id} - {emp.Name}");

            // ============================================================
            // 31. GROUP JOIN
            // Query: join ... into
            // Method: GroupJoin()
            // Every department remains; employeeGroup may be empty.
            // ============================================================
            PrintTitle("31. GROUP JOIN");

            var groupJoinQuery =
                from dept in departments
                join emp in employees
                    on dept.Id equals emp.DeptId into employeeGroup
                select new
                {
                    DeptName = dept.Name,
                    Employees = employeeGroup
                };

            var groupJoinMethod = departments
                .GroupJoin(
                    employees,
                    dept => dept.Id,
                    emp => emp.DeptId,
                    (dept, employeeGroup) => new
                    {
                        DeptName = dept.Name,
                        Employees = employeeGroup
                    });

            Console.WriteLine();
            Console.WriteLine("--- QUERY SYNTAX ---");
            foreach (var dept in groupJoinQuery)
            {
                Console.WriteLine(dept.DeptName);
                foreach (var emp in dept.Employees)
                    Console.WriteLine($"   -> {emp.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("--- METHOD SYNTAX ---");
            foreach (var dept in groupJoinMethod)
            {
                Console.WriteLine(dept.DeptName);
                foreach (var emp in dept.Employees)
                    Console.WriteLine($"   -> {emp.Name}");
            }

            // ============================================================
            // 32. SELECT MANY
            // Query syntax equivalent is multiple from clauses.
            // GroupBy keeps Employee objects inside each group.
            // SelectMany flattens groups back into one Employee sequence.
            // ============================================================
            PrintTitle("32. SELECT MANY");

            var groupedEmployees = employees
                .GroupBy(x => x.DeptId);

            var flattenedQuery =
                (from g in groupedEmployees
                 from emp in g
                 select emp)
                .ToList();

            var flattenedMethod = groupedEmployees
                .SelectMany(g => g)
                .ToList();

            PrintRows("QUERY SYNTAX", flattenedQuery, emp => emp.Name);
            PrintRows("METHOD SYNTAX", flattenedMethod, emp => emp.Name);

            // ============================================================
            // 33. MIN / MAX / SUM / AVERAGE
            // Aggregate operators have no dedicated query keywords.
            // ============================================================
            PrintTitle("33. AGGREGATE FUNCTIONS");

            var minSalary = employees.Min(x => x.Salary);
            var maxSalary = employees.Max(x => x.Salary);
            var totalSalary = employees.Sum(x => x.Salary);
            var avgSalary = employees.Average(x => x.Salary);

            Console.WriteLine($"Min     : {minSalary}");
            Console.WriteLine($"Max     : {maxSalary}");
            Console.WriteLine($"Sum     : {totalSalary}");
            Console.WriteLine($"Average : {avgSalary}");

            // ============================================================
            // 34. FIRST / FIRST OR DEFAULT
            // No query keyword.
            // First throws when no match; FirstOrDefault returns default/null.
            // ============================================================
            PrintTitle("34. FIRST / FIRST OR DEFAULT");

            var firstEmployee = employees.First(x => x.DeptId == 1);
            var firstOrDefaultEmployee = employees.FirstOrDefault(x => x.DeptId == 1000);

            Console.WriteLine($"First Dept 1: {firstEmployee.Name}");
            Console.WriteLine(
                $"FirstOrDefault Dept 1000: {firstOrDefaultEmployee?.Name ?? "Not Found"}");

            // ============================================================
            // 35. SINGLE / SINGLE OR DEFAULT
            // Single requires exactly one match.
            // SingleOrDefault allows zero or one, but throws if more than one.
            // ============================================================
            PrintTitle("35. SINGLE / SINGLE OR DEFAULT");

            var singleEmployee = employees.Single(x => x.Id == 1);
            var singleOrDefaultEmployee = employees.SingleOrDefault(x => x.Id == 1000);

            Console.WriteLine($"Single Id 1: {singleEmployee.Name}");
            Console.WriteLine(
                $"SingleOrDefault Id 1000: {singleOrDefaultEmployee?.Name ?? "Not Found"}");

            // ============================================================
            // 36. LAST / LAST OR DEFAULT
            // No query keyword.
            // ============================================================
            PrintTitle("36. LAST / LAST OR DEFAULT");

            var lastEmployee = employees.Last();
            var lastDept1Employee = employees.LastOrDefault(x => x.DeptId == 1);

            Console.WriteLine($"Last employee: {lastEmployee.Name}");
            Console.WriteLine($"Last Dept 1 employee: {lastDept1Employee?.Name ?? "Not Found"}");

            // ============================================================
            // 37. ELEMENT AT / ELEMENT AT OR DEFAULT
            // Zero-based index.
            // ============================================================
            PrintTitle("37. ELEMENT AT");

            var employeeAt2 = employees.ElementAt(2);
            var employeeAt100 = employees.ElementAtOrDefault(100);

            Console.WriteLine($"ElementAt(2): {employeeAt2.Name}");
            Console.WriteLine($"ElementAtOrDefault(100): {employeeAt100?.Name ?? "Not Found"}");

            // ============================================================
            // 38. COUNT / LONG COUNT
            // No query keyword.
            // ============================================================
            PrintTitle("38. COUNT / LONG COUNT");

            var employeeCount = employees.Count();
            var dept1Count = employees.Count(x => x.DeptId == 1);
            var longEmployeeCount = employees.LongCount();

            Console.WriteLine($"Count: {employeeCount}");
            Console.WriteLine($"Dept 1 Count: {dept1Count}");
            Console.WriteLine($"LongCount: {longEmployeeCount}");

            // ============================================================
            // 39. TAKE WHILE / SKIP WHILE
            // Process from the beginning until predicate changes.
            // Different from Where(), which checks every element.
            // ============================================================
            PrintTitle("39. TAKE WHILE / SKIP WHILE");

            var salaryOrdered = employees
                .OrderByDescending(x => x.Salary)
                .ToList();

            var takeWhile = salaryOrdered
                .TakeWhile(x => x.Salary >= 75000)
                .ToList();

            var skipWhile = salaryOrdered
                .SkipWhile(x => x.Salary >= 75000)
                .ToList();

            PrintRows("TAKE WHILE Salary >= 75000", takeWhile,
                emp => $"{emp.Name,-10} {emp.Salary}");
            PrintRows("SKIP WHILE Salary >= 75000", skipWhile,
                emp => $"{emp.Name,-10} {emp.Salary}");

            // ============================================================
            // 40. TAKE LAST / SKIP LAST
            // No query keyword.
            // ============================================================
            PrintTitle("40. TAKE LAST / SKIP LAST");

            var takeLast2 = employees.TakeLast(2).ToList();
            var skipLast2 = employees.SkipLast(2).ToList();

            PrintRows("TAKE LAST 2", takeLast2, emp => emp.Name);
            PrintRows("SKIP LAST 2", skipLast2, emp => emp.Name);

            // ============================================================
            // 41. DISTINCT BY
            // Returns one Employee for each distinct DeptId.
            // Requires modern .NET (introduced in .NET 6).
            // ============================================================
            PrintTitle("41. DISTINCT BY");

            var oneEmployeePerDept = employees
                .DistinctBy(x => x.DeptId)
                .ToList();

            PrintRows("DISTINCT BY DeptId", oneEmployeePerDept,
                emp => $"Dept:{emp.DeptId,-3} {emp.Name}");

            // ============================================================
            // 42. UNION / UNION BY
            // Union removes duplicates.
            // UnionBy compares using a selected key.
            // ============================================================
            PrintTitle("42. UNION / UNION BY");

            var idsA = new[] { 1, 2, 3, 4 };
            var idsB = new[] { 3, 4, 5, 6 };

            var unionIds = idsA.Union(idsB).ToList();
            Console.WriteLine($"Union: {string.Join(", ", unionIds)}");

            var employeeSetA = employees.Take(4);
            var employeeSetB = employees.Skip(2).Take(4);

            var unionById = employeeSetA
                .UnionBy(employeeSetB, x => x.Id)
                .ToList();

            PrintRows("UNION BY Employee.Id", unionById,
                emp => $"{emp.Id} - {emp.Name}");

            // ============================================================
            // 43. INTERSECT / INTERSECT BY
            // Keeps values/items present in both sequences.
            // ============================================================
            PrintTitle("43. INTERSECT / INTERSECT BY");

            var intersectIds = idsA.Intersect(idsB).ToList();
            Console.WriteLine($"Intersect: {string.Join(", ", intersectIds)}");

            var intersectById = employeeSetA
                .IntersectBy(
                    employeeSetB.Select(x => x.Id),
                    x => x.Id)
                .ToList();

            PrintRows("INTERSECT BY Employee.Id", intersectById,
                emp => $"{emp.Id} - {emp.Name}");

            // ============================================================
            // 44. EXCEPT / EXCEPT BY
            // Keeps values/items from first sequence not present in second.
            // ============================================================
            PrintTitle("44. EXCEPT / EXCEPT BY");

            var exceptIds = idsA.Except(idsB).ToList();
            Console.WriteLine($"Except: {string.Join(", ", exceptIds)}");

            var exceptById = employeeSetA
                .ExceptBy(
                    employeeSetB.Select(x => x.Id),
                    x => x.Id)
                .ToList();

            PrintRows("EXCEPT BY Employee.Id", exceptById,
                emp => $"{emp.Id} - {emp.Name}");

            // ============================================================
            // 45. CONCAT
            // Appends sequences and DOES NOT remove duplicates.
            // ============================================================
            PrintTitle("45. CONCAT");

            var concatIds = idsA.Concat(idsB).ToList();
            Console.WriteLine($"Concat: {string.Join(", ", concatIds)}");

            // ============================================================
            // 46. APPEND / PREPEND
            // Add one item to the end/start of a sequence.
            // ============================================================
            PrintTitle("46. APPEND / PREPEND");

            var numbers = new[] { 2, 3, 4 };

            var appended = numbers.Append(5).ToList();
            var prepended = numbers.Prepend(1).ToList();

            Console.WriteLine($"Append : {string.Join(", ", appended)}");
            Console.WriteLine($"Prepend: {string.Join(", ", prepended)}");

            // ============================================================
            // 47. SEQUENCE EQUAL
            // Compares sequence values AND order.
            // ============================================================
            PrintTitle("47. SEQUENCE EQUAL");

            var sequence1 = new[] { 1, 2, 3 };
            var sequence2 = new[] { 1, 2, 3 };
            var sequence3 = new[] { 3, 2, 1 };

            Console.WriteLine($"1,2,3 == 1,2,3: {sequence1.SequenceEqual(sequence2)}");
            Console.WriteLine($"1,2,3 == 3,2,1: {sequence1.SequenceEqual(sequence3)}");

            // ============================================================
            // 48. DEFAULT IF EMPTY
            // If sequence has no elements, return one default value.
            // Also fundamental to LINQ left outer joins.
            // ============================================================
            PrintTitle("48. DEFAULT IF EMPTY");

            var noEmployees = employees
                .Where(x => x.DeptId == 1000);

            var withDefault = noEmployees
                .DefaultIfEmpty();

            foreach (var emp in withDefault)
                Console.WriteLine(emp == null ? "Default Employee = null" : emp.Name);

            // ============================================================
            // 49. TO DICTIONARY
            // One unique key -> one value.
            // Duplicate keys throw an exception.
            // ============================================================
            PrintTitle("49. TO DICTIONARY");

            var employeeDictionary = employees
                .ToDictionary(
                    emp => emp.Id,
                    emp => emp.Name);

            foreach (var pair in employeeDictionary)
                Console.WriteLine($"{pair.Key} -> {pair.Value}");

            // ============================================================
            // 50. TO LOOKUP
            // One key -> many values. Similar to a materialized GroupBy.
            // ============================================================
            PrintTitle("50. TO LOOKUP");

            var employeesLookup = employees
                .ToLookup(emp => emp.DeptId);

            foreach (var group in employeesLookup)
            {
                Console.WriteLine($"DeptId: {group.Key}");
                foreach (var emp in group)
                    Console.WriteLine($"   -> {emp.Name}");
            }

            // ============================================================
            // 51. ZIP
            // Combines corresponding positions from two sequences.
            // Stops when the shorter sequence ends.
            // ============================================================
            PrintTitle("51. ZIP");

            var names = new[] { "A", "B", "C" };
            var scores = new[] { 90, 80, 70 };

            var zipped = names
                .Zip(scores, (name, score) => new { name, score })
                .ToList();

            PrintRows("ZIP", zipped,
                x => $"{x.name} -> {x.score}");

            // ============================================================
            // 52. CHUNK
            // Splits a sequence into arrays of a fixed maximum size.
            // Requires modern .NET (introduced in .NET 6).
            // ============================================================
            PrintTitle("52. CHUNK");

            var chunks = employees.Chunk(3).ToList();

            for (int i = 0; i < chunks.Count; i++)
            {
                Console.WriteLine($"Chunk {i + 1}");
                foreach (var emp in chunks[i])
                    Console.WriteLine($"   -> {emp.Name}");
            }

            // ============================================================
            // 53. AGGREGATE
            // Custom accumulator/fold operation.
            // ============================================================
            PrintTitle("53. AGGREGATE");

            var allNames = employees
                .Select(x => x.Name)
                .Aggregate((current, next) => current + ", " + next);

            Console.WriteLine(allNames);

            var salaryTotalUsingAggregate = employees
                .Aggregate(
                    0m,
                    (total, emp) => total + emp.Salary);

            Console.WriteLine($"Salary total using Aggregate: {salaryTotalUsingAggregate}");

            // ============================================================
            // 54. MIN BY / MAX BY
            // Return the full item having the minimum/maximum selected key.
            // Requires modern .NET (introduced in .NET 6).
            // ============================================================
            PrintTitle("54. MIN BY / MAX BY");

            var lowestPaidEmployee = employees.MinBy(x => x.Salary);
            var highestPaidEmployee = employees.MaxBy(x => x.Salary);

            Console.WriteLine(
                $"MinBy: {lowestPaidEmployee?.Name} - {lowestPaidEmployee?.Salary}");
            Console.WriteLine(
                $"MaxBy: {highestPaidEmployee?.Name} - {highestPaidEmployee?.Salary}");

            // ============================================================
            // 55. REVERSE
            // Reverses current sequence order.
            // ============================================================
            PrintTitle("55. REVERSE");

            var reversed = employees
                .Select(x => x.Name)
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(", ", reversed));

            // ============================================================
            // 56. CAST / OF TYPE
            // Cast<T> expects every item to be compatible.
            // OfType<T> keeps only compatible items.
            // ============================================================
            PrintTitle("56. CAST / OF TYPE");

            var objects = new object[] { "Amit", 100, "Neha", 200, "Priya" };

            var onlyStrings = objects
                .OfType<string>()
                .ToList();

            Console.WriteLine($"OfType<string>: {string.Join(", ", onlyStrings)}");

            var stringObjects = new object[] { "IT", "HR", "Finance" };
            var castStrings = stringObjects
                .Cast<string>()
                .ToList();

            Console.WriteLine($"Cast<string>: {string.Join(", ", castStrings)}");

            // ============================================================
            // 57. RANGE / REPEAT / EMPTY
            // Static Enumerable generation methods.
            // ============================================================
            PrintTitle("57. RANGE / REPEAT / EMPTY");

            var range = Enumerable.Range(1, 5);
            var repeated = Enumerable.Repeat("LINQ", 3);
            var empty = Enumerable.Empty<Employee>();

            Console.WriteLine($"Range : {string.Join(", ", range)}");
            Console.WriteLine($"Repeat: {string.Join(", ", repeated)}");
            Console.WriteLine($"Empty count: {empty.Count()}");

            // ============================================================
            // 58. SELECT WITH INDEX
            // Method syntax overload exposes zero-based index.
            // No direct query-syntax equivalent for the index overload.
            // ============================================================
            PrintTitle("58. SELECT WITH INDEX");

            var employeesWithIndex = employees
                .Select((emp, index) => new
                {
                    Position = index,
                    emp.Name
                })
                .ToList();

            PrintRows("SELECT WITH INDEX", employeesWithIndex,
                x => $"{x.Position} -> {x.Name}");

            // ============================================================
            // 59. WHERE WITH INDEX
            // Predicate receives item + zero-based index.
            // ============================================================
            PrintTitle("59. WHERE WITH INDEX");

            var evenPositionEmployees = employees
                .Where((emp, index) => index % 2 == 0)
                .ToList();

            PrintRows("EVEN POSITIONS", evenPositionEmployees,
                emp => emp.Name);

            // ============================================================
            // 60. SELECT MANY WITH CHILD COLLECTION
            // Practical flattening example.
            // ============================================================
            PrintTitle("60. SELECT MANY - DEPARTMENT TO EMPLOYEES");

            var deptWithEmployees = departments
                .GroupJoin(
                    employees,
                    dept => dept.Id,
                    emp => emp.DeptId,
                    (dept, empGroup) => new
                    {
                        Department = dept,
                        Employees = empGroup
                    });

            var flattenedDeptEmployees = deptWithEmployees
                .SelectMany(
                    x => x.Employees,
                    (x, emp) => new
                    {
                        DeptName = x.Department.Name,
                        EmpName = emp.Name
                    })
                .ToList();

            PrintRows("FLATTENED", flattenedDeptEmployees,
                x => $"{x.DeptName,-10} {x.EmpName}");

            PrintTitle("FINISHED");
        }

        // ================================================================
        // HELPER METHODS
        // ================================================================

        private static void PrintTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine(
                "============================================================");
            Console.WriteLine(title);
            Console.WriteLine(
                "============================================================");
        }

        private static void PrintRows<T>(
            string label,
            IEnumerable<T> rows,
            Func<T, string> formatter)
        {
            Console.WriteLine();
            Console.WriteLine($"--- {label} ---");

            foreach (var row in rows)
                Console.WriteLine(formatter(row));
        }

        private static void PrintEmployeeGroups(
            string label,
            IEnumerable<IGrouping<int, Employee>> groups)
        {
            Console.WriteLine();
            Console.WriteLine($"--- {label} ---");

            foreach (var group in groups)
            {
                Console.WriteLine($"Department Id: {group.Key}");

                foreach (var emp in group)
                    Console.WriteLine($"   -> {emp.Name}");
            }
        }

        private static void PrintTopEmployees(
            string label,
            IEnumerable<Employee> employees,
            IEnumerable<Department> departments)
        {
            Console.WriteLine();
            Console.WriteLine($"--- {label} ---");

            foreach (var emp in employees)
            {
                var deptName = departments
                    .First(d => d.Id == emp.DeptId)
                    .Name;

                Console.WriteLine(
                    $"{deptName,-10} {emp.Name,-10} {emp.Salary}");
            }
        }
    }
}