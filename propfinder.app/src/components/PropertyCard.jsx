import React from 'react';
import { Link } from 'react-router-dom';

function PropertyCard({ property }) {
    return (
        <div className="card mb-3 shadow-sm">
            <div className="card-body">
                <h5 className="card-title">{property.address}</h5>
                <p className="card-text">
                    Type: {property.type} <br />
                    Price: ${property.price}
                </p>
                <Link to={`/properties/${property.id}`} className="btn btn-primary">
                    View Details
                </Link>
            </div>
        </div>
    );
}

export default PropertyCard;