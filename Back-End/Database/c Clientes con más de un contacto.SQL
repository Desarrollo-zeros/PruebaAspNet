SELECT TOP 1 COUNT(co.client_id) AS counts, c.id, c.names, c.address, c.phone,c.created_at FROM clients c 
INNER JOIN contacts co ON c.id = co.client_id
GROUP BY c.id, c.names, c.address, c.phone,c.created_at
ORDER BY counts DESC