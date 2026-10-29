-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 29, 2026 at 08:07 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eshift_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `assistants`
--

CREATE TABLE `assistants` (
  `AssistantID` int(11) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Status` enum('AVAILABLE','ASSIGNED','ON DUTY','OFF DUTY') NOT NULL DEFAULT 'AVAILABLE',
  `CreatedAt` date DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `assistants`
--

INSERT INTO `assistants` (`AssistantID`, `FullName`, `Phone`, `Status`, `CreatedAt`) VALUES
(1, 'Demal Perara', '0712345672', 'ASSIGNED', '2026-10-20'),
(2, 'Dewan Jeens', '072345677', 'AVAILABLE', '2026-10-20');

-- --------------------------------------------------------

--
-- Table structure for table `containers`
--

CREATE TABLE `containers` (
  `ContainerID` int(11) NOT NULL,
  `ContainerNumber` varchar(30) NOT NULL,
  `CapacityKg` decimal(10,2) NOT NULL,
  `Status` enum('AVAILABLE','ASSIGNED','MAINTENANCE') NOT NULL DEFAULT 'AVAILABLE',
  `CreatedAt` date DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `containers`
--

INSERT INTO `containers` (`ContainerID`, `ContainerNumber`, `CapacityKg`, `Status`, `CreatedAt`) VALUES
(1, 'CONT001', 500.00, 'AVAILABLE', '2026-10-20'),
(2, 'CONT002', 750.00, 'ASSIGNED', '2026-10-20'),
(3, 'CONT003', 1000.00, 'AVAILABLE', '2026-10-20'),
(4, 'CONT004', 600.00, 'AVAILABLE', '2026-10-20'),
(5, 'CONT011', 100.00, 'AVAILABLE', '2026-10-20');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `CustomerID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Address` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`CustomerID`, `UserID`, `Phone`, `Address`) VALUES
(1, 1, '0765431234', 'Matara'),
(2, 2, '071176254', 'Galle'),
(3, 5, '071165423', 'Matara');

-- --------------------------------------------------------

--
-- Table structure for table `drivers`
--

CREATE TABLE `drivers` (
  `DriverID` int(11) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `LicenceNumber` varchar(50) NOT NULL,
  `Status` enum('AVAILABLE','ASSIGNED','ON DUTY','OFF DUTY') NOT NULL DEFAULT 'AVAILABLE',
  `CreatedAt` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `drivers`
--

INSERT INTO `drivers` (`DriverID`, `FullName`, `Phone`, `LicenceNumber`, `Status`, `CreatedAt`) VALUES
(1, 'Kamal Perera', '0771234567', 'B1234567', 'ASSIGNED', '2026-10-20'),
(2, 'Sam Perera', '074321245', 'FT786754', 'AVAILABLE', '2026-10-20'),
(3, 'Desal', '07123456', 'DR34567', 'AVAILABLE', '2026-10-20');

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

CREATE TABLE `jobs` (
  `JobID` int(11) NOT NULL,
  `JobNumber` varchar(30) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `PickupLocation` varchar(250) NOT NULL,
  `Destination` varchar(250) NOT NULL,
  `RequestedDate` date NOT NULL,
  `Status` enum('PENDING','ACCEPTED','DECLINED','IN_PROGRESS','COMPLETED','CANCELLED') NOT NULL DEFAULT 'PENDING',
  `CreatedAt` datetime NOT NULL DEFAULT current_timestamp(),
  `DeclineReason` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`JobID`, `JobNumber`, `CustomerID`, `PickupLocation`, `Destination`, `RequestedDate`, `Status`, `CreatedAt`, `DeclineReason`) VALUES
(7, 'JOB553AC3CCFDD2', 3, 'Jaffana', 'Matara', '2026-10-23', 'COMPLETED', '2026-10-23 08:57:48', NULL),
(8, 'JOB1F594F3B312E', 3, 'Matara', 'Galle', '2026-10-26', 'ACCEPTED', '2026-10-26 09:16:01', NULL),
(9, 'JOBAB5D0F3A1C88', 3, 'Matara', 'Galle', '2026-10-29', 'PENDING', '2026-10-29 11:44:42', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `loads`
--

CREATE TABLE `loads` (
  `LoadID` int(11) NOT NULL,
  `LoadNumber` varchar(30) NOT NULL,
  `JobID` int(11) NOT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `Description` varchar(250) NOT NULL,
  `Quantity` int(11) NOT NULL DEFAULT 1,
  `WeightKg` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loads`
--

INSERT INTO `loads` (`LoadID`, `LoadNumber`, `JobID`, `ProductID`, `Description`, `Quantity`, `WeightKg`) VALUES
(8, 'JOB553AC3CCFDD2-L01', 7, 4, 'Dining Table', 1, 0.01),
(9, 'JOB1F594F3B312E-L01', 8, 4, 'Dining Table', 1, 0.01),
(10, 'JOB1F594F3B312E-L02', 8, 1, 'Sofa', 1, 1.00),
(11, 'JOBAB5D0F3A1C88-L01', 9, 1, 'Sofa', 1, 0.01);

-- --------------------------------------------------------

--
-- Table structure for table `lorries`
--

CREATE TABLE `lorries` (
  `LorryID` int(11) NOT NULL,
  `RegistrationNumber` varchar(30) NOT NULL,
  `CapacityKg` decimal(10,2) NOT NULL,
  `Status` enum('AVAILABLE','ASSIGNED','MAINTENANCE') NOT NULL DEFAULT 'AVAILABLE',
  `CreatedAt` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lorries`
--

INSERT INTO `lorries` (`LorryID`, `RegistrationNumber`, `CapacityKg`, `Status`, `CreatedAt`) VALUES
(1, 'WP-ABC-1234', 2500.00, 'AVAILABLE', '2026-10-19'),
(2, 'WP-CAB-5678', 5000.00, 'AVAILABLE', '2026-10-19'),
(3, 'WP-DEF-9012', 3500.00, 'ASSIGNED', '2026-10-19'),
(4, 'WP-GHI-3456', 7500.00, 'AVAILABLE', '2026-10-19'),
(5, 'WP-JKL-7890', 10000.00, 'AVAILABLE', '2026-10-19'),
(6, 'WP-JYU-6744', 2000.00, 'AVAILABLE', '2026-10-20');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `ProductName` varchar(100) NOT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductName`, `Description`, `IsActive`) VALUES
(1, 'Sofa', 'Household sofa for transportation', 1),
(2, 'Refrigerator', 'Domestic refrigerator', 0),
(3, 'Washing Machine', 'Household washing machine', 1),
(4, 'Dining Table', 'Dining table and chairs', 1),
(5, 'Wardrobe', 'Bedroom storage wardrobe', 1),
(6, 'Cardboard Box', 'Box for packing household goods', 1),
(7, 'test', 'test', 1);

-- --------------------------------------------------------

--
-- Table structure for table `transportassignments`
--

CREATE TABLE `transportassignments` (
  `AssignmentID` int(11) NOT NULL,
  `JobID` int(11) NOT NULL,
  `LorryID` int(11) NOT NULL,
  `DriverID` int(11) NOT NULL,
  `AssistantID` int(11) NOT NULL,
  `ContainerID` int(11) NOT NULL,
  `AssignedAt` datetime DEFAULT current_timestamp(),
  `Status` enum('ASSIGNED','RELEASED') NOT NULL DEFAULT 'ASSIGNED'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transportassignments`
--

INSERT INTO `transportassignments` (`AssignmentID`, `JobID`, `LorryID`, `DriverID`, `AssistantID`, `ContainerID`, `AssignedAt`, `Status`) VALUES
(6, 7, 2, 1, 1, 3, '2026-10-23 08:59:03', 'RELEASED'),
(7, 8, 3, 1, 1, 2, '2026-10-29 11:35:16', 'ASSIGNED');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Role` enum('ADMIN','CUSTOMER') NOT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 1,
  `CreatedAt` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `FullName`, `Email`, `PasswordHash`, `Role`, `IsActive`, `CreatedAt`) VALUES
(1, 'Nadeesha', 'nadeesha@gmail.com', 'PBKDF2$100000$I+BlLKdqSFR4j3IZtfbpIw==$jzpc0P642bwilnoUMkrt6pwEW+AsB5xLjWmUVNqfEqE=', 'CUSTOMER', 1, '2026-10-17'),
(2, 'Saman Kumara', 'saman@gmail.com', 'PBKDF2$100000$4n0kCP3CSttmzD7CXuTx7A==$B5v1L7+I0wP+OSu22/xeNNkmhJ1aA22X3k6OA4IUZdI=', 'CUSTOMER', 1, '2026-10-19'),
(3, 'Himal Kavisha', 'himal@gmail.com', 'PBKDF2$100000$c9bhG1k+y2Q+amYoOFFdBQ==$v7jJiIjIh7RJNez6tj4xJB5Grbpq09b97Mx3Qf++ac4=', 'ADMIN', 1, '2026-10-19'),
(4, 'Siman Kavee', 'siman@gmail.com', 'PBKDF2$100000$tD+kVfa3AQUlVVExYtP5zQ==$d+9BGTXrvVQr53Pl93jcwPc7Zfe64jjYQwAr3OyA+6Y=', 'ADMIN', 1, '2026-10-23'),
(5, 'Nimal Perara', 'nimal@gmail.com', 'PBKDF2$100000$CyNByymlEdZUo+rgVE93xg==$Oq90aN9WCTOLKE4MGcUn5UJ7uMSsZsqHf8Xzt4k8maE=', 'CUSTOMER', 1, '2026-10-23');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `assistants`
--
ALTER TABLE `assistants`
  ADD PRIMARY KEY (`AssistantID`);

--
-- Indexes for table `containers`
--
ALTER TABLE `containers`
  ADD PRIMARY KEY (`ContainerID`),
  ADD UNIQUE KEY `ContainerNumber` (`ContainerNumber`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`CustomerID`),
  ADD UNIQUE KEY `UserID` (`UserID`);

--
-- Indexes for table `drivers`
--
ALTER TABLE `drivers`
  ADD PRIMARY KEY (`DriverID`),
  ADD UNIQUE KEY `LicenceNumber` (`LicenceNumber`);

--
-- Indexes for table `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`JobID`),
  ADD UNIQUE KEY `JobNumber` (`JobNumber`),
  ADD KEY `FK_Jobs_Customers` (`CustomerID`);

--
-- Indexes for table `loads`
--
ALTER TABLE `loads`
  ADD PRIMARY KEY (`LoadID`),
  ADD UNIQUE KEY `LoadNumber` (`LoadNumber`),
  ADD KEY `FK_Loads_Jobs` (`JobID`),
  ADD KEY `FK_Loads_Products` (`ProductID`);

--
-- Indexes for table `lorries`
--
ALTER TABLE `lorries`
  ADD PRIMARY KEY (`LorryID`),
  ADD UNIQUE KEY `RegistrationNumber` (`RegistrationNumber`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`);

