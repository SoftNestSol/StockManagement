import {useState, useEffect} from 'react';
import {jwtDecode} from 'jwt-decode';
import {useNavigate} from 'react-router-dom';
import '../styles/dashboard.scss';
import { Link } from 'react-router-dom';
import Card from '../components/cards';
import SearchBar from '../components/SearchBar';
import componentMapping from '../components/ComponenteMapper';




const Dashboard = ({options}) => {
    console.log(options);
    const [user, setUser] = useState(null);
    const Navigate = useNavigate();
    const [searchTerm, setSearchTerm] = useState('');
    const [filteredOptions, setFilteredOptions] = useState([]);
    useEffect(() => {
      if (searchTerm) {
        const filtered = options.filter(option =>
          option.name.toLowerCase().includes(searchTerm.toLowerCase())
        );
        setFilteredOptions(filtered);
      } else {
        setFilteredOptions([]);
      }
    }, [searchTerm, options]);
    useEffect(() => {
        const token = localStorage.getItem('jwtToken');
        if (token) {
            const decodedToken = jwtDecode(token);
            setUser(decodedToken);
            console.log(decodedToken);
            console.log(decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
        }
        else {
            setUser(null);
            Navigate('/')
        }
    }
    , []);

    return (
        <div className="dashboard">
        <SearchBar className='option-search'  onSearch={setSearchTerm} />
        <div className='searched-options'>
        {filteredOptions.map(option => {
          console.log(option);
          const Component = componentMapping[option.componentKey];
          return Component ? <Component key={option.id} /> : null;
        })}

        </div>
        <div className="quick-access">
          <h2>Quick access</h2>
            <div className="card-container">
                <Link to = "/angajat">
                <Card imgSrc="meeting.png" title="Angajati" />
                </Link>
                <Link to = "/produs">
                <Card imgSrc="electric.png" title="Produse" />
                </Link>
                <Link to = "/comanda">
                <Card imgSrc="order-delivery.png" title="Comenzi " />
                </Link>
                <Link to = "/stoc">
                <Card imgSrc="box.png" title="Stocuri" />
                </Link>
        </div>
        </div>
        <div className="all-options">
          <h2>All Options</h2>
          <div className="card-container">
                <Link to = "/angajat">
                <Card imgSrc="meeting.png" title="Angajati" />
                </Link>
                <Link to = "/produs">
                <Card imgSrc="electric.png" title="Produse" />
                </Link>
                <Link to = "/comanda">
                <Card imgSrc="order-delivery.png" title="Comenzi " />
                </Link>
                <Link to = "/stoc">
                <Card imgSrc="box.png" title="Stocuri" />
                </Link>
        </div>
        </div>
      </div>
    );


}

export default Dashboard;