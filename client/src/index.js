import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Stylists } from './Stylists';
import { AddStylist } from './AddStylist';
import { AddCustomer } from './AddCustomer';
import { AppointmentsList } from './AppointmentsList';
import { BookAppointment } from './BookAppointment';
import { AppointmentDetails } from './AppointmentDetails';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="stylists" element={<Stylists />}>
          <Route index element={<Stylists />} />
          <Route path="add" element={<AddStylist />} />
        </Route>
        <Route path="addcustomer" element={<AddCustomer />} />
        <Route path="appointments">
          <Route index element={<AppointmentsList />} />
          <Route path=":appointmentId" element={<AppointmentDetails />} />
        </Route>
        <Route path="bookappointment" element={<BookAppointment />}></Route>
      </Route>

    </Routes>
  </BrowserRouter>

);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
