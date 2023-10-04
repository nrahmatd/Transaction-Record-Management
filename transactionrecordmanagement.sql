-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 04 Okt 2023 pada 18.24
-- Versi server: 10.1.37-MariaDB
-- Versi PHP: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `transactionrecordmanagement`
--

DELIMITER $$
--
-- Prosedur
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAddCustomer` (IN `p_Name` VARCHAR(200))  BEGIN
	INSERT INTO customers (Name) VALUES (p_NAME); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spAddTransaction` (IN `p_TransactionDate` DATETIME, IN `p_Description` VARCHAR(255), IN `p_DebitCreditStatus` VARCHAR(2), IN `p_Amount` DECIMAL(10,2), IN `p_AccountId` INT(11))  BEGIN
	INSERT INTO transaction (TransactionDate, Description, DebitCreditsStatus, Amount, AccountId) VALUES (p_TransactionDate, p_Description, p_DebitCreditStatus, p_Amount, p_AccountId); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteCustomer` (IN `p_AccountId` INT)  BEGIN
	DELETE FROM customers WHERE AccountId = p_AccountId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteTransaction` (IN `p_TransactionId` INT)  BEGIN
	DELETE FROM transaction WHERE TransactionId = p_TransactionId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAllCustomer` ()  BEGIN
    SELECT * FROM customers
    ORDER BY AccountId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAllTransaction` ()  BEGIN
    SELECT * FROM transaction
    ORDER BY TransactionId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCustomer` (IN `p_AccountId` INT, IN `p_Name` VARCHAR(200))  BEGIN
	UPDATE customers
    SET Name = p_Name
    WHERE AccountId = p_AccountId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateTransaction` (IN `p_TransactionId` INT, IN `p_AccountId` INT, IN `p_TransactionDate` DATETIME, IN `p_Description` VARCHAR(255), IN `p_DebitCreditStatus` VARCHAR(2), IN `p_Amount` DECIMAL(10,2))  BEGIN
    UPDATE transaction           
    SET AccountId = p_AccountId,          
    TransactionDate = p_TransactionDate,          
    Description = p_Description,        
    DebitCreditsStatus = p_DebitCreditStatus, 
    Amount = p_Amount          
    WHERE TransactionId = p_TransactionId;          
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `customers`
--

CREATE TABLE `customers` (
  `AccountId` int(11) NOT NULL,
  `Name` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `customers`
--

INSERT INTO `customers` (`AccountId`, `Name`) VALUES
(1, 'Jono'),
(2, 'Andi m');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaction`
--

CREATE TABLE `transaction` (
  `TransactionId` int(11) NOT NULL,
  `AccountId` int(11) DEFAULT NULL,
  `TransactionDate` datetime DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `DebitCreditsStatus` varchar(2) DEFAULT NULL,
  `Amount` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `transaction`
--

INSERT INTO `transaction` (`TransactionId`, `AccountId`, `TransactionDate`, `Description`, `DebitCreditsStatus`, `Amount`) VALUES
(5, 1, '2023-10-04 23:17:00', 'Setor Tunai', 'D', '200000.00');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`AccountId`);

--
-- Indeks untuk tabel `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`TransactionId`),
  ADD KEY `transaction_ibfk_1` (`AccountId`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `customers`
--
ALTER TABLE `customers`
  MODIFY `AccountId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT untuk tabel `transaction`
--
ALTER TABLE `transaction`
  MODIFY `TransactionId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`AccountId`) REFERENCES `customers` (`AccountId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
