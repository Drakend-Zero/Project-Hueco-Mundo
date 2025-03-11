using System;
using Spectre.Console;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

namespace MazeGame
{
    public class Game:Player
    {
        public static int width = 131;
        public static int height = 21;
        public static int[,] maze = new int[width,height];
        public static Random random = new Random();
        public static int PlayerX = 1;
        public static int Player2X = 1;
        public static int PlayerY = 1;
        public static int Player2Y = 2;
        public static int pillarX, pillarY;
        public static int pillarA, pillarB;
        public static int pillarC, pillarD;
        public static int trapsSet = 0;
        public static int trapsSet2 = 0;
        public static int trapsSet3 = 0;
        public static int maxTraps = 2;
        public static int playerLife = (int)PlayerStats.Life;
        public static int player2Life = (int)Player2Stats.Life;
        public static int change = 1;
        public static int playedT;
        public static int newPI;
        public static int newI;
        public static int newPJ;
        public static int newJ;

        static void Main(string[] args)
        {
            int Ps = (int)PlayerStats.Speed;
            int Ps2 =  (int)Player2Stats.Speed;
            
            for(int i = 0; i < width;i++)
            {
                for(int j = 0;j < height;j++)
                {
                    maze[i,j] = 0;
                }
            }
            
            
            Player.Presentation(Ps,Ps2);
            
            while (true)
            {
                Generation(1,1);
                while(true)
                {
                    Console.Clear();
                    Print();
                    SetTrap();
                    AnsiConsole.MarkupLine($"P1 Life =[red] {playerLife}[/]");
                    AnsiConsole.MarkupLine($"P2 Life = [red]{player2Life}[/]");
                    Console.WriteLine($"P1-Speed = {Ps}");
                    Console.WriteLine($"P2-Speed = {Ps2}");
                    AnsiConsole.MarkupLine($"[Red]P1[/]:skull: remaining steps: {stepsP1}");
                    AnsiConsole.MarkupLine($"[Yellow]P2[/]:skull: remaining steps: {stepsP2}");
                    Console.WriteLine($"Turns ended: {playedT}");
                    if(change==1 )
                    {
                        if(soul1==1 && Redo%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [yellow]From the limits of my patience:[/]");
                            AnsiConsole.MarkupLine($"P1: [yellow]!!!!BAN-KAI!!!![/]");
                            AnsiConsole.MarkupLine($"P1: [violet]!!!!Katen Kyokotsu Karamatsu Shinju!!!![/]");
                        }
                        if(soul1==2 && SoundON%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [blue]SONIDO[/]");
                            AnsiConsole.MarkupLine($"P1: [blue]Now you'll see my power[/]");
                        }
                        if(soul1==3 && killerI%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [Red]HOLLOW MASK:[/]:ghost:");
                            AnsiConsole.MarkupLine($"P1: [Red]Vasto Lorde[/]");
                        }
                        if(soul1==4 && Pzero%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [darkgreen]Resurrection:[/]:fire:");
                            AnsiConsole.MarkupLine($"P1: [darkgreen]ZERO[/]:fire:");
                        }
                        if(soul1==5 && ReiStep%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [darkgreen]You won't beat my speed[/]:fire:");
                        }
                    }
                    else if(change==2)
                    {
                        if(soul2==1 &&  Redo2%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [yellow]From the limits of my patience:[/]");
                            AnsiConsole.MarkupLine($"P1: [yellow]!!!!BAN-KAI!!!![/]");
                            AnsiConsole.MarkupLine($"P1: [violet]!!!!Katen Kyokotsu Karamatsu Shinju!!!![/]");
                        }
                        if(soul2==2 && Sound2On%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [blue]SONIDO[/]");
                            AnsiConsole.MarkupLine($"P1: [blue]Now you'll see my power[/]");

                        }
                        if(soul2==3 && killerI2%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [Red]HOLLOW MASK:[/]:ghost:");
                            AnsiConsole.MarkupLine($"P1: [Red]Vasto Lorde[/]");
                        }
                        if(soul2==4 && Pzero2%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [darkgreen]Resurrection:[/]:fire:");
                            AnsiConsole.MarkupLine($"P1: [darkgreen]ZERO[/]:fire:");
                        }
                        if(soul2==5 && ReiStep2%2 == 0)
                        {
                            AnsiConsole.MarkupLine($"P1: [darkgreen]You won't beat my speed[/]:fire:");
                        }
                    }
                    if (playedT == 20 && playerLife > player2Life)Winning();
                    if (playedT == 20 && playerLife > player2Life)Winning2();
                    var key = Console.ReadKey(true).Key;
                    
                    if(key == ConsoleKey.Escape) 
                    {
                        Console.Clear();
                        Leaving();
                        Player.Presentation(Ps,Ps2);
                    }
                    if (stepsP1 == endturn)
                    {
                        change+= 1;
                        stepsP1 = reset;
                        ReiStep = 1;
                    }
                    else if (stepsP2 == endturn)
                    {
                        change-=1;
                        stepsP2 = reset;
                        ReiStep2=1;
                    }
                    else if (change == 1)
                    {
                        if(key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)
                        {
                            stepsP1 -= 1;
                            if (stepsP1 == endturn) 
                            {
                                Console.WriteLine("Player 1 has run out of steps. Switching turns.");
                            }
                        }
                        if(key == ConsoleKey.W) PlayerMove(0,-Ps);
                        else if(key == ConsoleKey.A) PlayerMove(-Ps,0);
                        else if(key == ConsoleKey.S) PlayerMove(0,Ps);
                        else if(key == ConsoleKey.D) PlayerMove(Ps,0);

                        if(key == ConsoleKey.U && stepsP1 <= 4 && soul1 == 2)SoundON++;
                        if(key == ConsoleKey.O && stepsP1 <= 3 && soul1 == 4)Pzero++;
                        if(key == ConsoleKey.R && stepsP1 <= 3 && soul1 == 1 && playedT >= 4)Redo++;
                        if(Redo %2 == 0 && soul1 == 1 && playerLife >=100)
                        { 
                            playerLife = 15;
                            player2Life = 30;
                        }
                        if(soul1 == 1 && playerLife <= 40 && player2Life >= 30 && Redo %2 != 0 && stepsP1 == reset)change = 1;  
                        if(Redo%2 == 0 && stepsP1 <= 3 && playedT >= 4 && playerLife < 100 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)playerLife+=5;

                        if(SoundON%2 !=0)Ps = (int)PlayerStats.Speed; 
                        if(stepsP1 <=4 && SoundON%2 == 0)
                        {
                            Ps = (int)BoostedStats.Speed2;
                            Ps2 = (int)Player2Stats.Speed; 
                            if(stepsP1 <= 3 && playedT >=5 && playerLife < 100 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)playerLife+=5;
                            if(stepsP1 <= 3 && playedT >=5 && playerLife < 40 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)playerLife+=10;
                            if(stepsP1 <= 3 && playedT >=5 && playerLife >= 100 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)playerLife+=0;
                        }
                        if (Pzero %2 == 0 && soul1 == 4)
                        {  
                            if(player2Life>=30 && player2Life < 100)
                            {
                                player2Life -=20 ; 
                                stepsP1 = 0;
                            }
                            else if(player2Life >= 110 && playedT >=5)
                            {
                                playerLife = 50; 
                                player2Life -= 50;
                                stepsP1 = 0; 
                            }
                            if(stepsP1 <= 3 && playedT >=5 && playerLife < 100 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)playerLife+=5;

                        }
                        else if (key == ConsoleKey.I && soul1 == 3 && stepsP1 <= 3)
                        {
                            killerI++;
                            
                        }
                        if(killerI%2 == 0)
                        {
                            if(player2Life > 30 && player2Life < 100 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)player2Life-=5;
                            else if(player2Life >= 100 && key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D)player2Life-=10;
                        }
                        if(key == ConsoleKey.Spacebar && soul1 == 5 && playedT >= 0 && stepsP1 <= 3)
                        {
                            ReiStep = 2;
                            stepsP1+=6;
                        }
                        if(stepsP1==0 || stepsP1 >3)Ps = (int)PlayerStats.Speed; 
                    }
                    else if (change == 2)
                    {
                        if(key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)
                        {
                            stepsP2 -= 1;
                            if (stepsP2 == endturn) 
                            {
                                Console.WriteLine("Player 2 has run out of steps. Switching turns.");
                            }
                        }  
                        if (key == ConsoleKey.UpArrow) PlayerMove2(0,-Ps2);
                        else if (key == ConsoleKey.LeftArrow) PlayerMove2(-Ps2,0);
                        else if (key == ConsoleKey.DownArrow) PlayerMove2(0,Ps2);
                        else if (key == ConsoleKey.RightArrow) PlayerMove2(Ps2,0);

                        if(key == ConsoleKey.U && stepsP2 <= 4 && soul2 == 2)Sound2On++;
                        if(key == ConsoleKey.O && stepsP2 == 1 && soul2 == 4)Pzero2++;
                        if(key == ConsoleKey.R && stepsP2 <= 3 && soul2 == 1 && playedT >= 4 )Redo2++;
                        if(Redo2 %2 == 0 && player2Life >= 100 && soul2 == 1 )
                        { 
                            player2Life = 15;
                            playerLife = 30;
                        }
                        if(soul2 == 1 && player2Life <= 40 && playerLife >= 30 && Redo2 %2 != 0 && stepsP2 == reset)change = 2;  
                        if(soul2 == 1 && stepsP2 <=3 && playedT >=4 && player2Life < 100 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)player2Life+=5;

                        if(Sound2On%2 !=0)Ps2 = (int)PlayerStats.Speed; 
                        if(stepsP2 <=4 && Sound2On%2 == 0)
                        {
                            Ps2 = (int)BoostedStats.Speed2;
                            Ps = (int)PlayerStats.Speed;
                            if (stepsP2 <=3 && playedT >=5 && player2Life < 100 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)player2Life+=5;                
                            if (stepsP2 <=3 && playedT >=5 && player2Life < 40 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)player2Life+=10;
                            if (stepsP2 <=3 && playedT >=5 && player2Life >= 100 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)player2Life+=0;
                        }
                        if (Pzero2 %2 == 0 && soul2 == 4)
                        {  
                            if(playerLife>=30 && playerLife < 100)
                            {
                                playerLife -=20 ; 
                                stepsP2 = 0;
                            }
                            else if(player2Life >= 110 && playedT >=5)
                            {
                                playerLife = 50; 
                                player2Life -= 50; 
                                stepsP2 = 0;
                            }
                            if (stepsP2 <=3 && playedT >=5 && player2Life < 100 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)player2Life+=5;

                        }
                        else if (key == ConsoleKey.I && soul2 ==3 && stepsP2 <= 4)
                        {
                            killerI2++;
                        }
                        if(killerI2%2 == 0)
                        {
                            if(playerLife > 30 && playerLife < 100 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)playerLife-=5;
                            else if(playerLife >= 100 && key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)playerLife-=10;
                        }
                        if(key == ConsoleKey.Spacebar && soul2 == 5 && playedT >= 5 && stepsP2 <=3)
                        {
                            ReiStep2 = 2;
                            stepsP2 += 6;
                        }
                        if(stepsP2==0 || stepsP2 >3)Ps2 = (int)PlayerStats.Speed;
                    }
                    if(stepsP1 == endturn || stepsP2 == endturn)playedT ++;
                    if(change == 1 && stepsP1 == endturn && Sound2On%2 == 0)Sound2On++;
                    if(change == 1 && stepsP1 == endturn && killerI2%2 == 0)killerI2++;
                    if(change == 1 && stepsP1 == endturn && Pzero2%2 == 0)Pzero2++;
                    if(change == 1 && stepsP1 == endturn && ReiStep2 == 2)ReiStep2-=1;
                    if(change == 1 && stepsP1 == endturn && Redo2%2 == 0)Redo2++;
                    if(change == 2 && stepsP2 == endturn && SoundON%2 == 0)SoundON++;
                    if(change == 2 && stepsP2 == endturn && killerI%2 == 0)killerI++;
                    if(change == 2 && stepsP2 == endturn && Pzero%2 == 0)Pzero++;
                    if(change == 2 && stepsP2 == endturn && ReiStep == 2)ReiStep-=1;
                    if(change == 2 && stepsP2 == endturn && Redo%2 == 0)Redo++;
                    
                }
            }
        }
        
