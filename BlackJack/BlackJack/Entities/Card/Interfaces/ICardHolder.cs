namespace BlackJack.Entities.Card.Interfaces
{
    public interface ICardHolder
    {
        int Id { get; set; }
        Hand Hand { get; set; }
    }
}
