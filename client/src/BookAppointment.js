import { FormGroup, Label, Input, Button, Form } from 'reactstrap'
import { getStylists } from './StylistData'
import { getCustomers } from './CustomerData'
import { useState, useEffect } from 'react'
import { addAppointment } from './AppointmentData'
import { useNavigate } from 'react-router-dom'

//select customer
//stylist
export const BookAppointment = () => {

    const navigate = useNavigate()

const [stylists, setStylists] = useState([])
const [customers, setCustomers] = useState([])
const [appointment, setAppointment] = useState({})

const handleGetCustomers = () => {
    getCustomers().then(setCustomers)
}

const handleChosenCustomer = (event) => {
    setAppointment({...appointment, customerId: event.target.value * 1})
}

const handleGetStylists = () => {
    getStylists().then(setStylists)
}

const handleChosenStylist = (event) => {
    setAppointment({...appointment, stylistId: event.target.value * 1})
}

const handleOnClick = () => {
    // save the appointment to db
    addAppointment(appointment).then((data) => {
        // then navigate to the new created appointment and choose services
        navigate(`/appointments/${data.id}`)
    })
}

useEffect(()=>{
    handleGetCustomers()
    handleGetStylists()
},[])
    return (

        <Form className="w-full max-w-xs mx-auto mt-4">
            <FormGroup>
                <Label for="exampleSelect" className="text-gray-700 font-bold">
                    Select Customer
                </Label>
                <Input onChange={handleChosenCustomer} id="exampleSelect" name="select" type="select" className="mt-1 block w-full">
                    <option>choose a customer</option>
                    {customers.map((customer, index) => (
                        <option value={customer.id}>{customer.firstName} {customer.lastName}</option>
                    ))}
                  
                </Input>
            </FormGroup>

            <FormGroup>
                <Label for="exampleSelect2" className="text-gray-700 font-bold">
                    Select Stylist
                </Label>
                <Input onChange={handleChosenStylist} id="exampleSelect2" name="select" type="select" className="mt-1 block w-full">
                    <option>choose a stylist</option>
                    {stylists.map((stylist, index) => (
                        <option value={stylist.id}>{stylist.firstName} {stylist.lastName}</option>
                    ))}
                  
                </Input>
            </FormGroup>
            <Button onClick={handleOnClick} color="primary" className="mt-4 w-full">
                Submit
            </Button>
        </Form>
    )
}