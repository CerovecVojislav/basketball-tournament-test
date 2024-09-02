public class TeamScore
{
        public String? Name { get; set; }
        public int? Win { get; set; }
        public int? Tied { get; set; }
        public int? Lose { get; set; }
        public int? GroupPoints { get; set; }
        public int? ScoredPoints { get; set; }
        public int? LostPoints { get; set; }
        public int? ScoreDifference { get; set; }
        public TeamScore(string Name)
        {
                this.Name = Name;
                Win = 0;
                Tied = 0;
                Lose = 0;
                GroupPoints = 0;
                ScoredPoints = 0;
                LostPoints = 0;
                ScoreDifference = 0;
        }
        public TeamScore(string Name, int Win, int Tied, int Lose, int GroupPoints, int ScoredPoints, int LostPoints, int ScoreDifference)
        {
                this.Name = Name;
                this.Win = Win;
                this.Tied = Tied;
                this.Lose = Lose;
                this.GroupPoints = GroupPoints;
                this.ScoredPoints = ScoredPoints;
                this.LostPoints = LostPoints;
                this.ScoreDifference = ScoreDifference;
        }

}