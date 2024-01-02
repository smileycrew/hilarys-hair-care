using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}