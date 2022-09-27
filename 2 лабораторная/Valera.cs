using System;
using System.IO;

class Marginal_life {
        public int health {get; set;}
        public int mana {get; set;}
        public int positive {get; set;}
        public int fatigue {get; set;}
        public int money {get; set;}

            static void Main() {
    string txt = File.ReadAllText("Rules.txt");
    Console.WriteLine(txt);

    Marginal_life Valera = new Marginal_life();
    string[] line = File.ReadAllLines("Save.csv");
    string[] word = line[0].Split(',');
        Valera.health = Int32.Parse(word[0]);
        Valera.mana = Int32.Parse(word[1]);
        Valera.positive = Int32.Parse(word[2]);
        Valera.fatigue = Int32.Parse(word[3]);
        Valera.money = Int32.Parse(word[4]);

    bool exit = true;
    Valera.output ();
    while (exit) {
        string? choice = Console.ReadLine();

        switch (choice) {
            case "1":
                Valera.GoWork();
                break;
            
            case "2":
                Valera.LookNature();
                break;
            
            case "3":
                Valera.DrinkAndWatch();
                break;
            
            case "4":
                Valera.GoBar();
                break;

            case "5":
                Valera.DrinkStrangers();
                break;

            case "6":
                Valera.SingMetro();
                break;

            case "7":
                Valera.Sleep();
                break;

            case "q":
                exit = false;
                break;

            case "s":
                string health_s = Valera.health.ToString();
                string mana_s = Valera.mana.ToString();
                string positive_s = Valera.positive.ToString();
                string fatigue_s = Valera.fatigue.ToString();
                string money_s = Valera.money.ToString();

                File.WriteAllText("Save.csv", health_s);
                File.WriteAllText("Save.csv", mana_s);
                File.WriteAllText("Save.csv", positive_s);
                File.WriteAllText("Save.csv", fatigue_s);
                File.WriteAllText("Save.csv", money_s);
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
                Console.WriteLine($"Деньги = {this.money}");
            }
            public void GoWork () {
                if (mana < 50 || fatigue < 10) {
                    positive -= 5;
                    mana -= 30;
                    money += 100;
                    fatigue += 70;
                } else {
                    Console.WriteLine($"Валера не может работать, поскольку! мана{mana} > 50 или усталость{fatigue} > 10");
                }
            }

            public void LookNature () {
                positive += 1;
                mana -= 10;
                fatigue += 10; 
            }

            public void DrinkAndWatch () {
                positive -= 1;
                mana += 30;
                fatigue += 10;
                health -= 5;
                money -= 20;
            }

            public void GoBar () {
                positive += 1;
                mana += 60;
                fatigue += 40;
                health -= 10;
                money -= 100;
            }

            public void DrinkStrangers () {
                positive += 5;
                health -= 80;
                mana += 90;
                fatigue += 80;
                money -= 150;
            }

            public void SingMetro () {
                positive += 1;
                money += 10;
                if (mana > 40 && mana < 70) {
                    money += 50;
                }
                mana += 10;
                fatigue += 20;
            }

            public void Sleep () {
                if (mana < 30) {
                    health += 90;
                }
                if (mana > 70) {
                    positive -= 3;
                }
                mana -= 50;
                fatigue -= 70;
            }
}