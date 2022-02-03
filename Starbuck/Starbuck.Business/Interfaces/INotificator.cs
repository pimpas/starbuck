using System.Collections.Generic;
using Starbuck.Business.Notifications;

namespace Starbuck.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}
