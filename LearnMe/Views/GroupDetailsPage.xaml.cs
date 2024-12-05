using LearnMe.Models;
using LearnMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace LearnMe.Views
{
    public partial class GroupDetailsPage : ContentPage
    {
        private readonly CardService _cardService;
        private readonly GroupsService _groupService;
        private readonly int _groupId;
        private readonly CollectionView _yourGroups;

        public GroupDetailsPage(int groupId, ViewGroup viewgroup, CardService cardService, GroupsService groupService, CollectionView yourGroups)
        {
            InitializeComponent();
            this.BindingContext = viewgroup;
            _cardService = cardService;
            _groupId = groupId;
            _groupService = groupService;
            _yourGroups = yourGroups;
        }

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void GroupChange_Clicked(object sender, EventArgs e)
        {
            var selectedGroup = (sender as ImageButton).BindingContext as ViewGroup;

            // Показываем диалоговое окно для ввода новых данных
            string newName = await DisplayPromptAsync("Change Group", "Enter new name", "OK", "Cancel", selectedGroup.Name);
            string newDescription = await DisplayPromptAsync("Change Group", "Enter new description", "OK", "Cancel", selectedGroup.Description);

            if (newName != null && newDescription != null)
            {
                // Обновляем информацию о группе
                selectedGroup.Name = newName;
                selectedGroup.Description = newDescription;

                // Обновляем данные в сервисе групп
                _groupService.UpdateGroup(new Group(selectedGroup.Id, selectedGroup.Name, selectedGroup.Description, selectedGroup.UserId, selectedGroup.AccentColorEnd.ToHex(), selectedGroup.AccentColorStart.ToHex()));

                await DisplayAlert("Notification", "Group details updated successfully!", "OK");

                // Обновляем отображение списка групп после изменений
                RefreshGroupList();
            }
        }

        private void RefreshGroupList()
        {
            var lst = _groupService.GetCreatedGroups();
            var viewcreategroups = lst.Select(group => new ViewGroup(group)).ToList();
            _yourGroups.ItemsSource = viewcreategroups;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            RefreshCardsList();
        }

        private void RefreshCardsList()
        {
            var groupcards = _cardService.GetCardByGroupId(_groupId);
            Cards.ItemsSource = groupcards.ToList();
        }

        async void CreateCardButton_Clicked(object sender, EventArgs e)
        {
            string question = await DisplayPromptAsync("New Card", "Enter the question:");
            if (string.IsNullOrEmpty(question)) return;

            string answer = await DisplayPromptAsync("New Card", "Enter the answer:");
            if (string.IsNullOrEmpty(answer)) return;

          
            AddCardToGroup(question, answer);
        }

        private void AddCardToGroup(string question, string answer)
        {

            var newCard = new Card { Question = question, Answer = answer, GroupId = _groupId};
            _cardService.AddCard(newCard);
            RefreshCardsList();
        }


        async void Flip_Cards_Clicked(object sender, EventArgs e)
        {

            var flipPage = new FlipCardPage(this, _cardService, _groupId);
            await Navigation.PushAsync(flipPage);
        }
        
        async void Memorization_Clicked(object sender, EventArgs e)
        {
            var memPage = new MemorizationPage(this, _cardService, _groupId);
            await Navigation.PushAsync(memPage);
        }

        async void Blitz_Clicked(object sender, EventArgs e)
        {
            var blitzPage = new BlitzPage(this, _cardService, _groupId);
            await Navigation.PushAsync(blitzPage);
        }

        async void OnCardDoubleTapped(object sender, EventArgs e)
        {
            if (sender is BindableObject bindableObject && bindableObject.BindingContext is Card selectedCard)
            {
                bool answer = await DisplayAlert("Delete Card", "Are you sure you want to delete this card?", "Yes", "No");
                if (answer)
                {
                    
                    _cardService.DeleteCard(selectedCard);

                   
                    RefreshCardsList();
                }
            }
        }
    }
}
