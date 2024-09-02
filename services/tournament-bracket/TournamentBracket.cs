class TournamentBracket
{
    public static List<Group> Create(List<TeamScore> groupPhase, Dictionary<string, List<Group>> groups)
    {
        Console.WriteLine();
        List<Group> gp = new List<Group>();

        for (int t = 0; t < 8; t++)
        {
            foreach (var group in groups)
            {
                foreach (var i in group.Value)
                {
                    if (groupPhase[t].Name == i.ISOCode)
                    {
                        gp.Add(i);
                    }
                }
            }
        }
        return gp;
    }
    public static void Play(List<Group> bracketGroups, Dictionary<string, List<Exibition>> exibitions)
    {
        string[] hats = ["Šešir D: ", "Šešir E: ", "Šešir F: ", "Šešir G: "];
        Random random = new Random();
        for (int i = 0; i < 8; i += 2)
        {
            Console.WriteLine(hats[i / 2]);
            Console.WriteLine(bracketGroups[i].Team);
            Console.WriteLine(bracketGroups[i + 1].Team);
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Četvrtfinale: ");
        List<Group> semiFinals = new List<Group>();
        int randomNumber = random.Next(0, 2);
        for (int i = 0; i < 2; i++)
        {
            Console.Write(bracketGroups[randomNumber].Team + "  -  " + bracketGroups[i + 6].Team + ":  ");
            semiFinals.Add(SimulateMatchBracket.Play(bracketGroups[randomNumber], bracketGroups[i + 6], exibitions));
            randomNumber = randomNumber == 0 ? 1 : 0;
            Console.WriteLine();
        }
        Console.WriteLine();
        randomNumber = random.Next(2, 4);
        for (int i = 2; i < 4; i++)
        {
            Console.Write(bracketGroups[randomNumber].Team + "  -  " + bracketGroups[i + 1].Team + ":  ");
            semiFinals.Add(SimulateMatchBracket.Play(bracketGroups[randomNumber], bracketGroups[i + 1], exibitions));
            randomNumber = randomNumber == 2 ? 3 : 2;
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Polufinale:");
        List<Group> finals = new List<Group>();
        Console.Write(semiFinals[0].Team + "  -  " + semiFinals[1].Team + ":  ");
        finals.Add(SimulateMatchBracket.Play(semiFinals[0], semiFinals[1], exibitions));
        Console.WriteLine();
        Console.Write(semiFinals[2].Team + "  -  " + semiFinals[3].Team + ":  ");
        finals.Add(SimulateMatchBracket.Play(semiFinals[2], semiFinals[3], exibitions));
        Console.WriteLine();
        Console.WriteLine();


        Console.WriteLine("Utakmica za treće mesto: ");
        Group tmp1 = finals.Contains(semiFinals[0])? semiFinals[1] : semiFinals[0];
        Group tmp3 = finals.Contains(semiFinals[2])? semiFinals[3] : semiFinals[2];
        Console.Write(tmp1.Team + "  -  " + tmp3.Team + ":  ");
        tmp3 = SimulateMatchBracket.Play(tmp1, tmp3, exibitions);
        Console.WriteLine();
        Console.WriteLine();



        Console.WriteLine("Finale:");
        Console.Write(finals[0].Team + "  -  " + finals[1].Team + ":  ");
        tmp1 = SimulateMatchBracket.Play(finals[0], finals[1], exibitions);
        Group tmp2 = tmp1 == finals[1]? finals[0] : finals[1];
        Console.WriteLine();


        Console.WriteLine();
        Console.WriteLine("Medalje: ");
        Console.WriteLine("1. "+tmp1.Team);
        Console.WriteLine("2. "+tmp2.Team);
        Console.WriteLine("3. "+tmp3.Team);

    }
}