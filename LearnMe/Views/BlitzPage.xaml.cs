namespace LearnMe.Views
{
    public partial class BlitzPage : ContentPage
    {
        ContentPage previousPage; 

        public BlitzPage(ContentPage previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); 
        }
    }
}
