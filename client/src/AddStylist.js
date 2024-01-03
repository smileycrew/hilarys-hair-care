import { Form, FormGroup, Label, Input, Button } from 'reactstrap'
import { newStylist } from './StylistData'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

export const AddStylist = () => {

    const [stylist, setStylist] = useState({})

    const navigate = useNavigate()

    const handleAddButton = () => {

        newStylist(stylist).then(() => navigate("/stylists"))
        
    }

    const handleFirstName = (event) => {
        setStylist({...stylist, firstName: event.target.value})
    }

    const handleLastName = (event) => {
        setStylist({...stylist, lastName: event.target.value})
    }


    return (
        <Form className="max-w-md mx-auto p-6 bg-white rounded shadow-lg">
            <FormGroup>
                <Label for="exampleEmail">Enter First Name</Label>
                <Input
                    id="exampleEmail"
                    type="text"
                    placeholder="First Name"
                    className="w-full px-3 py-2 border rounded-md text-gray-700 focus:outline-none focus:border-blue-500"
                    onChange={handleFirstName}
                />
            </FormGroup>
            <FormGroup>
                <Label for="examplePassword">Enter Last Name</Label>
                <Input
                    id="examplePassword"
                    type="text"
                    placeholder="Last Name"
                    className="w-full px-3 py-2 border rounded-md text-gray-700 focus:outline-none focus:border-blue-500"
                    onChange={handleLastName}
                />
            </FormGroup>
            <div className="flex justify-center">
                <Button color="primary" className="px-4 py-2 font-semibold rounded-md shadow-md hover:bg-blue-600 focus:outline-none focus:bg-blue-600"
                onClick={handleAddButton}>
                    Submit
                </Button>
            </div>
        </Form>
    )
}