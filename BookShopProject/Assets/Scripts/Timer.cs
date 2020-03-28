using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : UpdateBase
{
    Text text;
    float minitu = 50.0f;
    int hour = 8;
    public Text TextObj { get { return text; } set { text = value; } }
    bool is_update = false;
    public bool IsUpdate { get { return is_update; } set { is_update = value; } }
    float speed = 20.0f;
    Text day_text;
    int day_value = 1;
    public float Speed { get { return speed; } set { speed = value; } }
    public enum DayOfWeek
    {
        Sun,
        Mon,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat,
    }
    DayOfWeek day_of_week = DayOfWeek.Sun;
    public void Ini()
    {
        text = GameObject.Find("Timer").GetComponent<UnityEngine.UI.Text>();
        day_text = GameObject.Find("Day").GetComponent<UnityEngine.UI.Text>();
        day_text.text = day_value.ToString().PadLeft(2,'0') + "日" + "(日)";
    }

    public override void Update()
    {
        minitu += Time.deltaTime * speed;
        if(!is_update)
        {
            return;
        }
        if (minitu >= 60.0f)
        {
            minitu = 0.0f;
            hour++;
        }
        text.text = hour.ToString() + ":" + minitu.ToString("F0"); 
    }

    public DayOfWeek NextDay()
    {
        day_value++;
        day_of_week++;
        if((int)day_of_week > (int)DayOfWeek.Sat)
        {
            day_of_week = DayOfWeek.Sun;
        }
        var day_of_week_text = "";
        switch (day_of_week)
        {
            case DayOfWeek.Sun:
                day_of_week_text = "日";
                break;
            case DayOfWeek.Mon:
                day_of_week_text = "月";
                break;
            case DayOfWeek.Tue:
                day_of_week_text = "火";
                break;
            case DayOfWeek.Wed:
                day_of_week_text = "水";
                break;
            case DayOfWeek.Thu:
                day_of_week_text = "木";
                break;
            case DayOfWeek.Fri:
                day_of_week_text = "金";
                break;
            case DayOfWeek.Sat:
                day_of_week_text = "土";
                break;
        }
        var day = "(" + day_of_week_text + ")";
        day_text.text = day_value.ToString().PadLeft(2, '0') + "日" + day;
        return day_of_week;
    }
} 
