using CredentialManagement;

namespace CredentialManager
{
    public static class CredentialUtil
    {
        public static string GetCredential(string target)
        {

            var cm = new Credential { Target = target };
            if (!cm.Load())
            {
                return null;
            }
            return cm.Username + "|" + cm.Password;
        }

        public static bool SetCredentials(
             string target, string username, string password, PersistanceType persistenceType)
        {
            return new Credential
            {
                Target = target,
                Username = username,
                Password = password,
                PersistanceType = persistenceType
            }.Save();
        }

        public static bool RemoveCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }
    }
}
