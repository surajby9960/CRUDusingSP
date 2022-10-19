using CRUDusingSP.Context;
using CRUDusingSP.Model;
using CRUDusingSP.Repositories.Interfaces;
using Dapper;
 using System.Data;

namespace CRUDusingSP.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext context;
        public StudentRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddStudent(Student student)
        {
            var procedure = "SPIUDS";
            var parameter = new DynamicParameters();
            parameter.Add("name", student.Sname);
            parameter.Add("addr", student.Saddr);
            parameter.Add("flag", "i");
            using (var con = context.createCon())
            {
                var res = await con.QuerySingleAsync<int>(procedure, parameter, commandType: CommandType.StoredProcedure);
                return res;
            }

        }

        public async Task DeleteStudent(int id)
        {
            var procedure = "SPIUDS";
            var parameter = new DynamicParameters();
            parameter.Add("id", id);
            parameter.Add("flag", "d");
            using (var con = context.createCon())
            {
                await con.ExecuteAsync(procedure, parameter, commandType:  CommandType.StoredProcedure);
            }


        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var procedure = "SPIUDS";
            var parameter = new DynamicParameters();
            parameter.Add("flag", "s");
            using (var con = context.createCon())
            {
                var student = await con.QueryAsync<Student>(procedure, parameter, commandType: CommandType.StoredProcedure);
                return student.ToList();
            }


        }

        public async Task<Student> GetStudent(int id)
        {
            var procedure = "SPIUDS";
            var parameter= new DynamicParameters();
            parameter.Add("id", id);
           // parameter.Add()
           using(var con = context.createCon())
            {
                var student=await con.QuerySingleAsync<Student>(procedure, parameter, commandType: CommandType.StoredProcedure);
                return student;
            }
        }

        public async Task<int> UpdateStudent(Student student)
        {

            var procedure = "SPIUDS";
            var parameter = new DynamicParameters();
            parameter.Add("id",student.sId);
            parameter.Add("name", student.Sname);
            parameter.Add("addr", student.Saddr);
            parameter.Add("flag", "u");
            using (var con = context.createCon())
            {
                var res = await con.ExecuteAsync(procedure, parameter, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
    }
}
