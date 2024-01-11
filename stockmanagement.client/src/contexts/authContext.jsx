import {useContext, createContext, useEffect, useState} from 'react';
import {jwtDecode} from 'jwt-decode';

const AuthContext = createContext();

export const useAuthContext = () => {
	const authContext = useContext(AuthContext);
	if (!authContext)
		throw new Error("Something went wrong with the React Context API!");
	return authContext;
};


export const AuthContextProvider = ({children}) => {

    const [user, setUser] = useState(null);


    const login = (token) => {
        localStorage.setItem('jwtToken', token);
        const decodedToken = jwtDecode(token);
        setUser(decodedToken);
    };

    const logout = () => {
        localStorage.removeItem('jwtToken');
        setUser(null);
    };

    const state = {
        user,
        login,
        logout
    };

    return (
        <AuthContext.Provider value={state}>
            {children}
        </AuthContext.Provider>
    );
};