export const getAppointments = () => {
    return fetch("/api/appointments").then((response) => response.json())
}

export const getAppointment = (id) => {
    console.log(id)
    return fetch(`/api/appointments/${id}`).then((response) => response.json())
}

export const addAppointment = (appointmentObj) => {
    return fetch("/api/appointments", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(appointmentObj)
    }).then((response) => response.json())
}

export const deleteAppointment = (id) => {
    return fetch(`/api/appointments/${id}`, {
        method: "DELETE"
    }
    )
}