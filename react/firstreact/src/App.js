import axios from 'axios';
import { Component } from 'react'
import { Loading } from './Loading'
import { NoLoading } from './Loading'

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            loading: ""
        };

        this.LoadMoreUsers = this.LoadMoreUsers.bind(this);
        this.Show = this.Show.bind(this);
    }

    componentWillMount() {
        this.LoadUsers();
    }

    LoadUsers() {
        this.setState({ loading: <Loading message="User Information" /> });
        axios('https://api.randomuser.me?nat=US&results=3').then(
            response => this.setState({
                users:[...this.state.users, ...response.data.results],
                loading: <NoLoading message="USer Information" />
            })
        )
    }

    LoadMoreUsers(e) {
        e.preventDefault();
        this.LoadUsers();
        console.log('new users loaded');
       
    }

    Show(user) {
        console.log(`new users loaded${user.name.first}`);
    }

    render() {
        return ( 
            <div>
                < form id="LoadUserFoem" onSubmit={this.LoadMoreUsers}>
                    <input type="submit" id="LoadUserButton"></input>
                </form>
                <hr/>
                <h1 id="LoadingMessageHeadLine">{this.state.loading}</h1>
                {this.state.users.map(user => <div key={user.id.value} style={{ color: "red" }}> User Name:{user.name.title} {user.name.first} {user.name.last}
                  <br/>  <input type="button" value="Show" onClick={this.Show(user)}></input>
                </div> )                  
                }
              
            </div>
           
        );
    }
}


export default App;
