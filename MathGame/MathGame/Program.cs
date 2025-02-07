using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

public class MathGame
{
    public static void Main(string[] args)
    {
        List<string> hist = new List<string>();
        GameSelect( hist);
    }

    public static void GameSelect( List<string> hist)
    {
        Console.WriteLine($" --------------------------------------------------------------------------" +
            $" \n Welcome to Math Game \nTo Select an option, enter the option number below:" +
            $"\n1 Addition \n2 Subtraction \n3 Division \n4 Multiplication \n5 History \n6 Exit");
        string input = Console.ReadLine();
        int selection = 0;
        while (true)
        {
            if (int.TryParse(input, out selection))
            {
                if (0 < selection && selection < 7)
                {
                    break;
                }
            }
            Console.WriteLine("Please input a valid number between 1 and 6");
            input = Console.ReadLine();
        }

        switch (selection)
        {
            case 1: Console.WriteLine("Addition Selected");
                AdditionGame(hist);
                break;
            case 2: Console.WriteLine("Subtraction Selected");
                SubtractionGame(hist);
                break;
            case 3: 
                Console.WriteLine("Division Selected");
                DivisionGame(hist);
                break;
            case 4: 
                Console.WriteLine("Multiplication Selected");
                MultiplicationGame(hist);
                break;
            case 5: 
                Console.WriteLine("History Selected");
                History(hist);
                break;
            case 6: 
                Console.WriteLine("Exit Selected");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
    public static void AdditionGame(List<string> hist)
    {
        // establish variables
        string ans = "";
        int count = 0;
        int e = 0;
        Random r = new Random();
        int a, b, c;
        a = r.Next(100);
        b = r.Next(100);
        c = a + b;
        string ques = $"{a} + {b}";
 
        Console.WriteLine(ques + " = ?" );
        
        //run game
        PlayGame(hist, ans, a, b, c, e, ques, count);

        //Loop Game or Menu
        Console.WriteLine("Play Again? Y/N");
        ans = Console.ReadLine();
        if(ans.Trim().ToLower() == "y" || ans.Trim().ToLower() == "yes")
        {
            AdditionGame(hist);
        }
        else
        {
            GameSelect(hist);
        }  
    }
    public static void SubtractionGame(List<string> hist)
    {
        string ans = "";
        int count = 0;
        int e = 0;
        Random r = new Random();
        int a, b, c = 0;
        a = r.Next(100);
        b = r.Next(100);
        string ques = "";
        
        //instead of reselecting a number until A is larger than B just swap order. 
        if(a > b)
        {
            c = a - b;
            ques = $"{a} - {b}";
        }
        else if(a < b)
        {
            c = b - a;
            ques = $"{b} - {a}";
        }
        else if (a == b)
        {
            c = a - b;
            ques = $"{a} - {b}";
        }
        
        Console.WriteLine(ques + " = ?");

        //run game
        PlayGame(hist, ans, a, b, c, e, ques, count);

        // Loop or Menu
        Console.WriteLine("Play Again? Y/N");
        ans = Console.ReadLine();
        if (ans.Trim().ToLower() == "y")
        {
            SubtractionGame(hist);
        }
        else
        {
            GameSelect(hist);
        }
    }
    public static void MultiplicationGame(List<string> hist)
    {
        string ans = "";
        int count = 0;
        int e = 0;
        Random r = new Random();
        int a, b, c = 0;
        a = r.Next(100);
        b = r.Next(100);
        string ques = "";
      
        c = a * b;
        ques = $"{a} * {b}";
       

        Console.WriteLine(ques + "= ?");
        //run game
        PlayGame(hist, ans, a, b, c, e, ques, count);

        // Loop or Menu
        Console.WriteLine("Play Again? Y/N");
        ans = Console.ReadLine();
        if (ans.Trim().ToLower() == "y")
        {
            MultiplicationGame(hist);
        }
        else
        {
            GameSelect(hist);
        }

    }
    public static void DivisionGame(List<string> hist)
    {
        string ans = "";
        int count = 0;
        int e = 0;
        Random r = new Random();
        int a, b, c = 0;
        a = r.Next(100);
        b = r.Next(100);
        string ques = "";

        // verify it will be a whole number
        while(a%b != 0 && a != 0 && b != 0)
        {
            a = r.Next(100);
            b = r.Next(100);
        }
        c = a / b;
        ques = $"{a}/{b}";

        Console.WriteLine(ques + "= ?");
        //run game
        PlayGame(hist, ans, a, b, c, e, ques, count);

        // Loop or Menu
        Console.WriteLine("Play Again? Y/N");
        ans = Console.ReadLine();
        if (ans.Trim().ToLower() == "y")
        {
            DivisionGame(hist);
        }
        else
        {
            GameSelect(hist);
        }
    }
    public static void PlayGame(List<string> hist, string ans, int a, int b, int c, int e, string ques, int count)
    {
        while (true)
        {
            ans = Console.ReadLine();
            if (int.TryParse(ans, out e))
            {
                count++;
                if (e == c)
                {
                    hist.Add($"Question: {ques} = ? Answer: {c} Number of Neumerical Attempts: {count}");
                    Console.WriteLine("Correct!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect, please try again");
                }
            }
            else if (ans.Trim().ToLower() == "exit")
            {
                break;
            }

        }
    }
    public static void History(List<string> hist)
    {
        foreach (string h in hist)
        {
            Console.WriteLine($"{h}");
        }

        Console.WriteLine("Go Back to Menu? Y/N");
        string g = Console.ReadLine();
        if(g.ToLower().Trim() == "y")
        {
            GameSelect(hist);
        }

    }
}
   


