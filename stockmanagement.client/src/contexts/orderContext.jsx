import React, { createContext, useContext, useState, useCallback } from 'react';
import axios from 'axios';

const OrderContext = createContext();

export function useOrder() {
  return useContext(OrderContext);
}

export const OrderProvider = ({ children }) => {
  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const getOrders = useCallback(async () => {
    setLoading(true);
    try {
      const response = await axios.get(`http://localhost:5122/api/order`,
      {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')                    
      }
      });

      setOrders(response.data);
      setLoading(false);
    } catch (err) {
      setError(err);
      setLoading(false);
    }
  }, []);

  const addOrder = useCallback(async (orderData) => {
    try {
      const response = await axios.post(`http://localhost:5122/api/order/add`, orderData,{
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')  
      }                  
    });
  

  
  
      setOrders(prevOrders => [...prevOrders, response.data]);
    } catch (err) {
      setError(err);
    }
  }, []);


  const deleteOrder = useCallback(async (orderId) => {
    try {
      await axios.delete(`http://localhost:5122/api/order/${orderId}`,{
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')      
      }              
    });
      
      setOrders(prevOrders => prevOrders.filter(order => order.id !== orderId));
    } catch (err) {
      setError(err);
    }
  }, []);

  const value = {
    orders,
    loading,
    error,
    getOrders,
    addOrder,
    deleteOrder,
  };

  return (
    <OrderContext.Provider value={value}>
      {children}
    </OrderContext.Provider>
  );
};

