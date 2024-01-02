using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models;

public class AppointmentDetail
{
    public int Id { get; set; }
    [Required]
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    [Required]
    public int AppointmentId { get; set; }
}