        static void PlayerMove(int di, int dj)
        {
            newI = PlayerX + di;
            newJ = PlayerY + dj;

            if(newI > 0 && newI < width && newJ > 0 && newJ < height)
            {
                if (maze[newI, newJ] == 3 && playerLife > 0)
                {
                    playerLife -= 50;
                    Console.WriteLine("Life loss because of trap. Current Life: " + playerLife);
                }
                if (maze[newI,newJ] == 4 && stepsP1 > 0)stepsP1 = 0;
                if (maze[newI,newJ] == 5)
                {
                    SoundON = 1;
                    killerI = 1;
                    Pzero = 1;
                    Redo = 1;
                    ReiStep = 1;
                }
                else if (maze[newI, newJ] == 1)
                {
                    PlayerX = newI;
                    PlayerY = newJ;
                }
            }
        }

        static void PlayerMove2(int di, int dj)
        {
            newPI = Player2X + di;
            newPJ = Player2Y + dj;

            if(newPI > 0 && newPI < width && newPJ > 0 && newPJ < height)
            {
                if (maze[newPI, newPJ] == 3 && player2Life > 0)
                {
                    player2Life -= 50; 
                    Console.WriteLine("Player2 watch your life:" + player2Life);
                }
                if (maze[newPI,newPJ] == 4 && stepsP2 > 0)stepsP2 = 0;
                if (maze[newPI,newPJ] == 5)
                {
                    Sound2On = 1;
                    killerI2 = 1;
                    Pzero2 = 1;
                    Redo2 = 1;
                    ReiStep2 = 1;
                }
                else if (maze[newPI, newPJ] == 1 || maze[newPI,newPJ] == 3) 
                {
                    Player2X = newPI;
                    Player2Y = newPJ;
                }
            }
        }

