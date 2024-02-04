import React, { useState } from 'react';
import { useOrder} from '../contexts/orderContext';
import '../styles/GetOrders.scss';

function GetOrders() {
  const { orders, getOrders } = useOrder();
  const [showOrders, setShowOrders] = useState(false); // Stare pentru controlul afișării comenzilor

  const handleGetOrders = async () => {
    await getOrders(); // Preia comenzile
    setShowOrders(true); // Permite afișarea comenzilor după preluare
  };

  return (
    <div className="get-orders-container">
      <button onClick={handleGetOrders}>Get Orders</button>
      {showOrders && orders.length > 0 ? (
        <div className="orders-list">
          {orders.map(order => (
            <div key={order.orderId} className="order-item">
              <h3>Order ID: {order.orderId}</h3>
              <p>Employee ID: {order.employeeId}</p>
              <p>Supplier ID: {order.supplierId}</p>
              <p>Status: {order.status}</p>
              <p>Date: {order.date}</p>
              <p>Number of Products: {order.numberOfProducts}</p>
            </div>
          ))}
        </div>
      ) : showOrders && (
        <p>No orders to display.</p>
      )}
    </div>
  );
}

export default GetOrders;
