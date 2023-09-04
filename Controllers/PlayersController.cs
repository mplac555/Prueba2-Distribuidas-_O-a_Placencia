using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using ad_ona_placencia_prueba_2.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ad_ona_placencia_prueba_2.Controllers
{
    public class PlayersController : Controller
    {
        string baseURL = "https://v3.football.api-sports.io/players";

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-apisports-key", "a12be76f60ac7a3fa516ec7efb4dc228");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
            return client;
        }

        public async Task<ActionResult> Index()
        {
            List<Player> jugadores = new List<Player>();
            using (var client = GetClient())
            {
                HttpResponseMessage Res = await client.GetAsync("?season=2019&league=61");
                if (Res.IsSuccessStatusCode)
                {
                    var result = Res.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var jsonObject = (JObject)JsonConvert.DeserializeObject(result);
                        var response = (JArray)jsonObject["response"];
                        jugadores.AddRange(response.Select(teamJObject => teamJObject["player"].ToObject<Player>()));
                    }
                    catch (Exception) { }
                }
            }
            return View(jugadores);
        }

        public async Task<ActionResult> Detalles(int id)
        {
            Player jugador = new Player();
            using (var client = GetClient())
            {
                HttpResponseMessage Res = await client.GetAsync("?season=2019&league=61&id="+id);
                if (Res.IsSuccessStatusCode)
                {
                    var result = Res.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var jsonObject = (JObject)JsonConvert.DeserializeObject(result);
                        var response = (JArray)jsonObject["response"];
                        jugador = response[0]["player"].ToObject<Player>();
                    }
                    catch (Exception) { }
                }
            }
            return View(jugador);
        }
    }
}