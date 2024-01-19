import React, { useState } from 'react';
import { useProductContext } from '../contexts/productContext';
import '../styles/GetProduct.scss';
import Card from './cards';
function GetProduct() {
  const { products, getProducts } = useProductContext();
  const [showProducts, setShowProducts] = useState(false);

  const handleButtonClick = () => {
    if (!showProducts) {
      getProducts();
    }
    setShowProducts(!showProducts);
  };

  return (
    <>
      <button onClick={handleButtonClick} className="toggle-button">
        {showProducts ? 'Hide Products' : 'Show Products'}
        <Card
          className="card"
          imgSrc="list.png"
          
        />
      </button>
      {showProducts && (
        <div className="product-list">
          {products.map((product) => (
            <div className="product-item" key={product.productId}>
              <h3>{product.name}</h3>
              <p>ID: {product.productId}</p>
              <p>Description: {product.description}</p>
              <p>Price: ${product.price}</p>
            </div>
          ))}
        </div>
      )}
    </>
  );
}

export default GetProduct;
