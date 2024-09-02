class GroupBoard{
    public static void Add(string team1, string team2, double score1, double score2, List<TeamScore> groupPhase){
        int teamIndex1 = groupPhase.FindIndex(i => i.Name ==team1);
        int teamIndex2 = groupPhase.FindIndex(i => i.Name ==team2);
            groupPhase[teamIndex1].ScoredPoints+=Convert.ToInt32(score1);
            groupPhase[teamIndex1].LostPoints+=Convert.ToInt32(score2);
            groupPhase[teamIndex1].ScoreDifference= groupPhase[teamIndex1].ScoredPoints-groupPhase[teamIndex1].LostPoints;
            groupPhase[teamIndex2].ScoredPoints+=Convert.ToInt32(score2);
            groupPhase[teamIndex2].LostPoints+=Convert.ToInt32(score1);
            groupPhase[teamIndex2].ScoreDifference= groupPhase[teamIndex1].ScoredPoints-groupPhase[teamIndex1].LostPoints;
        if(score1 > score2){
            groupPhase[teamIndex1].Win++;
            groupPhase[teamIndex1].GroupPoints+=2;
            groupPhase[teamIndex2].Lose++;
        }else if(score1 < score2){
            groupPhase[teamIndex2].Win++;
            groupPhase[teamIndex2].GroupPoints+=2;
            groupPhase[teamIndex1].Lose++;
        } else {
            groupPhase[teamIndex1].Tied++;
            groupPhase[teamIndex1].GroupPoints+=1;
            groupPhase[teamIndex2].Tied++;
            groupPhase[teamIndex2].GroupPoints+=1;
        }
    }
    public static void Create(List<TeamScore> groupPhase, Dictionary<string, List<Exibition>> exibitions){
        
        foreach(var i in exibitions.Keys){
            groupPhase.Add(new TeamScore(i));
        }
    }

    public static List<TeamScore> Print(List<TeamScore> groupPhase){
        groupPhase = groupPhase.OrderByDescending(o => o.ScoreDifference).ToList();
        groupPhase = groupPhase.OrderByDescending(o => o.ScoredPoints).ToList();
        groupPhase = groupPhase.OrderByDescending(o => o.Win).ToList();
        int position=1;
        foreach(var i in groupPhase){
            Console.Write(position + ". ");
            Console.Write(i.Name);
            Console.Write("   / ");
            Console.Write(i.Win);
            Console.Write(" / ");
            Console.Write(i.Tied);
            Console.Write(" / ");
            Console.Write(i.Lose);
            Console.Write(" / ");
            Console.Write(i.GroupPoints);
            Console.Write(" / ");
            Console.Write(i.ScoredPoints);
            Console.Write(" / ");
            Console.Write(i.LostPoints);
            Console.Write(" / ");
            Console.Write(i.ScoreDifference);
            Console.WriteLine();
            position++;
        }
    return groupPhase;
    }

}