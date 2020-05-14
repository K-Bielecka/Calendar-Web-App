using System;

namespace CalendarMVC.Models{

    

 public class CalendarViewModel
 {
     public CalendarViewModel()
     {

     }
    
    public CalendarViewModel(DateTime date)
    {
        MyDate=date;
    }
    public DateTime startDate(DateTime date) // the parameter is current date 
    {
        int subsDays = date.Day-1;
       DateTime firstDay = date.AddDays(-subsDays);
        int FirstDayDOW= (int)firstDay.DayOfWeek;
        DateTime firstMonday = firstDay.AddDays(-FirstDayDOW+1); 
        return firstMonday;
    }
    
    public string getNext ()
    {
        int year = MyYear;
        int month = MyMonth + 1;
        if(MyMonth==12)
        {
            month =1;
            year= MyYear + 1;
        }
        string nextLink = month.ToString() +"-"+ year.ToString();
        return nextLink;
    }

     public string getPrev ()
    {
        int year = MyYear;
        int month = MyMonth - 1;
        if(MyMonth==1)
        {
            month =12;
            year= MyYear - 1;
        }
        string nextLink = month.ToString() +"-"+ year.ToString();
        return nextLink;
    }

      public string getEventList(int year, int month, int day)
    {
        string nextLink =day.ToString()+'-'+ month.ToString() +"-"+ year.ToString();
        return nextLink;
    }



    public DateTime MyDate { get; set; } 
    public int MyYear { get; set; }
     public int MyMonth{ get; set; }
    public int MyDay{ get; set; }
 }


}
