-- ===========================================
-- BD SPA con control de paquetes mejorado
-- Solución para evitar doble cobro en paquetes
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

-- Tabla de control de paquetes del cliente (MEJORADA)
CREATE TABLE IF NOT EXISTS tbl_cliente_paquete (
    pk_id_cliente_paquete INT PRIMARY KEY AUTO_INCREMENT,
    fk_id_cliente INT NOT NULL,
    fk_id_paquete INT NOT NULL,
    fecha_compra DATE NOT NULL,
    sesiones_usadas INT DEFAULT 0,
    saldo_pendiente DECIMAL(10,2) NOT NULL DEFAULT 0,
    estado ENUM('En uso','Finalizado') DEFAULT 'En uso',
    fk_id_cita_compra INT NULL, -- Cita donde se compró el paquete
    FOREIGN KEY (fk_id_cliente) REFERENCES tbl_clientes(pk_id_cliente),
    FOREIGN KEY (fk_id_paquete) REFERENCES tbl_paquetes(pk_id_paquete),
    INDEX idx_cliente_paquete_activo (fk_id_cliente, fk_id_paquete, estado)
);

CREATE TABLE IF NOT EXISTS tbl_citas (
    pk_id_cita INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cliente INT,
    fecha_cita DATE,
    estado VARCHAR(50) DEFAULT 'Pendiente',
    total DECIMAL(10,2) DEFAULT 0,             -- suma de montos a cobrar (NO precios originales)
    saldo_pendiente DECIMAL(10,2) DEFAULT 0,   -- se va reduciendo con pagos
    FOREIGN KEY (fk_id_cliente) REFERENCES tbl_clientes(pk_id_cliente)
);

-- Detalle de la cita (MEJORADA con control de cobro)
CREATE TABLE IF NOT EXISTS tbl_cita_servicio (
    pk_id_cita_servicio INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cita INT NOT NULL,
    fk_id_servicio INT NULL,        -- Para servicios individuales
    fk_id_paquete INT NULL,         -- Para paquetes
    numero_sesion INT NULL,         -- Número de sesión del paquete (si aplica)
    costo_referencia DECIMAL(10,2) NOT NULL, -- Precio "teórico" del servicio/paquete
    monto_a_cobrar DECIMAL(10,2) NOT NULL DEFAULT 0, -- Lo que realmente se cobra al cliente
    fk_id_cliente_paquete INT NULL, -- Referencia al paquete del cliente (si aplica)
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    FOREIGN KEY (fk_id_cita) REFERENCES tbl_citas(pk_id_cita),
    FOREIGN KEY (fk_id_servicio) REFERENCES tbl_servicios(pk_id_servicio),
    FOREIGN KEY (fk_id_paquete) REFERENCES tbl_paquetes(pk_id_paquete),
    FOREIGN KEY (fk_id_cliente_paquete) REFERENCES tbl_cliente_paquete(pk_id_cliente_paquete),
    
    -- Constraint para asegurar que sea O servicio individual O paquete
    CHECK (
        (fk_id_servicio IS NOT NULL AND fk_id_paquete IS NULL AND numero_sesion IS NULL AND fk_id_cliente_paquete IS NULL) OR
        (fk_id_servicio IS NULL AND fk_id_paquete IS NOT NULL AND numero_sesion IS NOT NULL)
    ),
    
    INDEX idx_cita_servicio (fk_id_cita),
    INDEX idx_paquete_sesion (fk_id_paquete, numero_sesion)
);

-- ===========================================
-- 2) PAGOS
-- ===========================================

CREATE TABLE IF NOT EXISTS tbl_pagos (
    pk_id_pago INT AUTO_INCREMENT PRIMARY KEY,
    fk_id_cita INT NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,
    fecha_pago DATE NOT NULL,
    nota TEXT NULL,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (fk_id_cita) REFERENCES tbl_citas(pk_id_cita)
);

select * from tbl_pagos;
-- Agregar campo 'estado' a tbl_cliente_paquete
ALTER TABLE tbl_cliente_paquete 
ADD COLUMN estado_eliminado TINYINT DEFAULT 1;

-- Agregar campo 'estado' a tbl_citas
ALTER TABLE tbl_citas 
ADD COLUMN estado_eliminado TINYINT DEFAULT 1;

-- Agregar campo 'estado' a tbl_cita_servicio
ALTER TABLE tbl_cita_servicio 
ADD COLUMN estado_eliminado TINYINT DEFAULT 1;

ALTER TABLE tbl_pagos 
ADD COLUMN estado_eliminado TINYINT DEFAULT 1;

select* from tbl_cliente_paquete ;
select* from tbl_citas ;
select* from tbl_cita_servicio ;
