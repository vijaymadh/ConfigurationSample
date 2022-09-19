import { Component, useState, useEffect } from "react";

const App = () => {
    const [count, SetCount] = useState(0);

    useEffect(() => {
        document.title = `Clicked ${count} times`
    });

    const increment = () => {
        SetCount(count + 1);
    }

    return (
        <div>

            < h2 > Counter App</h2 >
            <button onClick={increment} >Clicked ({count})</button>

        </div>
    );

}

export default App;