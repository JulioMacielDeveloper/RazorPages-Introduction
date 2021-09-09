using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIntroduction.Models;
using RazorPagesIntroduction.Pages.Data;

namespace RazorPagesIntroduction.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ContactsContext _context;

        public EditModel(ContactsContext context)
        {
            _context = context;
        }


        [BindProperty(SupportsGet = true)]
        public Customer Customer { get; set;}


        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new System.Exception($"Customer {Customer.Id} not found!");
            }

            return RedirectToPage("./Index");
        }
    }
}