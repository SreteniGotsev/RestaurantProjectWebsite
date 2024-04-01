export const login = async (email, password) => {
    let res = await fetch('/login', {
        method: 'Post',
        headers: {
            'content-type': 'application/json',
            
        },
        body: JSON.stringify({ email, password })
    });

    let jsonResult = await res.json();

    if (res.ok) {
        return jsonResult
    } else {
        throw jsonResult
    }
}

export const register = async (email, password) => {
    /*let res =*/ await fetch('/register', {
        method: 'Post',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ email, password })
    });

    //let jsonResult = await res.json();

    ////if (res.ok) {
    ////    return jsonResult
    ////} else {
    ////    throw jsonResult
    ////}
}


export const logout = async (token) => {
    await fetch("http://localhost:3030/users/logout", {
        method: "Get",
        headers: {
            "X-Authorization": token,
        },
    });
}