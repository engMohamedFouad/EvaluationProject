using DashboardMessage.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashboardMessage.Controllers
{
    public class HomeController : Controller
    {
        DashboardEntities2 db = new DashboardEntities2();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            User s = db.User.Where(x => x.UserName == u.UserName && x.Password == u.Password).FirstOrDefault();
            if(s!=null)
            {
                List<User> users = db.User.ToList();
                List<Message> m = db.Message.Where(x => x.Uid == s.Uid).ToList();
                if(m==null)
                {
                    ViewBag.numberOfMessage = 0;
                }
                else {
                    ViewBag.numberOfMessage =m.Count() ;
                }
                ViewBag.determineduser = s;
                return View("AllList",users);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult SendMessage(int id,string name)
        {
            User us= db.User.Where(x => x.Name == name).FirstOrDefault();
            User s = db.User.Where(x => x.Uid == id).FirstOrDefault();
            ViewBag.d = s;
            ViewBag.me = us;
            Message m = new Message();
            return View(m);
        }
        [HttpPost]
        public ActionResult SendMessage(Message m ,int userid,string Title)
        {
            Message sms = new Message();
            sms.MID = m.MID;
            sms.Title = Title;
            sms.Message1 = m.Message1;
            sms.Date = m.Date;
            sms.Uid = userid;
            db.Message.Add(sms);
            db.SaveChanges();
            return View("Thanks");
        }
        [HttpGet]
        public ActionResult MyMessage(int id)
        {
           IEnumerable<Message> m = db.Message.Where(x => x.Uid == id).ToList();
           return View(m);
        }
        [HttpPost]
        public ActionResult MyMessage(Message m,int id,string towho)
        {
            Message sms = db.Message.Where(x => x.MID == id).FirstOrDefault();
            User u = db.User.Where(x => x.Name == towho).FirstOrDefault();
            Message mess = new Message();
            if(m.Reply!=null)
            {
                sms.Reply = m.Reply;
                db.SaveChanges();
                mess.Title = u.Name ;
                mess.Date = m.Date;
                mess.Message1 = m.Reply;
                mess.Uid = u.Uid ;
                db.Message.Add(mess);
                db.SaveChanges();
                return View("Thanks");
            }
            else
            {
                return RedirectToAction("MyMessage");
            }
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            User u = db.User.Where(x => x.Uid == id).FirstOrDefault();
            return View(u);
        }


        }
}