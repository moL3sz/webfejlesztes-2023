using api.API.DTO.Common;
using api.BLL.Interfaces;
using api.DAL.Entities.Common;
using api.DAL.Interfaces;
using AutoMapper;

namespace api.BLL.Services {
    public class DictionaryService : IDictionaryService {


        private IDictionaryManagerRepository _repo;
        private byte EntityControllerNameIndex = 3;
        private readonly Mapper _mapper;
        private readonly IRecordInfoHelper _recordInfo;
        private Type _entityType;

        public DictionaryService(
                IDictionaryManagerRepository repo, IRecordInfoHelper recordInfo) {
            _repo = repo;

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<BaseEntityDictionary, BaseDictionaryDTO>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfiguration);
            _recordInfo = recordInfo;
        }


        /// <summary>
        /// Kiveszi az URL-ből az Entity nevét
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns>Entity neve</returns>
        private string GetEntityTypeNameFromUrl(string requestUrl) {
            try {
                var parts = requestUrl.Split("/");
                return parts[EntityControllerNameIndex];
            }
            catch (Exception) {
                return string.Empty;
            }
        }
     
        public async Task<List<BaseDictionaryDTO>> GetAllByProject(int projectId) {
            List<BaseEntityDictionary> records = await _repo.GetAllByProject(projectId);
            return _mapper.Map<List<BaseDictionaryDTO>>(records);
        }
       
        public async Task<BaseDictionaryDTO> GetById(int Id) {
            BaseEntityDictionary entity = await _repo.GetById(Id);
            return _mapper.Map<BaseDictionaryDTO>(entity);
        }


        public async Task<BaseDictionaryDTO> Insert(BaseDictionaryDTO dto) {
            BaseEntityDictionary entity = _mapper.Map<BaseEntityDictionary>(dto);
            _recordInfo.SetNewRecordInfo(ref entity);
            entity =  await _repo.Insert(entity);
            return _mapper.Map<BaseDictionaryDTO>(entity);
        }


        public async Task<BaseDictionaryDTO> Update(dynamic dto) {        
            var updatedEntity =  _repo.PartialUpdate(_entityType, dto);
            return _mapper.Map<BaseDictionaryDTO>(updatedEntity);
        }

        public async Task<BaseDictionaryDTO> Delete(int Id) {
           var entity =  await _repo.Delete(Id);
            return _mapper.Map<BaseDictionaryDTO>(entity);
        }

        public void ParseRequestUrl(string url) {
            string EntityTypeName = GetEntityTypeNameFromUrl(url);
            _entityType = _repo.GetEntityType(EntityTypeName);
        }

        public Task<List<BaseDictionaryDTO>> GetAll() {
            throw new NotImplementedException();
        }
    }
}
