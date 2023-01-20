-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 22, 2022 at 04:04 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `city_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_info`
--

CREATE TABLE `admin_info` (
  `Code` varchar(5) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin_info`
--

INSERT INTO `admin_info` (`Code`, `username`, `password`, `Email`, `Name`) VALUES
('242', 'alemam', '242', 'aryansuvo017@gmail.com', 'Al Emam'),
('261', 'anupam', '261', 'anupam@gmail.com', 'Anupam Kumar'),
('272', 'faruvai', '272', '19202103272@cse.bubt.edu.bd', 'Farhan');

-- --------------------------------------------------------

--
-- Table structure for table `bus_info`
--

CREATE TABLE `bus_info` (
  `bus_code` varchar(10) DEFAULT NULL,
  `driver_id` varchar(10) DEFAULT NULL,
  `supervisor_id` varchar(10) DEFAULT NULL,
  `available_sit` int(11) NOT NULL DEFAULT 40
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `bus_info`
--

INSERT INTO `bus_info` (`bus_code`, `driver_id`, `supervisor_id`, `available_sit`) VALUES
('B101', 'D111', 'S111', 31),
('B102', 'D112', 'S112', 34),
('B103', 'D113', 'S113', 40),
('B104', 'D114', 'S114', 40),
('B105', 'D115', 'S115', 40);

-- --------------------------------------------------------

--
-- Table structure for table `driver_info`
--

CREATE TABLE `driver_info` (
  `driver_id` varchar(10) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `dri_lic_no` varchar(100) DEFAULT NULL,
  `phone` varchar(15) NOT NULL DEFAULT '+880'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `driver_info`
--

INSERT INTO `driver_info` (`driver_id`, `name`, `dri_lic_no`, `phone`) VALUES
('D111', 'Ohi', '10203040', '01710101010'),
('D112', 'Rahul', '11223344', '016121212100'),
('D113', 'Kawsar', '15975365', '01898989898'),
('D114', 'Jihad', '98765321', '01563636363'),
('D115', 'Rakib', '586532109', '01965981265');

-- --------------------------------------------------------

--
-- Table structure for table `route`
--

CREATE TABLE `route` (
  `from_where` varchar(100) NOT NULL,
  `to_where` varchar(100) NOT NULL,
  `fare` int(11) NOT NULL,
  `time` varchar(100) NOT NULL,
  `bus_code` varchar(10) NOT NULL,
  `route_no` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `route`
--

INSERT INTO `route` (`from_where`, `to_where`, `fare`, `time`, `bus_code`, `route_no`) VALUES
('Mirpur-1', 'Gabtoli', 30, '9 AM', 'B101', 'R1'),
('Abdullahpur', 'Banani', 40, '10 AM', 'B102', 'R10'),
('Abdullahpur', 'Paltan', 50, '10 AM', 'B102', 'R11'),
('Mirpur-2', 'Airport', 40, '8:45 AM', 'B102', 'R2'),
('Mirpur-1', 'Airport', 30, '8:15 AM', 'B102', 'R3'),
('Mirpur-1', 'Gabtoli', 40, '8:30 AM', 'B102', 'R4'),
('Airport', 'Mirur-2', 40, '9 AM', 'B103', 'R5'),
('Kamlapur', 'Mirpur-2', 40, '9:30 AM', 'B104', 'R6'),
('Abdullahpur', 'Azampur', 20, '10 AM', 'B102', 'R7'),
('Abdullahpur', 'Khilkhet', 40, '10 AM', 'B102', 'R9');

-- --------------------------------------------------------

--
-- Table structure for table `supervisor_info`
--

CREATE TABLE `supervisor_info` (
  `superviser_id` varchar(10) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `nid` varchar(50) DEFAULT NULL,
  `phone` varchar(15) NOT NULL DEFAULT '+880',
  `pass` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supervisor_info`
--

INSERT INTO `supervisor_info` (`superviser_id`, `name`, `nid`, `phone`, `pass`) VALUES
('S111', 'Riyad', '198203654', '01654985498', 'S111'),
('S112', 'Nahid', '193265489', '01365982198', 'S112'),
('S113', 'Rasel', '896554134', '01574632541', 'S113'),
('S114', 'Alom', '984615621', '01985212374', 'S114'),
('S115', 'Jibon', '143249815', '01754896321', 'S115');

-- --------------------------------------------------------

--
-- Table structure for table `ticket_info`
--

CREATE TABLE `ticket_info` (
  `ticket_code` varchar(100) NOT NULL,
  `passenger_name` varchar(100) DEFAULT NULL,
  `from_where` varchar(100) NOT NULL,
  `to_where` varchar(100) NOT NULL,
  `bus_id` varchar(20) DEFAULT NULL,
  `booked_sit` int(11) DEFAULT NULL,
  `date` varchar(20) DEFAULT NULL,
  `time` varchar(20) DEFAULT NULL,
  `total_fare` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ticket_info`
--

INSERT INTO `ticket_info` (`ticket_code`, `passenger_name`, `from_where`, `to_where`, `bus_id`, `booked_sit`, `date`, `time`, `total_fare`) VALUES
('CT166429AS', 'Al Emam', 'Mirpur-1', 'Gabtoli', 'B101', 1, '03-22-2022', '8 AM', 30),
('CT410699AS', 'Al Emam', 'Mirpur-1', 'Gabtoli', 'B101', 2, '03-23-2022', '8 AM', 60),
('CT41237AS', 'Al Emam', 'Mirpur-1', 'Gabtoli', 'B101', 1, '03-24-2022', '8 AM', 30),
('CT503371AS', 'Anupam', 'Mirpur-1', 'Gabtoli', 'B101', 1, '03-06-2022', '8 AM', 30),
('CT624993AS', 'Al Emam', 'Mirpur-1', 'Gabtoli', 'B102', 1, '03-21-2022', '8:30 AM', 40),
('CT864310AS', 'Al Emam', 'Mirpur-1', 'Gabtoli', 'B102', 1, '03-25-2022', '8:30 AM', 40),
('TC37568CT', 'Albert Einstein', 'Mirpur-1', 'Gabtoli', 'B101', 1, '03-18-2022', '8 AM', 30),
('TC46191CT', 'Farhan', 'Mirpur-1', 'Gabtoli', 'B101', 3, '03-18-2022', '8 AM', 90),
('TC49258CT', 'Farhan', 'Mirpur-1', 'Gabtoli', 'B101', 3, '03-18-2022', '8 AM', 90);

-- --------------------------------------------------------

--
-- Table structure for table `user_info`
--

CREATE TABLE `user_info` (
  `name` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(20) NOT NULL,
  `email` varchar(255) NOT NULL,
  `gender` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user_info`
--

INSERT INTO `user_info` (`name`, `username`, `password`, `email`, `gender`) VALUES
('Albert Einstein', 'albert', '12345', 'alberteinstein@gmail.com', 'Male'),
('Farhan', 'farhan', '272', '19202103272@cse.bubt.edu.bd', 'Male'),
('Anupam', 'halum', 'halum', 'anupomkumar60607@gmail.com', 'Male'),
('Al Emam', 'suvo', '123', '19202103261@cse.bubt.edu.bd', 'Male'),
('Walid Al Hasan', 'walid', '271', 'walid@gmail.com', 'Male');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin_info`
--
ALTER TABLE `admin_info`
  ADD PRIMARY KEY (`Code`);

--
-- Indexes for table `route`
--
ALTER TABLE `route`
  ADD PRIMARY KEY (`route_no`);

--
-- Indexes for table `ticket_info`
--
ALTER TABLE `ticket_info`
  ADD PRIMARY KEY (`ticket_code`);

--
-- Indexes for table `user_info`
--
ALTER TABLE `user_info`
  ADD UNIQUE KEY `username` (`username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
