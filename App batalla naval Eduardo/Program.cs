using System;

class Program
{
    static void Main(string[] args)
    {
        const int BoardSize = 10;
        char[,] playerBoard = new char[BoardSize, BoardSize];
        char[,] computerBoard = new char[BoardSize, BoardSize];

        // Coloca los barcos del jugador
        Console.WriteLine("Coloca tus barcos:");
        PlaceShips(playerBoard);

        // Coloca los barcos de la computadora
        Console.WriteLine("La computadora está colocando sus barcos...");
        PlaceShips(computerBoard);

        // Juega hasta que alguien pierda todos sus barcos
        while (true)
        {
            // Turno del jugador
            Console.Clear();
            DisplayBoards(playerBoard, computerBoard);
            Console.WriteLine("Es tu turno.");
            if (PlayTurn(computerBoard))
            {
                Console.WriteLine("¡Le diste a un barco enemigo!");
                if (CheckWin(computerBoard))
                {
                    Console.WriteLine("¡Ganaste!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("¡Fallaste!");
            }
            Console.ReadLine();

            // Turno de la computadora
            Console.Clear();
            DisplayBoards(playerBoard, computerBoard);
            Console.WriteLine("La computadora está pensando su jugada...");
            System.Threading.Thread.Sleep(2000);
            if (ComputerPlayTurn(playerBoard))
            {
                Console.WriteLine("La computadora te ha golpeado un barco.");
                if (CheckWin(playerBoard))
                {
                    Console.WriteLine("¡Perdiste!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("La computadora falló.");
            }
            Console.ReadLine();
        }

        Console.ReadLine();
    }

    static void PlaceShips(char[,] board)
    {
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            int row, col;
            do
            {
                row = rand.Next(0, board.GetLength(0));
                col = rand.Next(0, board.GetLength(1));
            } while (board[row, col] != '\0');
            board[row, col] = 'S';
        }
    }

    static bool PlayTurn(char[,] board)
    {
        int row, col;
        do
        {
            Console.Write("Ingresa la fila: ");
            row = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Ingresa la columna: ");
            col = int.Parse(Console.ReadLine()) - 1;
        } while (board[row, col] == 'X' || board[row, col] == 'O');
        if (board[row, col] == 'S')
        {
            board[row, col] = 'X';
            return true;
        }
        else
        {
            board[row, col] = 'O';
            return false;
        }
    }

    static bool ComputerPlayTurn(char[,] board)
    {
        Random rand = new Random();
        int row, col;
        do
        {
            row = rand.Next(0, board.GetLength(0));
            col = rand.Next(0, board.GetLength(1));
        } while (board[row, col] == 'X' || board[row, col] == 'O');
        if (board[row, col] == 'S')
        {
            board[row, col] = 'X';
            return true;
        }
        else
        {
            board[row, col] = 'O';
            return false;
        }
    }

    static bool CheckWin(char[,] board)
    {
        for (int row = 0; row < board.GetLength(0); row
