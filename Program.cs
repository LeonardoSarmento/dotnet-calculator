class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Calculator calculator = new();
        Console.WriteLine("Welcome to the all knowing calculator!");
        calculator.StartCalculation();

        do
        {
            calculator.PerformFunction();
        } while (calculator.Function != EFunctionCalculator.Exit);
    }
}

enum EFunctionCalculator
{
    Add = 1,
    Subtract = 2,
    Multiply = 3,
    Divide = 4,
    Modulus = 5,
    Square = 6,
    Pow = 7,
    TryAgain = 8,
    Exit = 9
}
class Calculator
{
    public float Value;
    public float TotalValue;
    public EFunctionCalculator Function;

    public void StartCalculation()
    {
        Console.Clear();
        AskForValue();
        TotalValue += Value;
    }

    public static void FunctionsOptions()
    {
        foreach (EFunctionCalculator Option in Enum.GetValues(typeof(EFunctionCalculator)))
        {
            if (Option != EFunctionCalculator.TryAgain)
                Console.WriteLine($"{(int)Option} - {Option}");
        }
    }
    public EFunctionCalculator ChooseFunction()
    {
        Console.WriteLine("Choose wisely which function would u like to use:");
        FunctionsOptions();
        Console.WriteLine("-----------------------------------------");
        short res;
        while (true)
        {
            Console.Write("Please enter the number of the function: ");
            try
            {
                res = short.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        Function = res switch
        {
            1 => EFunctionCalculator.Add,
            2 => EFunctionCalculator.Subtract,
            3 => EFunctionCalculator.Multiply,
            4 => EFunctionCalculator.Divide,
            5 => EFunctionCalculator.Modulus,
            6 => EFunctionCalculator.Square,
            7 => EFunctionCalculator.Pow,
            9 => EFunctionCalculator.Exit,
            _ => EFunctionCalculator.TryAgain,
        };
        Console.WriteLine($"You choose: {Function}");
        Console.WriteLine("");
        return Function;
    }
    public void AskForValue()
    {
        Console.WriteLine("-----------------------------------------");
        while (true)
        {
            Console.Write("Please enter a number: ");
            try
            {
                Value = float.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        Console.WriteLine("");
    }
    public void InformResult()
    {
        Console.WriteLine($"After {Function}, the result was {TotalValue}");
        Console.WriteLine("-----------------------------------------");
    }
    public void PerformFunction()
    {
        do
        {
            ChooseFunction();
        } while (Function == EFunctionCalculator.TryAgain);
        if (Function != EFunctionCalculator.Square && Function != EFunctionCalculator.Exit)
        {

            AskForValue();
        }
        Calculate();
        InformResult();
    }
    public void Calculate()
    {
        switch ((int)Function)
        {
            case 1: Add(); break;
            case 2: Subtract(); break;
            case 3: Multiply(); break;
            case 4: Divide(); break;
            case 5: Modulus(); break;
            case 6: Square(); break;
            case 7: Pow(); break;
            case 9: Exit(); break;
            default: ChooseFunction(); break;
        }
    }
    public void Add()
    {
        Console.WriteLine($"Adding: {TotalValue} + {Value}");
        TotalValue += Value;
    }
    public void Subtract()
    {
        Console.WriteLine($"Subtracting: {TotalValue} - {Value}");
        TotalValue -= Value;
    }
    public void Multiply()
    {
        Console.WriteLine($"Multiplying: {TotalValue} * {Value}");
        TotalValue *= Value;
    }
    public void Divide()
    {
        Console.WriteLine($"Dividing: {TotalValue} / {Value}");
        TotalValue /= Value;
    }
    public void Modulus()
    {
        Console.WriteLine($"Modulus: {TotalValue} % {Value}");
        TotalValue %= Value;
    }
    public void Square()
    {
        Console.WriteLine($"Square root: √{TotalValue}");
        TotalValue = (float)Math.Sqrt(TotalValue);
    }
    public void Pow()
    {
        Console.WriteLine($"Powering: {TotalValue} ^ {Value}");
        TotalValue = (float)Math.Pow(TotalValue, Value);
    }

    public void Exit()
    {
        Console.WriteLine($"From my calculations, the total value of your desires was {TotalValue}");
        Console.WriteLine("Exiting the allknowing calculator!");
        System.Environment.Exit(0);
    }
}
