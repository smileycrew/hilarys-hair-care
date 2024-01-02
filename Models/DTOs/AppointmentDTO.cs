using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models.DTOs;

public class AppointmentDTO
{
    public int Id { get; set; }
    public DateTime AppointmentTime { get; set; }
    public bool IsCancelled { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
    [Required]
    public int StylistId { get; set; }
    public StylistDTO Stylist { get; set; }
    public List<AppointmentDetailDTO> AppointmentDetails { get; set; }
    public decimal TotalCost
    {
        get
        {
            decimal total = 0M;
            foreach (AppointmentDetailDTO AppointmentDetail in AppointmentDetails)
            {
                total += AppointmentDetail.Service.Price;
            }
            return total;
        }
    }
}