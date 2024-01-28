import { useEffect, useState } from 'react';
import axios from 'axios';
import AddEmp from './AddEmployee';
import '../styles/Angajat.css';

function AngajatController() {
    const [employees, setEmployees] = useState([]);
    const [deleteId, setDeleteId] = useState('');
    const [showAddEmp, setShowAddEmp] = useState(false);
    const [showDeleteEmp, setShowDeleteEmp] = useState(false);
    const [showEmployees, setShowEmployees] = useState(false);

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
            setEmployees(response.data);
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
        <div className="controller">
            <h1>AngajatController</h1>
            <div className="actions">
                <button className="action-button" onClick={() => {getEmployees(); setShowEmployees(!showEmployees)}}>Get Employees</button>
                <button className="action-button" onClick={() => setShowAddEmp(!showAddEmp)}>Add Employee</button>
                <button className="action-button" onClick={() => setShowDeleteEmp(!showDeleteEmp)}>Delete Employee</button>
            </div>

            {showAddEmp && <AddEmp />}
            {showDeleteEmp && (
                <form onSubmit={handleDeleteSubmit} className="delete-form">
                    <input
                        type="number"
                        placeholder="Enter Employee ID"
                        value={deleteId}
                        onChange={handleDeleteIdChange}
                        min="1" 
                    />
                    <button type="submit">Delete Employee</button>
                </form>
            )}

            <div className="employee-list">
                {showEmployees && employees.map((emp) => (
                    <div className="employee-card" key={emp.employeeId}>
                        {emp.employeeId} , {emp.name} {emp.surname}
                    </div>
                ))}
            </div>
        </div>
    );
}

export default AngajatController;
