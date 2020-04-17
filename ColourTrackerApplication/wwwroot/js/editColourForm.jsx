class EditColourForm extends React.Component {
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
        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitEditUrl, true);

        xhr.send(data);
    }
    render() {
        return (
            <form className="editColourForm" onSubmit={this.handleSubmit}>
                <h1>Edit a colour</h1>
                <div>
                    <input
                        type="text"
                        placeholder={this.props.colour.name}
                        value={this.state.name}
                        onChange={this.handleNameChange}
                    />
                </div>
                <div>
                    <input
                        type="text"
                        placeholder={this.props.colour.brand}
                        value={this.state.brand}
                        onChange={this.handleBrandChange}
                    />
                </div>
                <div>
                    <input
                        type="text"
                        placeholder={this.props.colour.expiry}
                        value={this.state.expiry}
                        onChange={this.handleExpiryChange}
                    />
                </div>
                <div>
                    <input
                        type="text"
                        placeholder={this.props.colour.serialNumber}
                        value={this.state.serialNumber}
                        onChange={this.handleSerialNumberChange}
                    />
                </div>
                <input type="submit" value="Post" className="actionButton" />
            </form>
        );
    }
}

ReactDOM.render(
    <EditColourForm
        submitEditUrl="/colours/submitEdit"
    />,
    document.getElementById('content')
);