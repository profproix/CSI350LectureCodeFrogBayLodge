using FrogBayLodge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrogBayLodge.Components
{
    public class SpaMenuViewComponent : ViewComponent
    {
        //Note: Custom Component, will populate a dynamic drop down menu
        private readonly ApplicationDbContext _context;

        public SpaMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var spa = await _context.Spa.ToListAsync();
            return View(spa);
        }
    }
}
