using System.ComponentModel.DataAnnotations;

namespace MediaBazaarWeb.Model
{
    public class ShiftChangeRequestDto
    {
        [Required]
        public string SelectedShift { get; set; }
        [Required(ErrorMessage = "A reason is required")]
        public string Reason { get; set; }
    }
}
