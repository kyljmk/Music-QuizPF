import "./App.css";
import Login from "./components/Login";
import Layout from "./components/Layout";
import Quiz from "./components/Quiz";
import Result from "./components/Result";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Login />} />
        <Route path="/" element={<Layout />}>
          <Route path="/quiz" element={<Quiz />} />
          <Route path="/result" element={<Result />} />
        </Route>
    </Routes>
  </BrowserRouter >
  );
}

export default App;
