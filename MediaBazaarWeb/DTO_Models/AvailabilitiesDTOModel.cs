using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarWeb.Model
{
    /// <summary>
    /// A DTO Model for marking and umarking availability from the web calendar
    /// </summary>
    public class AvailabilitiesDTOModel
    {
        [BindProperty]
        public int PersonId { get; set; }
        [BindProperty]
        public DateTime date { get; set; }
        [BindProperty]
        public string shift { get; set; }

    }
}

