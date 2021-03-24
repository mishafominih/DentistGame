using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class PushMessage : MonoBehaviour
{
    public int dHour;
    public int firstHour;
    public int secondHour;

    private string idChannal;

    // Start is called before the first frame update
    void Start()
    {
        idChannal = "id_channal";
        InitializeChannal();
        CreateMessageForChannal(firstHour);
        if(IsNeedDeletePushMassage(DateTime.Now.Hour, firstHour))
            DeleteMassage(GetIdMassage(firstHour, DateTime.Now));

        if (IsNeedDeletePushMassage(DateTime.Now.Hour, secondHour))
            DeleteMassage(GetIdMassage(secondHour, DateTime.Now));
    }

    private void DeleteMassage(int idMassage)
    {
        AndroidNotificationCenter.CancelNotification(idMassage);
    }

    private void InitializeChannal()
    {
        var channal = new AndroidNotificationChannel()
        {
            Id = idChannal,
            Name = "Default channal",
            Importance = Importance.High,
            Description = "Generic notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channal);
    }

    private void CreateMessageForChannal(int hour)
    {
        var dateForMassege = DateTime.Now.AddDays(1);
        var notification = new AndroidNotification
        {
            FireTime = new DateTime(dateForMassege.Year, dateForMassege.Month, dateForMassege.Day, hour, 0, 0),
            Title = "Чистим зубы",
            Text = "Пора чистить зубы!!"
        };
        AndroidNotificationCenter.SendNotificationWithExplicitID(notification, idChannal, GetIdMassage(hour, dateForMassege));
    }

    private int GetIdMassage(int hour, DateTime dateForMassage)
    {
        return int.Parse(hour.ToString() + dateForMassage.Day.ToString() + dateForMassage.Year.ToString());
    }

    private bool IsNeedDeletePushMassage(int nowHour, int hourForCleaning)
    {
        return nowHour < hourForCleaning && nowHour + dHour >= hourForCleaning;
    }
}
