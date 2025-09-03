-- ===========================================
-- 3) Datos de ejemplo
-- ===========================================

INSERT INTO tbl_clientes (nombre, telefono, es_vip)
VALUES ('Juan Pérez', '555-1234', 1);

select* from tbl_clientes;

INSERT INTO tbl_servicios (nombre, precio) VALUES
('Facial Hidratante', 40.00),
('Masaje Relajante', 50.00),
('Ejercicio Asistido', 60.00),
('Estiramiento Terapéutico', 45.00);

select* from tbl_servicios;

-- Paquete de 5 sesiones
INSERT INTO tbl_paquetes (nombre, precio_total, numero_sesiones)
VALUES ('Terapia Física – 5 sesiones', 500.00, 5);


select* from tbl_paquetes;

-- Definir las sesiones
INSERT INTO tbl_paquete_servicio (fk_id_paquete, fk_id_servicio, numero_sesion) VALUES
(1, 2, 1), 
(1, 3, 2),
(1, 2, 3),
(1, 4, 4),
(1, 3, 5);

select* from tbl_paquete_servicio;

-- Cita con servicio suelto + sesión 1 del paquete
INSERT INTO tbl_citas (fk_id_cliente, fecha_cita, estado, total, saldo_pendiente)
VALUES (1, '2025-08-28', 'Programada', 540, 540);  -- 40+50 ejemplo

INSERT INTO tbl_cita_servicio (fk_id_cita, fk_id_servicio, costo)
VALUES (1, 1, 40.00);

INSERT INTO tbl_cita_servicio (fk_id_cita, fk_id_paquete, numero_sesion, costo)
VALUES (1, 1, 1, 500.00);
select* from tbl_cita_servicio;
-- PAGOS
-- Pago del servicio suelto
INSERT INTO tbl_pagos (fk_id_cita, monto, metodo_pago, fecha_pago, nota)
VALUES (1, 40.00, 'Efectivo', '2025-08-28', 'Facial suelto');

-- Pago del paquete en dos cuotas (VIP)
INSERT INTO tbl_pagos (fk_id_cita, monto, metodo_pago, fecha_pago, nota)
VALUES 
(1, 250.00, 'Efectivo', '2025-08-28', '1a cuota paquete'),
(1, 250.00, 'Transferencia', '2025-09-10', '2a cuota paquete');

-- ===========================================
-- 4) Consultas útiles (ajustadas)
-- ===========================================

-- 4.1 Detalle de la cita
SELECT 
  c.pk_id_cita,
  cli.nombre AS cliente,
  c.fecha_cita,
  sd.nombre AS servicio_suelto,
  p.nombre  AS paquete,
  cs.numero_sesion,
  sp.nombre AS servicio_de_la_sesion
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

-- 4.2 Total pagado por la cita
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


select* from tbl_citas;