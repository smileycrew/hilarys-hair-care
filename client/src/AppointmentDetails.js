import { useParams } from "react-router-dom"
import { useState } from "react"
import { useEffect } from "react"
import { getServices } from "./ServicesData"
import { Form, FormGroup, Input, Label, Button } from 'reactstrap'
import { getAppointment } from "./AppointmentData"
import { addAppointmentDetail, deleteAppointmentDetail } from "./AppointmentDetailData"
import { useNavigate } from "react-router-dom"

export const AppointmentDetails = () => {

    const { appointmentId } = useParams()

    const navigate = useNavigate()

    const [appointment, setAppointment] = useState({})
    const [services, setServices] = useState([])
    const [appointmentDetail, setAppointmentDetail] = useState({
        appointmentId: appointmentId * 1
    })

    const handleGetServices = () => {
        getServices().then(setServices)
    }

    const handleGetAppointment = () => {
        getAppointment(appointmentId * 1).then(setAppointment)
    }

    const handleAddAppointmentDetail = (event, service) => {
        if (!event.target.checked) {
            const appointmentDetailId = appointment.appointmentDetails.find((appointmentDetail) => appointmentDetail.serviceId === service.id).id
            deleteAppointmentDetail(appointmentDetailId).then(() => handleGetAppointment())
        } else {
            addAppointmentDetail({ ...appointmentDetail, serviceId: service.id }).then(() => handleGetAppointment())
        }
    }

    const handleSubmit = (event) => {
        console.log("here")
        event.preventDefault()
        navigate("/appointments")
    }

    useEffect(() => {
        handleGetServices()
        handleGetAppointment()
    }, [])

    return (
        <Form className="w-full max-w-xs mx-auto mt-4">
            <FormGroup row tag="fieldset">
                <FormGroup check>
                    {services.map((service, index) => (
                        <div key={index}>
                            <Input checked={appointment.appointmentDetails?.some((appointmentDetail) => appointmentDetail.serviceId === service.id)} onChange={(event) => handleAddAppointmentDetail(event, service)} type="checkbox" id={service.id} className="form-radio h-5 w-5" />
                            <Label for={`${service.id}`} check className="ml-2">
                                {service.serviceName}
                            </Label>
                        </div>
                    ))}
                </FormGroup>
            </FormGroup>
            <Button onClick={handleSubmit} color="primary" className="mt-4 w-full">
                Submit
            </Button>
        </Form>
    )
}