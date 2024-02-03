import {useState,useEffect} from 'react'; 
import {useOrderContext} from '../contexts/orderContext';
import '../styles/OrderOptions.scss';

function GetOrders() {
  const { orders, getOrders, deleteOrder } = useOrderContext();
  const [showOrders, setShowOrders] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');
  const [filteredOrders, setFilteredOrders] = useState([]);

  useEffect(() => {
    if (showOrders && orders.length === 0) {
      getOrders();
    }
  }, [showOrders]); 

  useEffect(() => {
    const filtered = orders.filter(order => 
      order.customerName.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredOrders(filtered);
  }, [searchTerm, orders]);

  const handleDelete = (orderId) => {
    deleteOrder(orderId);
    setFilteredOrders(prevOrders => prevOrders.filter(o => o.orderId !== orderId));
  };

  return (
    <>
      <button onClick={() => setShowOrders(!showOrders)} className="toggle-button">
        {showOrders ? 'Hide Orders' : 'Show Orders'}
      </button>
      {showOrders && (
        <>
          <input
            type="text"
            placeholder="Search by customer name..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <div className="orders">
            {filteredOrders.map(order => (
              <div key={order.orderId} className="order">
                <p>{order.customerName}</p>
                <p>{order.orderDate}</p>
                <p>{order.totalPrice}</p>
                <button onClick={() => handleDelete(order.orderId)}>Delete</button>
              </div>
            ))}
          </div>
        </>
      )}
    </>
  );
}