import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AddEmp from './AddEmp';
import Login from './Login';
import AngajatController from './AngajatController';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<AddEmp />} />
                <Route path="/angajat" element={<AngajatController />} />
                <Route path="/login" element={<Login />} />
            </Routes>
        </Router>
    );
}

export default App;