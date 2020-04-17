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
        data.append('serialNumber', colour.serialNumber);

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
                <ColourList data={this.state.data} softDeleteUrl={this.props.softDeleteUrl} />
                <AddColourForm onColourSubmit={this.handleColourSubmit}/>
            </div>
        );
    }
}

class ColourList extends React.Component {
    render() {
        const colourNodes = this.props.data.map(colour => (            
            <Colour name={colour.name} key={colour.id}>
                <div>Brand: {colour.brand}</div>
                <div>Exp: {colour.expiry}</div>
                <div>Serial #: {colour.serialNumber}</div>
                <div>Date Added: {colour.dateAdded}</div>
                <SoftDeleteColour colour={colour} softDeleteUrl={this.props.softDeleteUrl}/>
            </Colour>
        ));
        return <div className="colourList">{colourNodes}</div>;
    }
}

class SoftDeleteColour extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            colour: this.props.colour
        };
    }
    HandleDeletion(colour) {
        var xhr = new XMLHttpRequest();
        var url = this.props.softDeleteUrl + colour.id;
        xhr.open('Post', url, true);

        xhr.onreadystatechange = () => {
            if (xhr.status == 204) {
                this.loadColoursFromServer();
            }
        }
        xhr.send();
    }
    render() {
        return (         
            <button className="actionButton" onClick={() => { this.HandleDeletion(this.state.colour); }}>Delete</button>              
        )
    }
}

class AddColourForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: '', brand: '', expiry: '', serialNumber: '' };
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleBrandChange = this.handleBrandChange.bind(this);
        this.handleExpiryChange = this.handleExpiryChange.bind(this);
        this.handleSerialNumberChange = this.handleSerialNumberChange.bind(this);
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
    handleSerialNumberChange(e) {
        this.setState({ serialNumber: e.target.value })
    }
    handleSubmit(e) {
        e.preventDefault();
        const name = this.state.name.trim();
        const brand = this.state.brand.trim();
        const expiry = this.state.expiry.trim();
        const serialNumber = this.state.serialNumber.trim();
        if (!name || !brand || !expiry || !serialNumber) {
            return;
        }
        this.props.onColourSubmit({
            name: name,
            brand: brand,
            expiry: expiry,
            serialNumber: serialNumber
        })
        this.setState({
            name: '',
            brand: '',
            expiry: '',
            serialNumber: ''
        });
    }
    render() {
        return (
            <form className="addColourForm" onSubmit={this.handleSubmit}>
                <h1>Add a colour to your list</h1>
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
                <div>
                    <input
                        type="text"
                        placeholder="Serial #"
                        value={this.state.serialNumber}
                        onChange={this.handleSerialNumberChange}
                    />
                </div>
                <input type="submit" value="Post" className="actionButton" />              
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
        softDeleteUrl="/colours/softDelete/"
        pollInterval={2000}
    />,
    document.getElementById('content')
);
