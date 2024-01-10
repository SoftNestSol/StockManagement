import { useState } from 'react';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';


function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    
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
                }
            });
    
            const token = response.data.token;
            localStorage.setItem('jwtToken', token); 
    
            console.log("Login successful", jwtDecode(token));
        } catch (error) {
            console.error("Login failed", error);
        }
    };
    

    return (
        <div>
            <h2>Login</h2>
            <form onSubmit={handleSubmit}>
                <label>
                    Username:
                    <input type="text" value={username} onChange={handleUsernameChange} />
                </label>
                <br />
                <label>
                    Password:
                    <input type="password" value={password} onChange={handlePasswordChange} />
                </label>
                <br />
                <button type="submit">Login</button>
            </form>
        </div>
    );
}

export default Login