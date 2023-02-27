using System.Diagnostics;
using DataBaseLastProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataBaseLastProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            SqlConnection conn = new SqlConnection("Server=BATIN-PC\\SQLEXPRESS;Database=arackirala;Trusted_Connetion=True;");
            SqlCommand cmd = new SqlCommand("select tcno,adı,soyadı,eposta,telefonno,cinsiyet from musteri", conn);
            List<Musteri> musteri = new List<Musteri>();

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                musteri.Add(
                    new Musteri
                    {
                        tc = (string)dr["tc"],
                        ad = (string)dr["ad"],
                        soyad = (string)dr["soyad"],
                        email = (string)dr["email"],
                        telefonno = (string)dr["telefonno"],
                        cinsiyet = (string)dr["cinsiyet"]
                    });
            }
      
            return View();
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