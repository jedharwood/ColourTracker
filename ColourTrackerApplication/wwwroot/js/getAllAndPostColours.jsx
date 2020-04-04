class ColourDisplay extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.handleColourSubmit = this.handleColourSubmit.bind(this);
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
    handleColourSubmit(colour) {
        const data = new FormData();
        data.append('name', colour.name);
        data.append('brand', colour.brand);
        data.append('expiry', colour.expiry);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.loadColoursFromServer();
        xhr.send(data);
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
                <AddColourForm onColourSubmit={this.handleColourSubmit}/>
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
    constructor(props) {
        super(props);
        this.state = { name: '', brand: '', expiry: '' };
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleBrandChange = this.handleBrandChange.bind(this);
        this.handleExpiryChange = this.handleExpiryChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleNameChange(e) {
        this.setState({ name: e.target.value });
    }
    handleBrandChange(e) {
        this.setState({ brand: e.target.value });
    }
    handleExpiryChange(e) {
        this.setState({ expiry: e.target.value });
    }
    handleSubmit(e) {
        e.preventDefault();
        const name = this.state.name.trim();
        const brand = this.state.brand.trim();
        const expiry = this.state.expiry.trim();
        if (!name || !brand || !expiry) {
            return;
        }
        this.props.onColourSubmit({ name: name, brand: brand, expiry: expiry })
        this.setState({ name: '', brand: '', expiry: '' });
    }
    render() {
        return (
            <form className="addColourForm" onSubmit={this.handleSubmit}>
                <h2>Add a colour to your list</h2>
                <div>
                    <input
                        type="text"
                        placeholder="Colour"
                        value={this.state.name}
                        onChange={this.handleNameChange}
                    />
                </div>
                <div>
                    <input
                        type="text"
                        placeholder="Brand"
                        value={this.state.brand}
                        onChange={this.handleBrandChange}
                    />
                </div>                
                <div>
                    <input
                        type="text"
                        placeholder="Expiry MM/YY"
                        value={this.state.expiry}
                        onChange={this.handleExpiryChange}
                    />
                </div>
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
    <ColourDisplay
        url="/colours"
        submitUrl="/colours/new"
        pollInterval={2000}
    />,
    document.getElementById('content')
);