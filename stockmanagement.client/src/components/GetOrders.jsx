import React from 'react'
import { useOrderContext } from '../contexts/orderContext'
import '../styles/GetOrders.scss'
function GetOrders() {
  const {orders, getOrders} = useOrderContext()
  return (
    <div>
      <button onClick={getOrders}>Get Orders</button>
      {orders.map(order => (
        <div key={order.orderId}>
          <h3>{order.orderId}</h3>
          <p>{order.orderDate}</p>
          <p>{order.totalPrice}</p>
        </div>
      ))}
    </div>
  )
}

export default GetOrders