import React, { useState } from 'react';
import { useOrder } from '../contexts/orderContext';
import '../styles/GetOrders.scss';

function GetOrders() {
  const { orders, getOrders, deleteOrder, updateOrder } = useOrder();
  const [showOrders, setShowOrders] = useState(false);
  const [isEditing, setIsEditing] = useState(null);
  const [editFormData, setEditFormData] = useState({
    orderId: '',
    employeeId: '',
    supplierId: '',
    status: '',
    date: '',
    numberOfProducts: '',
  });

  const handleGetOrders = async () => {
    await getOrders();
    setShowOrders(true);
  };

  const handleDelete = async (orderId) => {
    await deleteOrder(orderId);
    await getOrders(); // Refresh the orders list after deletion
  };

  const handleEditClick = (order) => {
    setIsEditing(order.orderId);
    setEditFormData({ ...order });
  };

  const handleUpdate = async () => {
    await updateOrder(editFormData);
    setIsEditing(null);
    await getOrders(); // Refresh the orders list after update
  };

  const handleEditFormChange = (event) => {
    const { name, value } = event.target;
    setEditFormData({
      ...editFormData,
      [name]: value,
    });
  };

  return (
    <div className="get-orders-container">
      <button onClick={handleGetOrders}>Get Orders</button>
      {showOrders && (
        <div className="orders-list">
          {orders.length > 0 ? orders.map(order => (
            <div key={order.orderId} className="order-item">
              {isEditing === order.orderId ? (
                <div>
                  <input
                    type="number"
                    name="orderId"
                    value={editFormData.orderId}
                    readOnly
                  />
                  <input
                    type="number"
                    name="employeeId"
                    value={editFormData.employeeId}
                    onChange={handleEditFormChange}
                  />
                  <input
                    type="number"
                    name="supplierId"
                    value={editFormData.supplierId}
                    onChange={handleEditFormChange}
                  />
                  <input
                    type="text"
                    name="status"
                    value={editFormData.status}
                    onChange={handleEditFormChange}
                  />
                  <input
                    type="text"
                    name="date"
                    value={editFormData.date}
                    onChange={handleEditFormChange}
                  />
                  <input
                    type="number"
                    name="numberOfProducts"
                    value={editFormData.numberOfProducts}
                    onChange={handleEditFormChange}
                  />
                  <button onClick={handleUpdate}>Save</button>
                </div>
              ) : (
                <div>
                  <h3>Order ID: {order.orderId}</h3>
                  <p>Employee ID: {order.employeeId}</p>
                  <p>Supplier ID: {order.supplierId}</p>
                  <p>Status: {order.status}</p>
                  <p>Date: {order.date}</p>
                  <p>Number of Products: {order.numberOfProducts}</p>
                  <button onClick={() => handleEditClick(order)}>Edit</button>
                  <button onClick={() => handleDelete(order.orderId)}>Delete</button>
                </div>
              )}
            </div>
          )) : <p>No orders to display.</p>}
        </div>
      )}
    </div>
  );
}

export default GetOrders;
