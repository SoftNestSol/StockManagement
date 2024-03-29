import {useContext, createContext, useEffect, useState} from 'react';
import axios from 'axios';


const StockContext = createContext();

export const useStockContext = () => {
	const stockContext = useContext(StockContext);
	if (!stockContext)
		throw new Error("Something went wrong with the React Context API!");
	return stockContext;
};


export const StockContextProvider = ({ children }) => {
    const [stocks, setStocks] = useState([]);
    const [stockLocations, setStockLocations] = useState([]);

    const getStocks = async () => {
        await axios.get('http://localhost:5122/api/stock',
        {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')    
      }                
    })
            .then((response) => {
                setStocks(response.data);
                setStockLocations(response.data.map((stock) => stock.Location));
            })
            .catch((error) => {
                console.log(error);
            });
    };


    const AddStock = async (stock) => {

        await axios.post('http://localhost:5122/api/stock', stock,
        {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')         
      }          
    })
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });

        await getStocks();
    }


    const getProductsInstock = async (id) => {
        try {
            const response = await axios.get(`http://localhost:5122/api/stock/${id}`,
            {
                headers: {
                  'Content-Type': 'application/json',
                  'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')                    
              }
        });
            return response.data;
        } catch (error) {
            console.error(error);
            return [];
        }
    };
    


    const state = {
        getStocks,
        stocks,
        stockLocations,
        AddStock,
        getProductsInstock
    };

    return (
        <StockContext.Provider value={state}>
            {children}
        </StockContext.Provider>
    );
};
