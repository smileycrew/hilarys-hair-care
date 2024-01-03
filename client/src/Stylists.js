import { List, Label, Input, Button } from 'reactstrap';
import { getStylists, changeStylistStatus, stylistStatus } from './StylistData';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';


//make server endpoint to get all stylists
//make client endpoint for all stylists
//render stylists
//make server endpoint to toggle active status



export const Stylists = () => {

  const navigate = useNavigate()

  const [stylists, setStylists] = useState([])

  const handleGetStylists = () => {getStylists().then(setStylists)}

  useEffect(() => {
    handleGetStylists()
  }, []);

  const handleCheckBox = (id) => {
    changeStylistStatus(id).then(() => handleGetStylists())
  }

  const handleClick = () => {
    navigate("add")
  }

  console.log(stylists)
  // use effect

  return (
    <div className="container mx-auto p-4">
      <div className="flex justify-between mb-4">
        <h2 className="text-3xl font-bold text-gray-800">Stylists</h2>
        <Button color="primary"
        onClick={handleClick}
        >Add New Stylist</Button>
      </div>
      <List>
        {stylists.map((stylist, index) => (
          <li key={index} className="flex justify-between items-center border-b border-gray-200 py-2">
            <span className="text-gray-800 text-2xl">{stylist.firstName} {stylist.lastName}</span>
            <div className="flex items-center">
              <Label check className="mr-4 text-sm text-gray-600">
                <Input
                  //only checked === true when the stylist is active
                  checked={stylist.isActive}
                  type="checkbox"
                  onChange={() => handleCheckBox(stylist.id)}
                />
                <span className="ml-2 text-xl">{stylist.isActive ? "Active" : "Not Active"}</span>
              </Label>
            </div>
          </li>
        ))}
      </List>
    </div>
  );
}