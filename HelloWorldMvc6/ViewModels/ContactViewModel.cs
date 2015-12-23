using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Server.Kestrel.Http;

namespace HelloWorldMvc6.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}