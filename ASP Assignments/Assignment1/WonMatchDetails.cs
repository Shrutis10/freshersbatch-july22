using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_1.Models
{
    public class WonMatchDetails
    {
        footballEntities entities=new footballEntities();
        public List<FOOTBALL_LEAGUE> winninglist()
        {
            return entities.WonMatchDetails().ToList();
        }
    }
}