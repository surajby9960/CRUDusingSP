using CRUDusingSP.Model;

namespace CRUDusingSP.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task<Student> GetStudent(int id);
        public Task<int> AddStudent(Student student);
        public Task<int> UpdateStudent(Student student);
        public Task DeleteStudent(int id);
    }
}
