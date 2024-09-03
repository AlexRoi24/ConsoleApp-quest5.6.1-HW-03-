namespace Quest5;

class Program
{
    static void Main(string[] args)
    {
        var inputed = EnterUser();
        OutputUserInfo(inputed);


    }

    private static void OutputUserInfo((string name, string lastname, int age, bool pet, int petnum, string[] petname, int numcolor, string[] color) inputed)
    {
        Console.WriteLine("------Ваши данные------");
        Console.WriteLine("Имя - {0}", inputed.name);
        Console.WriteLine("Фамилия - {0}", inputed.lastname);
        Console.WriteLine("Возраст - {0}", inputed.age);
        //Console.WriteLine("Количество животных - {0}", inputed.petnum); // включить по необходимости отображать количество питомцев
        Console.WriteLine("Имена животных: ");
        foreach (var item in inputed.petname)
        {
            Console.WriteLine("   " + item);
        }
        //Console.WriteLine("Количество цветов - {0}", inputed.numcolor); // включить по необходимости отображать количество цветов
        Console.WriteLine("Любимые цвета: ");
        foreach (var item1 in inputed.color)
        {
            Console.WriteLine("   " + item1);
        }
    }

    static (string name, string lastname, int age, bool pet, int petnum, string[] petname, int numcolor, string[] color) EnterUser()
    {
        (string name, string lastname, int age, bool pet, int petnum, string[] petname, int numcolor, string[] color) anketa;

            int intage;
            do
            {
                Console.WriteLine("Введите имя ");
                anketa.name = Console.ReadLine();

            } while (!CheckStr(anketa.name));

        do
        {
            Console.WriteLine("Введите фамилию ");
            anketa.lastname = Console.ReadLine();
        } while (!CheckStr(anketa.lastname));

        string age;
            
            do
            {
                Console.WriteLine("Введите возраст цифрами ");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));
            anketa.age = intage;

            Console.WriteLine("Есть ли у вас животные? Да или Нет");
            var result = Console.ReadLine();

            if (result == "Да")
            {
                anketa.pet = true;
                Console.WriteLine("Количество питомцев?");
                anketa.petnum = Convert.ToInt32(Console.ReadLine());
                int num = anketa.petnum;
                anketa.petname = CreateArrayPetname(num);


            }
            else
            {
                anketa.pet = false;
                anketa.petnum = 0;
                anketa.petname = null;
            }

            anketa.numcolor = -1;
            string num2;
            int intnum2;
            do
            {
                Console.WriteLine("Введите количество любимых цветов");
                num2 = Console.ReadLine();
            } while (CheckNum(num2, out intnum2));
            anketa.numcolor = intnum2;



            int numbercolor = anketa.numcolor;
            anketa.color = CreateArrayColor(numbercolor);


        return anketa;

    }

    static string[] CreateArrayPetname(int num)
    {

        Console.WriteLine("Введите имена питомцев?");
        var result = new string[num];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = Console.ReadLine();
        }


        return result;
    }
    static string[] CreateArrayColor(int numcolor)
    {

        Console.WriteLine("Введите любимые цвета?");
        var result = new string[numcolor];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = Console.ReadLine();
        }
        return result;
    }



    static bool CheckStr(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;
        if (int.TryParse(input, out int intnum))
        {
            return false;
        }
        return true;

    }

    static bool CheckNum(string number, out int corrnumber)
    {

        if (int.TryParse(number, out int intnum))
        {
            if (intnum > 0)
            {
                corrnumber = intnum;
                return false;
            }
        }
        {
            corrnumber = 0;
            return true;
        }

    }
}

