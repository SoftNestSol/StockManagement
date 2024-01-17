import { useEffect, useState } from 'react';
import axios from 'axios';
import AddEmp from './AddEmp';
function AngajatController() {
    const [employees, setEmployees] = useState([]);
    const [deleteId, setDeleteId] = useState('');

    async function getEmployees() {
        try {
           const response = await axios.get('http://localhost:5122/api/employee', {
            'headers': {
                'Authorization': 'Bearer ' + localStorage.getItem('jwtToken'),
                'Content-Type': 'application/json'
            }
           
        }
           );
           console.log(response.data);
           // setEmployees(resp.data);
        }
        catch (error) {
            console.error(error);
        }
    }

    async function deleteEmployee(id) {
        try {
            const resp = await axios.delete('http://localhost:5122/api/employee/' + id);
            console.log(resp.data);
            getEmployees();
        }
        catch (error) {
            console.error(error);
        }
    }

    function handleDeleteIdChange(event) {
        setDeleteId(event.target.value);
    }

    function handleDeleteSubmit(event) {
        event.preventDefault(); 
        if (deleteId) {
            deleteEmployee(deleteId);
            setDeleteId(''); 
        }
    }

    return (
        <div>
            <h1>AngajatController</h1>
            <button onClick={getEmployees}>Get Employees</button>
            <ul>
                {employees.map((emp) => (
                    <li key={emp.employeeId}>{emp.employeeId} , {emp.name} {emp.surname}</li>
                ))}
            </ul>
            <AddEmp />
            <form onSubmit={handleDeleteSubmit}>
                <input
                    type="number"
                    placeholder="Enter Employee ID"
                    value={deleteId}
                    onChange={handleDeleteIdChange}
                    min="1" // ID-urile încep de la 1
                />
                <button type="submit">Delete Employee</button>
            </form>
        </div>
    )
}

export default AngajatController;
