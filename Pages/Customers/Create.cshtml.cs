using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesIntroduction.Models;
using RazorPagesIntroduction.Pages.Data;

namespace RazorPagesIntroduction.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ContactsContext _context;

        public CreateModel(ContactsContext context)
        {
            _context = context;
        }

        
        public IActionResult OnGet() // Incializa o estado necessário para a página.
        {
            return Page();
        }

        [BindProperty(SupportsGet = true)] // Aceita a vinculação do modelo // Não pode constar em propriedades que não possam ser alteradas por clientes
        public Customer Customer { get; set; }



        public async Task<IActionResult> OnPostAsync() // Método Manipulador // Lida com os envios de formulários
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
}