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
    public int firstMinute;
    public int secondMinute;

    // Start is called before the first frame update
    void Start()
    {
        InitializeChannal();
        CrerateMessage();
    }

    private void InitializeChannal()
    {
        var channal = new AndroidNotificationChannel()
        {
            Id = "channal_id",
            Name = "Default channal",
            Importance = Importance.High,
            Description = "Generic notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channal);
    }

    private void CrerateMessage()
    {
        // var time = Math.Min(DateTime.Now.Hour - firstTime.Hour, DateTime.Now.Hour - secondTime.Hour);
        //if (DateTime.Now.Hour + dHour >= firstHour || DateTime.Now.Hour + dHour >= secondHour)
        //{
            var notification = new AndroidNotification();
            notification.Title = "Зубы чисть, а то выбью)";
            notification.Text = "Что смотришь? Иди чисть зубы, а то выпадут к 30 годам.";
            notification.FireTime = GoodTimeForMessage();
            AndroidNotificationCenter.SendNotification(notification, "channal_id");
        //}
    }

    private DateTime GoodTimeForMessage()
    {
        var now = DateTime.Now;
        var hourForMorningMessage = firstHour - DateTime.Now.Hour;
        var hourForNightMessage = secondHour - DateTime.Now.Hour;
        if (now.Hour > firstHour)
        {
            if (now.Hour > secondHour)
            {
                return now.AddDays(1).AddHours(24 - now.Hour + firstHour);
            }
            else
            {
                return now.AddHours(hourForNightMessage);
            }
        }
        else
        {
            return now.AddHours(hourForMorningMessage);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
