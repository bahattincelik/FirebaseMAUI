namespace Maui_Firebase
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        

        private void Button_ClickedAnmelden(object sender, EventArgs e)
        {
            if (SLEntry.IsVisible)
            {
                SLEntry.IsVisible = false;
                SLAnmelden.IsVisible = true;
            }
            else 
            { 
                SLEntry.IsVisible = true;
                SLAnmelden.IsVisible=false;
            }
        }
    }

}
