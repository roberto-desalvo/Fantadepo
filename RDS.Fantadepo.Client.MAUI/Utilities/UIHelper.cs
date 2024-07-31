
namespace RDA.Fantadepo.Client.MAUI.Utilities
{
    public static class UIHelper 
    {
        public static void SafeCall(Action action)
        {
            try
            {
                action();
            }
            catch(Exception ex) 
            { 
                Shell.Current.DisplayAlert("Exception occurred", ex.Message, string.Empty);
            }

        }
    }
}
