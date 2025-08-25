import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../api/api";
import SpaceList from "../components/SpaceList";

function PropertyDetailPage() {
    const { id } = useParams();
    const [property, setProperty] = useState(null);

    useEffect(() => {
        const fetchProperty = async () => {
            try {
                const res = await api.get(`/properties/${id}`);
                setProperty(res.data);
            } catch (err) {
                console.error("Error fetching property", err);
            }
        };
        fetchProperty();
    }, [id]);

    if (!property) return <p>Loading...</p>;

    return (
        <div>
            <h2>{property.address}</h2>
            <p>Type: {property.type}</p>
            <p>Price: ${property.price}</p>
            <p>{property.description}</p>

            <h4>Spaces</h4>
            <SpaceList spaces={property.spaces} />
        </div>
    );
}

export default PropertyDetailPage;
