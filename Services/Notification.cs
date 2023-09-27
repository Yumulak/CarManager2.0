using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarManager.Services
{
    public static class Notification
    {

        public static async Task ScheduleNotification(DateTime offset)
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled())
            {
                var request = new NotificationRequest
                {
                    NotificationId = 1000,
                    Title = "Vehicle Maintenance Due Soon",
                    Subtitle = "Vehicle Maintenance",
                    Description = "There is at least one maintenance task coming due on one of your vehicles.",
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = offset, //when to schedule notification
                        NotifyRepeatInterval = TimeSpan.FromDays(1)
                    }
                };
                await LocalNotificationCenter.Current.Show(request);
            }
            else
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
                var request1 = new NotificationRequest
                {
                    NotificationId = 1000,
                    Title = "Vehicle Maintenance Due Soon",
                    Subtitle = "Vehicle Maintenance",
                    Description = "There is at least one maintenance task coming due on one of your vehicles.",
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = offset, //when to schedule notification
                        NotifyRepeatInterval = TimeSpan.FromDays(1)
                    }
                };
                await LocalNotificationCenter.Current.Show(request1);
            }
        }
    }
}
