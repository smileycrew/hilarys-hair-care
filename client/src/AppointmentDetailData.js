export const addAppointmentDetail = (appointmentDetailObj) => {
    return fetch("/api/appointmentdetails", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(appointmentDetailObj)
    })
}

export const deleteAppointmentDetail = (id) => {
    console.log(id)
    return fetch(`/api/appointmentdetails/${id}`, {
        method: "DELETE"
    })
}