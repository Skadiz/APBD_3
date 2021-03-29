using System;

namespace Zadanie3.Models
{
    public class Student
    {
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }




        public Student(string info)
        {
            var tab = info.Split(",");

            fname = tab[0];
            lname = tab[1];
            indexNumber = "s" + tab[4];
            birthdate = DateTime.Parse(tab[5]).ToString("dd/MM/yyyy");
            email = tab[6];
            mothersName = tab[7];
            fathersName = tab[8];
        }

     
        public override string ToString()
        {
            return $"{fname} {lname} {indexNumber}";
        }

    }
}