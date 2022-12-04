using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _context;

        public CategoryService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        where c.LanguageId == languageId
                        select c;
            return await query.Select(x => new CategoryVm()
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        where c.LanguageId == languageId && c.Id == id
                        select c;
            return await query.Select(x => new CategoryVm()
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId
            }).FirstOrDefaultAsync();
        }
    }
}