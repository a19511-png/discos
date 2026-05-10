-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 10-Maio-2026 às 18:13
-- Versão do servidor: 10.4.32-MariaDB
-- versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `discos`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `artista`
--

CREATE TABLE `artista` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `nacionalidade` varchar(255) NOT NULL,
  `data_de_nascimento` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `artista_disco`
--

CREATE TABLE `artista_disco` (
  `id_artista` int(11) NOT NULL,
  `id_disco` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `disco`
--

CREATE TABLE `disco` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `ano` int(4) NOT NULL,
  `id_genero` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `faixa`
--

CREATE TABLE `faixa` (
  `id` int(11) NOT NULL,
  `id_disco` int(11) NOT NULL,
  `descricao` varchar(2048) DEFAULT NULL,
  `duracao` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `genero`
--

CREATE TABLE `genero` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `genero`
--

INSERT INTO `genero` (`id`, `nome`) VALUES
(1, 'Funk'),
(2, 'Rock and roll');

-- --------------------------------------------------------

--
-- Estrutura da tabela `login`
--

CREATE TABLE `login` (
  `id` int(64) NOT NULL,
  `username` varchar(50) NOT NULL,
  `passwd` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `login`
--

INSERT INTO `login` (`id`, `username`, `passwd`) VALUES
(0, 'admin', 'admin123');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `artista`
--
ALTER TABLE `artista`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `artista_disco`
--
ALTER TABLE `artista_disco`
  ADD PRIMARY KEY (`id_artista`,`id_disco`),
  ADD KEY `fk_ad_disco` (`id_disco`);

--
-- Índices para tabela `disco`
--
ALTER TABLE `disco`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_disco_genero` (`id_genero`);

--
-- Índices para tabela `faixa`
--
ALTER TABLE `faixa`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_faixa_disco` (`id_disco`);

--
-- Índices para tabela `genero`
--
ALTER TABLE `genero`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `artista`
--
ALTER TABLE `artista`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `disco`
--
ALTER TABLE `disco`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `faixa`
--
ALTER TABLE `faixa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `genero`
--
ALTER TABLE `genero`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `artista_disco`
--
ALTER TABLE `artista_disco`
  ADD CONSTRAINT `fk_ad_artista` FOREIGN KEY (`id_artista`) REFERENCES `artista` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_ad_disco` FOREIGN KEY (`id_disco`) REFERENCES `disco` (`id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `disco`
--
ALTER TABLE `disco`
  ADD CONSTRAINT `fk_disco_genero` FOREIGN KEY (`id_genero`) REFERENCES `genero` (`id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `faixa`
--
ALTER TABLE `faixa`
  ADD CONSTRAINT `fk_faixa_disco` FOREIGN KEY (`id_disco`) REFERENCES `disco` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
