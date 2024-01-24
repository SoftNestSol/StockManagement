import React, { useState, useEffect } from 'react';
import { useProductContext } from '../contexts/productContext';
import '../styles/GetProduct.scss';

function GetProduct() {
  const { products, getProducts, addProductToStock, deleteProduct } = useProductContext();
  const [showProducts, setShowProducts] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');
  const [filteredProducts, setFilteredProducts] = useState([]);
  const [showAddToStock, setShowAddToStock] = useState(false);
  const [stockId, setStockId] = useState('');
  const [quantity, setQuantity] = useState('');
  const [selectedProductId, setSelectedProductId] = useState(null);

  useEffect(() => {
    if (showProducts && products.length === 0) {
      getProducts();
    }
  }, [showProducts]); 

  useEffect(() => {
    const filtered = products.filter(product => 
      product.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredProducts(filtered);
  }, [searchTerm, products]);

  const handleDelete = (productId) => {
    deleteProduct(productId);
    setFilteredProducts(prevProducts => prevProducts.filter(p => p.productId !== productId));
  };

  const handleAddToStockClick = (productId) => {
    setShowAddToStock(true);
    setSelectedProductId(productId);
  };

  const handleAddToStock = () => {
    addProductToStock({
      stockId: stockId,
      ProductId: selectedProductId,
      quantity: quantity,
      UnitsSold: 0
    });
    setShowAddToStock(false);
    setStockId('');
    setQuantity('');
  };

  return (
    <>
      <button onClick={() => setShowProducts(!showProducts)} className="toggle-button">
        {showProducts ? 'Hide Products' : 'Show Products'}
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
                <button onClick={() => handleDelete(product.productId)}>Delete</button>
                <button onClick={() => handleAddToStockClick(product.productId)}>Add to Stock</button>
              </div>
            ))}
          </div>
          {showAddToStock && (
            <div>
              <input 
                type="number" 
                placeholder="Stock ID" 
                value={stockId} 
                onChange={(e) => setStockId(e.target.value)} 
              />
              <input 
                type="number" 
                placeholder="Quantity" 
                value={quantity} 
                onChange={(e) => setQuantity(e.target.value)} 
              />
              <button onClick={handleAddToStock}>Confirm Add to Stock</button>
            </div>
          )}
        </>
      )}
    </>
  );
}

export default GetProduct;
