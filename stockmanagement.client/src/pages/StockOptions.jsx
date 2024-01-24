import { useState, useEffect } from 'react';
import { useStockContext, StockContextProvider } from '../contexts/stockContext';
import "../styles/stocks.css";
import Card from '../components/cards';
import { Link } from 'react-router-dom';

const StockOptions = () => {
    const { stocks, getStocks, AddStock } = useStockContext();
    const [showStocks, setShowStocks] = useState(false);
    const [addStock, setAddStock] = useState(false);

    console.log(stocks);

    const toggleStocks = () => {
        setShowStocks(!showStocks);
    }

    useEffect(() => {
        getStocks();
    }, []);


    const handleSubmit = (e) => {
        e.preventDefault();
        const stock = {
            stockId: e.target.stockId.value,
            location: e.target.location.value,
            numberOfProducts: 0
        };
        AddStock(stock);
        setAddStock(false);
    }

    return (
        <div className="stockOptionsContainer">
            <h1>Stock Options</h1>
            
            {showStocks && stocks.map(stock => (
                <Link to={`/stock/${stock.stockId}`}>
                <Card
                    className="card"
                    key={stock.stockId}
                    imgSrc="box.png"
                    title={`Stock ID: ${stock.stockId}, Location: ${stock.location}`}
                />
                </Link>
            ))}

            {showStocks && (
                <button onClick={toggleStocks}>Collapse Stocks</button>
            )}

            {!showStocks && (
                <button onClick={toggleStocks}>Show Stocks</button>
            )}

          
          {addStock && (
            <form onSubmit={handleSubmit}>
                <label htmlFor="stockId">Stock ID</label>
                <input type="text" name="stockId" id="stockId" />
                <label htmlFor="location">Location</label>
                <input type="text" name="location" id="location" />
                <button>Add Stock</button>
            </form>
            )}
                
                {!addStock && (
                    <button onClick={() => setAddStock(true)}>Add Stock</button>
                )}

                {addStock && (
                    <button onClick={() => setAddStock(false)}>Cancel</button>
                )}

        </div>
    );
}

export default StockOptions;