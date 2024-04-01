import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './pages/Home/Home.jsx'
import Login from './pages/Login/Login.jsx'
import Register from './pages/Register/Register.jsx'
import { AuthProvider } from './contexts/authContext.jsx';

function App() {



    return (
        <BrowserRouter>
            <AuthProvider>
            <Routes>
                <Route path="/register" element={<Register />} />
                <Route path="/login" element={<Login/> } />
                <Route path="/" element={<Home/>} />
            </Routes>
            </AuthProvider>
        </BrowserRouter>
    );
}

export default App;