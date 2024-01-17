import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AddEmp from './pages/AddEmp';
import Login from './pages/Login';
import AngajatController from './pages/AngajatController';
import Dashboard from './pages/DashBoard';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/create-employee" element={<AddEmp />} />
                <Route path="/angajat" element={<AngajatController />} />
                <Route path="/" element={<Login />} />
                <Route path="/dashboard" element={<Dashboard/>} />
            </Routes>
        </Router>
    );
}

export default App;