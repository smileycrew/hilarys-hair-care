using HillarysHaircare.Models;
using HillarysHaircare.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHaircareDbContext>(builder.Configuration["HillarysHairCareDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//endpoints----------------------------------------------------------------

//get all stylists

app.MapGet("/api/stylists", (HillarysHaircareDbContext db) =>
{
    return db.Stylists
    .Select(s => new StylistDTO
    {
        Id = s.Id,
        FirstName = s.FirstName,
        LastName = s.LastName,
        IsActive = s.IsActive
    }).ToList();
});

//---------------------------------------------------------------------------

app.MapPut("/api/stylists/{id}", (HillarysHaircareDbContext db, int id) =>
{
    Stylist? stylistToUpdate = db.Stylists.FirstOrDefault(s => s.Id == id);

    if (stylistToUpdate == null)
    {
        return Results.NotFound();
    }

    stylistToUpdate.IsActive = false;

    try
    {
        db.SaveChanges();
        return Results.NoContent();
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Failed to update stylist status");
    };




});

//---------------------------------------------------------------------------
app.MapDelete("/api/stylists/{id}", (HillarysHaircareDbContext database, int id) =>
{
    Stylist? stylist = database.Stylists
    .First((stylist) => stylist.Id == id);
    if (stylist == null)
    {
        return Results.BadRequest();
    }
    stylist.IsActive = !stylist.IsActive;
    database.SaveChanges();
    return Results.NoContent();
});


//---------------------------------------------------------------------------

//add new stylist

app.MapPost("/api/stylists", (HillarysHaircareDbContext database, Stylist newStylist) =>
{
    newStylist.IsActive = true;
    database.Add(newStylist);
    database.SaveChanges();

    return Results.Created($"/api/stylists{newStylist.Id}", newStylist);

});

//---------------------------------------------------------------------------

//add new customer

app.MapPost("/api/customers", (HillarysHaircareDbContext database, Customer newCustomer) =>
{

    database.Add(newCustomer);
    database.SaveChanges();

    return Results.Created($"/api/customers{newCustomer.Id}", newCustomer);

});

//---------------------------------------------------------------------------

// get all customers

app.MapGet("/api/customers", (HillarysHaircareDbContext db) =>
{
    return db.Customers
    .Select(c => new CustomerDTO
    {
        Id = c.Id,
        FirstName = c.FirstName,
        LastName = c.LastName,
    }).ToList();
});


//---------------------------------------------------------------------------

//get all appointments and including customer and stylist tables

app.MapGet("/api/appointments", (HillarysHaircareDbContext database) =>
{
    List<Appointment> appointments = database.Appointments
    .Include((appointment) => appointment.Customer)
    .Include((appointment) => appointment.Stylist)
    .Include((appointment) => appointment.AppointmentDetails)
        .ThenInclude((appointmentDetail) => appointmentDetail.Service)
    .ToList();
    return appointments.Select((appointment) => new AppointmentDTO
    {
        Id = appointment.Id,
        AppointmentTime = appointment.AppointmentTime,
        IsCancelled = appointment.IsCancelled,
        CustomerId = appointment.CustomerId,
        Customer = new CustomerDTO
        {
            Id = appointment.Customer.Id,
            FirstName = appointment.Customer.FirstName,
            LastName = appointment.Customer.LastName
        },
        StylistId = appointment.StylistId,
        Stylist = new StylistDTO
        {
            Id = appointment.Stylist.Id,
            FirstName = appointment.Stylist.FirstName,
            LastName = appointment.Stylist.LastName
        },
        AppointmentDetails = appointment.AppointmentDetails.Select((ad) => new AppointmentDetailDTO
        {
            Id = ad.Id,
            AppointmentId = ad.AppointmentId,
            ServiceId = ad.ServiceId,
            Service = new ServiceDTO
            {
                Id = ad.Service.Id,
                ServiceName = ad.Service.ServiceName,
                Price = ad.Service.Price
            }
        }).ToList()
    });
});

// app.MapGet("/api/appointments", (HillarysHaircareDbContext database) =>
// {
//     return database.Appointments
//     .Include((appointment) => appointment.Customer)
//     .Include((appointment) => appointment.Stylist)
//     .Select((appointment) => new AppointmentDTO
//     {
//         Id = appointment.Id,
//         AppointmentTime = appointment.AppointmentTime,
//         IsCancelled = appointment.IsCancelled,
//         CustomerId = appointment.CustomerId,
//         Customer = new CustomerDTO
//         {
//             Id = appointment.Customer.Id,
//             FirstName = appointment.Customer.FirstName,
//             LastName = appointment.Customer.LastName
//         },
//         StylistId = appointment.StylistId,
//         Stylist = new StylistDTO
//         {
//             Id = appointment.Stylist.Id,
//             FirstName = appointment.Stylist.FirstName,
//             LastName = appointment.Stylist.LastName
//         }
//     });
// });


//---------------------------------------------------------------------------

app.MapDelete("/api/appointments/{id}", (HillarysHaircareDbContext database, int id) => 
{
    Appointment? appointmentToDelete = database.Appointments.FirstOrDefault(app => app.Id == id);

    if (appointmentToDelete == null)
    {
        return Results.NotFound();
    }

    appointmentToDelete.IsCancelled = true;
    database.SaveChanges();
    return Results.NoContent();
});

//---------------------------------------------------------------------------\

//get all services

app.MapGet("/api/services", (HillarysHaircareDbContext database) =>
{
    return database.Services.Select((service) => new ServiceDTO
    {
        Id = service.Id,
        ServiceName = service.ServiceName,
        Price = service.Price
    });
});

//---------------------------------------------------------------------------

app.MapPost("/api/appointments", (HillarysHaircareDbContext database, Appointment newAppointment) =>
{
    newAppointment.AppointmentTime = DateTime.Now;
    database.Add(newAppointment);
    database.SaveChanges();
    return Results.Created($"/api/appointments/{newAppointment.Id}", newAppointment);
});

//---------------------------------------------------------------------------

app.MapPost("/api/appointmentdetails", (HillarysHaircareDbContext database, AppointmentDetail newAppointmentDetail) =>
{
    database.Add(newAppointmentDetail);
    database.SaveChanges();
    return Results.Created($"/api/appointmentdetails/{newAppointmentDetail.Id}", newAppointmentDetail);
});


//---------------------------------------------------------------------------

app.MapGet("/api/appointments/{id}", (HillarysHaircareDbContext database,int id) =>
{
    Appointment appointment = database.Appointments
    .Include((appointment) => appointment.AppointmentDetails)
    .Single((appointment) => appointment.Id == id);

    List<AppointmentDetail> appointmentDetails = database.AppointmentDetails
    .Include((appointmentDetail) => appointmentDetail.Service)
    .Where((appointmentDetail) => appointmentDetail.AppointmentId == id).ToList();

    return new AppointmentDTO
    {
        Id = appointment.Id,
        AppointmentTime = appointment.AppointmentTime,
        IsCancelled = appointment.IsCancelled,
        CustomerId = appointment.CustomerId,
        //customer
        StylistId = appointment.StylistId,
        //stylist
        AppointmentDetails = appointmentDetails.Select((appointmentDetail) => new AppointmentDetailDTO
        {
            Id = appointmentDetail.Id,
            AppointmentId = appointmentDetail.AppointmentId,
            ServiceId = appointmentDetail.ServiceId,
            Service = new ServiceDTO
            {
                Id = appointmentDetail.Service.Id,
                ServiceName = appointmentDetail.Service.ServiceName,
                Price = appointmentDetail.Service.Price
            }
        }).ToList()
    };
});




//---------------------------------------------------------------------------
//delete service from appt
app.MapDelete("/api/appointmentdetails/{id}", (HillarysHaircareDbContext database, int id) => 
{
    AppointmentDetail AppToDelete = database.AppointmentDetails
    .Single(ad => ad.Id == id);

    database.Remove(AppToDelete);
    database.SaveChanges();

    return Results.NoContent();
});


//---------------------------------------------------------------------------

app.Run();
