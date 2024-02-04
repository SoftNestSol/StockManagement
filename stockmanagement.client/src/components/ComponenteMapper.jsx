import GetProducts from './GetProduct';
import AddProduct from './AddProduct';
import GetProductId from './GetProductId';
import AddEmp from '../pages/AddEmployee';
import GetOrders from './GetOrders';
import AddOrder from './AddOrder';


const componentMapping = {
    GetProducts: GetProducts,
    AddProduct: AddProduct,
    GetProductId: GetProductId,
    AddEmp: AddEmp,
    GetOrders: GetOrders,
    AddOrder: AddOrder,
    
//future components
};

export default componentMapping;
