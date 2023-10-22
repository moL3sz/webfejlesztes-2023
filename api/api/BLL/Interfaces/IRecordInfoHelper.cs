using api.DAL.Entities.Common;

namespace api.BLL.Interfaces {
    public interface IRecordInfoHelper {
        public void SetNewRecordInfo<T>(ref T entity) where T : BaseEntity;

        public void SetModifiedRecordInfo<T>(ref T entity) where T : BaseEntity;
    }
}
