using System.ComponentModel.DataAnnotations;

namespace AppWeb_Api.BoundedPostulant.Domain.Service.Communication
{
    public class AuthenticatePostulantRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}