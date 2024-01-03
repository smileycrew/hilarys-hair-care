export const addAppointmentDetail = (appointmentDetailObj) => {
    return fetch("/api/appointmentdetails", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(appointmentDetailObj)
    })
}