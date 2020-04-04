class ColourDisplay extends React.Component {
    render() {
        return (
            <div className="colourDisplay">
                <h1>Colours</h1>
                <ColourList data={this.props.data}/>
                <AddColourForm />
            </div>
        );
    }
}

class ColourList extends React.Component {
    render() {
        const colourNodes = this.props.data.map(colour => (
            <Colour name={colour.name} key={colour.id}>
                brand: {colour.brand}
                exp: {colour.expiry}
            </Colour>
        ));
        return <div className="colourList">{colourNodes}</div>;
    }
}

class AddColourForm extends React.Component {
    render() {
        return (
            <div className="addColourForm">Add a colour to your list</div>
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

const data = [
    {
        id: 1,
        name: 'Red',
        brand: 'Waverly',
        expiry: '03/22'
    },
    {
        id: 2,
        name: 'Golden Yellow',
        brand: 'Old Gold',
        expiry: '06/23'
    },
    {
        id: 3,
        name: 'Olive Green',
        brand: 'DermaGlo',
        expiry: '06/24'
    }
];

ReactDOM.render(<ColourDisplay data={data} />, document.getElementById('content'),);