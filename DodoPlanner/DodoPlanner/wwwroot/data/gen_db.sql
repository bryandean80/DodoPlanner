CREATE TABLE Categories(
  catID CHAR(36),
  catName VARCHAR(25),
  color VARCHAR(25),
  PRIMARY KEY(catID)
);
CREATE TABLE Lists(
  listID CHAR(36),
  listName VARCHAR(25),
  catID CHAR(36),
  PRIMARY KEY(listID),
  FOREIGN KEY(catID) REFERENCES Categories
);
CREATE TABLE Users(
  username VARCHAR(25),
  password VARCHAR(50),
  PRIMARY KEY(username)
);
CREATE TABLE Items(
  itemID CHAR(36),
  title VARCHAR(25),
  dueDate DATE,
  completed INTEGER,
  listID CHAR(36),
  PRIMARY KEY(itemID),
  FOREIGN KEY(listID) REFERENCES Lists(listID)
);
CREATE TABLE Is_In(
  itemID CHAR(36),
  listID CHAR(36),
  PRIMARY KEY (itemID, listID),
  FOREIGN KEY (itemID) REFERENCES Items,
  FOREIGN KEY (listID) REFERENCES Lists
);
CREATE TABLE Can_View(
  username VARCHAR(25),
  catID CHAR(36),
  PRIMARY KEY (username, catID),
  FOREIGN KEY (username) REFERENCES Users,
  FOREIGN KEY (catID) REFERENCES Categories
);