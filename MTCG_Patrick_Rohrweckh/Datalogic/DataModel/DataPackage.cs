using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataModel
{
    public class DataPackage
    {
        public DataPackage()
        {

        }
        public DataPackage(string status)
        {
            Status = status;
        }
        public int? Id { get; set; }
        public string? Status { get; set; }

        public override string ToString()
        {
            return $"Package: Id={Id}, Status={Status}";
        }
    }
}
