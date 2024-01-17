import { useState } from 'react';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import '../styles/login.css';
import { useNavigate } from 'react-router';


function Login() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();
    
    const user ={
        username: username,
        password: password
    }
    
    const handleUsernameChange = (e) => {
        setUsername(e.target.value);
    };

    const handlePasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('http://localhost:5122/api/login', user, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')                    
                }
            });
    
            const token = response.data.token;
            localStorage.setItem('jwtToken', token); 
            
            console.log("Login successful", jwtDecode(token));
            navigate('/dashboard');
            
        } catch (error) {
            console.error("Login failed", error);
            alert("Login failed. Check console for details.");
        }
    };
    

    return (
        <>
        <div className="login-container">
        <div className='login-title'>
            Biotel Ltd.
        </div>
            <form onSubmit={handleSubmit}>
            <h2>Stock Login</h2>
                <label>
                    Username:
                </label>
                <input type="text" value={username} onChange={handleUsernameChange} />
                <br />
                <label>
                    Password:
                </label>
                <input type="password" value={password} onChange={handlePasswordChange} />
                <br />
                <button type="submit" >Login</button>
            </form>
        </div>
        </>
    );
}

export default Login