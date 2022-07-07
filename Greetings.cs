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
}