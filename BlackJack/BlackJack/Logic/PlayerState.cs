using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Logic.Interfaces;

namespace BlackJack.Logic
{
    public class PlayerState
    {
        internal IPlayer Player { get; set; }
        internal bool Stand { get; set; }
    }
}
