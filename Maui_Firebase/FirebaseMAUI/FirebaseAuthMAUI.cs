namespace Maui_Firebase.FirebaseMAUI
{

    public interface IAuth
    {
        Task<bool> Entry(string email, string password);
        Task<bool> Anmelden(string username, string email, string password);

        bool IsEntry();
    }

    internal class FirebaseAuthMAUI
    {
        static IAuth auth = DependencyService.Get<IAuth>();


        public static async Task<bool> Anmelden(string username, string email, string password)
        {
            return await auth.Anmelden(username, email, password);
        }

        public static async Task<bool> Entry(string email, string password)
        {
            return await auth.Entry(email, password);
        }

        public static bool IsEntry()
        {
            return auth.IsEntry();
        }
    }
}
