using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models;

public class Service
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public decimal Price { get; set; }
}