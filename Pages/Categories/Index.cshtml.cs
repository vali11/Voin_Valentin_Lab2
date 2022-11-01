using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Voin_Valentin_Lab2.Data;
using Voin_Valentin_Lab2.Models;
using Voin_Valentin_Lab2.Models.ViewModels;

namespace Voin_Valentin_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Voin_Valentin_Lab2.Data.Voin_Valentin_Lab2Context _context;

        public IndexModel(Voin_Valentin_Lab2.Data.Voin_Valentin_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? BookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Book)
            .ThenInclude(i => i.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
            }
        }
    }
}
