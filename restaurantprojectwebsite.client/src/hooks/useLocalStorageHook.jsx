import { useState } from "react"

const useLocalStorage = (key, initialValue) => {

    const [state, setState] = useState(() => {

        let item = localStorage.getItem(key)

        return item ? JSON.parse(item) : initialValue
    })

    const setItem = (value) => {
        localStorage.setItem(key, JSON.stringify(value))
        setState(value)
    }

    return [
        state,
        setItem
    ]

}

export default useLocalStorage;