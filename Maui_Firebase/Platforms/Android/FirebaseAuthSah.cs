using Maui_Firebase.FirebaseMAUI;


namespace Maui_Firebase.Platforms.Android
{
    internal class FirebaseAuthSah : IAuth
    {
        public async Task<bool> Anmelden(string username, string email, string password)
        {
            try
            {


                await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var profileUpdates = new Firebase.Auth.UserProfileChangeRequest.Builder();
                profileUpdates.SetDisplayName(username);
                var build = profileUpdates.Build();

                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                await user.UpdateProfileAsync(build);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Entry(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool IsEntry()
        {
            throw new NotImplementedException();
        }
    }
}
