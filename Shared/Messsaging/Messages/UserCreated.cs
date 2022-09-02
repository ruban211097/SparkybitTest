using System.ComponentModel.DataAnnotations;

namespace Messsaging.Messages
{
    public interface UserCreated
    {
        [Required]
        string Name { get; set; }
    }
}