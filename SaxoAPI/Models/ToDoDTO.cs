using System.ComponentModel.DataAnnotations;

namespace SaxoAPI.Models
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }
    }


}
