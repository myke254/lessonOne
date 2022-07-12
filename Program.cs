Greetings greetings = new Greetings();

do
{
    
  greetings.GetName();
} while (string.IsNullOrEmpty(greetings.name));
do
{
   greetings.GetYOB(greetings.name);
} while (greetings.yob == 0);

greetings.GetAge(greetings.yob);
greetings.LuckyNumber(greetings.name);