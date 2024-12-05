using LearnMe.Models;

namespace LearnMe.CustomControls
{

    public partial class CardView : Frame
    {
        public CardView()
        {
            InitializeComponent();
        }

        public void SetCard(ViewCard viewcard)
        {
            QuestionLabel.Text = viewcard.Question;
            AnswerLabel.Text = viewcard.Answer;
            BackgroundColor = viewcard.BackgroundColor;
        }
    }
}