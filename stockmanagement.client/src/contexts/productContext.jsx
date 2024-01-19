import {useContext, createContext, useEffect, useState} from 'react';
import axios from 'axios';

const ProductContext = createContext();

export const useProductContext = () => {
    const productContext = useContext(ProductContext);
    if (!productContext)
        throw new Error("Something went wrong with the React Context API!");
    return productContext;
}

export const ProductContextProvider = ({children}) => {
    const [products, setProducts] = useState([]);
    const getProducts = async () => {
        await axios.get('http://localhost:5122/api/product')
            .then((response) => {
                setProducts(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };

   

    const addProduct = async (product) => {
        await axios.post('http://localhost:5122/api/product', product)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    };

    const state = {
        getProducts,
        products
    };
    return (
        <ProductContext.Provider value={state}>
            {children}
        </ProductContext.Provider>
    );
};


