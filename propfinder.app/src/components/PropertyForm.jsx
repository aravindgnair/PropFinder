import React, { useState } from 'react';

function PropertyForm({ onSubmit }) {
    const [form, setForm] = useState({
        address: "",
        type: "",
        price: "",
        description: ""
    });

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(form);
    }

    return (
        <form onSubmit={handleSubmit} className="card p-3 shadow-sm">
            <div className="mb-3">
                <label className="form-label">Address</label>
                <input
                    name="address"
                    className="form-control"
                    value={form.address}
                    onChange={handleChange}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Type</label>
                <select
                    name="type"
                    className="form-select"
                    value={form.type}
                    onChange={handleChange}
                    required
                >
                    <option value="">Select...</option>
                    <option value="house">House</option>
                    <option value="apartment">Apartment</option>
                    <option value="condo">Condo</option>
                </select>
            </div>
            <div className="mb-3">
                <label className="form-label">Price</label>
                <input
                    name="price"
                    type="number"
                    className="form-control"
                    value={form.price}
                    onChange={handleChange}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Description</label>
                <textarea
                    name="description"
                    className="form-control"
                    value={form.description}
                    onChange={handleChange}
                />
            </div>
            <button type="submit" className="btn btn-success">Save</button>
        </form>
    );
}

export default PropertyForm;