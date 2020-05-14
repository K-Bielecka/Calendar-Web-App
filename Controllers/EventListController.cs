using Microsoft.AspNetCore.Mvc;
using CalendarMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace CalendarMVC.Controllers
{
    public class EventListController : Controller
    {
         public EventViewModel EventModel;
         public EventListViewModel listViewModel;


         public  List<EventViewModel> EventsInfo = new List<EventViewModel>();


        
       [Route("{day:int}-{month:int}-{year:int}")]
          public IActionResult EventList(int year, int month,int day)
        {
           listViewModel = new EventListViewModel();
            listViewModel.MyDay=day;
            listViewModel.MyMonth=month;
            listViewModel.MyYear=year;
            listViewModel.EventsInfoList = new List<EventViewModel>();
            readFile();

        foreach (EventViewModel temp in EventsInfo)
        {
            if(temp.MyYear==year && temp.MyMonth==month && temp.MyDay==day){
            listViewModel.EventsInfoList.Add(temp);
            }
        }
            return View(listViewModel);
        }

            public IActionResult Event()
        {   int year = listViewModel.MyYear;
            int month= listViewModel.MyMonth;
            int day=listViewModel.MyDay;
            
              return Event(year,month,day);
        }

        [HttpGet]
        [Route("{day:int}-{month:int}-{year:int}-NewEvent")]
        public IActionResult Event(int year, int month,int day)
        {
            EventViewModel EventModel = new EventViewModel();
            EventModel.MyDay=day;
            EventModel.MyMonth=month;
            EventModel.MyYear=year;
           

              return View(EventModel);
        }

        [HttpPost]
        [Route("{day:int}-{month:int}-{year:int}-NewEvent")]
        public ActionResult Event(string MyName, string MyTime, int year, int month, int day) 
        {
            
             EventViewModel eventData = new EventViewModel();
             eventData.MyName=MyName;
             eventData.MyTime=MyTime;
             eventData.MyYear=year;
             eventData.MyMonth=month;
             eventData.MyDay=day;
            

             int numOfEvents = EventsInfo.Count;
            readFile();
             EventsInfo.Add(eventData); 
               
            saveFile();

             return RedirectToAction("EventList", new{year=year, month= month, day=day});
        }

        [HttpGet]
        [Route("{day:int}-{month:int}-{year:int}-Edit/{MyName}/{MyTime}")]
        public IActionResult editEvent(int year, int month, int day,string MyName, string MyTime)
        {
            EventViewModel EventModel = new EventViewModel();
            EventModel.MyDay=day;
            EventModel.MyMonth=month;
            EventModel.MyYear=year;
            EventModel.MyName=MyName;
            EventModel.MyTime=MyTime;
          readFile(); 
          int removeAt = EventsInfo.FindIndex( x =>( x.MyTime==MyTime && x.MyName==MyName && x.MyDay==day && x.MyMonth==month && x.MyYear==year)); 
          EventsInfo.RemoveAt(removeAt);
          saveFile();
         
              return View(EventModel);
        }

        [HttpPost]
        [Route("{day:int}-{month:int}-{year:int}-Edit/{MyName}/{MyTime}")]
        public ActionResult editEvent(int year, int month, int day,string MyName, string MyTime,int Id ) 
        {
            
             EventViewModel eventData = new EventViewModel();
             eventData.MyName=MyName;
             eventData.MyTime=MyTime;
              eventData.MyDay=day;
            eventData.MyMonth=month;
            eventData.MyYear=year;
             
            readFile();
            
             EventsInfo.Add(eventData);
               
            saveFile();
       
             return RedirectToAction("EventList", new{year=year, month=month, day=day});
        }


        public void readFile()
        {
               if(!System.IO.File.Exists("file.txt"))
            {
                using(System.IO.File.Create("file.txt")){}  
            }

                 try{
                using (StreamReader sr = new System.IO.StreamReader("file.txt")){
                    string Line;

                    while((Line=sr.ReadLine())!=null){
                        string[] temp = Line.Split("|");
                        EventViewModel currEventView = new EventViewModel();
                        currEventView.MyYear=Int32.Parse(temp[0]);
                         currEventView.MyMonth=Int32.Parse(temp[1]);
                          currEventView.MyDay=Int32.Parse(temp[2]);
                        currEventView.MyName=temp[3];
                        currEventView.MyTime=temp[4];
                    
                        EventsInfo.Add(currEventView);
                         //sr.ReadLine();
                    }
                   
                }
            }catch(Exception){
                throw new IOException("error");
            }
        }

       public void saveFile()
       {
           try{
                using (StreamWriter sw = new System.IO.StreamWriter("file.txt")){
                    foreach(EventViewModel temp in EventsInfo)
                    {
                        sw.WriteLine(temp.MyYear +"|"+ temp.MyMonth +"|"+ temp.MyDay +"|"+ temp.MyName +"|"+ temp.MyTime);
                    }
                    
                }
            }catch(Exception){
                throw new IOException("error");
            }
       } 

           
      
    }
}
    
