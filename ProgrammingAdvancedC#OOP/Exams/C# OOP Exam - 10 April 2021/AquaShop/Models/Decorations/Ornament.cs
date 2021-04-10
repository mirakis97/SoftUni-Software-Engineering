namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int InitialComfort = 1;
        private const int InitialPrice = 5;

        public Ornament()
               : base(InitialComfort, InitialPrice)
        {
        }
    }
}
