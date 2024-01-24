import {useState, useEffect} from 'react';

import {useStockContext} from '../contexts/stockContext';

import "../styles/stocks.css";

import Card from '../components/cards';


const StockPage = () =>
{
    const id = window.location.pathname.split('/')[2];

    const {getProductsInstock} = useStockContext();

    const [products, setProducts] = useState([]);
    

    useEffect(() => {

        const getProducts = async () => {
            const products = await getProductsInstock(id);
            setProducts(products);
        }

        getProducts();
     
    }, []);

   
    
    

    return (
        <div className="stockPageContainer">
            <h1>Stock Page</h1>
            {products.map(product => (
                <Card
                    className="card"
                    key={product.productId}
                    imgSrc="box.png"
                    title={`Product ID: ${product.productId}, Name: ${product.name} , Quantity: ${product.quantity}`}
                />
            ))}
        </div>
    );




}

export default StockPage;