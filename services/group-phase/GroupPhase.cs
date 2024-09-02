using System;
using System.Collections.Generic;

class GroupPhase
{

    public static void Play(Dictionary<string, List<Group>> groups, Dictionary<string, List<Exibition>> exibitions, List<TeamScore> groupPhase)
    {
        int[] positionForMatch = [0, 1, 2, 3, 0, 2, 1, 3, 0, 3, 1, 2];
        int round = 1;
        for (int i = 0; i < 12; i += 4)
        {
            Console.WriteLine("Grupna faza: kolo " + round);
            foreach (var group in groups)
            {
                Console.WriteLine("Grupa " + group.Key + ": ");
                for (int t = 0; t < 4; t += 2)
                {
                    Group group1 = group.Value[positionForMatch[0 + t + i]];
                    Group group2 = group.Value[positionForMatch[1 + t + i]];
                    Console.Write(group1.Team + "  -  " + group2.Team + ":   ");
                    SimulateMatch.Play(group1, group2, exibitions, groupPhase);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            round++;
        }
    }

}