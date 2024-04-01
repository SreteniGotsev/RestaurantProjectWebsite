import { Link, useNavigate } from 'react-router-dom';
//import './Register.css'
import { useContext, useState } from 'react';
import { AuthContext } from '../../contexts/authContext.jsx';
import * as authService from '../../services/authService.js';
import * as validate from '../../common/validate.jsx';
import * as err from '../../common/style.jsx'



const Register = () => {

    const navigate = useNavigate();
    const [errObj, setErrObj] = useState({
        email: { err: false, message: '' },
        password: { err: false, message: '' },
        repeatPassword: { err: false, message: '' },
    })

    const { login } = useContext(AuthContext)

    const onRegisterHandler = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get("email");
        let password = formData.get("password");
        let repeatPassword = formData.get("repeatPassword");

        if (password !== repeatPassword) {
            alert('The passwords should match!')
        } else if (errObj.email.err || errObj.password.err || errObj.repeatPassword.err) {
            return
        } else {

            authService
                .register(email, password)
                .then((authData) => {
                    login(authData);
                    navigate("/");
                })
                .catch(() => {
                    navigate("/Error");
                });

        }
    }

    const onChangeHandler = (e) => {
        if (e) {
            const ob = Object.assign({}, validate.user(e.target.name, e.target.value))
            setErrObj(ob)
        }
    }

    return (
        <div className="container-register">
            <div className="container">
                <div className="registration form">
                    <header>Signup</header>
                    <form onSubmit={onRegisterHandler}>
                        <input
                            name="email"
                            type="text"
                            placeholder="Enter your email"
                            onBlur={onChangeHandler}
                            style={err.borderError(errObj.email.err)}
                        />
                        {
                            <span style={err.displayError(errObj.email.err)}>
                                {errObj.email.message}
                            </span>
                        }
                        <input
                            name="password"
                            type="password"
                            placeholder="Create a password"
                            onBlur={onChangeHandler}
                            style={err.borderError(errObj.password.err)}
                        />
                        {
                            <span style={err.displayError(errObj.password.err)}>
                                {errObj.password.message}
                            </span>
                        }
                        <input
                            name="repeatPassword"
                            type="password"
                            placeholder="Confirm your password"
                            onBlur={onChangeHandler}
                            style={err.borderError(errObj.repeatPassword.err)}
                        />
                        {
                            <span style={err.displayError(errObj.repeatPassword.er)}>
                                {errObj.repeatPassword.message}
                            </span>
                        }
                        <input type="submit" className="button" value="Signup" />
                    </form>
                    <div className="signup">
                        <span className="signup">
                            Already have an account?
                            <Link to="/login">Login</Link>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    );
}



export default Register;