using RDS.Fantadepo.Business.Models;
using RDS.Fantadepo.MAUI.ViewModels;

namespace RDS.Fantadepo.MAUI.Pages;

public partial class PlayersPage : ContentPage
{
    public PlayersPage(PlayersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void OnTapGestureRecognizerDoubleTapped(object sender, FocusEventArgs e)
    {
        if (sender is Frame frame)
        {
            var entry = frame.Children.OfType<Entry>().FirstOrDefault() ?? new Entry();

            if ((entry.BindingContext is Player player) && (this.BindingContext is PlayersViewModel model))
            {
                model.OnModifyPlayer(player);
            }
        }
    }
}