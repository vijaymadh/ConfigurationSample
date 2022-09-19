import { Component, useState } from "react";

const App = () => {
    const [count, SetCount] = useState(0);

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
