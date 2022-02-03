using Starbuck.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace Starbuck.Business.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;
        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            throw new NotImplementedException();
        }

        public bool HasNotification()
        {
            return _notifications.Count > 0;
        }
    }
}
