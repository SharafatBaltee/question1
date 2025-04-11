using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Input string, only z is user input
        string input23 = "x:4; y:9; z:userinput; result: x * y + z;";

        Dictionary<string, double> variables23 = new Dictionary<string, double>();

        try
        {
            string[] parts = input23.Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string trimmedPart = part.Trim();
                if (!trimmedPart.StartsWith("result"))
                {
                    string[] keyValue = trimmedPart.Split(':');
                    if (keyValue.Length == 2)
                    {
                        string varName = keyValue[0].Trim();
                        string varValue = keyValue[1].Trim();

                        // Only ask input for z
                        if (varValue.Equals("userinput"))
                        {
                            Console.Write($"Enter value for {varName}: ");
                            varValue = Console.ReadLine();
                        }

                        if (double.TryParse(varValue, out double value))
                        {
                            variables23[varName] = value;
                        }
                        else
                        {
                            Console.WriteLine($"Error: Unable to parse '{varValue}' as a number for variable '{varName}'.");
                            return;
                        }
                    }
                }
            }

            // Use fixed x = 4 and y = 9
            double x = 4;
            double y = 9;
            variables23["x"] = x;
            variables23["y"] = y;

            if (variables23.ContainsKey("z"))
            {
                double z = variables23["z"];
                double result23 = x * y + z;

                Console.WriteLine($"\nx = {x}");
                Console.WriteLine($"y = {y}");
                Console.WriteLine($"z = {z}");
                Console.WriteLine($"Result = {result23}");
            }
            else
            {
                Console.WriteLine("Error: Missing required variable z.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
