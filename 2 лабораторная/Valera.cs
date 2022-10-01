using System;
using System.IO;

class Marginal_life {
        public int health {get; set;}
        public int mana {get; set;}
        public int positive {get; set;}
        public int fatigue {get; set;}
        public int money {get; set;}

            static void Main() {
                Console.WriteLine("1 - Работать\n2 - Любоваться природой\n3 - Пить вино, смотреть сериал\n4 - Пойти в бар\n5 - Пить с маргинальными личностями\n6 - Петь в метро\n7 - Спать\ns - Сохранить сосотяние Валеры\nr - Правила\nq - Выход\n");
    
        bool exit = true;
        Marginal_life Valera = new Marginal_life();
        string[] line = File.ReadAllLines("Save.csv");
        string[] word = line[0].Split(',');
        Valera.health = Int32.Parse(word[0]);
        Valera.mana = Int32.Parse(word[1]);
        Valera.positive = Int32.Parse(word[2]);
        Valera.fatigue = Int32.Parse(word[3]);
        Valera.money = Int32.Parse(word[4]);

    
    Valera.output ();
    while (exit) {
        string? choice = Console.ReadLine();

        switch (choice) {
            case "1":
                Console.WriteLine("Валера пошел на работу.");
                Valera.GoWork();
                break;
            
            case "2":
                Console.WriteLine("Валера созерцает прекрасное.");
                Valera.LookNature();
                break;
            
            case "3":
                Console.WriteLine("Валера отдыхает под кино.");
                Valera.DrinkAndWatch();
                break;
            
            case "4":
                Console.WriteLine("Валера идет в бар.");
                Valera.GoBar();
                break;

            case "5":
                Console.WriteLine("Валера попал в плохую компанию.");
                Valera.DrinkStrangers();
                break;

            case "6":
                Console.WriteLine("Валера рубит капусту в метро.");
                Valera.SingMetro();
                break;

            case "7":
                Console.WriteLine("Валера пошел спать");
                Valera.Sleep();
                break;

            case "q":
                Console.WriteLine("Игра окончена");
                exit = false;
                break;

            case "s":
                Console.WriteLine("Сохраняем биометрику Валеры");
                string health_s = Valera.health.ToString();
                string mana_s = Valera.mana.ToString();
                string positive_s = Valera.positive.ToString();
                string fatigue_s = Valera.fatigue.ToString();
                string money_s = Valera.money.ToString();

                File.WriteAllText("Save.csv", String.Join(',', health_s, mana_s, positive_s, fatigue_s, money_s));
                break;
            
            case "r":
                Console.WriteLine("Возможности Валеры:");
                string txt = File.ReadAllText("Rules.txt");
                Console.WriteLine(txt);
                break;
        }
    Valera.output();
    }
}

            public void output () {
                Console.WriteLine($"Здоровье = {this.health}");
                Console.WriteLine($"Мана= {this.mana}");
                Console.WriteLine($"Жизнерадостность = {this.positive}");
                Console.WriteLine($"Усталость = {this.fatigue}");
                Console.WriteLine($"Деньги = {this.money}\n");
            }
            public void GoWork () {
                if (mana >= 50 || fatigue >= 10 || (positive - 5 <= -10) || (fatigue + 70 >= 100)) {
                    Console.WriteLine($"Валера не может работать, поскольку! мана {mana} > 50 или усталость {fatigue} > 10 или настроение после работы будет {positive - 5} <= -10 или усталость{fatigue + 70} >= 100");
                } else {
                    positive -= 5;
                    mana -= 30;
                    if (mana < 0) {
                        mana = 0;
                    }
                    money += 100;
                    fatigue += 70;
                } 
            }

            public void LookNature () {
                if (fatigue +10 >= 100){
                    Console.WriteLine($"Валера слишком устал, чтобы смотреть на природу ({fatigue + 10}>=100)");
                } else {
                    positive += 1;
                    if (positive > 10) {
                        positive = 10;
                    }
                    mana -= 10;
                    if (mana < 0) {
                        mana = 0;
                    }
                    fatigue += 10; 
                }
            }
            public void DrinkAndWatch () {
                if ((positive - 1 <= -10)||(mana + 30 >= 100)||(fatigue + 10 >= 100)||(health - 5 <= 0)){
                    Console.WriteLine($"Валера не готов к такой нагрузке. Он или грустный {positive -1} <= -10, или пьяный {mana + 30} >= 100, или устал {fatigue + 10} >= 100, или болен {health - 5} <= 0");
                } else {
                positive -= 1;
                mana += 30;
                fatigue += 10;
                health -= 5;
                money -= 20;
                }
            }

            public void GoBar () {
                if ((mana + 60 >= 100) || (fatigue + 40 >= 100) || (health - 10 <= 10)) {
                    Console.WriteLine($"Валера не стоячий, или пьяный {mana + 60} >= 100, или уставший {fatigue + 40} >= 100, или больной {health - 10} <= 10");
                } else {
                positive += 1;
                if (positive > 10) positive = 10;
                mana += 60;
                fatigue += 40;
                health -= 10;
                money -= 100;
                }
            }

            public void DrinkStrangers () {
                if ((health - 80 <= 0) || (mana + 90 >= 100) || (fatigue + 80 >= 100)) {
                    Console.WriteLine($"Валера выбирает верную дорогу, так как не подходят параметры");
                } else {
                positive += 5;
                if (positive > 10) positive = 10;
                health -= 80;
                mana += 90;
                fatigue += 80;
                money -= 150;
                }
            }

            public void SingMetro () {
                if ((mana + 10 >= 100) || (fatigue + 20 >= 100)) {
                    Console.WriteLine($"Валера сегодня не певец. Мана {mana + 10 } >= 100 или усталость {fatigue + 20} >=100");
                    } else {
                positive += 1;
                if (positive>10) positive = 10;
                money += 10;
                if (mana > 40 && mana < 70) {
                    money += 50;
                }
                mana += 10;
                fatigue += 20;
                }
            }

            public void Sleep () {
                if (mana < 30) {
                    health += 90;
                }
                if (mana > 70) {
                    positive -= 3;
                }
                mana -= 50;
                if (mana < 0) mana = 0;
                fatigue -= 70;
                if(fatigue < 0) fatigue = 0;
                if (health > 100) health = 100;
            }
}