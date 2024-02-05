import React, { useState } from 'react';
import { useOrder } from '../contexts/orderContext';

const AddOrder = () => {
  const { addOrder } = useOrder();
  const [products, setProducts] = useState([{ productId: '', quantity: '', unitsSold: 0 }]);
  const [EmployeeId, setEmployeeId] = useState('');
  const [SupplierId, setSupplierId] = useState('');

  const handleProductChange = (index, event) => {
    const newProducts = [...products];
    newProducts[index][event.target.name] = event.target.value;
    setProducts(newProducts);
  };

  const handleAddProduct = () => {
    setProducts([...products, { productId: '', quantity: '', unitsSold: 0 }]);
  };

  const handleRemoveProduct = (index) => {
    const newProducts = [...products];
    newProducts.splice(index, 1);
    setProducts(newProducts);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const OrderId = Math.floor(Math.random() * 1000); // Generarea unui ID pentru comandă
    const Status = 'pending';
    const NumberOfProducts = products.length;
    const date = new Date().toISOString(); 

    // Crearea obiectului comandă
    const newOrder = {
      OrderId,
      EmployeeId,
      SupplierId,
      Status,
      date,
      NumberOfProducts,
      ProductInOrder: products.map(product => ({ ...product, OrderId })), // Adăugarea orderId pentru fiecare produs
    };

    try {
      await addOrder(newOrder);
      // Logica de post-trimitere (de exemplu, resetarea formularului)
    } catch (error) {
      console.error('Eroare la adăugarea comenzii', error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      {products.map((product, index) => (
        <div key={index}>
          <input
            name="productId"
            value={product.productId}
            onChange={(e) => handleProductChange(index, e)}
            placeholder="Product ID"
          />
          <input
            name="quantity"
            value={product.quantity}
            onChange={(e) => handleProductChange(index, e)}
            placeholder="Quantity"
          />
          {products.length > 1 && (
            <button type="button" onClick={() => handleRemoveProduct(index)}>
              Remove
            </button>
          )}
        </div>
      ))}
      <button type="button" onClick={handleAddProduct}>
        Add Another Product
      </button>
      <input
        value={EmployeeId}
        onChange={(e) => setEmployeeId(e.target.value)}
        placeholder="Employee ID"
      />
      <input
        value={SupplierId}
        onChange={(e) => setSupplierId(e.target.value)}
        placeholder="Supplier ID"
      />
      <button type="submit">Submit Order</button>
    </form>
  );
};

export default AddOrder;
