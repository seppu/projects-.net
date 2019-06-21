import React from 'react';
import logo from './logo.svg';
import './App.css';
import Hello from './components/Hello';
import StatefullHello from './components/StatefulHello';

const App: React.FC = () => {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
          Test
        </p>
        <Hello name="Joseph" enthusiasmLevel={10}></Hello>
        <StatefullHello name="Joseph" enthusiasmLevel={20}></StatefullHello>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
