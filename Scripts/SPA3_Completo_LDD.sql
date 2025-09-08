-- ===========================================
-- BD simple con paquetes por sesión + pagos
-- ===========================================
CREATE DATABASE IF NOT EXISTS BD_SPADos;
USE BD_SPADos;

-- ===========================================
-- 1) Tablas base
-- ===========================================
CREATE TABLE IF NOT EXISTS tbl_clientes (
    pk_id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    telefono VARCHAR(20),
    correo VARCHAR(100),
    es_vip BOOLEAN DEFAULT 0 -- 0 = normal, 1 = cliente frecuente/VIP
);

CREATE TABLE IF NOT EXISTS tbl_servicios (
    pk_id_servicio INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_paquetes (
    pk_id_paquete INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    precio_total DECIMAL(10,2) NOT NULL,
    numero_sesiones INT NOT NULL
);

-- Servicios del paquete en ORDEN
CREATE TABLE IF NOT EXISTS tbl_paquete_servicio (
    pk_id_paquete_servicio INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_paquete INT NOT NULL,
    fk_id_servicio INT NOT NULL,
    numero_sesion INT NOT NULL,
    FOREIGN KEY (fk_id_paquete) REFERENCES tbl_paquetes(pk_id_paquete),
    FOREIGN KEY (fk_id_servicio) REFERENCES tbl_servicios(pk_id_servicio),
    UNIQUE (fk_id_paquete, numero_sesion)
);

CREATE TABLE tbl_cliente_paquete (
    pk_id_cliente_paquete INT PRIMARY KEY AUTO_INCREMENT,
    fk_id_cliente INT NOT NULL,
    fk_id_paquete INT NOT NULL,
    fecha_compra DATE NOT NULL,
    sesiones_usadas INT DEFAULT 0,
    saldo_pendiente DECIMAL(10,2) NOT NULL,
    estado ENUM('En uso','Finalizado') DEFAULT 'En uso',
    FOREIGN KEY (fk_id_cliente) REFERENCES tbl_clientes(pk_id_cliente),
    FOREIGN KEY (fk_id_paquete) REFERENCES tbl_paquetes( pk_id_paquete)
);

CREATE TABLE IF NOT EXISTS tbl_citas (
    pk_id_cita INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cliente INT,
    fecha_cita DATE,
    estado VARCHAR(50),
    total DECIMAL(10,2),             -- suma de servicios y/o paquetes
    saldo_pendiente DECIMAL(10,2),   -- se va reduciendo con pagos
    FOREIGN KEY (fk_id_cliente) REFERENCES tbl_clientes(pk_id_cliente)
);

-- Detalle de la cita
CREATE TABLE IF NOT EXISTS tbl_cita_servicio (
    pk_id_cita_servicio INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cita INT,
    fk_id_servicio INT,
    fk_id_paquete INT NULL,
    numero_sesion INT NULL,  -- número de sesión del paquete (si aplica)
    costo DECIMAL(10,2),
    FOREIGN KEY (fk_id_cita) REFERENCES tbl_citas(pk_id_cita),
    FOREIGN KEY (fk_id_servicio) REFERENCES tbl_servicios(pk_id_servicio),
    FOREIGN KEY (fk_id_paquete) REFERENCES tbl_paquetes(pk_id_paquete),
    CHECK (
        (fk_id_servicio IS NOT NULL AND fk_id_paquete IS NULL AND numero_sesion IS NULL) OR
        (fk_id_servicio IS NULL AND fk_id_paquete IS NOT NULL AND numero_sesion IS NOT NULL)
    )
);

-- ===========================================
-- 2) PAGOS
-- ===========================================
CREATE TABLE IF NOT EXISTS tbl_pagos (
    pk_id_pago INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cita INT NULL,        -- pago por servicios sueltos de la cita
    monto DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,
    fecha_pago DATE NOT NULL,
    nota TEXT NULL,
    FOREIGN KEY (fk_id_cita) REFERENCES tbl_citas(pk_id_cita)
);

CREATE TABLE IF NOT EXISTS tbl_seguimiento_clientes (
  pk_id_seguimiento INT AUTO_INCREMENT PRIMARY KEY,
  fk_id_cliente     INT NOT NULL,
  fecha             DATE NOT NULL,
  servicio          VARCHAR(100) NOT NULL,
  monto             DECIMAL(10,2) NOT NULL,
  observaciones     VARCHAR(255) NULL,
  CONSTRAINT fk_seguimiento_cliente
    FOREIGN KEY (fk_id_cliente) REFERENCES tbl_clientes(pk_id_cliente)
    ON UPDATE CASCADE ON DELETE RESTRICT,
  INDEX idx_seguimiento_cliente (fk_id_cliente),
  INDEX idx_seguimiento_fecha (fecha)
);