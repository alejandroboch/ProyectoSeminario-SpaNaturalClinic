


-- Insertar servicios
INSERT INTO tbl_servicios (nombre, precio) VALUES
('Corte de cabello', 15.00),
('Manicure', 10.00),
('Pedicure', 12.00),
('Masaje relajante', 25.00),
('Tratamiento facial', 30.00),
('Depilación', 20.00);

-- Insertar paquetes
INSERT INTO tbl_paquetes (nombre, precio_total, numero_sesiones) VALUES
('Paquete Belleza Básico', 50.00, 3),
('Paquete Relax', 70.00, 2),
('Paquete Spa Completo', 120.00, 4);

-- Relación paquete-servicio (orden de sesiones)
-- Paquete Belleza Básico
INSERT INTO tbl_paquete_servicio (fk_id_paquete, fk_id_servicio, numero_sesion) VALUES
(1, 1, 1), -- Corte de cabello
(1, 2, 2), -- Manicure
(1, 3, 3); -- Pedicure

-- Paquete Relax
INSERT INTO tbl_paquete_servicio (fk_id_paquete, fk_id_servicio, numero_sesion) VALUES
(2, 4, 1), -- Masaje relajante
(2, 5, 2); -- Tratamiento facial

-- Paquete Spa Completo
INSERT INTO tbl_paquete_servicio (fk_id_paquete, fk_id_servicio, numero_sesion) VALUES
(3, 1, 1), -- Corte de cabello
(3, 4, 2), -- Masaje relajante
(3, 5, 3), -- Tratamiento facial
(3, 6, 4); -- Depilación


select* from tbl_servicios;
select* from tbl_paquetes;
select* from tbl_paquete_servicio;
select* from tbl_cliente_paquete;