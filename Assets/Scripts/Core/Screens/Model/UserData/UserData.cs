using Models;
using UnityEngine;

namespace Data
{
    public class UserData
    {
        private const string SAVED_USER_PHONE = "savedPhone";
        private const string SAVED_USER_ID = "savedId";
        private const string USER_CREATED_PPS = "userCreated";
        
        private UserModel _user;

        public UserModel User => _user;

        public void SetUserModelOfUser(UserModel userModel)
        {
            _user = userModel;
        }
        
        public string GetSavedPhone()
        {
            if (!PlayerPrefs.HasKey(SAVED_USER_PHONE))
            {
                return string.Empty;
            }
            else
            {
                return PlayerPrefs.GetString(SAVED_USER_PHONE);
            }
        }
        
        public void SetSavedPhone(string value)
        {
            PlayerPrefs.SetString(SAVED_USER_PHONE, value);
        }
        
        public bool UserEverCreated()
        {
            return PlayerPrefs.GetInt(USER_CREATED_PPS) == 1;
        }

        public void SetUserEverCreated()
        {
            PlayerPrefs.SetInt(USER_CREATED_PPS, 1);
        }
        
        public void Logout()
        {        
            _user = null;
            PlayerPrefs.DeleteKey(USER_CREATED_PPS);
            PlayerPrefs.DeleteKey(SAVED_USER_PHONE);
        }
    }
}
