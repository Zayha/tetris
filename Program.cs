// Console.WriteLine("▒");

int[,] matrix = new int[15,20];
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

int[,] LineCrash(int[,] array)
{
    int sum = 0;
    for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                if(array[i, j] == 1)
                {
                    sum++;
                }
            }
            if(sum == array.GetLength(1))
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = 0;
                }
                for(int xi = i; xi >=0; xi--)
                {
                    for(int j = 0; j < array.GetLength(1); j++)
                    {
                        if(array[xi, j] == 1)
                        {
                            array[xi, j] = 0;
                            array[xi + 1, j] = 1;
                        }
                    }
                }
            }            
            sum = 0;
        }
    return array;
}


void ObjectCoord(int[,] array)
{   
    Random rnd = new Random();
    int x = 0;
    int y = rnd.Next(0, array.GetLength(1) - 1);
    
    int fl = 0;
    int lf = 0;
    int ytemp = 0;

    while(lf == 0) 
    {   
        array[x, y] = 1;
        
        while(fl == 0)
        {        
            ShowArea(array);
            var key = Console.ReadKey();
            int triger = Convert.ToInt32(key.Key);
            ytemp = y;
            //left
            if((triger == 37) && (y >= 1))
            {   
                y = y - 1;
            }
            //right
            if((triger == 39) && (y < array.GetLength(1) -1 ))
            {          
                y = y + 1;
            }
            // Console.Write($"{x} : {y}");
            // Console.ReadKey();
            // Console.WriteLine(array.GetLength(0));
            if((x < array.GetLength(0) - 2) & (array[x + 1, y] == 0))
            {   
                array[x + 1, y] = 1;
                array[x, ytemp] = 0;
                x++;
            }
            else
            {
                ObjectCoord(LineCrash(array));
            }
        }
    }
}


Console.Clear();
ObjectCoord(matrix);