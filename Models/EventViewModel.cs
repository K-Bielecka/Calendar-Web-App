using System;

namespace CalendarMVC.Models{

 public class EventViewModel
 {
     public EventViewModel()
     {

     }
    
         public string cancelEvent()
    {
        string Link ="/" + MyDay.ToString() +"-"+ MyMonth.ToString() +"-"+ MyYear.ToString();
        
        return Link;
    }


    public int MyYear { get; set; }
    public int MyMonth{ get; set; }
    public int MyDay{ get; set; }

    public string MyName{get; set;}
      public string MyTime{get; set;}
  
 }


}
