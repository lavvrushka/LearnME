using LearnMe.ViewModels;
namespace LearnMe.Views;

public partial class ExplorePage : ContentPage
{
	public ExplorePage(ExploreViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}