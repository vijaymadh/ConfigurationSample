import { Component, useState } from "react";


class App extends Component {
    state = {
        count: 0
    };

    increment = () => {

        this.setState({
            count: this.state.count + 1
        });
    }

    componentDidMount() {
        document.title = `Clicked ${this.state.count} times`
    }

    componentDidUpdate() {
        document.title = `Clicked ${this.state.count} times`
    }

    render() {
        return (
            <div>

                < h2 > Counter App</h2 >
                <button onClick={this.increment} >Clicked ({this.state.count})</button>

            </div>
        );
    }

}

export default App;