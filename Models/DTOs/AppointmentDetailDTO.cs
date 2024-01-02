using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models.DTOs;

public class AppointmentDetailDTO
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int ServiceId { get; set; }
    public ServiceDTO Service { get; set; }
}