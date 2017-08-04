CREATE DATABASE  IF NOT EXISTS `friendship` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `friendship`;

DROP TABLE IF EXISTS users;
CREATE TABLE IF NOT EXISTS users (
	id int auto_increment,
    first_name varchar(55),
    last_name varchar(55),
    created_at DATETIME,
    updated_at DATETIME,
    PRIMARY KEY(id));
    
DROP TABLE IF EXISTS friends;
CREATE TABLE IF NOT EXISTS friends (
	id int auto_increment,
    user_id int,
    friend_id int,
    created_at DATETIME,
    updated_at DATETIME,
    PRIMARY KEY(id));
    
SELECT CONCAT(users.first_name, " ", users.last_name) as UserName, CONCAT(users2.first_name," ",users2.last_name) as FriendName
FROM users
JOIN friends
ON users.id = friends.user_id
JOIN users as users2
ON users2.id = friends.friend_id
ORDER BY UserName;