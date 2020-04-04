class ColourDisplay extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }
    loadColoursFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    componentDidMount() {
        this.loadColoursFromServer();
        window.setInterval(
            () => this.loadColoursFromServer(),
            this.props.pollInterval,
        );
    }
    render() {
        return (
            <div className="colourDisplay">
                <h1>Colours</h1>
                <ColourList data={this.state.data}/>
                <AddColourForm />
            </div>
        );
    }
}

class ColourList extends React.Component {
    render() {
        const colourNodes = this.props.data.map(colour => (
            <Colour name={colour.name} key={colour.id}>
                <div>brand: {colour.brand}</div>
                <div>exp: {colour.expiry}</div>
            </Colour>
        ));
        return <div className="colourList">{colourNodes}</div>;
    }
}

class AddColourForm extends React.Component {
    render() {
        return (
            <form className="addColourForm">
                <h2>Add a colour to your list</h2>
                <input type="text" placeholder="Colour" />
                <input type="text" placeholder="Brand" />
                <input type="text" placeholder="Expiry" />
                <input type="submit" value="Post" />
            </form>           
        );
    }
}

class Colour extends React.Component {
    render() {
        return (
            <div className="colour">
                <h2 className="colourName">{this.props.name}</h2>
                {this.props.children}               
            </div>
        );
    }
}

ReactDOM.render(
    <ColourDisplay url="/colours" pollInterval={2000} />,
    document.getElementById('content')
);