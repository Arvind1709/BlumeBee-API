using BlumeBee.Model;
using BlumeBee.ModelDTO;

namespace BlumeBee.IRepository
{
    public interface IVisitorLogRepository
    {
        List<VisitorLogModel> GetAll();
        VisitorLogModel? GetById(long id);
        long Insert(VisitorLogModelDto model);
        bool Update(long id, VisitorLogModelDto model);
        bool Delete(long id);
    }
}
