using DataLayer;
using DataLayer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MapController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        public Map CreateMap(Map map)
        {
            db.Maps.Add(map);
            db.SaveChanges();
            return map;
        }

        public Map ChooseMap(string name)
        {
            Map chosenMap = new Map();

            chosenMap = db.Maps.
                Where(m => m.Name == name).
                FirstOrDefault();
            return chosenMap;
        }

    }
}
