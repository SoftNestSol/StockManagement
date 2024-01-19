
import React, { useState } from 'react';
import { useProductContext } from '../contexts/productContext';
import Card from './cards';
import '../styles/AddProduct.scss';

function AddProduct() {
  const { addProduct } = useProductContext();
  const [productName, setProductName] = useState('');
  const [productPrice, setProductPrice] = useState('');
  const [productDescription, setProductDescription] = useState('');
  const [showForm, setShowForm] = useState(false);

  const handleAddProduct = () => {
    const productId = Math.floor(Math.random() * 100000000);
    addProduct({ProductId:productId,  Name: productName, Price: productPrice, Description: productDescription });
    console.log({ProductId:productId,  name: productName, price: productPrice, description: productDescription });
    setProductName('')
    setProductPrice('');
    setProductDescription('');
  };

  return (
    <div className="add-product">
    <button onClick={() => setShowForm(prevShowForm => !prevShowForm)} className="toggle-button">
      <Card
        imgSrc="plus.png"
        title="Add Product"
      />
    </button>
    {showForm && (
      <div className="form">
          <input
            type="text"
            placeholder="Product Name"
            value={productName}
            onChange={(e) => setProductName(e.target.value)}
          />
          <input
            type="text"
            placeholder="Product Price"
            value={productPrice}
            onChange={(e) => setProductPrice(e.target.value)}
          />
          <input
            type="text"
            placeholder="Product Description"
            value={productDescription}
            onChange={(e) => setProductDescription(e.target.value)}
          />
          <button onClick={handleAddProduct}>Add Product</button>
        </div>
      )}
    </div>
  );
}

export default AddProduct;
