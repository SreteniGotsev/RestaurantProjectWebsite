/*import LogoutLink from "../../components/logoutLink.jsx"*/
/*import AuthorizeView from "../../components/AuthorizeView.jsx"*/
import { Link } from "react-router-dom";
import WeatherForcast from "../../components/WeatherForcast.jsx";
function Home() {
    return (
        /* <AuthorizeView>*/
        <>
            <li>
                <Link to="/register">Register</Link>
            </li>
            <li>
                <Link to="/login">Log in</Link>
            </li>
            <li>
                <WeatherForcast></WeatherForcast>
            </li>
        </>
        //{/*<span><LogoutLink>Logout<AuthorizeUser value="email"></AuthorizeUser></LogoutLink></span>*/}
        //</AuthorizeView>
    );
}

export default Home;