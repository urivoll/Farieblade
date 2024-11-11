namespace UI.Manager
{
    public class EventManager
    {
        private const string Prefix = "ManagerEvents_";
        public const string AppInitially = Prefix + "AppInitially";
        public const string AppVersion = Prefix + "AppVersion";
        
        public const string OnEdit = Prefix + "OnEdit";
        public const string OnSave = Prefix + "OnSave";
        public const string OnDelete = Prefix + "OnDelete";
        public const string OnClick = Prefix + "OnClick";
        public const string OnClickBack = Prefix + "OnClickBack";
        
        public const string CodeСonfirmed = Prefix + "CodeСonfirmed";
        public const string RegistrationComplete = Prefix + "RegistrationComplete";
                
        public const string AlchemyScreen = Prefix + "ProfileScreen";
        public const string DealerScreen = Prefix + "SupportScreen";
        public const string TavernScreen = Prefix + "AboutScreen";

        public const string Logout = Prefix + "Logout";
    }
}