using System.Text.RegularExpressions;
using lessonOne;

public class Greetings : IGreetings
{
    public string? name;
    public int yob;
    private string? yobString;
    private int today = DateTime.Now.Year;
    private bool isnum;

    MyConstants myConstants = new MyConstants();
    private readonly static Regex nameWOSpace = new Regex(@"\s+");

    public Greetings(string pName = "", int pyob = 0, string? pYobstring = "", bool pIsnum = false)
    {
        this.name = pName;
        this.yob = pyob;
        this.yobString = pYobstring;
        this.isnum = pIsnum;
    }

    public void GetName()
    {
        Console.WriteLine(myConstants.initialGreeting);
    start:
        name = Console.ReadLine();
        Regex rx = new Regex(@"^[A-Za-z ]+$");
        if (!rx.IsMatch(name!) || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine(myConstants.invalidName);
            goto start;
        }
    }

    public void GetYOB(string myName)
    {
        Console.WriteLine(myConstants.AskForYOB(name!));

    start:
        yobString = Console.ReadLine()!;
        isnum = int.TryParse(yobString, out yob);

        if (!isnum || yob < 0 || yob >= today)
        {
            Console.WriteLine(myConstants.invalidYear(name!));
            goto start;
        }

        yob = int.Parse(yobString!);
    }

    public void GetAge(int yearOfBirth)
    {
        int age = (today - yearOfBirth);

        string myAge = myConstants.ageMessage(age);

        Console.WriteLine(myConstants.finalMessage(name!, myAge));
    }

    public void LuckyNumber(string name)
    {
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        char[] nameArray = ParsedName(name).ToLower().ToCharArray();
        int[] charPosition = new int[nameArray.Length];

        for (int i = 0; i < nameArray.Length; i++)
        {
            charPosition[i] = (Array.IndexOf(alphabet, nameArray[i])+1);
        }
    start:
        var temp = string.Join("", charPosition).ToArray();
        Console.WriteLine("[{0}]", string.Join(", ", temp));

        double a = temp.Length * .5;
        var iterations = (int)Math.Ceiling(a);
        int[] tmp = new int[iterations];
        for (int i = 0; i < iterations; i++)
        {
            int p = int.Parse($"{temp[i]}");
            int q = (temp.Length - (i + 1)) == (i) ? 0 : int.Parse($"{temp[temp.Length - (i + 1)]}");
            tmp[i] = p + q;

        }
        charPosition = tmp;
        if (tmp.Length != 1)
        {
            goto start;
        }
        Console.WriteLine("[{0}]", string.Join(", ", charPosition));
        Console.WriteLine($"{charPosition[0]} is your lucky number");
    }
    public string ParsedName(string name)
    {
        return nameWOSpace.Replace(name, "");
    }
}