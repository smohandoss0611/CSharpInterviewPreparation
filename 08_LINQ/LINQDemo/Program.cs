// See https://aka.ms/new-console-template for more information
using LINQDemo;

Console.WriteLine("Hello, World!");

var peoples = new List<Person>
{
                new Person { Id = 1, Name = "Alice", Age = 25, IsActive = true },
                new Person { Id = 2, Name = "Bob", Age = 30, IsActive = false },
                new Person { Id = 3, Name = "Charlie", Age = 25, IsActive = true },
                new Person { Id = 4, Name = "David", Age = 30, IsActive = true },
                new Person { Id = 5, Name = "Eve", Age = 35, IsActive = false }
};

var lstPeople = peoples
                .Where(x => x.IsActive)
                .GroupBy(x => x.Age)
                .Select(g => (
                    Age: g.Key,
                    Count: g.Count(),
                    Names: g.Select(x => x.Name).ToList()
                ));
Console.WriteLine(lstPeople.Count());




var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice Smith", Department = "HR", Projects = new List<string> { "Payroll System", "HR Portal" } },
                new Employee { Id = 2, Name = "Bob Johnson", Department = "IT", Projects = new List<string> { "Cloud Migration", "API Dev" } },
                new Employee { Id = 3, Name = "Charlie Brown", Department = "IT", Projects = new List<string> { "Web App" } }
            };

var hrEmployees = employees.Select(x => (x.Id, x.Name)).ToList();
  Console.WriteLine("HR Employees:");
            foreach (var (id, name) in hrEmployees)
            {
                Console.WriteLine($"ID: {id}, Name: {name}");
            }

var itProjects = employees.SelectMany(e => e.Projects.Select(p => (e.Id, e.Name, Project: p)));
        
foreach (var (id, name, project) in itProjects)
            {
                Console.WriteLine($"ID: {id}, Name: {name}, Project: {project}");
            }
           

