using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace FirstHomeWork
{
    class PhoneNumbersManager
    {
        private List<PhoneNumber> phoneNumbers;
        private const string fileNameTXT = "PhoneListNumbers.txt";
        private const string fileNameBIN = "PhoneListNumbers.bin";

        public PhoneNumbersManager()
        {
            phoneNumbers = new List<PhoneNumber>();
        }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            phoneNumbers.Add(phoneNumber);
        }

        public bool ReplacePhoneNumber(int index, PhoneNumber phoneNumber)
        {
            if (index >= 0 && index <= phoneNumbers.Count - 1)
            {
                phoneNumbers[index] = phoneNumber;
                return true;
            }
            else
            {
                throw new Exception("Такого контакта не существует");
            }

        }

        public bool DeletePhoneNumber(int index)
        {
            if (index >= 0 && index <= phoneNumbers.Count - 1)
            {
                phoneNumbers.RemoveAt(index);
                return true;
            }
            else
            {
                throw new Exception("такого контакта не существует");
            }
        }

        public void PrintPhoneNumbers()
        {
            if (phoneNumbers.Count == 0)
            {
                Console.WriteLine("\nЧто ж, список контактов пуст :(");
                Console.WriteLine("======");
            }
            else
            {
                for (int i = 0; i < phoneNumbers.Count; i++)
                {
                    Console.WriteLine($"Котнтакт номер №{i + 1}");
                    Console.WriteLine(phoneNumbers[i]);
                    Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+\n");
                }
            }
        }

        public void PrintPhoneNumbersByGrade(PhoneNumber.GradeList grade)
        {
            int count = 0;

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                if (phoneNumbers[i].Grade == grade)
                {
                    count++;
                    Console.WriteLine($"Котнтакт номер №{i + 1}");
                    Console.WriteLine(phoneNumbers[i]);
                    Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+\n");
                }
            }

            if (count == 0)
            {
                Console.WriteLine("\nЧто ж, никого с заданными парметрами не нашлось :(");
            }
        }


        public void LoadPhoneNumbersFromTxtFile()
        {
            StreamReader reader = new StreamReader(fileNameTXT);

            int count = Convert.ToInt32(reader.ReadLine());
            phoneNumbers = new List<PhoneNumber>();

            for (int i = 0; i < count; i++)
            {
                string number = reader.ReadLine();
                string name = reader.ReadLine();
                string info = reader.ReadLine();
                PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(reader.ReadLine());

                phoneNumbers.Add(new PhoneNumber(number, name, info, grade));
            }

            reader.Close();
        }

        public void SavePhoneNumbersTxtToFile()
        {
            StreamWriter writer = new StreamWriter(fileNameTXT);
            int count = phoneNumbers.Count;
            writer.WriteLine(count);

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                writer.WriteLine(phoneNumbers[i].Number);
                writer.WriteLine(phoneNumbers[i].Name);
                writer.WriteLine(phoneNumbers[i].Info);
                writer.WriteLine((int)phoneNumbers[i].Grade);
            }

            writer.Close();
        }

        public void LoadPhoneNumbersFromBinFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileNameBIN, FileMode.Open);

            phoneNumbers = (List<PhoneNumber>)binaryFormatter.Deserialize(fileStream);

            fileStream.Close();
        }

        public void SavePhoneNumbersBinToFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileNameBIN, FileMode.OpenOrCreate);

            binaryFormatter.Serialize(fileStream, phoneNumbers);

            fileStream.Close();
        }
    }

}
