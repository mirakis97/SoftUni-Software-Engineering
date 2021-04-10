namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int InitialComfort = 5;
        private const int InitialPrice = 10;

        public Plant()
               : base(InitialComfort, InitialPrice)
        {
        }
    }
}
