using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetnSaltyController : Controller
    {
        //constructor
        public SweetnSaltyController(ISweetnSaltyBusinessClass ISweetnSaltyBusinessClass)
        {
        }


        [HttpPost]
        [Route("postaflavor/{flavor}")]
        public async Task<Flavor> PostFlavor(string flavor)
        {

        }

        [HttpPost]
        [Route("postaperson/{fname}/{lname}")]
        public async Task<Person> PostPerson(string fname, string lname)
        {

        }

        [HttpGet]
        [Route("getaperson/{fname}/{lname}")]
        public async Task<Person> PostFlavor(string fname, string lname)
        {

        }

        [HttpGet]
        [Route("getapersonandflavors/{id}")]
        public async Task<Person> GetPersonAndFlavors(int id)
        {

        }

        [HttpGet]
        [Route("getlistofflavors")]
        public async Task<List<Flavor>> GetAllFlavors()
        {

        }


    }
}
