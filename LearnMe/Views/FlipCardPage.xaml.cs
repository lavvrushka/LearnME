using LearnMe.CustomControls;
using LearnMe.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace LearnMe.Views
{
    public partial class FlipCardPage : ContentPage
    {
        private readonly ContentPage previousPage;
        private readonly CardService _cardService;
        private readonly int _groupId;
        private int _currentCardIndex;

        public FlipCardPage(ContentPage previousPage, CardService cardService, int groupId)
        {
            this.previousPage = previousPage;
            _cardService = cardService;
            _groupId = groupId;

            InitializeComponent();
            InitializeCards();
            ShowNextCard();

            BindingContext = this;
        }

        private int _cardCount;
        public int CardCount
        {
            get => _cardCount;
            set
            {
                _cardCount = value;
                OnPropertyChanged();
            }
        }

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private ObservableCollection<ViewCard> _cards;
        private void InitializeCards()
        {
            var cards = _cardService.GetCardsByGroupId(_groupId);

            _cards = new ObservableCollection<ViewCard>(
                cards.Select(card => new ViewCard(card) { BackgroundColor = Color.FromArgb("#393965") })
            );
            _currentCardIndex = 0;
            CardCount = _cards.Count;
        }

        private void ShowNextCard()
        {
            if (_currentCardIndex < _cards.Count)
            {
                var card = _cards[_currentCardIndex];
                var flipcardView = new FlipCardView();
                flipcardView.SetCard(card);
                flipcardView.TranslationX = 0;
                flipcardView.TranslationY = 0;
                flipcardView.Rotation = 0;

                var tapGesture = new TapGestureRecognizer();
                tapGesture.NumberOfTapsRequired = 2; // Double tap
                tapGesture.Tapped += (sender, e) => OnCardDoubleTapped(flipcardView);
                flipcardView.GestureRecognizers.Add(tapGesture);

                CardPlaceholder.Content = flipcardView;
                _currentCardIndex++;
            }
            else
            {
                CardPlaceholder.Content = null; // No more cards to show
                StartOverButton.IsVisible = true; // Show the "Start Over" button
                NextCardButton.IsVisible = false; // Hide the "Next Card" button
            }
        }

        private void OnNextCardClicked(object sender, EventArgs e)
        {
            CardCount--;
            ShowNextCard();
        }

        private void OnCardDoubleTapped(FlipCardView flipcardView)
        {   
            flipcardView.RotateYTo(90, 250, Easing.SinInOut).ContinueWith(t =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    flipcardView.FlipCard();
                    flipcardView.RotateYTo(0, 250, Easing.SinInOut);
                });
            });
        }

        private void OnStartOverClicked(object sender, EventArgs e)
        {
            InitializeCards();
            ShowNextCard();
            StartOverButton.IsVisible = false;
            NextCardButton.IsVisible = true;
        }
    }
}
