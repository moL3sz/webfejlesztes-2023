using api.API.DTO.Auth;
using api.BLL.Interfaces;
using api.DAL.Entities.Common;

namespace api.BLL.Helpers
{
    public class RecordInfoHelper: IRecordInfoHelper
    {

        private readonly IUserHelper _userHelper;
        private  UserPrinciple _currentUser;

        public RecordInfoHelper(IUserHelper userHelper) {
            _userHelper = userHelper;
        }

        public void SetNewRecordInfo<T>(ref T entity) where T : BaseEntity
        {
            _currentUser = _userHelper.GetUserPrinciple();

            entity.Active = true;
            entity.Created = DateTime.Now;
            entity.Updated = DateTime.Now;
            entity.UpdaterUserName = _currentUser.Name;
            entity.UpdatorUserId = _currentUser.Id;
            entity.CreatorUserName = _currentUser.Name;
            entity.CreatorUserId = _currentUser.Id;
            entity.VersionNumber = 0;
        }

        public void SetModifiedRecordInfo<T>(ref T entity) where T : BaseEntity
        {
            _currentUser = _userHelper.GetUserPrinciple();
            entity.Updated = DateTime.Now;
            entity.UpdaterUserName = _currentUser.Name;
            entity.UpdatorUserId = _currentUser.Id;
            entity.VersionNumber++;
        }
    }
}
