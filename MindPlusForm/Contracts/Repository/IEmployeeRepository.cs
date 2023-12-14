using MindPlusForm.DTO;
using MindPlusForm.Entity;

namespace MindPlusForm.Contracts.Repository
{
    public interface IEmployeeRepository
    {
        Task Add(EmployeeDTO employee);
        Task Update(EmployeeEntity employee);
        Task Delete(int id);
        Task<EmployeeEntity> GetById(int id);
        Task<IEnumerable<EmployeeEntity>> Get();
    }
}
