from Drugovapr4 import Pabotbl
from Drugovapr4 import Porychenia
import sqlite3


db_Pabotbl = Pabotbl()
db_Porychenia = Porychenia()

is_run=True

def add_command_Pabotbl():
    Nazvanie = input("Введите название работы: ")
    FIO = input("Введите ФИО сотрудника: ")
    Vbldacha = input("Введите дату выдачи поручения на работу: ")
    Okonchanie = input("Введите дату окончания работы: ")
    db_Pabotbl.Pabotbl_insert(Nazvanie, FIO, Vbldacha, Okonchanie)
    print()

def add_command_Porychenia():
    Doljnostb = input("Введите должность сотрудника: ")
    Trydoemkostb = input("Введите трудоемкость сотрудника: ")
    db_Porychenia.Porychenia_insert(Doljnostb, Trydoemkostb)
    print()

def view_command_Pabotbl():
    for row in db_Pabotbl.Pabotbl_view():
        print(row)
        print()

def view_command_Porychenia():
    for row in db_Porychenia.Porychenia_view():
        print(row)
        print()

def delete_command_Pabotbl():
    ID_Pabotbl = int(input('Введите Id работу для удаления: '))
    db_Pabotbl.Tovapbl_delete(ID_Pabotbl)
    print()

def delete_command_Porychenia():
    ID_Porychenia = int(input('Введите Id поручение для удаления: '))
    db_Porychenia.Postavchiki_delete(ID_Porychenia)
    print()

def search_command_Pabotbl():
    search_Nazvanie = input('Название работы: ')
    if len(db_Pabotbl.Pabotbl_search(search_Nazvanie)) > 0:
        for row in db_Pabotbl.Pabotbl_search(search_Nazvanie):
            print(row)
    else:
        print("Такой работы нет")
    print()

def search_command_Porychenia():
    search_Doljnostb = input('Должность: ')
    if len(db_Porychenia.Porychenia_search(search_Doljnostb)) > 0:
        for row in db_Porychenia.Porychenia_search(search_Doljnostb):
            print(row)
    else:
        print("Такой должности нет")
    print()

def update_command_Pabotbl():
    ID_pabotbl = int(input("Введите Id работы для редактирования: "))
    Nazvanie = input("Введите название работы для редактирования: ")
    FIO = input("Введите ФИО работника для редактирования: ")
    Vbldacha = input("Введите дату выдачи поручения на работу для редактирования: ")
    Okonchanie = input("Введите дату окончания работы для редактирования: ")
    db_Pabotbl.Tovapbl_update(ID_pabotbl, Nazvanie, FIO, Vbldacha, Okonchanie)

def update_command_Porychenia():
    ID_Porychenia = int(input("Введите Id поручение для редактирования: "))
    Doljnostb = input("Введите должность работника для редактирования: ")
    Trydoemkostb = input("Введите трудоемкость работника для редактирования: ")
    db_Porychenia.Porychenia_update(ID_Porychenia, Doljnostb, Trydoemkostb)

while is_run:
    command = input('Введите комманду: ')

    if command == 'Работы':
        view_command_Pabotbl()
    elif command == 'Поручения':
        view_command_Porychenia()
    elif command == 'Добавить работу':
        add_command_Pabotbl()
    elif command == 'Добавить поручения':
        add_command_Porychenia()
    elif command == 'Удалить работу':
        delete_command_Pabotbl()
    elif command == 'Удалить поручения':
        delete_command_Porychenia()
    elif command == 'Редактировать работы':
        update_command_Pabotbl()
    elif command == 'Редактировать поручения':
        update_command_Porychenia()
    elif command == 'Поиск работы':
        search_command_Pabotbl()
    elif command == 'Поиск поручения':
        search_command_Porychenia()
    elif command == 'Выход':
        is_run = False
    else:
        print('Команда не найдена')
    print()
