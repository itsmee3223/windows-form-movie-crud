/*
SQLyog Ultimate v12.5.1 (64 bit)
MySQL - 10.4.21-MariaDB : Database - cobaaa
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`cobaaa` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `cobaaa`;

/*Table structure for table `tblactor` */

DROP TABLE IF EXISTS `tblactor`;

CREATE TABLE `tblactor` (
  `actId` varchar(50) NOT NULL,
  `actName` varchar(50) DEFAULT NULL,
  `actGender` varchar(50) DEFAULT NULL,
  `movId` varchar(50) NOT NULL,
  PRIMARY KEY (`actId`),
  KEY `movId` (`movId`),
  CONSTRAINT `tblactor_ibfk_1` FOREIGN KEY (`movId`) REFERENCES `tblmovie` (`movId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tblactor` */

insert  into `tblactor`(`actId`,`actName`,`actGender`,`movId`) values 
('1FDPUNOVjc','Martin Balsam','Male','ooQ0v3URhx'),
('bZjlFYnDeF','Lee J. Cobb','Male','ooQ0v3URhx'),
('HskAufIvH1','AI Pacino','Male','wjpNYExvsA'),
('jerAFAXShv','James Caan','Male','wjpNYExvsA'),
('L8vy1CFkDm','Morgan Freeman','Male','CkkIOxp3xw'),
('mkl31Kigvt','Henry Fonda','Male','ooQ0v3URhx'),
('MYDZLd1Kk7','Bob Gunton','Male','CkkIOxp3xw'),
('SBVoDHALaW','Marlon Brando','Male','wjpNYExvsA'),
('Y1MTziuw1n','Tim Robbins','Male','CkkIOxp3xw');

/*Table structure for table `tbldirector` */

DROP TABLE IF EXISTS `tbldirector`;

CREATE TABLE `tbldirector` (
  `dirId` varchar(50) NOT NULL,
  `dirName` varchar(50) DEFAULT NULL,
  `dirGender` char(10) DEFAULT NULL,
  `movId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`dirId`),
  KEY `tbldirector_ibfk_1` (`movId`),
  CONSTRAINT `tbldirector_ibfk_1` FOREIGN KEY (`movId`) REFERENCES `tblmovie` (`movId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbldirector` */

insert  into `tbldirector`(`dirId`,`dirName`,`dirGender`,`movId`) values 
('CH9X15GX7f','Frank Darabont','Male','CkkIOxp3xw'),
('d2n5JPR9kQ','Sidney Lumet','Male','ooQ0v3URhx'),
('os2aRN38vM','Francis Ford Coppola','Male','wjpNYExvsA');

/*Table structure for table `tblmovie` */

DROP TABLE IF EXISTS `tblmovie`;

CREATE TABLE `tblmovie` (
  `movId` varchar(50) NOT NULL,
  `movTitle` varchar(50) DEFAULT NULL,
  `movGenre` varchar(50) DEFAULT NULL,
  `movDate` date DEFAULT NULL,
  PRIMARY KEY (`movId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tblmovie` */

insert  into `tblmovie`(`movId`,`movTitle`,`movGenre`,`movDate`) values 
('CkkIOxp3xw','The Shawshank Redemption','Drama','1994-10-05'),
('nFdjFazOCp','Miasjai','slidah','2022-01-04'),
('ooQ0v3URhx','12 Angry Men','Crime, Drama','1957-06-18'),
('wjpNYExvsA','The Godfather','Crime, Drama','1972-04-14');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
