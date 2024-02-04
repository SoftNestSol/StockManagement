import React from 'react';
import AddOrder from '../components/AddOrder';
import GetOrders from '../components/GetOrders';
function OrderOptions() {
  return (
    <div className="order-options">
      <h2>Orders</h2>
        <GetOrders />
        <AddOrder />
    </div>
  );
}

export default OrderOptions;