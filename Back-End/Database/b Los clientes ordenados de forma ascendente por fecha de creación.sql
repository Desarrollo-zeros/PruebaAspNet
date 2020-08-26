SELECT c.id, c.names, c.address, c.phone,c.created_at FROM clients c 
INNER JOIN JOIN contacts co ON c.id = co.client_id 
ORDER BY c.created_at ASC