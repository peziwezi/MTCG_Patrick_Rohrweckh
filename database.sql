CREATE TABLE IF NOT EXISTS users (
  id SERIAL PRIMARY KEY,
  username VARCHAR(50) NOT NULL UNIQUE,
  password VARCHAR(50) NOT NULL,
  elo INT DEFAULT 0,
  coins INT DEFAULT 0
);

CREATE TABLE IF NOT EXISTS cards (
id VARCHAR(50) PRIMARY KEY,
name VARCHAR(50) NOT NULL,
damage FLOAT(24) DEFAULT 0
);

CREATE TABLE IF NOT EXISTS packages (
id SERIAL PRIMARY KEY,
cardid1 VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE,
cardid2 VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE,
cardid3 VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE,
cardid4 VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE,
cardid5 VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE
);


CREATE TABLE IF NOT EXISTS stacks (
userid SERIAL REFERENCES users(id) ON DELETE CASCADE,
cardid VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE,
stacktype VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS trades (
id VARCHAR(50) PRIMARY KEY,
cardid VARCHAR(50) REFERENCES cards(id) ON DELETE CASCADE,
userid SERIAL REFERENCES users(id) ON DELETE CASCADE,
damage FLOAT(24) DEFAULT 0,
cardtype VARCHAR(50) NOT NULL
);




