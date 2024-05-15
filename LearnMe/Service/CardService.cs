using LearnMe.Data;
using LearnMe.Models;

public class CardService
{
    private readonly CardRepository _cardRepository;

    public CardService(CardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    public List<Card> GetAllCards()
        => _cardRepository.GetAllCards();

    public IEnumerable<Card> GetCardByGroupId(int id)
    {
        return _cardRepository.GetCardByGroupId(id);
    }

    public void AddCard(Card card)
    {
        _cardRepository.AddCard(card);
    }

    public void DeleteCard(Card card)
    {
        _cardRepository.DeleteCard(card);
    }

}
