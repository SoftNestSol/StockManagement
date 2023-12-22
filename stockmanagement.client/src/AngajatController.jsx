import { useEffect, useState } from 'react';
import axios from 'axios';
function AngajatController() {
    const [employees, setEmployees] = useState([]);

    async function getEmployees() {
        try{

            const resp = await axios.get('http://localhost:5122/api/employee');
            console.log(resp.data);
            setEmployees(resp.data);
        }
        catch(error){
            console.error(error);
        }
    }




  return (
    <div>
        <h1>AngajatController</h1>
        <button onClick={getEmployees}>Get Employees</button>
        <ul>
            {employees.map((emp) => (
                <li key={emp.Id}>{emp.Name}</li>
            ))}
        </ul>
        
    </div>
  )
}

export default AngajatController