using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormAfflineLesson
{
    public class Employee
    {
        int id;
        string surname;
        string name;
        string patronimyc;
        string country;
        DateTime birthday;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id
        { 
            get
            { 
                return id; 
            }
            set
            {
                id = value;
            }
        }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronimyc
        {
            get
            {
                return patronimyc;
            }
            set
            {
                patronimyc = value;
            }
        }
        
        /// <summary>
        /// ФИО
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                return Surname + " " + Name + " " + Patronimyc;
            }
        }

        /// <summary>
        /// Страна
        /// </summary>
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
    }
}
