﻿using TicketMicroservice.Database;
using Microsoft.EntityFrameworkCore;
using TicketMicroservice.Models.ModelDatabase;
using System.Linq.Expressions;

namespace TicketMicroservice.Repositories
{
    public class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
	{
		private ApplicationContext _context { get; set; }
		public BaseRepository(ApplicationContext context)
		{
			_context = context;
        }
		public List<DbModel> GetAll()
		{
			return _context.Set<DbModel>().ToList();
		}
        public DbModel GetById(Guid Id)
		{
			return _context.Set<DbModel>().FirstOrDefault(t => t.Id == Id)??null;
		}
        public async Task<DbModel> GetByAttribute(Expression<Func<DbModel, bool>> predicate)
        {
            return await _context.Set<DbModel>().FirstOrDefaultAsync(predicate);
        }
		public IQueryable<DbModel> Where(Expression<Func<DbModel, bool>> predicate)
		{
			return  _context.Set<DbModel>().Where(predicate);
		}
		public DbModel Update(DbModel model)
		{
			var toUpdate = _context.Set<DbModel>().FirstOrDefault(t => t.Id == model.Id);
			if (toUpdate != null)
			{
				toUpdate = model;
			}
			_context.Set<DbModel>().Update(toUpdate);
			_context.SaveChanges();
			return model;
		}
        public void DeleteById(DbModel model)
		{
			_context.Set<DbModel>().Remove(model);
			_context.SaveChanges();
		}
        public DbModel Create(DbModel model)
        {
            _context.Set<DbModel>().AddAsync(model);
            _context.SaveChanges();
            return model;
        }
		public DbSet<DbModel> GetSet()
		{
			return _context.Set<DbModel>();
		}
		public IQueryable<DbModel> Select(Expression<Func<DbModel, int, DbModel>> predicate)
		{
			return _context.Set<DbModel>().Select(predicate);
		}
    }
}
