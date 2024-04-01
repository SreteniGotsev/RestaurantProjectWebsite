import { createContext, useContext } from "react";
import useLocalStorage from '../hooks/useLocalStorageHook'

export const AuthContext = createContext();


export const AuthProvider = ({children}) => {



    const [token, setToken] = useLocalStorage('accessToken', {
        accessToken: '',
        expiresIn: '',
        refreshToken: '',
        tokenType: ''
    })

    const login = (authData) => {
        setToken(authData);
    }

    const logout = () => {
        setToken({
            _id: '',
            email: '',
            accessToken: ''
        });
    }

    return (
        <AuthContext.Provider value={{ token, login, logout /*isAuthenticated: Boolean(user.email)*/ }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const authState = useContext(AuthContext);

    return authState;
}