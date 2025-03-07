using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataModel
{
    public class DataStack
    {
        public DataStack()
        {

        }
        public DataStack(int? userId, string? cardId, string stackType)
        {
            UserId = userId;
            CardId = cardId;
            StackType = stackType;
        }
        public int? UserId { get; set; }
        public string? CardId { get; set; }
        public string StackType { get; set; } = "";
        public override string ToString()
        {
            return $"Card: UserId={UserId}, CardId={CardId}, StackType={StackType}";
        }
    }
}
