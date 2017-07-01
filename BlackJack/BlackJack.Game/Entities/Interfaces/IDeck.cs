﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Entities.Interfaces
{
    interface IDeck
    {       
        void Initialize();
        ICard GetCard();
    }
}