--
-- Indexes for table `transportassignments`
--
ALTER TABLE `transportassignments`
  ADD PRIMARY KEY (`AssignmentID`),
  ADD KEY `JobID` (`JobID`),
  ADD KEY `LorryID` (`LorryID`),
  ADD KEY `DriverID` (`DriverID`),
  ADD KEY `AssistantID` (`AssistantID`),
  ADD KEY `ContainerID` (`ContainerID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `assistants`
--
ALTER TABLE `assistants`
  MODIFY `AssistantID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `containers`
--
ALTER TABLE `containers`
  MODIFY `ContainerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `drivers`
--
ALTER TABLE `drivers`
  MODIFY `DriverID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
  MODIFY `JobID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `loads`
--
ALTER TABLE `loads`
  MODIFY `LoadID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `lorries`
--
ALTER TABLE `lorries`
  MODIFY `LorryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `transportassignments`
--
ALTER TABLE `transportassignments`
  MODIFY `AssignmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customers`
--
ALTER TABLE `customers`
  ADD CONSTRAINT `FK_Customers_Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON UPDATE CASCADE;

--
-- Constraints for table `jobs`
--
ALTER TABLE `jobs`
  ADD CONSTRAINT `FK_Jobs_Customers` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`) ON UPDATE CASCADE;

--
-- Constraints for table `loads`
--
ALTER TABLE `loads`
  ADD CONSTRAINT `FK_Loads_Jobs` FOREIGN KEY (`JobID`) REFERENCES `jobs` (`JobID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_Loads_Products` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `transportassignments`
--
ALTER TABLE `transportassignments`
  ADD CONSTRAINT `transportassignments_ibfk_1` FOREIGN KEY (`JobID`) REFERENCES `jobs` (`JobID`),
  ADD CONSTRAINT `transportassignments_ibfk_2` FOREIGN KEY (`LorryID`) REFERENCES `lorries` (`LorryID`),
  ADD CONSTRAINT `transportassignments_ibfk_3` FOREIGN KEY (`DriverID`) REFERENCES `drivers` (`DriverID`),
  ADD CONSTRAINT `transportassignments_ibfk_4` FOREIGN KEY (`AssistantID`) REFERENCES `assistants` (`AssistantID`),
  ADD CONSTRAINT `transportassignments_ibfk_5` FOREIGN KEY (`ContainerID`) REFERENCES `containers` (`ContainerID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
