// Console.WriteLine("▒");

int[,] matrix = new int[10,20];
// matrix[0,1] = 1;

void ShowArea(int[,] array)
{
    Console.Clear();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == 1)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write("▒");
            }
        }
    Console.WriteLine();    
    }
}

void ObjectCoord(int[,] array, int x = 0, int y = 5)
{   
    int fl = 0;
    int lf = 0;
    array[x, y] = 1;
    while(lf == 0) 
    {
        int ytemp = 0;
        while(fl == 0)
        {        
            ShowArea(array);
            var key = Console.ReadKey();
            int triger = Convert.ToInt32(key.Key);
            //left
            if((triger == 37) && (y < 20) && (y >= 0))
            {   
                ytemp = y;
                y = y - 1;
            }
            //right
            if((triger == 39) && (y < 20) && (y >= 0))
            {   
                ytemp = y;
                y = y + 1;
            }
            Console.Write($"*-{array[x + 1, y]}");
            if((array[x + 1, y] == 0) && (x + 1 < 10))
            {   
                Console.Write(">>>YES");
                array[x + 1, y] = 1;
                array[x, ytemp] = 0;
                x++;
            }
            var j = Console.ReadKey();
            // else
            // {
            //     fl = 1;
            // }
        }
    }
}


Console.Clear();
ObjectCoord(matrix);
// var i = Console.ReadKey();
// int triger = Convert.ToInt32(i.Key);
// Console.WriteLine();
// Console.WriteLine(triger);