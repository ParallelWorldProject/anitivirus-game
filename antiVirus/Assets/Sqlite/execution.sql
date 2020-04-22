CREATE TABLE storyinfo(
    id INTEGER PRIMARY KEY NOT NULL,
    userid INT NOT NULL,
    round INT NOT NULL,
    day INT NOT NULL,
    startTime DATE NOT NULL,
    endTime DATE,
    status int NOT NULL
);
    
DROP TABLE storyinfo;

INSERT INTO storyinfo (userid,round,day,startTime,status)
VALUES (1,1,1,'2019-01-01',0);


