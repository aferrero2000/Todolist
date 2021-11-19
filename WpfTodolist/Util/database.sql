﻿CREATE TABLE IF NOT EXISTS Prioritat (
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	Nom TEXT CHECK(Nom IN ('Alta','Mitja','Baixa')) NOT NULL,
	Color TEXT NOT NULL
);

INSERT INTO Prioritat (nom, color) VALUES
("Alta", "Red"),
("Mitja", "Yellow"),
("Baixa", "Green");

CREATE TABLE IF NOT EXISTS Responsable (
	ID	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	Nom	TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Tasca (
	ID	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	Nom	TEXT NOT NULL,
	Descripcio TEXT,
	Data_creacio DATE NOT NULL,
	Data_finalitzacio DATE NOT NULL,
	Responsable INTEGER,
	Prioritat INTEGER,
	Estat TEXT CHECK(Estat IN ('ToDo', 'Doing', 'Done')) NOT NULL,
	FOREIGN KEY(Prioritat) REFERENCES Prioritat(ID),
	FOREIGN KEY(Responsable) REFERENCES Responsable(ID)
);