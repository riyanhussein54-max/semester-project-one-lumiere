/// <summary>
/// Her starter vi spillet!
/// </summary>
class Program
{
    static Verden world = new Verden();
    static SpilStyrer spilStyrer = new SpilStyrer(world.GetEntry());

    static void Main(string[] args)
    {
        Introduktion();

        while (spilStyrer.TjekStatus() == SpilStatus.Aktiv)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();

            if (line == null)
                continue;

            // parse line
            string[] elements = line.Split(" ");
            string command = elements[0];
            string[] parameters = GetParameters(elements);

            switch (command)
            {
                case "to":
                    if (parameters.Length != 1)
                    {
                        Console.WriteLine("I don't seem to know where that is 🤔");
                        return;
                    }
                    spilStyrer.Transition(parameters[0]);
                    break;
                case "h":
                case "help":
                    UdskrivKommandoer();
                    break;
                case "q":
                case "quit":
                case "exit":
                    spilStyrer.AfslutSpil();
                    break;
                default:
                    Console.WriteLine($"Woopsie, I don't understand '{command}' 😕");
                    break;
            }
        }
        Console.WriteLine("Game Over 😥");
    }

    private static void Introduktion()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.Write("Velkommen til Lumiére.");
        Thread.Sleep(2400);

        Console.Clear();
        Console.Write("En by hvor lyset aldrig slukker.");
        Thread.Sleep(2600);

        Console.Clear();
        Console.Write("Dette har fysiske og mentale konsekvenser for de lokale.");
        Thread.Sleep(3400);

        Console.Clear();
        Console.Write("Du er den eneste der kan redde byen, held og lykke.");
        Thread.Sleep(3400);

        Console.Clear();
        spilStyrer.TegnSkærm();
    }

    private static void UdskrivKommandoer()
    {
        Console.WriteLine(
            $"""
            Muligheder:
            - q, quit, exit    Forlad spil
            - to               Følg en udgang
            - h, help          Display a help message
            """
        );
    }

    private static string[] GetParameters(string[] input)
    {
        string[] output = new string[input.Length - 1];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = input[i + 1];
        }
        return output;
    }
}
