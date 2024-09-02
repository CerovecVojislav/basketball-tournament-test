using System.ComponentModel;

class SimulateMatch
{
    public static void Play(Group group1, Group group2, Dictionary<string, List<Exibition>> exibitions, List<TeamScore> groupPhase)
    {
        double team1 = Convert.ToDouble(group1.FIBARanking);
        double team2 = Convert.ToDouble(group2.FIBARanking);
        double tmp = (team1 - team2) / (team1 + team2);
        double score1 = 80 - tmp * 20;
        double score2 = 80 + tmp * 20;

        List<Exibition> e = exibitions[group1.ISOCode];
        Exibition team = e.Find(g => g.Opponent == group2.ISOCode);
        if (team != null)
        {
            string[] parts = new string[2];
            parts = team.Result.Split("-");
            double historyScore1 = Convert.ToDouble(parts[0]);
            double historyScore2 = Convert.ToDouble(parts[1]);
            score1 = (score1 + historyScore1) / 2;
            score2 = (score2 + historyScore2) / 2;
        }
        GroupBoard.Add(group1.ISOCode, group2.ISOCode, score1, score2, groupPhase);
        Console.Write(Math.Round(score1) + " : " + Math.Round(score2));
    }
}