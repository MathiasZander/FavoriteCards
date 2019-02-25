namespace FavoriteCards.Business.Model
{
    internal struct Row
    {
        public string FrontName { get; }
        public string BackName { get; }
        public string Front { get; }
        public string Back { get; }

        public Row(string frontName, string backName, string front, string back)
        {
            FrontName = frontName;
            BackName = backName;
            Front = front;
            Back = back;
        }
    }
}