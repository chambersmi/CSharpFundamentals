namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currencies = new Dictionary<string, string>();
            currencies["USA"] = "USD";
            currencies["Japan"] = "JPY";
            currencies["Brazil"] = "BRL";

            var currenciesComparedToUsDollar = new Dictionary<string, decimal>();
            currenciesComparedToUsDollar["USD"] = 1m;
            currenciesComparedToUsDollar["JPY"] = 0.0086m;
            currenciesComparedToUsDollar["BRL"] = 0.18m;

            var savedGames = new Dictionary<string, string>
            {
                ["save1"] = @"C:/saves/save1.dat",
                ["autosave"] = @"C:/saves/autosave.dat"
            };

            // exception:
            //savedGames.Add("save1", @"C:/saves/save1.dat");

            var employees = new List<Employee>
            {
                new Employee(Department.Xenobiology, 15000),
                new Employee(Department.MissionControl, 14000),
                new Employee(Department.Xenobiology, 16500),
                new Employee(Department.PlanetTerraforming, 152400),
                new Employee(Department.Xenobiology, 1522000)
            };

            // Calculate average salary of each department
            var averageSalaryInDepartments =
                employees.GroupBy(d => d.Department)
                .ToDictionary(grouping => grouping.Key,
                grouping => grouping.Average(g => g.Salary));

            foreach(var salary in averageSalaryInDepartments)
            {
                Console.WriteLine($"Average Salary in {salary.Key}" +
                    $" is {salary.Value:F2}");
            }
        }
    }

    record Employee(Department Department, decimal Salary);
    enum Department { MissionControl, Xenobiology, PlanetTerraforming };
    
}
