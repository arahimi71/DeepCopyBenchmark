namespace DeepCopyBenchmark;

internal class VerifyClone
{
    private static readonly string Red = "\u001b[31m";
    private static readonly string Reset = "\u001b[0m";
    private static readonly string Green = "\u001b[32m";

 public static void VerifyDeepClone(List<Company> original, List<Company> clone)
    {
        // Check if the lists themselves are different objects
        PrintResult("Original and Cloned company lists are different objects: ", original != clone);

        for (int i = 0; i < original.Count; i++)
        {
            var originalCompany = original[i];
            var clonedCompany = clone[i];

            // Check if the Company objects are different instances
            PrintResult($"Company {i}: Original and Cloned are different objects: ", originalCompany != clonedCompany);

            // Check if the CompanyName property is the same
            PrintResult($"Company {i}: CompanyName is the same: ", originalCompany.CompanyName == clonedCompany.CompanyName);

            for (int j = 0; j < originalCompany.Employees.Count; j++)
            {
                var originalEmployee = originalCompany.Employees[j];
                var clonedEmployee = clonedCompany.Employees[j];

                // Check if the Person objects are different instances
                PrintResult($"  Employee {j}: Original and Cloned are different objects: ", originalEmployee != clonedEmployee);

                // Check if the Name and Age properties are the same
                PrintResult($"  Employee {j}: Name is the same: ", originalEmployee.Name == clonedEmployee.Name);
                PrintResult($"  Employee {j}: Age is the same: ", originalEmployee.Age == clonedEmployee.Age);

                // Check if the Address objects are different instances
                PrintResult($"  Employee {j}: Address objects are different: ", originalEmployee.Address != clonedEmployee.Address);

                // Check if the Address properties are the same
                PrintResult($"  Employee {j}: Address.Street is the same: ", originalEmployee.Address.Street == clonedEmployee.Address.Street);
                PrintResult($"  Employee {j}: Address.City is the same: ", originalEmployee.Address.City == clonedEmployee.Address.City);

                // Check if the PhoneNumbers lists are different instances
                PrintResult($"  Employee {j}: PhoneNumbers lists are different: ", originalEmployee.PhoneNumbers != clonedEmployee.PhoneNumbers);

                // Check if the PhoneNumbers contents are the same
                for (int k = 0; k < originalEmployee.PhoneNumbers.Count; k++)
                {
                    PrintResult($"    Phone number {k} is the same: ", originalEmployee.PhoneNumbers[k] == clonedEmployee.PhoneNumbers[k]);
                }
            }
        }
    }

    private static void PrintResult(string message, bool condition)
    {
        if (condition)
        {
            Console.WriteLine(Green + message + condition + Reset);
        }
        else
        {
            Console.WriteLine(Red + message + condition + Reset);
        }
    }}