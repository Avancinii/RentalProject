using MotorcycleRentalSystem.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleRentalSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string name { get; set; }
        public required string CNPJ { get; set; }
        public DateTime birthDate { get; set; }
        public string? cnhNumber { get; set; }
        public required string cnhType { get; set; }
        public byte[]? cnhImagePath { get; set; }
        public Profile profileId { get; set; }


        public virtual ICollection<LocationModel> Location { get; set; }
    }
}
