// customer, stylist, time, cancel button
import { Button, Table } from 'reactstrap'
import { getAppointments, deleteAppointment } from './AppointmentData'
import { useState, useEffect } from 'react'



export const AppointmentsList = () => {

    const [appointments, setAppointments] = useState([])

    const handleGetAppointments = () => { getAppointments().then(setAppointments) }

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        return date.toLocaleString(); // Adjust this formatting to suit your preferences
    };

    const handleDeleteAppointment = (id) => {
        deleteAppointment(id).then(() => {
            handleGetAppointments()
        })
    }

    useEffect(() => {
        handleGetAppointments()
    }, [])

    return (

        <Table hover className="min-w-full divide-y divide-gray-200">
            <thead className="bg-gray-50">
                <tr>
                    <th className="px-6 py-3 text-left text-2xl font-medium text-gray-500 uppercase tracking-wider">#</th>
                    <th className="px-6 py-3 text-left text-2xl font-medium text-gray-500 uppercase tracking-wider">Customer</th>
                    <th className="px-6 py-3 text-left text-2xl font-medium text-gray-500 uppercase tracking-wider">Stylist</th>
                    <th className="px-6 py-3 text-left text-2xl font-medium text-gray-500 uppercase tracking-wider">Appointment Time</th>
                    <th className="px-6 py-3 text-left text-2xl font-medium text-gray-500 uppercase tracking-wider">Status</th>
                </tr>
            </thead>
            <tbody className="bg-white divide-y divide-gray-200">
                {appointments.map((appointment, index) => (
                    <tr key={index} className="hover:bg-gray-50">
                        <th className="px-6 py-4 whitespace-nowrap">{index + 1}</th>
                        <td className="px-6 py-4 whitespace-nowrap">{`${appointment.customer.firstName} ${appointment.customer.lastName}`}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{`${appointment.stylist.firstName} ${appointment.stylist.lastName}`}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{formatDate(appointment.appointmentTime)}</td>
                        <td className="px-6 py-4 whitespace-nowrap">
                            {appointment.isCancelled ? "Cancelled" : <Button onClick={()=>handleDeleteAppointment(appointment.id)} color="danger">Cancel</Button>}
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
    )
}

