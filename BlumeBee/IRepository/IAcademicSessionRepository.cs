using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IAcademicSessionRepository
    {
        IEnumerable<AcademicSessionModel> GetAllActive();
        IEnumerable<AcademicSessionModel> GetAllNonActive();
        AcademicSessionModel GetById(int id);
        int Create(AcademicSessionModel model);
        int Update(AcademicSessionModel model);
        int Delete(int id); // Soft delete
    }
}
