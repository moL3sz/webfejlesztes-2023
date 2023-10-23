using api.API.DTO.Common;
using api.BLL.Interfaces.Common;

namespace api.BLL.Interfaces {
    public interface IDictionaryService : IBaseService<BaseDictionaryDTO>{
        void ParseRequestUrl(string url);
        Task<List<BaseDictionaryDTO>> GetAllByProject(int projectId);

    }
}
