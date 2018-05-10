/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : task

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2018-05-10 21:21:30
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for tb_achievement
-- ----------------------------
DROP TABLE IF EXISTS `tb_achievement`;
CREATE TABLE `tb_achievement` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `content` text,
  `status` varchar(50) DEFAULT NULL,
  `is_deleted` bit(1) DEFAULT NULL,
  `creator` int(8) DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `pass_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for tb_task
-- ----------------------------
DROP TABLE IF EXISTS `tb_task`;
CREATE TABLE `tb_task` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `content` varchar(200) DEFAULT NULL,
  `is_public` bit(1) DEFAULT NULL,
  `is_deleted` bit(1) DEFAULT NULL,
  `time_limit` datetime DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `creator` int(8) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `belongs_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for tb_user
-- ----------------------------
DROP TABLE IF EXISTS `tb_user`;
CREATE TABLE `tb_user` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) DEFAULT NULL,
  `nick_name` varchar(50) DEFAULT NULL,
  `password` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