        static void SetTrap()
        {
            while (trapsSet < maxTraps)
            {
                do
                {
                    pillarX = random.Next(1, width - 1);
                    pillarY = random.Next(1, height - 1);
                } while (maze[pillarX, pillarY] !=0  && maze[pillarX,pillarY] != maze[newI,newJ] && maze[pillarX,pillarY] != maze[newPI,newPJ]);
                maze[pillarX,pillarY] = 3;
                trapsSet++;
                do
                {
                    pillarA = random.Next(1, width - 1);
                    pillarB = random.Next(1, height - 1);
                } while (maze[pillarA,pillarB] !=0  && maze[pillarA,pillarB] != maze[newI,newJ] && maze[pillarA,pillarB] != maze[newPI,newPJ]);
                maze[pillarA,pillarB] = 4;
                trapsSet2++;
                do
                {
                    pillarC = random.Next(1, width - 1);
                    pillarD = random.Next(1, height - 1);
                } while (maze[pillarC,pillarD] !=0  && maze[pillarC,pillarD] != maze[newI,newJ] && maze[pillarC,pillarD] != maze[newPI,newPJ]);
                maze[pillarC,pillarD] = 5;
                trapsSet3++;
            }   
        }

        static void Generation(int i,int j)
        {
            int[] di = {0,2,0,-2};
            int[] dj = {2,0,-2,0};

            for(int x = 0;x < 4;x++)
            {
                int y = random.Next(x,4);
                (di[x],di[y]) = (di[y],di[x]);
                (dj[x],dj[y]) = (dj[y],dj[x]);
            }

            for(int x = 0; x < 4; x++)
            {
                int ni = i + di[x];
                int nj = j + dj[x];

                if(ni > 0 && ni < width && nj > 0 && nj < height && maze[ni,nj] == 0)
                {
                    maze[ni,nj] = 1;
                    maze[i+di[x]/2,j+dj[x]/2] = 1;
                    Generation(ni,nj);
                }
            }
        }
        static void Print()
        {
            Console.Clear();
            for(int j = 0;j < height;j++)
            {
                for(int i = 0;i < width;i++)
                {
                    if(i == PlayerX && j == PlayerY) AnsiConsole.Markup("[red on red] [/]");   
                    else if(i == Player2X && j == Player2Y) AnsiConsole.Markup("[violet on violet] [/]");
                    else if(maze[i,j] == 0 && maze[i,j] != 3 && maze[i,j] != 4 && maze[i,j] != 5) AnsiConsole.Markup("[white on white] [/]");
                    else if(maze[i,j] == 1) Console.Write(" ");   
                    else if(maze[pillarA,pillarB] == 4 )AnsiConsole.Markup(" ");
                    else if(maze[pillarX,pillarY] == 3 )AnsiConsole.Markup(" ");
                    else if(maze[pillarC,pillarD] == 5 )AnsiConsole.Markup(" ");
                    
                }
                Console.WriteLine();
            }
        }

        public static void Winning()
        {
                Console.Clear();
                AnsiConsole.Write(new FigletText("Player1 won").Centered().Color(Color.Blue));
                Console.ReadKey(false);       
        }
        public static void Winning2()
        {
                Console.Clear();
                AnsiConsole.Write(new FigletText("Player2 won").Centered().Color(Color.Blue));
                Console.ReadKey(false); 
        }
        public static void Leaving()
        {
                AnsiConsole.Write(new FigletText("Seems like you have to leave. See you next time").Centered().Color(Color.Red));
                AnsiConsole.MarkupLine("Press Enter to restart or Scape to quit");
                var Leave = Console.ReadKey(false).Key;   
        }
    }
}
