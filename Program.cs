using RunRace;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml.Serialization;

var filePath = "Race.cs";
List<Runner> runners;
List<Race> race;

if (File.Exists(filePath))
{
    var fileString = File.ReadAllText(filePath);
    runners = JsonSerializer.Deserialize<List<Runner>>(fileString); 
}
else
{
    runners = new List<Runner>(); 
}


var doExit = false;

do
{
    Console.WriteLine("*1 Create Runner");
    Console.WriteLine("*2 Modify Runner");
    Console.WriteLine("*3 Delete Runner");
    Console.WriteLine("*0 Exit");

    Console.WriteLine("* Choose an option: ");
    var check = Enum.TryParse(Console.ReadLine(), out enuMenu menu);

    if (!check)
    {
        Console.WriteLine("Invalid Input!");
        continue;
    }
    {
        switch (menu)
        {
            case enuMenu.AddRunner:
                var runner = new Runner();
                
                runner.id = runners.Max(runner => runner.id)+1;
                
                
                Console.WriteLine("What is the runner's name?: ");
                runner.Name = Console.ReadLine();

                Console.WriteLine("When were they born? (year 1900 - 2006): ");
                var result = int.TryParse(Console.ReadLine(), out var birth);
                runner.Birth = birth;

                if (birth < 1900 || birth > 2006)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                runners.Add(runner);

                break;

            case enuMenu.ModifyRunner:
                Console.WriteLine("Runners List:");
                Console.WriteLine("ID\tName\tBirth");
                foreach (var r in runners)
                {
                    Console.WriteLine($"{r.id}\t{r.Name}\t{r.Birth}");
                }
                Console.WriteLine("Which runner would you like to modify? (Enter ID):");
                if (int.TryParse(Console.ReadLine(), out var modifyId))
                {
                    var runnerToModify = runners.Find(r => r.id == modifyId);
                    if (runnerToModify != null)
                    {
                        Console.WriteLine("Enter new name for the runner:");
                        runnerToModify.Name = Console.ReadLine();

                        Console.WriteLine("Enter new birth year for the runner (1900-2006):");
                        if (int.TryParse(Console.ReadLine(), out var newBirth) && newBirth >= 1900 && newBirth <= 2006)
                        {
                            runnerToModify.Birth = newBirth;
                            Console.WriteLine("Runner modified successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid birth year!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Runner not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for runner ID!");
                }
                break;

            case enuMenu.DeleteRunner:
                Console.WriteLine("Runners List:");
                Console.WriteLine("ID\tName\tBirth");
                foreach (var r in runners)
                {
                    Console.WriteLine($"{r.id}\t{r.Name}\t{r.Birth}");
                }

                Console.WriteLine("Which runner would you like to delete? (Enter ID):");
                if (int.TryParse(Console.ReadLine(), out var deleteId))
                {
                    var runnerToDelete = runners.Find(r => r.id == deleteId);
                    if (runnerToDelete != null)
                    {
                        runners.Remove(runnerToDelete);
                        Console.WriteLine("Runner deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Runner not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for runner ID!");
                }
                break;

            case enuMenu.Exit:
                doExit = true;
                break;

            default:
                Console.WriteLine("Bad Input");
                continue;
        }
    }
} while (!doExit);

do
{
    Console.WriteLine("*1 List Races");
    Console.WriteLine("*2 Create Race");
    Console.WriteLine("*3 Delete Race");
    Console.WriteLine("*0 Exit");

    Console.WriteLine("* Choose an option: ");
    var check = Enum.TryParse(Console.ReadLine(), out RaceEnuMenu menu);

    if (!check)
    {
        Console.WriteLine("Invalid Input!");
        continue;
    }

    switch (menu)
    {
        case RaceEnuMenu.ListRaces:
            
            Console.WriteLine("Race List:");
            Console.WriteLine("ID\tPlace\tDistance\tDate");
            foreach (var r in race)
            {
                Console.WriteLine($"{r.id}\t{r.Place}\t{r.Distance}\t{r.Date}");
            }

            break;

        case RaceEnuMenu.CreateRace:
            Console.WriteLine("");
            break;

        case RaceEnuMenu.DeleteRace:
            Console.WriteLine("");
            break;

        case RaceEnuMenu.Exit:
            doExit= true; 
            break;
    }

} while (!doExit);

var FileStringJ = JsonSerializer.Serialize(runners);
File.WriteAllText(filePath, FileStringJ);