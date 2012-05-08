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
using DotNetNuke.Services.Journal;



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
        public ActionResult JournalList(int RowIndex, int MaxRows)
        {
            try
            {
                DotNetNuke.Services.Journal.JournalController jc = new JournalController();
                return Json(jc.GetJournalItems(PortalSettings.PortalId, -1, base.UserInfo.UserID, RowIndex, MaxRows));

            }
            catch (Exception exc)
            {
                log.Error(exc);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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
        public ActionResult Notifications(int afterNotificationId, int numberOfRecords)
        {
            try
            {
                var notificationsDomainModel = NotificationsController.Instance.GetNotifications(UserInfo.UserID, UserController.GetCurrentUserInfo().PortalID, afterNotificationId, numberOfRecords);

                
                var notificationsViewModel = new                 {
                    TotalNotifications = NotificationsController.Instance.CountNotifications(UserInfo.UserID, UserController.GetCurrentUserInfo().PortalID),
                    Notifications = new List<object>(notificationsDomainModel.Count)
                };

                foreach (var notification in notificationsDomainModel)
                {
                    var notificationViewModel = new 
                    {
                        NotificationId = notification.NotificationID,
                        Subject = notification.Subject,
                        From = notification.From,
                        Body = notification.Body,
                        DisplayDate = Common.Utilities.DateUtils.CalculateDateForDisplay(notification.CreatedOnDate),
                        SenderAvatar = string.Format(DotNetNuke.Common.Globals.UserProfilePicFormattedUrl(), notification.SenderUserID, 32, 32),
                        SenderProfileUrl = DotNetNuke.Common.Globals.UserProfileURL(notification.SenderUserID),
                        Actions = new List<object>()
                    };

                    var notificationType = NotificationsController.Instance.GetNotificationType(notification.NotificationTypeID);
                    var notificationTypeActions = NotificationsController.Instance.GetNotificationTypeActions(notification.NotificationTypeID);

                    foreach (var notificationTypeAction in notificationTypeActions)
                    {
                        var notificationActionViewModel = new 
                        {
                            Name = "Name",
                            Description = "Description",
                            Confirm = "Confirm",
                            APICall = notificationTypeAction.APICall
                        };

                        notificationViewModel.Actions.Add(notificationActionViewModel);
                    }

                    if (notification.IncludeDismissAction)
                    {
                        notificationViewModel.Actions.Add(new 
                        {
                            Name = "Dismiss",
                            Description = "Dismiss",
                            Confirm = "",
                            APICall = "DesktopModules/InternalServices/API/NotificationsService.ashx/Dismiss"
                        });
                    }

                    notificationsViewModel.Notifications.Add(notificationViewModel);
                }

                return Json(notificationsViewModel, JsonRequestBehavior.AllowGet);
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