SHOW DATABASES;
CREATE database elective3_db;
USE elective3_db;
SHOW TABLES;
SELECT * FROM elective3db_table; 
DROP TABLE elective3db_table;
SHOW TABLES;
CREATE TABLE elective3db_table(id INTEGER PRIMARY KEY AUTO_INCREMENT, bike_number TEXT, user_name TEXT, time_left TEXT, time_start TEXT, time_end TEXT, isAvailable TEXT, isPaid TEXT);
INSERT INTO elective3db_table(bike_number, user_name, time_left, time_start, time_end, isAvailable, isPaid) VALUES ('1', 'steven', '60', '1:20', '2:20', 'True', 'False');
INSERT INTO elective3db_table(bike_number, user_name, time_left, time_start, time_end, isAvailable, isPaid) VALUES ('5', '', 0, '', '', true, false);
USE elective3;
UPDATE `elective3_db`.`elective3db_table` SET `user_name`='jen', `time_left`='1', `time_start`='1:11', `time_end`='1:12', `isAvailable`='False', `isPaid`='True' WHERE bike_number='1';
UPDATE elective3db_table SET user_name = 'helllllloooooooooo' WHERE bike_number = '1';

SELECT email FROM elective3 WHERE email = '004@yahoo.com';

