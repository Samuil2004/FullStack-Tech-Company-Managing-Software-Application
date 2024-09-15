using System.ComponentModel.DataAnnotations;

namespace MediaBazaarWeb.Model
{
    /// <summary>
    /// A DTO model for the shift change that all users can request
    /// </summary>
    public class ShiftChangeRequestDTOModel
    {
        [Required]
        public string SelectedShift { get; set; }
        [Required(ErrorMessage = "A reason is required")]
        public string Reason { get; set; }
    }
}
