using System.Collections.Generic;
using WebServices.Data.Models;

namespace WebServices.Data
{
    static public class Db
    {
        static Db()
        {
            Cities = new List<City>() {
                new City{
                    Id=1,
                    Name="Neftçala"
                },
                new City{
                    Id=2,
                    Name="Bakı"
                }
            };
        }

        static public List<City> Cities { get; private set; }
    }
}
