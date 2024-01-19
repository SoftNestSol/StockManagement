import React, { useState } from 'react';
import { useProductContext } from '../contexts/productContext';
import '../styles/GetProductId.scss';

function GetProductId() {
  const { product, getProductById } = useProductContext();
  const [productId, setProductId] = useState('');

  const handleSearch = () => {
    getProductById(productId);
  };

  return (
    <div className="get-product-id">
      <div className="search-bar">
        <input
          type="text"
          placeholder="Enter Product ID"
          value={productId}
          onChange={(e) => setProductId(e.target.value)}
        />
        <button onClick={handleSearch} className="search-button">Search</button>
      </div>
      {product && (
        <div className="product-details">
          <h3>{product.name}</h3>
          <p>ID: {product.productId}</p>
          <p>Description: {product.description}</p>
          <p>Price: ${product.price}</p>
        </div>
      )}
    </div>
  );
}

export default GetProductId;
