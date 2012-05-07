using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Social.Controllers;

namespace DotNetNuke.Social.Repositories
{
    public class CredentialRepository
    {
        public CredentialRepository() {
            LoadCredentials();
        }

        public Models.Credential Default
        {
            get
            {
                if (Credentials != null && Credentials.Count > 0) return Credentials[0];
                return new Models.Credential();
            }
        }
        public List<Models.Credential> Credentials
        {
            get
            {
                if (_Credentials != null) return _Credentials;
                return LoadCredentials();
            }
            set
            {
                _Credentials = value;
                SaveCredentials();
            }
        }

        private List<Models.Credential> _Credentials;
        private string CredentialsFile = "Credentials.xml";
        private object _ReadLock = new object();
        private object _WriteLock = new object();
        public List<Models.Credential> LoadCredentials()
        {
            lock (_ReadLock)
            {
                StorageController<List<Models.Credential>> credentialStorage = new StorageController<List<Models.Credential>>();
                _Credentials = credentialStorage.Load(CredentialsFile);
                if (_Credentials == null) _Credentials = new List<Models.Credential>();
            }

            return _Credentials;
        }

        public void SaveCredentials()
        {
            lock (_WriteLock)
            {

                StorageController<List<Models.Credential>> credentialStorage = new StorageController<List<Models.Credential>>();
                credentialStorage.Save(_Credentials, CredentialsFile);
            }
        }

        public void AddCredential(Models.Credential Credential)
        {
            bool found = false;
            if (Credentials != null)
            {
                foreach (Models.Credential c in Credentials)
                {
                    if (c.Password == Credential.Password && c.Username == Credential.Username && c.Site == Credential.Site)
                    {
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                _Credentials = new List<Models.Credential>();
            }
            if (!found)
            {
                _Credentials.Add(Credential);
                SaveCredentials();
            }
        }

        public void RemoveCredential(Models.Credential Credential)
        {
            Models.Credential found = null;
            if (Credentials != null)
            {
                foreach (Models.Credential c in Credentials)
                {
                    if (c.Password == Credential.Password && c.Username == Credential.Username && c.Site == Credential.Site)
                    {
                        found = c;
                        break;
                    }
                }
            }
            if (found != null)
            {
                _Credentials.Remove(found);
                SaveCredentials();
            }

        }

    }
}