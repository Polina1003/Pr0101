import sqlite3
class Pabotbl:
    def __init__(self):
        self.con = sqlite3.connect("Practan.db")
        self.cur = self.con.cursor()
        self.cur.execute(
        "CREATE TABLE IF NOT EXISTS pabotbl "
        "(ID_pabotbl INTEGER PRIMARY KEY,"
        "Nazvanie TEXT,"
        "FIO TEXT,"
        "Vbldacha REAL,"
        "Okonchanie REAL)"
        )
        self.con.commit()
    def __del__(self):
        self.con.close()

    def Pabotbl_view(self):
        self.cur.execute("SELECT * FROM pabotbl")
        rows = self.cur.fetchall()
        return rows

    def Pabotbl_insert(self, Nazvanie, FIO, Vbldacha, Okonchanie):
        self.cur.execute("INSERT INTO pabotbl "
                         "VALUES (NULL, ?, ?, ?, ?)",
            (Nazvanie, FIO, Vbldacha, Okonchanie))
        self.con.commit()

    def Pabotbl_update(self, ID_pabotbl, Nazvanie, FIO, Vbldacha, Okonchanie):
        self.cur.execute("UPDATE pabotbl SET "
                        "Nazvanie=?, FIO=?, Vbldacha=?, Okonchanie=?"
                        "WHERE ID_Pabotbl=? ",
        (Nazvanie, FIO, Vbldacha, Okonchanie, ID_pabotbl))
        self.con.commit()

    def Pabotbl_delete(self, id):
        self.cur.execute("DELETE FROM pabotbl "
                        "WHERE ID_Pabotbl=?", (id,))
        self.con.commit()

    def Pabotbl_search(self, Nazvanie):
        self.cur.execute("SELECT * FROM pabotbl "
                         "WHERE Nazvanie=?", (Nazvanie,))
        rows = self.cur.fetchall()
        return rows

class Porychenia:
    def __init__(self):
        self.con = sqlite3.connect("Practan.db")
        self.cur = self.con.cursor()
        self.cur.execute(
        "CREATE TABLE IF NOT EXISTS porychenia "
        "(ID_Porychenia INTEGER PRIMARY KEY,"
        "Doljnostb TEXT,"
        "Trydoemkostb REAL)"
        )
        self.con.commit()
    def __del__(self):
        self.con.close()

    def Porychenia_view(self):
        self.cur.execute("SELECT * FROM porychenia")
        rows = self.cur.fetchall()
        return rows

    def Porychenia_insert(self, Doljnostb, Trydoemkostb):
        self.cur.execute("INSERT INTO porychenia "
                        "VALUES (NULL, ?, ?)",
        (Doljnostb, Trydoemkostb))
        self.con.commit()

    def Porychenia_update(self,ID_Porychenia, Doljnostb, Trydoemkostb):
        self.cur.execute("UPDATE porychenia SET "
                        "Doljnostb=?, Trydoemkostb=?"
                        "WHERE ID_Porychenia = ?",
        (Doljnostb, Trydoemkostb, ID_Porychenia))
        self.con.commit()

    def Porychenia_delete(self, id):
        self.cur.execute("DELETE FROM porychenia "
                        "WHERE ID_Porychenia=?", (id,))
        self.con.commit()

    def Porychenia_search(self, Doljnostb):
        self.cur.execute("SELECT * FROM porychenia "
                        "WHERE Doljnostb=?", (Doljnostb,))
        rows = self.cur.fetchall()
        return rows
