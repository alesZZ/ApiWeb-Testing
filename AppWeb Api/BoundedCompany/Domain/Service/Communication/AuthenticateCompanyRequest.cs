using System.ComponentModel.DataAnnotations;

namespace AppWeb_Api.BoundedCompany.Domain.Service.Communication
{
    public class AuthenticateCompanyRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}