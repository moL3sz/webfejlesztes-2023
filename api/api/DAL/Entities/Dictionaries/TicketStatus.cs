﻿using api.DAL.Entities.Common;

namespace api.DAL.Entities.Dictionaries
{
    public class TicketStatus: BaseEntityDictionary
    {
        public virtual Project Project { get; set; }

    }
}
