using LearnMe.Models;
using Microsoft.Maui.Controls;

namespace LearnMe.CustomControls
{
    public partial class FlipCardView : Frame
    {
        public static readonly BindableProperty QuestionProperty = BindableProperty.Create(
            nameof(Question),
            typeof(string),
            typeof(FlipCardView),
            string.Empty);

        public static readonly BindableProperty AnswerProperty = BindableProperty.Create(
            nameof(Answer),
            typeof(string),
            typeof(FlipCardView),
            string.Empty);

        //public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
        //    nameof(BackgroundColor),
        //    typeof(Color),
        //    typeof(FlipCardView),
        //    Color.FromArgb("#393965"));

        public string Question
        {
            get => (string)GetValue(QuestionProperty);
            set => SetValue(QuestionProperty, value);
        }

        public string Answer
        {
            get => (string)GetValue(AnswerProperty);
            set => SetValue(AnswerProperty, value);
        }

        //public new Color BackgroundColor
        //{
        //    get => (Color)GetValue(BackgroundColorProperty);
        //    set => SetValue(BackgroundColorProperty, value);
        //}

        private bool _isFlipped;

        public FlipCardView()
        {
            InitializeComponent();
            _isFlipped = false;
        }

        public void SetCard(ViewCard viewcard)
        {
            BindingContext = viewcard;
        }

        public void FlipCard()
        {
           
            Device.BeginInvokeOnMainThread(() =>
            {
                if (_isFlipped)
                {
                    FrontSide.IsVisible = true;
                    BackSide.IsVisible = false;
                }
                else
                {
                    FrontSide.IsVisible = false;
                    BackSide.IsVisible = true;
                }

                _isFlipped = !_isFlipped;
            });
        }
    }
}
