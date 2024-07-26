class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the all knowing calculator!");
        Console.WriteLine("Choose wisely which function would u like to use:");
        Console.WriteLine("1 - Add");
        Console.WriteLine("2 - Subtraction");
        Console.WriteLine("3 - Multiply");
        Console.WriteLine("4 - Divide");
        Console.WriteLine("9 - Exit");
        Console.WriteLine("-------------");
        short res = short.Parse(Console.ReadLine());
        

        switch (res)
        {
            case 1: Add(); break;
            case 2: Subtraction(); break;
            case 3: Multiply(); break;
            case 4: Divide(); break;
            case 9: Exit(); break;
            default: Menu(); break;
        }
    }
    private static Values GetValues()
    {
        Values values = new();
        Console.WriteLine("State the first value:");
        values.FirstValue = float.Parse(Console.ReadLine());
        Console.WriteLine("State the second value:");
        values.SecondValue = float.Parse(Console.ReadLine());
        return values;
    }
    private static void Add()
    {
        Console.Clear();
        Values values = GetValues();
        float result = values.FirstValue + values.SecondValue;
        Console.WriteLine($"After adding ,the result was {result}");
        Console.ReadKey();
        Menu();
    }
    private static void Subtraction()
    {
        Values values = GetValues();
        float result = values.FirstValue - values.SecondValue;
        Console.WriteLine($"After subtracting ,the result was {result}");
        Console.ReadKey();
        Menu();
    }
    private static void Multiply()
    {
        Values values = GetValues();
        float result = values.FirstValue * values.SecondValue;
        Console.WriteLine($"After multiplying ,the result was {result}");
        Console.ReadKey();
        Menu();
    }
    private static void Divide()
    {
        Values values = GetValues();
        float result = values.FirstValue / values.SecondValue;
        Console.WriteLine($"After dividing ,the result was {result}");
        Console.ReadKey();
        Menu();
    }
    private static void Exit()
    {
        Console.WriteLine("Exiting the allknowing calculator!");
        System.Environment.Exit(0);
    }
}

struct Values(float firstValue, float secondValue)
{
    public float FirstValue = firstValue;
    public float SecondValue = secondValue;
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
        Console.Clear();
        Console.WriteLine("Welcome to the all knowing calculator!");
        Console.WriteLine("Choose wisely which function would u like to use:");
        Console.WriteLine("1 - Add");
        Console.WriteLine("2 - Subtraction");
        Console.WriteLine("3 - Multiply");
        Console.WriteLine("4 - Divide");
        Console.WriteLine("9 - Exit");
        Console.WriteLine("-------------");
        short res = short.Parse(Console.ReadLine());
        Function = res switch
        {
            1 => EFunctionCalculator.Add,
            2 => EFunctionCalculator.Subtract,
            3 => EFunctionCalculator.Multiply,
            4 => EFunctionCalculator.Divide,
            9 => EFunctionCalculator.Exit,
            _ => EFunctionCalculator.TryAgain,
        };
        return Function;
    }
    public void AskForValue(){
        Console.WriteLine("State the value:");
        Value = float.Parse(Console.ReadLine());
    }
    public void Add(){
        AskForValue();
        TotalValue += Value;
        Console.WriteLine($"After adding ,the result was {TotalValue}");
    }
    public void Subtract(){
        AskForValue();
        TotalValue -= Value;
        Console.WriteLine($"After subtracting ,the result was {TotalValue}");
    }
    public void Multiply(){
        AskForValue();
        TotalValue *= Value;
        Console.WriteLine($"After multiplying ,the result was {TotalValue}");
    }
    public void Divide(){
        AskForValue();
        TotalValue /= Value;
        Console.WriteLine($"After dividing ,the result was {TotalValue}");
    }

    public void Exit(){
        Console.WriteLine($"From my calculations, the total value of your desires was {TotalValue}");
        Console.WriteLine("Exiting the allknowing calculator!");
        System.Environment.Exit(0);
    }
}
