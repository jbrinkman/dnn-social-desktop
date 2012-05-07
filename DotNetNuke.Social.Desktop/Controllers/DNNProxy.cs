using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Controllers
{
    public class DNNProxy
    {

        //private static Models.UserItems CurrentUserItems = null;
        public static bool Authenticate(Models.Credential Credential)
        {
            try
            {
                System.Random rnd = new Random();
                var id = rnd.NextDouble();
                var result = PostService("SocialWeb", "SocialWeb", "Echo", "Input=" + id, Credential);
                return result.Contains(id.ToString());
                //CurrentUserItems = Serialize.FromJson<Models.UserItems>(result);

            }
            catch (Exception exc)
            {
                DotNetNuke.Social.Desktop.Program.UserContext.LastException = exc;
                return false;
            }

        }


        public static bool CountNotifications(Models.Credential Credential)
        {
            try
            {
                var result = PostService("SocialWeb", "SocialWeb", "GetTotals", null, Credential);
                Models.Notifications not = Serialize.FromJson<Models.Notifications>(result);
                DotNetNuke.Social.Desktop.Program.UserContext.Notifications = not;
                return true;
            }
            catch (Exception e)
            {
                DotNetNuke.Social.Desktop.Program.UserContext.LastException = e;
            }
            return false;
        }

        public static bool Inbox(Models.Credential Credential, int? start, int? limit)
        {
            try
            {
                if (start == null) start = 0;
                if (limit == null) limit = 10;

                var result = PostService("SocialWeb", "SocialWeb", "Inbox", string.Format("start={0}&limit={1}", start, limit), Credential);
                //Models.Notifications not = Serialize.FromJson<Models.Notifications>(result);
                //DotNetNuke.Social.Desktop.Program.UserContext.Notifications = not;
                return true;
            }
            catch (Exception e)
            {
                DotNetNuke.Social.Desktop.Program.UserContext.LastException = e;
            }
            return false;
        }


        public static string PostService(string Module, string Controller, string Method, string Args, Models.Credential Credential)
        {

            byte[] payload = null;
            if (!string.IsNullOrEmpty(Args)) payload = System.Text.Encoding.UTF8.GetBytes(Args);
            return Web.HTTPAsString(string.Format("{0}/DesktopModules/{1}/API/{2}.ashx/{3}", Credential.Site, Module, Controller, Method), payload, Credential.Username, Credential.Password, "", "", -1, true);
        }
        public static string GetService(string Module, string Controller, string Method, string Args, Models.Credential Credential)
        {

            byte[] payload = null;
            if (!string.IsNullOrEmpty(Args)) payload = System.Text.Encoding.UTF8.GetBytes(Args);
            return Web.HTTPAsString(string.Format("{0}/DesktopModules/{1}/API/{2}.ashx/{3}", Credential.Site, Module, Controller, Method), payload, Credential.Username, Credential.Password, "", "", -1, false);
        }


    }
}
