using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServices.Data;
using WebServices.Data.Models;

namespace AsmxWebService
{
    /// <summary>
    /// Summary description for DemoV1
    /// </summary>
    [WebService(Namespace = "http://intelect.az/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DemoV1 : System.Web.Services.WebService
    {

        [WebMethod]
        public City GetCityById(int id)
        {
            return Db.Cities.FirstOrDefault(c => c.Id == id);
        }

        [WebMethod]
        public List<City> GetCities()
        {
            return Db.Cities;
        }

        [WebMethod]
        public void AddCity(City city)
        {
            Db.Cities.Add(city);
        }
    }
}
