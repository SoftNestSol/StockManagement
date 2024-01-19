import React from 'react'
import { useProductContext, ProductContextProvider } from '../contexts/productContext';
import Card from './cards';


function GetProduct() {


    const {products, getProducts} = useProductContext();
    console.log(products);

  return (
    <>
    <button onClick={getProducts}>
        <Card
            className="card"
            key={products.productId}
            imgSrc="plus.png"
            title={`Product ID: ${products.productId}, Name: ${products.name}`}
        />
    </button> 
    {products.map(product => (
        <Card
            className="card"
            key={product.productId}
            imgSrc="box.png"
            title={`Product ID: ${product.productId}, Name: ${product.name}`}
        />
    ))}
    </>
  );
}

export default GetProduct