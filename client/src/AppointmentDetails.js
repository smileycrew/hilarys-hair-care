import { useParams } from "react-router-dom"
import { useState } from "react"
import { useEffect } from "react"
import { getServices } from "./ServicesData"
import { Form, FormGroup, Input, Label, Button } from 'reactstrap'
import { getAppointment } from "./AppointmentData"
import { addAppointmentDetail } from "./AppointmentDetailData"

export const AppointmentDetails = () => {

    const { appointmentId } = useParams()
    

    const [appointment, setAppointment] = useState({})
    const [services, setServices] = useState([])
    const [appointmentDetail, setAppointmentDetail] = useState({
        appointmentId: appointmentId*1
    })

    const handleGetServices = () => {
        getServices().then(setServices)
    }

    const handleGetAppointment = () => {
        getAppointment(appointmentId*1).then(setAppointment)
    }

    const handleAddAppointmentDetail = (service) => {
        addAppointmentDetail({...appointmentDetail, serviceId: service.id}).then(()=>handleGetAppointment())
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
                                <Input onChange={() => handleAddAppointmentDetail(service)} type="radio" id={service.id} className="form-radio h-5 w-5" />
                                <Label for={`${service.id}`} check className="ml-2">
                                    {service.serviceName}
                                </Label>
                            </div>
                        ))}
                    </FormGroup>
            </FormGroup>
            <Button color="primary" className="mt-4 w-full">
                Submit
            </Button>
        </Form>
    )
}