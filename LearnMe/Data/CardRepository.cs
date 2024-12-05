using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;

namespace LearnMe.Data
{
    public class CardRepository
    {
        private readonly DbContext _dbContext;

        public CardRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCard(Card card)
        {
            _dbContext.Cards.Add(card);
            _dbContext.SaveChanges();
        }

        public List<Card> GetAllCards()
        {
            return _dbContext.Cards.ToList();
        }

        public IEnumerable<Card> GetCardByGroupId(int id) 
        {
            foreach(Card card in _dbContext.Cards)
            {
                if (card.GroupId == id)
                {
                    yield return card;
                }
            }
        }

        public void DeleteCardsByGroupId(int id)
        {
            foreach (Card card in _dbContext.Cards)
            {
                if (card.GroupId == id)
                {
                   DeleteCard(card);
                }
            }
        }

        public void DeleteCard (Card card)
        {
            _dbContext.Cards.Remove(card);
            _dbContext.SaveChanges();
        }
    }
}
