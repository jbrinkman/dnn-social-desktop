using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DotNetNuke.Social.Controllers
{
    public class DNNController
    {


        public static bool JournalList(Models.Credential Credential, int? RowIndex, int? MaxRows)
        {
            try
            {
                if (RowIndex == null) RowIndex = 0;
                if (MaxRows == null) MaxRows = 10;

                var result = PostService("SocialWeb", "SocialWeb", "JournalList", string.Format("RowIndex={0}&MaxRows={1}", RowIndex, MaxRows), Credential);
                DotNetNuke.Social.Desktop.Program.UserContext.Journal = Serialize.FromJson<List<Models.Journal.Journal>>(result);

                return true;
            }
            catch (Exception e)
            {
                DotNetNuke.Social.Desktop.Program.UserContext.LastException = e;
            }
            return false;
        }









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

        public static bool NotificationAction(Models.Credential Credential, int NotificationId, Models.Action Action)
        {
            if (Action == null || string.IsNullOrEmpty(Action.APICall)) return false;

            var result = PostRaw(string.Format("", Credential.Site, Action.APICall), string.Format("NotificationId={0}", NotificationId), Credential);

            return true;
        }

        public static bool Notifications(Models.Credential Credential, int? afterNotificationId, int? numberOfRecords)
        {
            try
            {
                if (afterNotificationId == null) afterNotificationId = 0;
                if (numberOfRecords == null) numberOfRecords = 10;

                var result = PostService("SocialWeb", "SocialWeb", "Notifications", string.Format("afterNotificationId={0}&numberOfRecords={1}", afterNotificationId, numberOfRecords), Credential);
                DotNetNuke.Social.Desktop.Program.UserContext.Notifications = Serialize.FromJson<Models.NotificationTop>(result);
                
                return true;
            }
            catch (Exception e)
            {
                DotNetNuke.Social.Desktop.Program.UserContext.LastException = e;
            }
            return false;
        }




        public static bool CountNotifications(Models.Credential Credential)
        {
            try
            {
                var result = PostService("SocialWeb", "SocialWeb", "GetTotals", null, Credential);
                Models.NotificationTop not = Serialize.FromJson<Models.NotificationTop>(result);
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
                DotNetNuke.Social.Desktop.Program.UserContext.Inbox = Serialize.FromJson<Models.Inbox>(result);

                return true;
            }
            catch (Exception e)
            {
                DotNetNuke.Social.Desktop.Program.UserContext.LastException = e;
            }
            return false;
        }


        public static string PostRaw(string Url, string Args, Models.Credential Credential)
        {
            byte[] payload = null;
            if (!string.IsNullOrEmpty(Args)) payload = System.Text.Encoding.UTF8.GetBytes(Args);
            return Web.HTTPAsString(Url, payload, Credential.Username, Credential.Password, "", "", -1, true);
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
