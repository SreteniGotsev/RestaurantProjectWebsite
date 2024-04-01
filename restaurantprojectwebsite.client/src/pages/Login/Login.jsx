import { Link } from 'react-router-dom';
/*import './Login.css'*/
import { useNavigate } from 'react-router-dom';
import * as authService from '../../services/authService.js';
import { AuthContext } from '../../contexts/authContext.jsx';
import { useContext } from 'react';


const Login = () => {

    const navigate = useNavigate();
    const {login}  = useContext(AuthContext)

    const onLoginHandler = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get("email");
        let password = formData.get("password");

        authService.login(email, password)
            .then((authData) => {
                login(authData)
                navigate('/')
            })
            //.catch( err => {
               
            //    window.alert(err)
            //})
    }

    return (
        <div className="container-register">
            <div className="container">
                <div className="form">
                    <header>Login</header>
                    <form onSubmit={onLoginHandler}>
                        <input name='email' type="text" placeholder="Enter your email" />
                        <input name='password' type="password" placeholder="Enter your password" />
                        <Link to="/">Forgot password?</Link>
                        <input type="submit" className="button" value="Login" />
                    </form>
                    <div className="signup">
                        <span className="signup">
                           {/* Don't have an account?*/}
                            <Link to="/register">Signup</Link>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    );
}



export default Login;