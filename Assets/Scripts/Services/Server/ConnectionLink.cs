using UnityEngine;

namespace Server
{
    public class ConnectionLink : MonoBehaviour
    {
        public const string Url = "http://90.156.224.27:8080/api/";    
        public const string AppVersions = "AppVersions/";
        public const string Users = "Users/";
        public const string Order = "Orders/";
        public const string Garages = "Garages/";
        public const string Comments = "Comments/";
        public const string Files = "Files/";
        public const string Z = "1/";
        public const string DateTime = "DateTime/";

        public const string DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
    }
}