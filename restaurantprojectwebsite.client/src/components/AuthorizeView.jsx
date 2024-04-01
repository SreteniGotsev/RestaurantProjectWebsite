

import { useState, useEffect,createContext} from 'react';
import { Navigate } from 'react-router-dom'

const UserContext = createContext({});

 
function AuthorizeView(children) {

    const [authorized, setAuthorized] = useState < Boolean > (false);
    const [loading, setLoading] = useState < Boolean > (true);
    let emptyUser = { email: "" }

    const [user, setUser] = useState(emptyUser);

    useEffect(() => {
        let retryCount = 0;
        const maxRetries = 10;
        const delay = 1000;

        function wait(delay) {
            return new Promise((resolve => setTimeout(resolve, delay)))
        }

        async function fetchWithRetry(url, options) {

            try {
                let response = await fetch(url, options)

                if (response.status == 200) {
                    console.log("Authorized");
                    let j = await response.json();
                    setUser({ email: j.email });
                    setAuthorized(true)
                    return response;
                } else if (response.status == 401) {
                    console.log("Unauthorized")
                    return response
                } else {
                    throw new Error("" + response.status);
                }
            } catch (error) {
                retryCount++
                if (retryCount > maxRetries) {
                    throw error;
                } else {
                    await wait(delay);
                    return fetchWithRetry(url, options)
                }

            }
        }

        fetchWithRetry("/isAuth", {
            method: "GET"
        }).catch((error) => {
            console.log(error.message)
        }).finally(() => {
            setLoading(false);
        })

    }, []);

    if (loading) {
        return (
            <>
                <p>Loading...</p>
            </>
        );
    } else {
        if (authorized && !loading) {
            return (
                <>
                    <UserContext.Provider value={user}>
                        {children}
                    </UserContext.Provider>
                </>
            );
        } else {
            return (
                <>
                    <Navigate to="/login" />;
                </>
            );
        }

    }
    
}

export default AuthorizeView;