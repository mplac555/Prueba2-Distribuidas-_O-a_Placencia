using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ad_ona_placencia_prueba_2.Models
{
    public class Player
    {
        public class BirthData
        {
            public string date { get; set; }
            public string place { get; set; }
            public string country { get; set; }
        }

        public int id { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public BirthData birth { get; set; }
        public string nationality { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public bool injured { get; set; }
        public string photo { get; set; }
    }
}