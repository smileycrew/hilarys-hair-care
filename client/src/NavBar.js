import { Navbar, NavbarBrand, Nav, NavItem, NavLink, card, pills, tabs } from "reactstrap";
import "bootstrap/dist/css/bootstrap.css";

export const NavBar = () => {
    return (
        <>
 <Navbar color="dark" expand="md" className="flex justify-between items-center w-full px-6 py-4 font-mono">
  <Nav navbar className="flex">
    <NavbarBrand href="/" className="text-white">✂️ Hillary's Hair Care 💈</NavbarBrand>
    <NavItem>
      <NavLink href="/customers" className="text-white">Add Customer</NavLink>
    </NavItem>
    <NavItem>
      <NavLink className="text-white">|</NavLink>
    </NavItem>
    <NavItem>
      <NavLink href="/stylists" className="text-white">Stylists</NavLink>
    </NavItem>
    <NavItem>
      <NavLink className="text-white">|</NavLink>
    </NavItem>
    <NavItem>
      <NavLink href="/appointments" className="text-white">Book Appointments</NavLink>
    </NavItem>
  </Nav>
  <Nav navbar>
    <NavItem className="ml-auto">
      <NavLink href="/browse" className="text-white">Home</NavLink>
    </NavItem>
  </Nav>
</Navbar>
</>
    )
}