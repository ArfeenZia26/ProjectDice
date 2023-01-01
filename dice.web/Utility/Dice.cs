using dice.web.Interface;
using dice.web.Models;

namespace dice.web.Utility
{
    public class Dice : IDice
    {
        private List<int> _dice = new List<int> { 1, 2, 3, 4, 5, 6 };
        private Random random = new Random();

        public IList<int> FavourSelection(int face, int factor)
        {
            for (int i = 0; i < factor; i++)
            {
                _dice.Add(face);
            }
            _dice = Shuffle(_dice).ToList();
            return _dice;
        }

        public IList<int> GetDice()
        {
            _dice = new List<int> { 1, 2, 3, 4, 5, 6 };

            return _dice;
        }

        public IList<int> ResetDice()
        {
            return GetDice();
        }

        public int RollDice()
        {
            int num = random.Next(0, _dice.Count);
            return _dice[num];
        }

        private IList<int> Shuffle(IList<int> list)
        {
            try
            {
                Random rng = new Random();
                int[] arr = new int[list.Count];
                for (int i = 0; i < list.Count;)
                {
                    int num = rng.Next(0, _dice.Count);
                    if (arr[num] == 0)
                    {
                        arr[num] = list[i];
                        i++;
                    }
                }

                return arr.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception during shuffling", ex);
            }
        }
    }
}
