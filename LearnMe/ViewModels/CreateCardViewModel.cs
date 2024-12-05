using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearnMe.Models;
using LearnMe.Service;




namespace LearnMe.ViewModels
{
    public partial class CreateCardViewModel
    {
        private readonly CardService _cardService;


        public CreateCardViewModel(CardService cardService)
        {
            _cardService = cardService;
        }

        public void AddCard(int groupid, string answer, string question)
        {
            _cardService.AddCard(new Models.Card { Answer = answer, Question = question, GroupId = groupid });
        }

        public List<Card> GetAllCards()
        {
            return _cardService.GetAllCards();
        }

        public List<Card> GetCardByGroupId(int id)
        {
            return _cardService.GetCardByGroupId(id).ToList();
        }

        public void DeleteCard(Card card)
        {
            _cardService.DeleteCard(card);
        }

    }
}
