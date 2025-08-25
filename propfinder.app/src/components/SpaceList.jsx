import React from 'react';

function SpaceList({ spaces }) {
    if (!spaces || spaces.Length === 0) {
        return <p>No spaces listed.</p>
    }

    return (
        <ul className="list-group">
            {spaces.map((space) => (
                <li key={space.id} className="list-group-item">
                    <strong>{space.type}</strong> - {space.size} sq ft
                    {space.description && <div>{space.description}</div>}
                </li>
            ))}
        </ul>
    );
}

export default SpaceList;