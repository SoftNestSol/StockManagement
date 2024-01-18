import {useState, useEffect} from 'react';
import { useStockContext, StockContextProvider } from '../contexts/stockContext';
import "../styles/stocks.css";
import Card from '../components/cards';
import { Link } from 'react-router-dom';


const StockOptions = () => {


    const {stocks, getStocks} = useStockContext();
    console.log(stocks);

    useEffect(() => {
        const fetchStocks = async () => {
            await getStocks();
        };
    
        fetchStocks();
    }, []);
    

    return (
        <div className="stockOptionsContainer">
        <h1>Stock Options</h1>
        {stocks.map(stock => (
            <Card  
                className="card"
                key={stock.stockId} 
                imgSrc="box.png"
                title={`Stock ID: ${stock.stockId}, Location: ${stock.location}`} 
            />
        ))}
       
        <Link to = "/addstock" className = "addStockButton">
        Add Stock
        </Link>
    </div>
    );

  


}

export default StockOptions;