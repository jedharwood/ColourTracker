class ColourDisplay extends React.Component {
    render() {
        return (
            <div className="colourDisplay">
                <h1>Colours</h1>
                <ColourList />
                <AddColourForm />
            </div>
        );
    }
}

class ColourList extends React.Component {
    render() {
        return (
            <div className="colourList">Hello, world! I am a ColourList.</div>
        );
    }
}

class AddColourForm extends React.Component {
    render() {
        return (
            <div className="addColourForm">Add a colour to your list</div>
        );
    }
}

ReactDOM.render(<ColourDisplay />, document.getElementById('content'),);