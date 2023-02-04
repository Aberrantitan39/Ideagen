public class Calculator
{
    public static void Main()
    {
        List<string> lstEquation = new List<string>();
        lstEquation.Add("1 + 1");
        lstEquation.Add("2 * 2");
        lstEquation.Add("1 + 2 + 3");
        lstEquation.Add("6 / 2");
        lstEquation.Add("11 + 23");
        lstEquation.Add("11.1 + 23");
        lstEquation.Add("1 + 1 * 3");
        lstEquation.Add("(11.5 + 15.4) + 10.1");
        lstEquation.Add("23 - (29.3 - 12.5)");
        lstEquation.Add("(1 / 2) - 1 + 1");
        lstEquation.Add("10 - (2 + 3 * (7 - 5))");

        Console.WriteLine("Welcome to Ideagen Calculator. Enter 1 to calculate default expressions or enter your custom expression below.");

        try
        {
            string input = Console.ReadLine();

            if (input == "1")
            {
                foreach (var equation in lstEquation)
                {
                    Console.WriteLine("Result for " + equation + " is " + Calculate(equation));
                }
            }
            else
            {
                Console.WriteLine("Result for " + input + " is " + Calculate(input));
            }

            Reset();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid expression!");
            Reset();
        }
    }

    public static void Reset()
    {
        Console.WriteLine("Enter 1 to reset calculator.");
        var input = Console.ReadLine();

        if (input == "1")
        {
            Console.Clear();
            Main();
        }
    }

    public static double Calculate(string expression)
    {
        Stack<char> operators = new Stack<char>();
        Stack<double> values = new Stack<double>();

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            if (char.IsDigit(c))
            {
                int j = i;

                //Loop and find digit until next operator
                while (j < expression.Length && (char.IsDigit(expression[j]) || expression[j] == '.'))
                {
                    j++;
                }

                values.Push(double.Parse(expression.Substring(i, j - i)));
                i = j - 1;
            }
            else if (c == '(')
            {
                operators.Push(c);
            }
            else if (c == ')')
            {
                while (operators.Peek() != '(')
                {
                    values.Push(Evaluate(operators.Pop(), values.Pop(), values.Pop()));
                }

                operators.Pop();
            }
            else if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                // Check if last operator is a multiply or divide, then perform the calculation first
                while (operators.Count > 0 && HasPrecedence(c, operators.Peek()))
                {
                    values.Push(Evaluate(operators.Pop(), values.Pop(), values.Pop()));
                }

                operators.Push(c);
            }
            else if (c == ' ')
            {
                continue;
            }
        }

        while (operators.Count > 0)
        {
            values.Push(Evaluate(operators.Pop(), values.Pop(), values.Pop()));
        }


        var result = values.Pop();
        if (!(result % 1 == 0))
        {
            result = Math.Round(result, 2);
        }

        return result;
    }

    static bool HasPrecedence(char operator1, char operator2)
    {
        if (operator2 == '(' || operator2 == ')')
        {
            return false;
        }

        if ((operator1 == '*' || operator1 == '/') && (operator2 == '+' || operator2 == '-'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static double Evaluate(char operator1, double firstDigit, double secondDigit)
    {
        switch (operator1)
        {
            case '+':
                return secondDigit + firstDigit;
            case '-':
                return secondDigit - firstDigit;
            case '*':
                return secondDigit * firstDigit;
            case '/':
                return secondDigit / firstDigit;
        }
        return 0;
    }
}