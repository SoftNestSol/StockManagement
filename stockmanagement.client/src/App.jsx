import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AddEmp from './pages/AddEmployee';
import Login from './pages/Login';
import AngajatController from './pages/EmpOptions';
import Dashboard from './pages/DashBoard';
import StockOptions from './pages/StockOptions';
import ProductOptions from './pages/ProductOptions';
import OrderOptions from './pages/OrderOptions';
import { StockContextProvider } from './contexts/stockContext';
import { ProductContextProvider } from './contexts/productContext';
import { OrderProvider } from './contexts/orderContext';
import StockPage from './pages/stock-id.jsx';

function App() {


    const options = [
        { id: 2, name: 'Vezi Produse', componentKey: 'GetProducts' },
        { id: 3, name: 'Adauga Produs', componentKey: 'AddProduct' },
        { id: 4, name: 'Vezi Produs', componentKey: 'GetProductId' },
        { id: 5, name: 'Adauga Angajat', componentKey: 'AddEmp' },
        { id: 6, name: 'Vezi Angajati', componentKey: 'GetEmp'}
      ];
      

    return (
        <OrderProvider>
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
                <Route path="/stock" element={<StockOptions></StockOptions>}/>
                <Route path="/stock/:id" element={<StockPage/>}/>
                <Route path="/comanda" element={<OrderOptions/>}/>
        
            </Routes>
        </Router>
        </ProductContextProvider>
        </StockContextProvider>
        </OrderProvider>
    );
}

export default App;