using System.ComponentModel.DataAnnotations;

namespace Dingo.ViewModels
{
    public class RoleVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public string Role { get; set; }
    }
}
