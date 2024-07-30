using RDS.Fantadepo.MAUI.MVVM.ViewModels;
using RDS.Fantadepo.Models.Models;

namespace RDS.Fantadepo.MAUI.MVVM.Views;

public partial class PlayerListPage : ContentPage
{
    public PlayerListPage(PlayerListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
    }

    private void OnTapGestureRecognizerDoubleTapped(object sender, FocusEventArgs e)
    {
        if (sender is Frame frame)
        {
            var entry = frame.Children.OfType<Entry>().FirstOrDefault() ?? new Entry();

            if ((entry.BindingContext is Player player) && (this.BindingContext is PlayerListViewModel model))
            {
                //model.OnModifyPlayer(player);
            }
        }
    }
}