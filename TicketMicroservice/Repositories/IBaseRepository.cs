using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketMicroservice.Models.ModelDatabase;

namespace TicketMicroservice.Repositories
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
	{
		public List<DbModel> GetAll();
		public DbModel GetById(Guid id);
		public DbModel GetByAttribute(Expression<Func<DbModel, bool>> predicate);
		public IQueryable<DbModel> Where(Expression<Func<DbModel, bool>> predicate);
		public DbModel Update(DbModel model);
		public void DeleteById(DbModel model);
		public DbModel Create(DbModel model);
		public DbSet<DbModel> GetSet();
    }
}
