import React, { useState, useEffect } from 'react';
import { useProductContext } from '../contexts/productContext';
import '../styles/GetProduct.scss';
import Card from './cards';

function GetProduct() {
  const { products, getProducts ,addProductToStock} = useProductContext();
  const [showProducts, setShowProducts] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');
  const [filteredProducts, setFilteredProducts] = useState([]);

  useEffect(() => {
    if (showProducts) {
      getProducts();
    }
  }, [showProducts, getProducts]);

  useEffect(() => {
    const filtered = products.filter(product => 
      product.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredProducts(filtered);
  }, [searchTerm, products]);

  const handleButtonClick = () => {
    setShowProducts(!showProducts);
  };

  return (
    <>
      <button onClick={handleButtonClick} className="toggle-button">
        {showProducts ? 'Hide Products' : 'Show Products'}
        <Card
            imgSrc="list.png"
            title="Products"
            />
      </button>
      {showProducts && (
        <>
          <input
            type="text"
            placeholder="Search by name..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="search-input"
          />
          <div className="product-list">
            {filteredProducts.map((product) => (
              <div className="product-item" key={product.productId}>
                <h3>{product.name}</h3>
                <p>ID: {product.productId}</p>
                <p>Description: {product.description}</p>
                <p>Price: ${product.price}</p>
              </div>
            ))}
          </div>
        </>
      )}
    </>
  );
}

export default GetProduct;
