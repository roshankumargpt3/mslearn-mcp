using MyMonkeyApp;

Console.OutputEncoding = System.Text.Encoding.UTF8;
DisplayWelcomeBanner();

// Initialize the monkey collection
MonkeyHelper.InitializeMonkeys();

if (MonkeyHelper.GetMonkeyCount() == 0)
{
    Console.WriteLine("No monkeys available in the collection.");
    return;
}

// Main application loop
bool running = true;
while (running)
{
    Console.WriteLine("\n╔════════════════════════════════════╗");
    Console.WriteLine("║   🐵 MONKEY SPECIES EXPLORER 🐵   ║");
    Console.WriteLine("╚════════════════════════════════════╝\n");
    Console.WriteLine("1. Pick a Random Monkey");
    Console.WriteLine("2. List All Monkeys");
    Console.WriteLine("3. Search Monkey by Name");
    Console.WriteLine("4. Exit");
    Console.Write("\nSelect an option (1-4): ");

    var choice = Console.ReadLine() ?? string.Empty;

    switch (choice)
    {
        case "1":
            DisplayRandomMonkey();
            break;
        case "2":
            DisplayAllMonkeys();
            break;
        case "3":
            SearchMonkeyByName();
            break;
        case "4":
            running = false;
            Console.WriteLine("\nThank you for exploring monkeys! Goodbye! 👋");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

/// <summary>
/// Displays a welcome banner with ASCII art.
/// </summary>
void DisplayWelcomeBanner()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"
    ╔═══════════════════════════════════════════════════╗
    ║                                                   ║
    ║         🐵  MONKEY EXPLORER APPLICATION  🐵      ║
    ║                                                   ║
    ║    Discover fascinating monkey species from       ║
    ║    around the world and learn about their         ║
    ║    unique characteristics and habitats.           ║
    ║                                                   ║
    ╚═══════════════════════════════════════════════════╝
    ");
    Console.ResetColor();
}

/// <summary>
/// Displays a random monkey with full details and ASCII art.
/// </summary>
void DisplayRandomMonkey()
{
    var monkey = MonkeyHelper.GetRandomMonkey();

    if (monkey == null)
    {
        Console.WriteLine("No monkeys available!");
        return;
    }

    DisplayMonkeyDetails(monkey);
}

/// <summary>
/// Displays detailed information about a monkey.
/// </summary>
void DisplayMonkeyDetails(Monkey monkey)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
     ╭─────────────────────────────────────╮
     │         🐵 MONKEY PROFILE 🐵       │
     ╰─────────────────────────────────────╯
    ");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Name:       {monkey.Name}");
    Console.WriteLine($"Location:   {monkey.Location}");
    Console.WriteLine($"Population: {monkey.Population:N0}");
    Console.ResetColor();

    Console.WriteLine($"\nDescription:\n{monkey.Details}");

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"\n📍 Geographic Coordinates:");
    Console.WriteLine($"   Latitude:  {monkey.Latitude:F6}°");
    Console.WriteLine($"   Longitude: {monkey.Longitude:F6}°");
    Console.ResetColor();

    if (!string.IsNullOrEmpty(monkey.Image))
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"   Image: {monkey.Image}");
        Console.ResetColor();
    }

    Console.WriteLine("\n" + new string('─', 50));
    Console.Write("Press any key to continue...");
    Console.ReadKey();
}

/// <summary>
/// Displays all monkeys in a formatted table.
/// </summary>
void DisplayAllMonkeys()
{
    var monkeys = MonkeyHelper.GetAllMonkeys();

    if (monkeys.Count == 0)
    {
        Console.WriteLine("No monkeys available!");
        return;
    }

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                      ALL MONKEY SPECIES                        ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════════════╝\n");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{"#",-3} {"Name",-25} {"Location",-30} {"Population",-10}");
    Console.WriteLine(new string('─', 70));
    Console.ResetColor();

    for (int i = 0; i < monkeys.Count; i++)
    {
        var monkey = monkeys[i];
        Console.WriteLine($"{i + 1,-3} {monkey.Name,-25} {monkey.Location,-30} {monkey.Population,-10:N0}");
    }

    Console.WriteLine();
    Console.Write("Press any key to continue...");
    Console.ReadKey();
}

/// <summary>
/// Searches for and displays a monkey by name.
/// </summary>
void SearchMonkeyByName()
{
    Console.Write("\nEnter monkey name to search: ");
    var name = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Please enter a valid name.");
        return;
    }

    var monkey = MonkeyHelper.GetMonkeyByName(name);

    if (monkey == null)
    {
        Console.WriteLine($"Monkey '{name}' not found. Please try again.");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        return;
    }

    DisplayMonkeyDetails(monkey);
}
