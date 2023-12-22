import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

function AddEmp() {
    const [employee, setEmployee] = useState({
        EmployeeId : 0,
        Name: '',
        Surname: '',
        Job: '',
        Email: '',
        Password: '',
        PhoneNumber: '',
        ApplicationUserId: ''

    });

    const getLastId = async () => {
        try {
            const response = await axios.get('http://localhost:5122/api/employee/lastid');
            console.log(response.data);
            setEmployee(prevEmployee => ({ 
                ...prevEmployee, 
                Id: response.data + 1, 
                ApplicationUserId: toString(response.data + 1)
            }));
        }
        catch (error) {
            console.error(error);
        }
    }

    useEffect(() => {
        getLastId();
    }, []);

    const handleChange = (e) => {
        setEmployee({ ...employee, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
  
            const response = await axios.post('http://localhost:5122/api/employee', employee, {
                headers: {
                    'Content-Type': 'application/json',
                }
            });
       
            console.log(response.data);
        } catch (error) {
            console.log(employee);
            console.error(error.response ? error.response.data : error.message);
        }
    };
    

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                name="Name"
                value={employee.Name}
                onChange={handleChange}
                placeholder="Name"
            />
            <input
                type="text"
                name="Job"
                value={employee.Job}
                onChange={handleChange}
                placeholder="Job"
            />
            <input
                type="text"
                name="Email"
                value={employee.Email}
                onChange={handleChange}
                placeholder="Email"
            />
            <input
                type="text"
                name="Surname"
                value={employee.Surname}
                onChange={handleChange}
                placeholder="Surname"
            />
            <input
                type="password"
                name="Password"
                value={employee.Password}
                onChange={handleChange}
                placeholder="Password"
            />
            <input
                type="text"
                name="PhoneNumber"
                value={employee.PhoneNumber}
                onChange={handleChange}
                placeholder="PhoneNumber"
            />
            <button type="submit">Add Employee</button>
        </form>
    );
}


export default AddEmp