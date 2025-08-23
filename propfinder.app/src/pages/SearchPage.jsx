import React, { useEffect, useState } from "react";
import api from "../api/api";
import PropertyCard from "../components/PropertyCard";

function SearchPage() {
    const [properties, setProperties] = useState([]);
    const [filters, setFilters] = useState({ type: "", minPrice: "", maxPrice: "" });

    const fetchProperties = async () => {
        try {
            const res = await api.get("/properties", { params: filters });
            setProperties(res.data);
        } catch (err) {
            console.error("Error fetching properties", err);
        }
    };

    useEffect(() => {
        fetchProperties();
    }, []);

    const handleChange = (e) => {
        setFilters({ ...filters, [e.target.name]: e.target.value });
    };

    const handleSearch = (e) => {
        e.preventDefault();
        fetchProperties();
    };

    return (
        <div>
            <h2>Search Properties</h2>
            <form onSubmit={handleSearch} className="row g-3 mb-4">
                <div className="col-md-3">
                    <select
                        className="form-select"
                        name="type"
                        value={filters.type}
                        onChange={handleChange}
                    >
                        <option value="">All Types</option>
                        <option value="house">House</option>
                        <option value="apartment">Apartment</option>
                        <option value="condo">Condo</option>
                    </select>
                </div>
                <div className="col-md-3">
                    <input
                        type="number"
                        name="minPrice"
                        placeholder="Min Price"
                        className="form-control"
                        value={filters.minPrice}
                        onChange={handleChange}
                    />
                </div>
                <div className="col-md-3">
                    <input
                        type="number"
                        name="maxPrice"
                        placeholder="Max Price"
                        className="form-control"
                        value={filters.maxPrice}
                        onChange={handleChange}
                    />
                </div>
                <div className="col-md-3">
                    <button type="submit" className="btn btn-primary w-100">Search</button>
                </div>
            </form>

            {properties.length > 0 ? (
                properties.map((p) => <PropertyCard key={p.id} property={p} />)
            ) : (
                <p>No properties found.</p>
            )}
        </div>
    );
}

export default SearchPage;
