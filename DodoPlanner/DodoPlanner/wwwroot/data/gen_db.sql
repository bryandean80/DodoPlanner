
CREATE TABLE Category(
      catID CHAR(36),
      catName VARCHAR(25),
      color VARCHAR(25),
      PRIMARY KEY(catID)
);
CREATE TABLE List(
      listName VARCHAR(25),
      listColor VARCHAR(25),
      listID CHAR(36),
      catID CHAR(36),
      PRIMARY KEY(listID, catID),
      FOREIGN KEY(catID) REFERENCES Category
);
CREATE TABLE User(
      username VARCHAR(25),
      password VARCHAR(50),
      PRIMARY KEY(username)
);
CREATE TABLE Item(
      itemID CHAR(36),
      itemColor VARCHAR(25),
      title VARCHAR(25),
      description VARCHAR(140),
      dueDate DATE,
      listID CHAR(36),
      PRIMARY KEY(itemID, listID),
      FOREIGN KEY(listID) REFERENCES List
);
CREATE TABLE Is_In(
      itemID CHAR(36),
      listID CHAR(36),
      PRIMARY KEY (itemID, listID),
      FOREIGN KEY (itemID) REFERENCES Item,
      FOREIGN KEY (listID) REFERENCES List
);
CREATE TABLE Can_View(
      username VARCHAR(25),
      listID CHAR(36),
      PRIMARY KEY (username, listID),
      FOREIGN KEY (username) REFERENCES User,
      FOREIGN KEY (listID) REFERENCES List
);