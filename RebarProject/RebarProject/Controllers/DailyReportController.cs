using Microsoft.AspNetCore.Mvc;
using RebarProject.Models;
using RebarProject.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebarProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReportController : ControllerBase
    {
        private readonly IDailyReportService dailyReportService;


        public DailyReportController(IDailyReportService dailyReportService)
        {
            this.dailyReportService = dailyReportService;
        }
        // GET: api/<SgakesController>
        [HttpGet]
        public ActionResult<List<DailyReport>> Get()
        {
            return dailyReportService.Get();
        }

        // GET api/<SgakesController>/5
        [HttpGet("{date}")]
        public ActionResult<DailyReport> Get(DateTime date)
        {
            var dailyReport = dailyReportService.Get(date);
            if (dailyReport == null)
            {
                return NotFound($"order with date={date}not found");
            }
            return dailyReport;
        }

    }
}
