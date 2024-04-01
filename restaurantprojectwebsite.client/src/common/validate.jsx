let userObj = {
    email: { err: false, message: '' },
    password: { err: false, message: '' },
    repeatPassword: { err: false, message: '' },
};

export const user = (name, input) => {

    if (name === "email" && (input.length < 5 || input.length > 50)) {
        userObj.email.message = `The ${name} should be between 5 and 50 charecters`
        userObj.email.err = true
    } else if (name === "email" && (input.length > 5 || input.length < 50)) {
        userObj.email.message = ``
        userObj.email.err = false
    } else if (name === "password" && (input.length < 5 || input.length > 50)) {
        userObj.password.message = `The ${name} should be between 5 and 50 charecters`
        userObj.password.err = true
    } else if (name === "password" && (input.length > 5 || input.length < 50)) {
        userObj.password.message = ``
        userObj.password.err = false
    } else if (name === "repeatPassword" && (input.length < 5 || input.length > 50)) {
        userObj.repeatPassword.message = `The ${name} should be between 5 and 50 charecters`
        userObj.repeatPassword.err = true
    } else if (name === "repeatPassword" && (input.length > 5 || input.length < 50)) {
        userObj.repeatPassword.message = ``
        userObj.repeatPassword.err = false
    }
    return userObj;

}

