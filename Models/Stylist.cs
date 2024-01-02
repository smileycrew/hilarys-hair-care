using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models;

public class Stylist
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
}