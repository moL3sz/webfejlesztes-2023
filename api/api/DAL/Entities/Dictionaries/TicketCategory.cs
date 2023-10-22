using api.DAL.Entities.Common;

namespace api.DAL.Entities.Dictionaries
{
    public class TicketCategory : BaseEntityDictionary
    {
        public virtual Project Project { get; set; }
    }
}
