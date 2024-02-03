import { useContext,createContext,useState} from "react";
import axios from "axios";

const OrderContext = createContext();

export function useOrder() {
    return useContext(OrderContext);
}

export function OrderProvider({children}) {

    const [orders, setOrders] = useState([]);
    const [order, setOrder] = useState({});

    const getOrders = async () => {
        await axios.get('http://localhost:5122/api/order')
            .then((response) => {
                setOrders(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const addOrder = async (order) => {
        await axios.post('http://localhost:5122/api/order/add', order)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const deleteOrder = async (orderId) => {
        await axios.delete(`http://localhost:5122/api/order/${orderId}`)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const getOrderById = async (orderId) => {
        await axios.get(`http://localhost:5122/api/order/${orderId}`)
            .then((response) => {
                setOrder(response.data);
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const value = {
        orders,
        order,
        getOrders,
        addOrder,
        deleteOrder,
        getOrderById
    };

    return (
        <OrderContext.Provider value={value}>
            {children}
        </OrderContext.Provider>
    );
}