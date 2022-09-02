using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAfflineLesson
{
    public partial class Form1 : Form
    {
        DbRepository db;

        #region Конструктор
        public Form1()
        {
            InitializeComponent();

            db = new DbRepository();
            db.Employees.Load();

            dataGridView1.DataSource = db.Employees.Local.ToBindingList();
        }
        #endregion

        #region Добавление
        private void addButton_Click(object sender, EventArgs e)
        {
            registrForm RegForm = new registrForm();
            DialogResult result = RegForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Employee employee = new Employee();

            employee.Surname = RegForm.textBox1.Text;
            employee.Name = RegForm.textBox2.Text;
            employee.Patronimyc = RegForm.textBox4.Text;
            employee.Birthday = RegForm.dateTimePicker1.Value;
            employee.Country = RegForm.textBox3.Text;

            db.Employees.Add(employee);
            db.SaveChanges();

            MessageBox.Show("Работник успешно добавлен :)");
        }
        #endregion

        #region Редактирование
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Достаем индекс выбранной строки
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                // Достаем из базы игрока с индексом
                Employee employee = db.Employees.Find(id);

                // Запускаем форму для редактирования
                registrForm plForm = new registrForm();

                plForm.textBox1.Text = employee.Surname;
                plForm.textBox2.Text = employee.Name;
                plForm.textBox4.Text = employee.Patronimyc;
                plForm.dateTimePicker1.Value = employee.Birthday;
                plForm.textBox3.Text = employee.Country;

                // Читаем результат диалога с пользователем - нажата ОК/нажата Cancel
                DialogResult result = plForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                employee.Surname = plForm.textBox1.Text;
                employee.Name = plForm.textBox2.Text;
                employee.Patronimyc = plForm.textBox4.Text;
                employee.Birthday = plForm.dateTimePicker1.Value;
                employee.Country = plForm.textBox3.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");

            }
        }
        #endregion

        #region Удаление
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Достаем индекс выбранной строки
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                // Достаем из базы игрока с индексом
                Employee employee = db.Employees.Find(id);

                db.Employees.Remove(employee);
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }
        }
        #endregion
    }
}
