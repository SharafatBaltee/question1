using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Input string
        string input23 = "x:userinput; y:userinput; z:4; result: x * y + z;";
        // Dictionary to store variables and their values
        Dictionary<string, double> variables23 = new Dictionary<string, double>();
        try
        {
            // Split the input string into parts
            string[] parts = input23.Split(';', StringSplitOptions.RemoveEmptyEntries);
            // Process each part to extract variables and values
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
                        // Handle user input prompts
                        if (varValue.Equals("userinput") || varValue.Equals("userinptut"))
                        {
                            Console.Write($"Enter value for {varName}: ");
                            varValue = Console.ReadLine();
                        }
                        // Parse the value to double
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
            // Find the result expression
            string expression23 = "";
            foreach (string part in parts)
            {
                if (part.Trim().StartsWith("result"))
                {
                    string[] resultParts = part.Split(':', 2);
                    if (resultParts.Length == 2)
                    {
                        expression23 = resultParts[1].Trim();
                    }
                    break;
                }
            }
            
            // Evaluate the expression
            if (variables23.ContainsKey("x") && variables23.ContainsKey("y") && variables23.ContainsKey("z"))
            {
                double result23 = variables23["x"] * variables23["y"] + variables23["z"];
                // Display output in specified format
                Console.WriteLine($"z = {variables23["z"]}");
                Console.WriteLine($"Result = {result23}");
            }
            else
            {
                Console.WriteLine("Error: Missing required variables x, y, or z.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}