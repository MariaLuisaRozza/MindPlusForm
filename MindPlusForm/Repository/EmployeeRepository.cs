using Dapper;
using MindPlusForm.Contracts.Repository;
using MindPlusForm.DTO;
using MindPlusForm.Entity;
using MindPlusForm.Infrastructure;

namespace MindPlusForm.Repository
{
    public class employeeRepository : Connection, IEmployeeRepository
    {
        public async Task Add(EmployeeDTO employee)
        {
            string sql = @"
                INSERT INTO employees (Name, Email, Contact, Address, Office, Company, Password)
                           VALUE (@Name, @Email, @Contact, @Address, @Office, @Company, @Password)
            ";
            await Execute(sql, employee);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM employees WHERE Id = @id";
            await Execute(sql, new { id });
        }

        public async Task<IEnumerable<EmployeeEntity>> Get()
        {
            string sql = "SELECT * FROM employees";
            return await GetConnection().QueryAsync<EmployeeEntity>(sql);
        }

        public async Task<EmployeeEntity> GetById(int id)
        {
            string sql = "SELECT * FROM employees WHERE Id = @id";
            return await GetConnection().QueryFirstAsync<EmployeeEntity>(sql, new { id });
        }

        public async Task Update(EmployeeEntity employee)
        {
            string sql = @"
                UPDATE employees 
                   SET Name = @Name, 
                       Email = @Email,
                       Contact = @Contact,
                       Address = @Address,
                       Office = @Office,
                       Company = @Company,
                       Password = @Password
                 WHERE Id = @Id
            ";
            await Execute(sql, employee);
        }
    }
}
