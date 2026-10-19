using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterLeadSourceRepository
    {
        int Insert(MasterLeadSourceModel model);
        int Update(MasterLeadSourceModel model);
        int Delete(int id);
        List<MasterLeadSourceModel> GetAll();
        MasterLeadSourceModel GetById(int id);
    }
}
