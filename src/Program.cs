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
                case "go":
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
        Console.WriteLine("Velkommen til Lumiére");
        Thread.Sleep(2200);

        Console.Clear();
        spilStyrer.TegnSkærm();
        Thread.Sleep(0);
        /*
            TODO:
            - Fjern "You are now at {name}" i Lokation-klassen.
            - Derudover skal vi havde ændret movementsystemet, så det ikke bliver en
              kedelig væk med kommandoer
        */
        // spilStyrer.NuværendeLokation.Welcome();
    }

    private static void UdskrivKommandoer()
    {
        Console.WriteLine(
            $"""
            Muligheder:
            - q, quit, exit   Forlad spil
            - go              Følg en udgang
            - h, help         Display a help message
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
