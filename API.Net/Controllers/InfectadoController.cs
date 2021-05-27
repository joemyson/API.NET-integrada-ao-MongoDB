using API.Net.Data.Collection;
using API.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;

        IMongoCollection<Infectados> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectados>(typeof(Infectados).Name.ToUpper());
        }

        [HttpPost]
        public ActionResult SalvarInfectados([FromBody]InfectadosDTO dto)
        {
            var infectado = new Infectados(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            _infectadosCollection.InsertOne(infectado);
            return StatusCode(201, "Infectado adicionado com sucesso");
        }
        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectados>.Filter.Empty).ToList();
            return Ok(infectados);
        }
        [HttpPut]
        public ActionResult AtualizarInfectado( [FromBody] InfectadosDTO dto)
        {
            _infectadosCollection.UpdateOne(Builders<Infectados>.Filter.Where( _=>_.))
        }
    }
}
