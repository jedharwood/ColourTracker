import React from "react";
import { Route, Switch } from "react-router-dom";
import Header from "./common/Header";
import HomePage from "./HomePage";
import AboutPage from "./AboutPage";
import ColoursPage from "./ColoursPage";
import ManageColourPage from "./ManageColourPage";
import NotFoundPage from "./NotFound";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <div className="container-fluid">
      <ToastContainer autoClose={3000} hideProgressBar />
      <Header />
      <Switch>
        <Route path="/" exact component={HomePage} />
        <Route path="/colours" component={ColoursPage} />
        <Route path="/about" component={AboutPage} />
        <Route path="/colour/:id" component={ManageColourPage} />
        <Route path="/colour" component={ManageColourPage} />
        <Route component={NotFoundPage} />
      </Switch>
    </div>
  );
}

export default App;
