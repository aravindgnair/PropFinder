import React from 'react'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Navbar from './components/Navbar'
import SearchPage from './pages/SearchPage'
import PropertyDetailPage from './pages/PropertyDetailPage'
import AddPropertyPage from './pages/AddPropertyPage'
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css'

function App() {
    return (
        <Router>
            <Navbar />
            <div className="container mt-4">
                <Routes>
                    <Route path="/" element={<SearchPage />} />
                    <Route path="/properties/:id" element={<PropertyDetailPage />} />
                    <Route path="/add" element={<AddPropertyPage />} />
                </Routes>
            </div>
        </Router>
    )
}

export default App
