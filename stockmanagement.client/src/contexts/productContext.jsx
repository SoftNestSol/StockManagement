import {useContext, createContext,  useState} from 'react';
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
    const [product, setProduct] = useState({});
    const getProducts = async () => {
        await axios.get('http://localhost:5122/api/product',
        {
            headers: {
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')  
            }                  
          })
            .then((response) => {
                setProducts(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };

   

    const addProduct = async (product) => {
        await axios.post('http://localhost:5122/api/product/add', product,
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
    };
    const deleteProduct = async (productId) => {
        await axios.delete(`http://localhost:5122/api/product/${productId}`,
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
    };

    const addProductToStock = async (productInStock) => {
        await axios.post('http://localhost:5122/api/product/addToStock', productInStock, {
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
    };
    const getProductById = async (productId) => {
        await axios.get(`http://localhost:5122/api/product/${productId}`,{
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')                    
     }})
            .then((response) => {
                setProduct(response.data);
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    };
    const state = {
        getProducts,
        addProduct,
        addProductToStock,
        getProductById,
        deleteProduct,
        product,
        products
    };
    return (
        <ProductContext.Provider value={state}>
            {children}
        </ProductContext.Provider>
    );
};


