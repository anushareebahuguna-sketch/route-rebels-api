using Microsoft.AspNetCore.Mvc;
using RouteRebels.Api.Models;

namespace RouteRebels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnersController : ControllerBase
    {
        private static readonly List<PartnerSubmission> Partners = new();

        private static int nextId = 1;

        [HttpPost]
        public ActionResult<PartnerSubmission> Submit(
            [FromBody] PartnerSubmission submission)
        {
            submission.Id = nextId++;
            submission.SubmittedAt = DateTime.Now;

            Partners.Add(submission);

            return Ok(submission);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PartnerSubmission>> GetAll()
        {
            return Ok(Partners);
        }
    }
}