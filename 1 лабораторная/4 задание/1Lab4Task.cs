string file = System.IO.File.ReadAllText("File.csv");

//переход на новую строку и возврат каретки
file = file.Replace('\n', '\r');

//Split - бьем на строки игнорирую пустые
//Удаляем пустые вхождения
string[] lines = file.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

//строки
int num_rows = lines.Length;
//стобцы
int num_cols = lines[0].Split(',').Length;

//массив под файл
string[,] array = new string[num_rows, num_cols];

//заполнение матрицы 
for (int r = 0; r < num_rows; r++) {
    string[] line_r = lines[r].Split(',');
    for (int c = 0; c < num_cols; c++) {
        array[r, c] = line_r[c];
    }
}