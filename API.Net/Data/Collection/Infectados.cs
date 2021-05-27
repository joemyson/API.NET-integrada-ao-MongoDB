using System;
using MongoDB.Driver.GeoJsonObjectModel;


namespace API.Net.Data.Collection
{
    public class Infectados
    {
       

        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infectados(DateTime datetime, string sexo,double longitude,double latitude)
        {
            Datetime = datetime;
            this.Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }


    }
}
