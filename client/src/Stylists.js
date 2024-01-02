import { List, Label, Input, Button } from 'reactstrap';

//make server endpoint to get all stylists
//make client endpoint for all stylists
//render stylists
//make server endpoint to toggle active status



export const Stylists = () => {

    // use state

    // handler

    // use effect

    return (
        <div className="container mx-auto p-4">
          <div className="flex justify-between mb-4">
            <h2 className="text-3xl font-bold text-gray-800">Stylists</h2>
            <Button color="primary">Add New Stylist</Button>
          </div>
          <List>
            <li className="flex justify-between items-center border-b border-gray-200 py-2">
              <span className="text-gray-800 text-2xl">Lorem ipsum</span>
              <div className="flex items-center">
              <Label check className="mr-4 text-sm text-gray-600">
              <Input type="checkbox" />
              <span className="ml-2 text-xl">Active</span> 
            </Label>
              </div>
            </li>
            
          </List>
        </div>
      );
}