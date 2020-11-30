
CREATE TABLE Categories(
  catID CHAR(36),
  catName VARCHAR(25),
  color VARCHAR(25),
  PRIMARY KEY(catID)
);
CREATE TABLE Lists(
  listName VARCHAR(25),
  listID CHAR(36),
  catID CHAR(36),
  PRIMARY KEY(listID, catID),
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
  PRIMARY KEY(itemID, listID),
  FOREIGN KEY(listID) REFERENCES Lists
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
  listID CHAR(36),
  PRIMARY KEY (username, listID),
  FOREIGN KEY (username) REFERENCES Users,
  FOREIGN KEY (listID) REFERENCES Lists
);