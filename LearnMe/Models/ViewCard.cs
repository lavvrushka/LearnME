using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{

    public class ViewCard
    {

        public ViewCard(Card card)
        {
            Id = card.Id;
            Question = card.Question;
            Answer = card.Answer;
            GroupId = card.GroupId;
            //CreationDate = card.CreationDate;

        }
        public int Id { get; set; }

        public string Question { get; set; }


        public string Answer { get; set; }

        public int GroupId { get; set; }

        public Color BackgroundColor { get; set; }


    }

}