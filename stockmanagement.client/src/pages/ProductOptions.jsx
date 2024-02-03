import React from 'react'
import GetProduct from '../components/GetProduct'
import AddProduct from '../components/AddProduct';
import GetProductId from '../components/GetProductId';
import { Link } from 'react-router-dom';


function ProductOptions() {
  return (
    <>
    <h1>Product Page</h1>
    <div className="stockOptionsContainer">
    <GetProduct />  
    <AddProduct />
    <GetProductId />
    </div>
    </>
  )
}

export default ProductOptions