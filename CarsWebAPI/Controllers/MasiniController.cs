using CarParkDbAPI;
using CarParkDbAPI.Models;
using CarsWebAPI.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasiniController : ControllerBase
    {
        [HttpGet("{id}")]
        public Autovehicul GetById(int id) =>
             DataLayerSingleton.Instance.GetAutovehicul(id);

        [HttpGet()]
        public List<Autovehicul> GetAll([FromQuery] int? maxCapacitateCilindrica)
        {
            if (maxCapacitateCilindrica == null)
            {
                return DataLayerSingleton.Instance.GetAllAutovehicule();
            }
            return DataLayerSingleton.Instance.GetAllAutovehicule()
                .Where(a => a.CarteTehnica != null && a.CarteTehnica.CC <= maxCapacitateCilindrica)
                .ToList();
        }

        [HttpPost("new car")]
        public Autovehicul AddAutovehicul([FromBody] NewCarDto dateAutovehicul)
        {
            return DataLayerSingleton.Instance.AdaugaAutovehicul(dateAutovehicul.Nume, dateAutovehicul.IdProd);
        }

        [HttpPut("{id}")]
        public Autovehicul UpdateAutovehicul(int id, [FromBody] string newName)
        {
            return DataLayerSingleton.Instance.ChangeName(id, newName);
        }

        [HttpDelete("{id}")]
        public void DeleteAutovehicul(int id)
        {
            DataLayerSingleton.Instance.StergeAutovehicul( id);
        }

    }
}
