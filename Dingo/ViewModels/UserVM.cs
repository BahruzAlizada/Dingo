using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dingo.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email adresini düzgün qeyd edin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana boş qala bilməz")]
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsDeactive { get; set; }

    }
}
