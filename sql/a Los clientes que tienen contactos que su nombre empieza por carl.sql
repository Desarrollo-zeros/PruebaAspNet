SELECT DISTINCT c.id, c.names, c.address, c.phone,c.created_at FROM clients c 
INNER JOIN contacts co ON c.id = co.client_id 
WHERE UPPER(co.names) LIKE UPPER('carl%');