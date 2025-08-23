import React from "react";
import { useNavigate } from "react-router-dom";
import PropertyForm from "../components/PropertyForm";
import api from "../api/api";

function AddPropertyPage() {
    const navigate = useNavigate();

    const handleSubmit = async (form) => {
        try {
            await api.post("/properties", form);
            navigate("/");
        } catch (err) {
            console.error("Error adding property", err);
        }
    };

    return (
        <div>
            <h2>Add Property</h2>
            <PropertyForm onSubmit={handleSubmit} />
        </div>
    );
}

export default AddPropertyPage;
