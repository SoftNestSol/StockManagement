import { useEffect, useState } from 'react';
import axios from 'axios';
import '../styles/Angajat.css';


function AddEmp() {
    const [employee, setEmployee] = useState({
        EmployeeId : 0,
        Name: '',
        Surname: '',
        Job: '',
        Email: '',
        Password: '',
        PhoneNumber: '',
        Role:'',
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
        <form onSubmit={handleSubmit} className='react-form'>
            <fieldset className='form-group'>
                <label htmlFor='formName' className='form-label'>Full Name:</label>
                <input
                    id='formName'
                    className='form-input'
                    type="text"
                    name="Name"
                    value={employee.Name}
                    onChange={handleChange}
                    placeholder="Name"
                />
            </fieldset>
    
            <fieldset className='form-group'>
                <label htmlFor='formJob' className='form-label'>Job:</label>
                <input
                    id='formJob'
                    className='form-input'
                    type="text"
                    name="Job"
                    value={employee.Job}
                    onChange={handleChange}
                    placeholder="Job"
                />
            </fieldset>
    
            <fieldset className='form-group'>
                <label htmlFor='formEmail' className='form-label'>Email:</label>
                <input
                    id='formEmail'
                    className='form-input'
                    type="text"
                    name="Email"
                    value={employee.Email}
                    onChange={handleChange}
                    placeholder="Email"
                />
            </fieldset>
    
            <fieldset className='form-group'>
                <label htmlFor='formSurname' className='form-label'>Surname:</label>
                <input
                    id='formSurname'
                    className='form-input'
                    type="text"
                    name="Surname"
                    value={employee.Surname}
                    onChange={handleChange}
                    placeholder="Surname"
                />
            </fieldset>
    
            <fieldset className='form-group'>
                <label htmlFor='formPassword' className='form-label'>Password:</label>
                <input
                    id='formPassword'
                    className='form-input'
                    type="password"
                    name="Password"
                    value={employee.Password}
                    onChange={handleChange}
                    placeholder="Password"
                />
            </fieldset>
    
            <fieldset className='form-group'>
                <label htmlFor='formPhoneNumber' className='form-label'>Phone Number:</label>
                <input
                    id='formPhoneNumber'
                    className='form-input'
                    type="text"
                    name="PhoneNumber"
                    value={employee.PhoneNumber}
                    onChange={handleChange}
                    placeholder="PhoneNumber"
                />
            </fieldset>
    
            <fieldset className='form-group'>
                <label htmlFor='formRole' className='form-label'>Role:</label>
                <input
                    id='formRole'
                    className='form-input'
                    type="text"
                    name="Role"
                    value={employee.Role}
                    onChange={handleChange}
                    placeholder="Role"
                />
            </fieldset>
    
            <div className='form-group'>
                <button className='btn' type="submit">Add Employee</button>
            </div>
        </form>
    );
    
}


export default AddEmp