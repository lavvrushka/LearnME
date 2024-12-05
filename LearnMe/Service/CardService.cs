using System.Collections.Generic;
using LearnMe.Data;
using LearnMe.Models;
using Microsoft.EntityFrameworkCore;

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
        => _cardRepository.GetCardByGroupId(id);

    public void AddCard(Card card)
        => _cardRepository.AddCard(card);

    public void DeleteCardsByGroupId(int id)
    {
        _cardRepository.DeleteCardsByGroupId(id);
    }
 
    public void DeleteCard(Card card)
        => _cardRepository.DeleteCard(card);

    public List<Card> GetCardsByGroupId(int groupId)
        => _cardRepository.GetCardByGroupId(groupId).ToList();
}
