namespace BlazorServer.Domain.DTOs
{
    using System.ComponentModel.DataAnnotations;
    public class HotelRoom
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a room name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an occupancy")]
        public int Occupancy { get; set; }

        [Range(1, 3000, ErrorMessage = "The regular rate must be between 1 and 3000")]
        [Required(ErrorMessage = "Please enter a regular rate")]
        public double RegularRate { get; set; }

        public string Details { get; set; }
        public string SqFt { get; set; }
    }
}
