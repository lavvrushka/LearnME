using LearnMe.CustomControls;
using LearnMe.Models;
using LearnMe.Service;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Graphics;
using System.Diagnostics;


namespace LearnMe.Views;

public partial class MemorizationPage : ContentPage
{
    private readonly ContentPage previousPage;
    private readonly CardService _cardService;
    private readonly int _groupId;

    public MemorizationPage(ContentPage previousPage, CardService cardService, int groupId)
    {
        InitializeComponent();
        this.previousPage = previousPage;
        _cardService = cardService;
        _groupId = groupId;

        BindingContext = this;

        InitializeCards();

        GoodAnswer = 0;
        BadAnswer = 0;
    }

    async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private ObservableCollection<ViewCard> _cards;
    private const double SwipeThreshold = 120;
    private const double SwipeRemoveBoundary = 160;

    private int _goodAnswer;
    public int GoodAnswer
    {
        get => _goodAnswer;
        set
        {
            _goodAnswer = value;
            OnPropertyChanged();
        }
    }

    private int _badAnswer;
    public int BadAnswer
    {
        get => _badAnswer;
        set
        {
            _badAnswer = value;
            OnPropertyChanged();
        }
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

    private void InitializeCards()
    {
        var cards = _cardService.GetCardsByGroupId(_groupId);

        _cards = new ObservableCollection<ViewCard>(
            cards.Select(card => new ViewCard(card) { BackgroundColor = Color.FromArgb("#393965") })
        );

        foreach (var card in _cards.Reverse())
        {
            AddCard(card);
        }

        CardCount = _cards.Count;
    }

    private void AddCard(ViewCard viewCard)
    {
        var cardView = new CardView();
        cardView.SetCard(viewCard);
        cardView.TranslationX = 0;
        cardView.TranslationY = 0;
        cardView.Rotation = 0;

        var panGesture = new PanGestureRecognizer();
        panGesture.PanUpdated += OnPanUpdated;
        cardView.GestureRecognizers.Add(panGesture);

        CardContainer.Children.Add(cardView);
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        var cardView = sender as CardView;

        switch (e.StatusType)
        {
            case GestureStatus.Running:
                cardView.TranslationX = e.TotalX;
                cardView.TranslationY = e.TotalY;
                cardView.Rotation = e.TotalX / 10;
                cardView.Scale = 0.95 + Math.Abs(e.TotalX / 1000);
                break;

            case GestureStatus.Completed:
                if (Math.Abs(e.TotalX) > SwipeThreshold)
                {
                    var direction = e.TotalX > 0 ? 1 : -1;
                    SwipeCard(cardView, direction);
                }
                else
                {
                    ResetCardPosition(cardView);
                }
                break;
        }

        if (Math.Abs(cardView.TranslationX) > SwipeRemoveBoundary)
        {
            RemoveCard(cardView);
        }
    }


    private void SwipeCard(CardView cardView, int direction)
    {
        var endX = cardView.TranslationX + (direction * 1000);
        cardView.TranslateTo(endX, cardView.TranslationY, 250, Easing.SpringOut);
        cardView.RotateTo(cardView.Rotation + (direction * 30), 250, Easing.SpringOut);
        cardView.FadeTo(0, 500, Easing.SpringOut);

        Device.StartTimer(TimeSpan.FromMilliseconds(250), () =>
        {
            RemoveCard(cardView);

            Device.BeginInvokeOnMainThread(() =>
            {
                if (direction > 0)
                {
                    GoodAnswer++; // Increment for correct answer
                }
                else
                {
                    BadAnswer++; // Increment for incorrect answer
                }
            });

            return false;
        });
    }


    private void RemoveCard(CardView cardView)
    {
        CardContainer.Children.Remove(cardView);
        _cards.RemoveAt(_cards.Count - 1);

        CardCount = _cards.Count;

        if (_cards.Count == 0)
        {
            InitializeCards();
        }
    }

    private void ResetCardPosition(CardView cardView)
    {
        cardView.TranslateTo(0, 0, 250, Easing.SpringOut);
        cardView.RotateTo(0, 250, Easing.SpringOut);
        cardView.ScaleTo(1, 250, Easing.SpringOut);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
