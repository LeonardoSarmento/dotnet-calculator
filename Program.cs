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
         calculator.Calculate();
        } while ((int)calculator.Function != 9 );
    }
}

// Working of the Calculator v2 below
enum EFunctionCalculator {
    Add = 1,
    Subtract = 2,
    Multiply = 3,
    Divide = 4,
    TryAgain = 8,
    Exit = 9
}
class Calculator
{
    public float Value;
    public float TotalValue;
    public EFunctionCalculator Function;
    public EFunctionCalculator ChooseFunction(){
        Console.WriteLine("Choose wisely which function would u like to use:");
        Console.WriteLine("1 - Add");
        Console.WriteLine("2 - Subtraction");
        Console.WriteLine("3 - Multiply");
        Console.WriteLine("4 - Divide");
        Console.WriteLine("9 - Exit");
        Console.WriteLine("-------------");
        short res;
        while (true)
        {
            Console.Write("Please enter a number: ");
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
            9 => EFunctionCalculator.Exit,
            _ => EFunctionCalculator.TryAgain,
        };
        Console.WriteLine($"You choose: {Function}");
        Console.WriteLine("");
        return Function;
    }
    public void Calculate(){
        switch ((int)Function)
        {
            case 1: Add(); break;
            case 2: Subtract(); break;
            case 3: Multiply(); break;
            case 4: Divide(); break;
            case 9: Exit(); break;
            default: ChooseFunction(); break;
        }
    }

    public void AskForValue(){
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
    public void StartCalculation(){
        Console.Clear();
        AskForValue();
        TotalValue += Value;
        ChooseFunction();
    }
    public void Add(){
        Console.WriteLine("-----------------------------------------");
        AskForValue();
        Console.WriteLine($"Adding: {TotalValue} + {Value}");
        TotalValue += Value;
        GetTotalValue();
        Console.WriteLine("-----------------------------------------");
        ChooseFunction();
    }
    public void Subtract(){
        Console.WriteLine("-----------------------------------------");
        AskForValue();
        Console.WriteLine($"Subtracting: {TotalValue} - {Value}");
        TotalValue -= Value;
        GetTotalValue();
        Console.WriteLine("-----------------------------------------");
        ChooseFunction();
    }
    public void Multiply(){
        Console.WriteLine("-----------------------------------------");
        AskForValue();
        Console.WriteLine($"Multiplying: {TotalValue} * {Value}");
        TotalValue *= Value;
        GetTotalValue();
        Console.WriteLine("-----------------------------------------");
        ChooseFunction();
    }
    public void Divide(){
        Console.WriteLine("-----------------------------------------");
        AskForValue();
        Console.WriteLine($"Dividing: {TotalValue} / {Value}");
        TotalValue /= Value;
        GetTotalValue();
        Console.WriteLine("-----------------------------------------");
        ChooseFunction();
    }
    public void GetTotalValue(){
    Console.WriteLine($"After {Function}, the result was {TotalValue}");
    }

    public void Exit(){
        Console.WriteLine($"From my calculations, the total value of your desires was {TotalValue}");
        Console.WriteLine("Exiting the allknowing calculator!");
        System.Environment.Exit(0);
    }
}
