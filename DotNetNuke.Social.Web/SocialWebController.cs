using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using DotNetNuke.Web.Services;
using System.Web.Mvc;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Portals;
using System.IO;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.Social.Notifications;
using DotNetNuke.Services.Social.Messaging;

namespace DotNetNuke.Social.Web
{
    [DnnAuthorize()]
    public class SocialWebController : DnnController
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SocialWebController));

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Echo(string Input)
        {

            return Json(Input);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetTotals()
        {
            try
            {
                var TotalUnreadMessages = DotNetNuke.Services.Social.Messaging.MessagingController.Instance.CountUnreadMessages(base.UserInfo.UserID, base.PortalSettings.PortalId);
                var TotalNotifications = NotificationsController.Instance.CountNotifications(UserInfo.UserID, UserController.GetCurrentUserInfo().PortalID);
                return Json(new { TotalNotifications = TotalNotifications, TotalUnreadMessages = TotalUnreadMessages });
            }
            catch (Exception exc)
            {
                log.Error(exc);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Inbox(int start, int limit)
        {
            try
            {
                log.Info("Start:" + start);
                log.Info("Limit:" + limit);

                var messageBoxView = DotNetNuke.Services.Social.Messaging.MessagingController.Instance.GetRecentInbox(UserInfo.UserID, start, limit);

                messageBoxView.TotalNewThreads = DotNetNuke.Services.Social.Messaging.MessagingController.Instance.CountUnreadMessages(UserInfo.UserID, UserController.GetCurrentUserInfo().PortalID);
                messageBoxView.TotalConversations = DotNetNuke.Services.Social.Messaging.MessagingController.Instance.CountConversations(UserInfo.UserID, UserController.GetCurrentUserInfo().PortalID, MessageReadStatus.Any, MessageArchivedStatus.UnArchived, MessageSentStatus.Received);

                return Json(messageBoxView, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                log.Error(exc);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



    }
}
