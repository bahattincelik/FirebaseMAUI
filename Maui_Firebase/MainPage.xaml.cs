using Maui_Firebase.FirebaseMAUI;

namespace Maui_Firebase
{
    public partial class MainPage : ContentPage
    {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public MainPage()
        {
            InitializeComponent(); 
            this.BindingContext = this;
        }



        private void Button_ClickedAnmeldenEntry(object sender, EventArgs e)
        {
            if (SLEntry.IsVisible)
            {
                SLEntry.IsVisible = false;
                SLAnmelden.IsVisible = true;
            }
            else
            {
                SLEntry.IsVisible = true;
                SLAnmelden.IsVisible = false;
            }
        }

        private async void Button_ClickedAnmelden(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(UserName))
            {
                await DisplayAlert("Error", "Fields cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await DisplayAlert("Error", "All fields must be filled", "OK");
                return;
            }

            bool result = await FirebaseAuthMAUI.Anmelden(UserName, Email, Password);
            if (result)
            {
                await DisplayAlert("Info", "Registration Successful", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Registration Failed", "OK");
            }
        }

        private async void Button_ClickedEntry(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) )
            {
                await DisplayAlert("Error", "Fields cannot be empty", "OK");
                return;
            }


            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await DisplayAlert("Error", "Email and Password must be filled", "OK");
                return;
            }

            bool result = await FirebaseAuthMAUI.Entry(Email, Password);
            if (result)
            {
                await DisplayAlert("Info", "Login Successful", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Login Failed", "OK");
            }
        }

    }

}
