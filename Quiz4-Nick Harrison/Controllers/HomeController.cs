using Microsoft.AspNetCore.Mvc;
using Quiz4_Nick_Harrison.Models;
using System.Diagnostics;
using Quiz4_Nick_Harrison.Entities;
using System.IO;


namespace Quiz4_Nick_Harrison.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // The DB context param
        private BpmeasurementsContext _BpmesurmentDbContext;

        public HomeController(ILogger<HomeController> logger, BpmeasurementsContext bpmesurmentDbContext)
        {
            _logger = logger;

            //setting the passed in obj to the private field
            _BpmesurmentDbContext = bpmesurmentDbContext;
        }

        public IActionResult Index()
        {
            //fill list based on DB context
            List<Bpmeasurement> Bp = _BpmesurmentDbContext.Bpmeasurements.OrderBy(Bp => Bp.BpmeasurementId).ToList();
           
            //loop through the list to make the measurement position obj not null anymore
            foreach(Bpmeasurement b in Bp) 
            {
                b.MeasurementPosition = _BpmesurmentDbContext.MeasurementPositions.Find(b.MeasurementPositionId);
            }

            //return the list to the index view 
            return View(Bp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
