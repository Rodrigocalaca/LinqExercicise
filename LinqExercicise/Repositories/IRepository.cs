using LinqExercicise.Models;

namespace LinqExercicise.Repositories
{
    public interface IRepository
    {
        List<Numbers> Get();

        Numbers GetNumById(int id);

        Numbers PostNumber(Numbers number);

        Numbers UpdateNumber(Numbers number);

        bool DeleteNumber(int id);

        List<Numbers> GetSquaredNumber();

        List<Numbers> GetLastNumbers(int n);

        List<Numbers> GetFirstNumbers(int n);

        List<Numbers> GetLowerThanN(int n);

        List<Numbers> GetGreaterThanN(int n);

        Numbers GetFirstGreaterThanN(int n);

        Numbers GetLastLowerThanN(int n);
    }
}
