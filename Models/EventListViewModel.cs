using System;
using System.Collections.Generic;

namespace CalendarMVC.Models{

 public class EventListViewModel
 {
     public EventListViewModel()
     {

     }
    
    public EventListViewModel(int year,int month, int day)
    {
       MyYear =year;
       MyMonth= MyMonth;
       MyDay=day;
    } 
    public int MyYear { get; set; }
    public int MyMonth{ get; set; }
    public int MyDay{ get; set; }


    public List <EventViewModel> EventsInfoList;

       public string getEventForm()
    {
        string Link = MyDay.ToString()+"-"+ MyMonth.ToString() +"-"+ MyYear.ToString()+"-NewEvent";
        return Link;
    }

        public string editEvent(string MyName, string MyTime)
    {
        string Link = MyDay.ToString()+"-"+ MyMonth.ToString() +"-"+ MyYear.ToString()+"-Edit"+"/"+ MyName +"/"+ MyTime;
        EventViewModel temp = new EventViewModel();
        temp.MyYear=MyYear;
        temp.MyMonth=MyMonth;
        temp.MyDay=MyDay;
        temp.MyName=MyName;
        temp.MyTime=MyTime;
        return Link;
    }

          public string closeEventList()
    {
        string Link = MyMonth.ToString() +"-"+ MyYear.ToString();
        return Link;
    }


  
 }


}
