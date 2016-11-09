using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using Cinema.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.UI.Controllers
{
    public class FilmController : Controller
    {
        IGenericRepository<Film> repofilm;
        IGenericRepository<Genre> repogen;
        IGenericRepository<Hall> repohall;
        IGenericRepository<Photo> repopic;
        IGenericRepository<SessionsDate> reposes;
        IGenericRepository<Statuss> repostat;
        IGenericRepository<Ticket> repoticket;
        public FilmController(IGenericRepository<Film> repofilm,IGenericRepository<Genre> repogen,IGenericRepository<Hall> repohall,
            IGenericRepository<Photo> repopic,IGenericRepository<SessionsDate> reposes,IGenericRepository<Statuss> repostat,
            IGenericRepository<Ticket> repoticket)
        {
            this.repofilm = repofilm;
            this.repogen = repogen;
            this.repohall = repohall;
            this.repopic = repopic;
            this.reposes = reposes;
            this.repostat = repostat;
            this.repoticket = repoticket;
        }

        public ActionResult DeleteItem(int id)
        {
            List<Ticket> ls = new List<Ticket>();
            ls = (List<Ticket>)Session["ShoppingCart"];

            ls.RemoveAt(id);

            return RedirectToPrevious("Index", "Film");
            // return View(shopcart);

        }

        public ActionResult Index()
        {
            ViewModelFilmRepository repo = new ViewModelFilmRepository(repofilm,repopic);
            var model = repo.GetAll();

            return View(model);
        }
       
        public ActionResult Show(int id)
        {
            ViewModelFilmRepository repo = new ViewModelFilmRepository(repofilm, repopic);
            var model = repo.GetAll().Where(x => x.film_id == id);
            ViewBag.Ses = reposes.FindBy(x => x.film_id == id);
            //var model = repopic.FindBy(x => x.film_id == id);
            //ViewBag.FilmId = id;
            return View(model);
        }

        public ActionResult Seanses(int? id)
        {
            int count = 0;
            List<string> s = new List<string>();
           var book= repoticket.GetAll();

            foreach (var item in book)
            {
                
                HttpCookie myCookie = new HttpCookie(item.ses_id.ToString()+'.'+count++.ToString());
                myCookie.Value = item.seat.ToString();
                Response.Cookies.Add(myCookie);
            }
            
            

            ViewModelHallRepository repo = new ViewModelHallRepository( repohall, reposes);
            var model = repo.GetAll().Where(x=>x.film_id==id);
           
            return View(model);
        }

        [System.Web.Services.WebMethod]
        public ActionResult Cart(List<string> id)
        {
            List<Ticket> ls = new List<Ticket>();
            
            int sid =13;
            int? fid = reposes.Get(sid).film_id;
            ViewModelTicketRepository repo = new ViewModelTicketRepository(repofilm, repohall, repoticket);
            foreach (var item in id)
            {
                Ticket t = new Ticket()                               
                {
                    film_id = (int)fid,
                    hall_id =(int)reposes.Get(sid).hall_id,
                    ses_id=sid,
                    price = 100,
                    sessionDate = reposes.Get(sid).sesDate,
                    seat = Convert.ToInt32(item)
                };
              
               ls.Add(t);
            }
            Session["ShoppingCart"] = ls;
            var model = ls;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Cart(IEnumerable<Ticket> lt)
        {
            List<Ticket> ls = new List<Ticket>();
            ls = (List<Ticket>)Session["ShoppingCart"];

            if (ModelState.IsValid)
            {
                foreach (var item in ls)
                {
                    repoticket.AddOrUpdate(item);
                }
               
                return RedirectToAction("Index");
            }

            return View(lt);
        }

        public ActionResult Seat(int? ids)
        {
            ViewModelSeatsRepository repo = new ViewModelSeatsRepository(repohall, repoticket);
            var model = repo.GetAll().Where(x => x.ses_id == ids);
            return View(model);
        }
        public ActionResult RedirectToPrevious(String defaultAction, String defaultController)
        {
            if (Session == null || Session["PrevUrl"] == null)
            {
                return RedirectToAction(defaultAction, defaultController);
            }

            String url = ((Uri)Session["PrevUrl"]).PathAndQuery;

            if (Request.Url != null && Request.Url.PathAndQuery != url)
            {
                return Redirect(url);
            }

            return RedirectToAction(defaultAction, defaultController);
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;

            if (httpContext.Request.RequestType == "GET"
                && !httpContext.Request.IsAjaxRequest()
                && filterContext.IsChildAction == false)    // do no overwrite if we do child action.
            {
                // stop overwriting previous page if we just reload the current page.
                if (Session["CurUrl"] != null
                    && ((Uri)Session["CurUrl"]).Equals(httpContext.Request.Url))
                    return;

                Session["PrevUrl"] = Session["CurUrl"] ?? httpContext.Request.Url;
                Session["CurUrl"] = httpContext.Request.Url;
            }
        }

    }
}