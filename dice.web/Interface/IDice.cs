using dice.web.Models;

namespace dice.web.Interface;

public interface IDice
{
    public IList<int> GetDice();
    public IList<int> FavourSelection(int face, int factor);
    public IList<int> ResetDice();
    public int RollDice();
}
