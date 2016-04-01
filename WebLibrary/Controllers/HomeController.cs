using DataAccess;
using System;
using System.Web.Mvc;
using Domain;
using WebLibrary.Controllers.Utility;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class HomeController : ImpedanceBaseController
    {
        private readonly SpeakerDao _speakerDao;

        public HomeController()
        {
            _speakerDao = new SpeakerDao();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertSpeaker(string model, string brand, string impedance)
        {
            try
            {
                _speakerDao.InsertSpeaker(new SpeakerInfo
                {
                    Model = model,
                    Brand = brand,
                    Impedance = int.Parse(impedance)
                });
                return SuccessMessageJsonResponse("Speaker successfully added.");

            }
            catch (Exception e)
            {
                return FailureMessageJsonResponse(e.Message);

            }
        }

    }
}