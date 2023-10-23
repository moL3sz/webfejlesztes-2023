using api.DAL.Entities.Common;
using api.DAL.Interfaces.Common;

namespace api.DAL.Interfaces {
    public interface IDictionaryManagerRepository : IBaseRepository<BaseEntityDictionary>, IPartialUpdateHelper {

        Type GetEntityType(string entityTypeName);
        Task<List<BaseEntityDictionary>> GetAllByProject(int projectId);

    }
}
