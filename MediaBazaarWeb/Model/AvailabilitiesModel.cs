using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarWeb.Model
{
    public class AvailabilitiesModel
    {
        [BindProperty]
        public int PersonId { get; set; }
        [BindProperty]
        public DateTime date { get; set; }
        [BindProperty]
        public string shift { get; set; }

    }
}

