using VaccineManagement.Model;

namespace VaccineManagement.Session
{
    public class UserSession
    {
        private static UserSession _instance;

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSession();
                }
                return _instance;
            }
        }

        public Staff User { get; set; } 
    }
}
