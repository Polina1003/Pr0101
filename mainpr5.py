from tkinter import *
from tkinter import ttk, messagebox
from dbPabotbl import Pabotbl

global selected_tuple

def get_selected_row(event):
    global selected_tuple
    index = list1.curselection()[0]
    selected_tuple = list1.get(index)
    Nazvanie_entry.delete(0, END)
    Nazvanie_entry.insert(END, selected_tuple[1])
    FIO_entry.delete(0, END)
    FIO_entry.insert(END, selected_tuple[2])
    Vbldacha_entry.delete(0, END)
    Vbldacha_entry.insert(END, selected_tuple[3])
    Okonchanie_entry.delete(0, END)
    Okonchanie_entry.insert(END, selected_tuple[4])
def view_command():
    list1.delete(0, END)
    for row in database_students.Pabotbl_view():
        list1.insert(END, row)
def search_command():
    list1.delete(0, END)
    for row in database_students.Pabotbl_search(Nazvanie_text.get()):
        list1.insert(END, row)
def add_command():
    database_students.Pabotbl_insert(Nazvanie_text.get(),
                            FIO_text.get(),
                            Vbldacha_text.get(),
                            Okonchanie_text.get())
    view_command()
def delete_command():
    database_students.Pabotbl_delete(selected_tuple[0])
    view_command()
def update_command():
    database_students.Pabotbl_update(selected_tuple[0],
                            Nazvanie_text.get(),
                            FIO_text.get(),
                            Vbldacha_text.get(),
                            Okonchanie_text.get())
    view_command()


window = Tk()
window.title("Демонстрация действий с БД")
window.configure(bg='#649566')

def on_closing():
    if messagebox.askokcancel("", "Закрыть программу?"):
        window.destroy()

window.protocol("WM_DELETE_WINDOW", on_closing)

frame = ttk.Frame(borderwidth=1, relief=SOLID, padding=5)
l1 = Label(frame, text="Название организации")
l1.pack()
Nazvanie_text = StringVar()
Nazvanie_entry = ttk.Entry(frame, textvariable=Nazvanie_text)
Nazvanie_entry.pack()
frame.grid(row=0, column=0)

frame = ttk.Frame(borderwidth=1, relief=SOLID, padding=5)
l2 = Label(frame, text="ФИО сотрудника")
l2.pack()
FIO_text = StringVar()
FIO_entry = ttk.Entry(frame, textvariable=FIO_text)
FIO_entry.pack()
frame.grid(row=0, column=1)

frame = ttk.Frame(borderwidth=1, relief=SOLID, padding=5)
l3 = Label(frame, text="Дата выдачи договора")
l3.pack()
Vbldacha_text = StringVar()
Vbldacha_entry = ttk.Entry(frame, textvariable=Vbldacha_text)
Vbldacha_entry.pack()
frame.grid(row=0, column=2)

frame = ttk.Frame(borderwidth=1, relief=SOLID, padding=5)
l4 = Label(frame, text="Дата окончания договора")
l4.pack()
Okonchanie_text = StringVar()
Okonchanie_entry = ttk.Entry(frame, textvariable=Okonchanie_text)
Okonchanie_entry.pack()
frame.grid(row=0, column=3)

frame = ttk.Frame(borderwidth=1, relief=SOLID, padding=5)

list1 = Listbox(frame, height=25, width=65)
list1.pack(side=LEFT, fill=BOTH, expand=1)

sb1 = Scrollbar(frame)
sb1.pack(side=RIGHT, fill=Y)

list1.configure(yscrollcommand=sb1.set)
sb1.configure(command=list1.yview)
frame.grid(row=1, column=0, columnspan=2)
list1.bind('<<ListboxSelect>>', get_selected_row)

frame = ttk.Frame(borderwidth=1, relief=SOLID, padding=5)
b1 = Button(frame, text="Посмотреть все", width=12, command=view_command)
b1.pack()

b2 = Button(frame, text="Поиск", width=12, command=search_command)
b2.pack()

b3 = Button(frame, text="Добавить", width=12, command=add_command)
b3.pack()

b4 = Button(frame, text="Обновить", width=12, command=update_command)
b4.pack()

b5 = Button(frame, text="Удалить", width=12, command=delete_command)
b5.pack()

b6 = Button(frame, text="Закрыть", width=12, command=on_closing)
b6.pack()
frame.grid(row=1, column=2)

database_students = Pabotbl()

window.mainloop()
