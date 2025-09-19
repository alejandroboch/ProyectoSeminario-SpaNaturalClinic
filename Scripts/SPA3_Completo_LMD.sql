-- ===========================================
-- 3) Datos de ejemplo
-- ===========================================

-- Cliente
INSERT INTO tbl_clientes (nombre, telefono, es_vip)
VALUES ('Juan Pérez', '555-1234', 1);

SELECT * FROM tbl_clientes;

-- Servicios sueltos
INSERT INTO tbl_servicios (nombre, precio) VALUES
('Facial Hidratante', 40.00),
('Masaje Relajante', 50.00),
('Ejercicio Asistido', 60.00),
('Estiramiento Terapéutico', 45.00);

SELECT * FROM tbl_servicios;

-- Paquete de 5 sesiones
INSERT INTO tbl_paquetes (nombre, precio_total, numero_sesiones)
VALUES ('Terapia Física – 5 sesiones', 500.00, 5);

SELECT * FROM tbl_paquetes;

-- Definir servicios que componen el paquete
INSERT INTO tbl_paquete_servicio (fk_id_paquete, fk_id_servicio, numero_sesion) VALUES
(1, 2, 1), 
(1, 3, 2),
(1, 2, 3),
(1, 4, 4),
(1, 3, 5);

SELECT * FROM tbl_paquete_servicio;

-- Cliente compra el paquete
INSERT INTO tbl_cliente_paquete (fk_id_cliente, fk_id_paquete, fecha_compra, saldo_pendiente, fk_id_cita_compra)
VALUES (1, 1, '2025-08-28', 500.00, NULL);

SELECT * FROM tbl_cliente_paquete;

-- Cita con servicio suelto + sesión 1 del paquete
INSERT INTO tbl_citas (fk_id_cliente, fecha_cita, estado, total, saldo_pendiente)
VALUES (1, '2025-08-28', 'Programada', 540.00, 540.00);  

SELECT * FROM tbl_citas;

-- Servicio individual en la cita
INSERT INTO tbl_cita_servicio (fk_id_cita, fk_id_servicio, costo_referencia, monto_a_cobrar)
VALUES (1, 1, 40.00, 40.00);  -- Facial Hidratante

-- Primera sesión del paquete (se cobra el total del paquete solo en la primera vez)
INSERT INTO tbl_cita_servicio (fk_id_cita, fk_id_paquete, numero_sesion, costo_referencia, monto_a_cobrar, fk_id_cliente_paquete)
VALUES (1, 1, 1, 500.00, 500.00, 1);

SELECT * FROM tbl_cita_servicio;

-- ===========================================
-- PAGOS
-- ===========================================

-- Pago del servicio suelto
INSERT INTO tbl_pagos (fk_id_cita, monto, metodo_pago, fecha_pago, nota)
VALUES (1, 40.00, 'Efectivo', '2025-08-28', 'Facial suelto');

-- Pago del paquete en dos cuotas
INSERT INTO tbl_pagos (fk_id_cita, monto, metodo_pago, fecha_pago, nota)
VALUES 
(1, 250.00, 'Efectivo', '2025-08-28', '1a cuota paquete'),
(1, 250.00, 'Transferencia', '2025-09-10', '2a cuota paquete');

SELECT * FROM tbl_pagos;

-- ===========================================
-- 4) Consultas útiles
-- ===========================================

-- 4.1 Detalle de la cita (qué se agendó, si fue servicio suelto o paquete con sesión)
SELECT 
  c.pk_id_cita,
  cli.nombre AS cliente,
  c.fecha_cita,
  sd.nombre AS servicio_suelto,
  p.nombre  AS paquete,
  cs.numero_sesion,
  sp.nombre AS servicio_de_la_sesion,
  cs.costo_referencia,
  cs.monto_a_cobrar
FROM tbl_cita_servicio cs
JOIN tbl_citas c          ON c.pk_id_cita = cs.fk_id_cita
JOIN tbl_clientes cli     ON cli.pk_id_cliente = c.fk_id_cliente
LEFT JOIN tbl_servicios sd ON sd.pk_id_servicio = cs.fk_id_servicio
LEFT JOIN tbl_paquetes p   ON p.pk_id_paquete = cs.fk_id_paquete
LEFT JOIN tbl_paquete_servicio ps 
       ON ps.fk_id_paquete = cs.fk_id_paquete 
      AND ps.numero_sesion = cs.numero_sesion
LEFT JOIN tbl_servicios sp ON sp.pk_id_servicio = ps.fk_id_servicio
WHERE c.pk_id_cita = 1
ORDER BY cs.pk_id_cita_servicio;

-- 4.2 Total pagado y saldo pendiente
SELECT 
  c.pk_id_cita,
  cli.nombre,
  c.fecha_cita,
  COALESCE(SUM(pg.monto),0) AS total_pagado_en_cita,
  (c.total - COALESCE(SUM(pg.monto),0)) AS saldo_restante
FROM tbl_pagos pg
JOIN tbl_citas c      ON c.pk_id_cita = pg.fk_id_cita
JOIN tbl_clientes cli ON cli.pk_id_cliente = c.fk_id_cliente
WHERE c.pk_id_cita = 1
GROUP BY c.pk_id_cita, cli.nombre, c.fecha_cita;

SELECT * FROM tbl_citas;
