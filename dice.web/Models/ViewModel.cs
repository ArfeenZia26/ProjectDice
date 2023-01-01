namespace dice.web.Models
{
    public class ViewModel
    {
        public IList<DicesFace> Dice { get; set; }
        public ViewModel()
        {
             Dice = new List<DicesFace>();
        }
    }
    public class Dice
    {
        public int Face { get; set; }
    }
    public class DicesFace
    {
        public Dice Dice1 { get; set; }
        public Dice Dice2 { get; set; }
        public int Total { get; set; }
    }
}
