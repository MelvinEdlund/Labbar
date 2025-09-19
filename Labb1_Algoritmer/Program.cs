
Console.Write("Mata in en text: ");
string input = Console.ReadLine();

long total = 0;

for (int start = 0; start < input.Length; start++)
{
    char första = input[start];
    if (char.IsDigit(första) == false) continue;


    for (int slut = start + 1; slut < input.Length; slut++)
    {
        char sista = input[slut];
        if (sista != första) continue;


        string tal = input.Substring(start, slut - start + 1);

        if (!tal.All(char.IsDigit)) continue;


        string mitten = tal.Substring(1, tal.Length - 2);

        if (mitten.Contains(första)) continue;


        for (int i = 0; i < input.Length; i++)
        {
            if (i >= start && i <= slut)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write(input[i]);
        }

        Console.WriteLine();

        total += long.Parse(tal);
    }

    Console.ForegroundColor = ConsoleColor.Gray;
}

Console.ResetColor();
Console.WriteLine();
Console.WriteLine($"Total = {total}");