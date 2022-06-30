using LinqExercicise.Models;

namespace LinqExercicise.Repositories
{
    public class Repository// : IRepository
    {
        private Numbers _number;

        public Repository()
        {
            _number = new Numbers();
        }

        public List<Numbers> Get()
        {
            throw new NotImplementedException();
        }

        public Numbers GetFirstGreaterThanN(int n)
        {
            throw new NotImplementedException();
        }

        public List<Numbers> GetFirstNumbers(int n)
        {
            throw new NotImplementedException();
        }

        public List<Numbers> GetGreaterThanN(int n)
        {
            throw new NotImplementedException();
        }

        public Numbers GetLastLowerThanN(int n)
        {
            throw new NotImplementedException();
        }

        public List<Numbers> GetLastNumbers(int n)
        {
            throw new NotImplementedException();
        }

        public List<Numbers> GetLowerThanN(int n)
        {
            throw new NotImplementedException();
        }

        public Numbers GetNumById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Numbers> GetSquaredNumber()
        {
            throw new NotImplementedException();
        }

        public Numbers PostNumber(Numbers number)
        {
            throw new NotImplementedException();
        }

        public Numbers UpdateNumber(Numbers number)
        {
            throw new NotImplementedException();
        }
    }
}
