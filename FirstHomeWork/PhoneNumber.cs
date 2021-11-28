using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstHomeWork
{
    [Serializable]
    class PhoneNumber
    {
        [Serializable]
        public enum GradeList
        {
            colleague,
            friend,
            kinsman,
            important
        }

        public string Number { private set; get; }
        public string Name { private set; get; }
        public string Info { private set; get; }
        public GradeList Grade { private set; get; }

        public PhoneNumber(string number, string name, string info, GradeList grade)
        {
            this.Number = number;
            this.Name = name;
            this.Info = info;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"Номер телефона: {Number}\nИмя контакта: {Name}\nИнформация о контакте: {Info}\nКонтакт для вас является: {Grade}";
        }
    }
}
