import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AddEmp from './pages/AddEmployee';
import Login from './pages/Login';
import AngajatController from './pages/EmpOptions';
import Dashboard from './pages/DashBoard';
import StockOptions from './pages/StockOptions';
import { StockContextProvider } from './contexts/stockContext';

function App() {
    return (
        <StockContextProvider>
        <Router>
            <Routes>
                <Route path="/create-employee" element={<AddEmp />} />
                <Route path="/angajat" element={<AngajatController />} />
                <Route path="/" element={<Login />} />
                <Route path="/dashboard" element={<Dashboard/>} />
                <Route path="*" element={<h1>Not Found</h1>} />
                <Route path="/stoc" element={<StockOptions/>} />
            </Routes>
        </Router>
        </StockContextProvider>
    );
}

export default App;