import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AddEmp from './pages/AddEmployee';
import Login from './pages/Login';
import AngajatController from './pages/EmpOptions';
import Dashboard from './pages/DashBoard';
import StockOptions from './pages/StockOptions';
import ProductOptions from './pages/ProductOptions';
import { StockContextProvider } from './contexts/stockContext';
import { ProductContextProvider } from './contexts/productContext';

function App() {


    const options = [
        { id: 2, name: 'Vezi Produse', componentKey: 'GetProducts' },
        { id: 3, name: 'Adauga Produs', componentKey: 'AddProduct' },
        { id: 4, name: 'Vezi Produs', componentKey: 'GetProductId' },
        // alte opțiuni
      ];
      

    return (
        <StockContextProvider>
        <ProductContextProvider>
        <Router>
            <Routes>
                <Route path="/create-employee" element={<AddEmp />} />
                <Route path="/angajat" element={<AngajatController />} />
                <Route path="/" element={<Login />} />
                <Route path="/dashboard" element={<Dashboard options={options} />} />
                <Route path="*" element={<h1>Not Found</h1>} />
                <Route path="/produs" element={<ProductOptions/>} />
                <Route path="/stoc" element={<StockOptions/>} />
            </Routes>
        </Router>
        </ProductContextProvider>
        </StockContextProvider>
    );
}

export default App;