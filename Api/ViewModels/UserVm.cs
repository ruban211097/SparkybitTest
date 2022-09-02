using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class UserVm
    {
        [Required]
        public string Name { get; set; }
    }
}
