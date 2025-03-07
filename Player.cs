using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace MazeGame
{
    public class Player
    {
        public static int soul1;
        public static int soul2;
        public static int stepsP1 = 9;
        public static int stepsP2 = 9;
        public static int reset = 9;
        public static int endturn = 0;
        public static int SoundON = 1;
        public static int Sound2On = 1;
        public static int killerI = 1;
        public static int killerI2 = 1;
        public static int Pzero = 1;
        public static int Pzero2 = 1;
        public static int Redo = 1;
        public static int Redo2 = 1;
        public static int ReiStep = 1;
        public static int ReiStep2 = 1;

        public static void Presentation(int Ps,int Ps2)
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Welcome to HUECO MUNDO").Centered().Color(Color.Red));
            AnsiConsole.Write(new FigletText("Wait a second").Centered().Color(Color.Red));
            Thread.Sleep(2000);
            AnsiConsole.Progress()
                .AutoRefresh(true)
                .AutoClear(false)
                .HideCompleted(false)
                .Columns(new ProgressColumn[]
                {
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new PercentageColumn(),
                    new SpinnerColumn(Spinner.Known.Aesthetic)
                })
                .StartAsync(async ctx =>
                {
                    var task1 = ctx.AddTask("[yellow]Processing selections[/]");
                    var task2 = ctx.AddTask("[yellow]Invoking souls[/]");
                    var taskFS = ctx.AddTask("[blue]Invoking souls[/]:ghost:");
                    while(!ctx.IsFinished)
                    {
                        await Task.Delay(50);
                        task1.Increment(4);
                        
                        task2.Increment(5);
                        if(!ctx.IsFinished && task1.IsFinished && task2.IsFinished)
                        {
                            await Task.Delay(100);   
                            taskFS.Increment(10);
                        }
                    }    
                });
                Thread.Sleep(4000);
                AnsiConsole.Write(new FigletText("Continue").Centered().Color(Color.Red));
                Console.ReadKey(true);
                AnsiConsole.WriteLine("(en español) En este juego serán medidos la presición de cada jugador a la hora de decidir cuantos pasos usar y cómo,");
                AnsiConsole.WriteLine("(ojo si fallan el paso será tomado como gastado :confunded_face:).");
                AnsiConsole.WriteLine("También las tácticas serán vitales para ser el ganador en este juego de resistencia y paciencia");
                ClassofPlayer1(Ps,Ps2);
                ClassofPlayer2(Ps,Ps2);
                AnsiConsole.MarkupLine("Los primeros 4 o 5 turnos son de posicionamiento" );
                Thread.Sleep(2000);
        }


        public static void ClassofPlayer1(int Ps,int Ps2)
        {
            Console.ReadKey(false);
            Console.Clear();

            var table = new Table().LeftAligned();
            table.Border = TableBorder.Ascii;
                 

            AnsiConsole.Write(new FigletText("Soul Selection").Centered().Color(Color.Blue));
            
            AnsiConsole.MarkupLine("ENTER THE NUMBER OF YOUR SOUL :skull: :" );
            AnsiConsole.Live(table)
                .AutoClear(false)
                .StartAsync(async ctx=>
                {
                    await Task.Delay(100);
                    table.AddColumn(":ghost:");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("1");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("2");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("3");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("4");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("5");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddRow("Classes:","Shinigami","Arrancar","Vizard","Espada","Quincy");
                    ctx.Refresh();
                    Thread.Sleep(100);

                });
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
                
            soul1 = int.Parse(Console.ReadLine()!);
            if(soul1 == 1)
            {
                grid.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid.AddRow("Skill","[Yellow]Bankai[/](R)");
                grid.AddRow("Speed",$"{Ps}");
                grid.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid);
                AnsiConsole.MarkupLine("He can redo everything with his bankai and win in certain turns");
                Console.WriteLine("Continue second player:" );
                Console.ReadKey(true);
                if(true)
                {
                    Console.Clear();
                }
                AnsiConsole.Write(new FigletText("Soul Selection")
                .LeftJustified()
                .Color(Color.Blue));
                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("[red]P2 choose your soul[/]:skull::" );
                
            }
            else if(soul1 == 2)
            {
                grid.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid.AddRow("Skill","[Blue]Sonido[/](U)");
                grid.AddRow("Speed",$"{Ps}");
                grid.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid);
                AnsiConsole.MarkupLine("This player can move fast around walls and if the conditions are well he has a special hability");
                Console.WriteLine("Press any key to continue:" );
                Console.ReadKey(true);
                if(true)
                {
                    Console.Clear();
                }
                AnsiConsole.Write(new FigletText("Soul Selection")
                .LeftJustified()
                .Color(Color.Blue));
                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("[red]P2 choose your soul[/]:skull::" );

            }
            else if(soul1 == 3)
            {
                grid.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid.AddRow("Skill","[Red]Hollow Mask[/](I)");
                grid.AddRow("Speed",$"{Ps}");
                grid.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid);
                AnsiConsole.MarkupLine("This player can incapacitate the other player of using their hability with his Hollow Mask");
                Console.WriteLine("Continue second player:" );
                
                Console.ReadKey(true);
                if(true)
                {
                    Console.Clear();
                }
                AnsiConsole.Write(new FigletText("Soul Selection")
                .LeftJustified()
                .Color(Color.Blue));
                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("[red]P2 choose your soul[/]:skull::" );

                
            }
            else if(soul1 == 4)
            {
                grid.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid.AddRow("Skill","[Yellow]Zero[/](O)");
                grid.AddRow("Speed",$"{Ps}");
                grid.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid);
                AnsiConsole.MarkupLine("A normal player but not so much in certain conditions when he use his ZERO");
                
                Console.WriteLine("Continue second player:" );
                Console.ReadKey(true);
                if(true)
                {
                    Console.Clear();
                }
                AnsiConsole.Write(new FigletText("Soul Selection")
                .LeftJustified()
                .Color(Color.Blue));
                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("[red]P2 choose your soul[/]:skull::" );

            
            }
            else if(soul1 == 5)
            {
                grid.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid.AddRow("Skill","[Yellow]Spiritual Absortion[/](Spacebar)");
                grid.AddRow("Speed",$"{Ps}");
                grid.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid);
                AnsiConsole.MarkupLine("This player can have more steps by his stamina recovery");
                
                Console.WriteLine("Continue second player:" );
                Console.ReadKey(true);
                if(true)
                {
                    Console.Clear();
                }
                AnsiConsole.Write(new FigletText("Soul Selection")
                .LeftJustified()
                .Color(Color.Blue));
                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("[red]P2 choose your soul[/]:skull::" );
        
            }
            else if(soul1 != 1 || soul1 != 2 || soul1 != 3 || soul1 != 4 || soul1 != 5 )
            {
                Console.Clear();
                AnsiConsole.Write(new FigletText("Please select one of the souls").Centered().Color(Color.Red));
                Thread.Sleep(2000);
                ClassofPlayer1(Ps,Ps2);
            }
            Console.Clear();

        }
        public static void ClassofPlayer2(int Ps,int Ps2)
        {
            Console.ReadKey(false);
            Console.Clear();

            var table = new Table().LeftAligned();
            table.Border = TableBorder.Ascii;
                 

            AnsiConsole.Write(new FigletText("Soul Selection").Centered().Color(Color.Blue));
            
            AnsiConsole.MarkupLine("ENTER THE NUMBER OF YOUR SOUL :skull: :" );
            AnsiConsole.Live(table)
                .AutoClear(false)
                .StartAsync(async ctx=>
                {
                    await Task.Delay(100);
                    table.AddColumn(":ghost:");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("1");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("2");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("3");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("4");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddColumn("5");
                    ctx.Refresh();
                    Thread.Sleep(100);

                    table.AddRow("Classes:","Shinigami","Arrancar","Vizard","Espada","Quincy");
                    ctx.Refresh();
                    Thread.Sleep(100);

                });
            var grid2 = new Grid();
            grid2.AddColumn();
            grid2.AddColumn();

            soul2 = int.Parse(Console.ReadLine()!);
            if (soul1 >= 1 && soul1 <= 5 && soul2 == 1 )
            {
                grid2.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid2.AddRow("Skill","[Yellow]Bankai[/]()");
                grid2.AddRow("Speed",$"{Ps2}");
                grid2.AddRow("Steps",$"{stepsP2}");
                AnsiConsole.Write(grid2);
                AnsiConsole.MarkupLine("He can redo everything with his bankai and win in certain turns");
            }
            else if (soul1 >= 1 && soul1 <= 5 && soul2 == 2)
            {
                grid2.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid2.AddRow("Skill","[Blue]Sonido[/](U)");
                grid2.AddRow("Speed",$"{Ps2}");
                grid2.AddRow("Steps",$"{stepsP2}");
                AnsiConsole.Write(grid2);
                AnsiConsole.MarkupLine("This player can move fast around walls and if the conditions are well he has a special hability");
            }
            else if (soul1 >= 1 && soul1 <= 5 && soul2 == 3)
            {
                grid2.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid2.AddRow("Skill","[Red]Hollow Mask[/](I)");
                grid2.AddRow("Speed",$"{Ps2}");
                grid2.AddRow("Steps",$"{stepsP2}"); 
                AnsiConsole.Write(grid2);
                AnsiConsole.MarkupLine("This player can incapacitate the other player of using their hability with his Hollow Mask");
            }
            else if (soul1 >= 1 && soul1 <=5 && soul2 == 4)
            {
                grid2.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid2.AddRow("Skill","[Yellow]Zero[/](O)");
                grid2.AddRow("Speed",$"{Ps}");
                grid2.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid2);
                AnsiConsole.MarkupLine("A normal player but not so much in certain conditions when he use his ZERO");
                
            }
            else if (soul1 >= 1 && soul1 <=5 && soul2 == 5)
            {
                grid2.AddRow(new string[]{"Life",$"[Green]{(int)PlayerStats.Life}[/]"});
                grid2.AddRow("Skill","[Yellow]Spiritual Absortion[/](Spacebar)");
                grid2.AddRow("Speed",$"{Ps}");
                grid2.AddRow("Steps",$"{stepsP1}");
                AnsiConsole.Write(grid2);
                AnsiConsole.MarkupLine("This player can have more steps by his stamina recovery");
                
            }
            else if (soul1 >= 1 || soul1 <=5 || soul2 != 1 || soul2 != 2 || soul2 != 3 || soul2 != 4 || soul2 != 5)
            {
                Console.Clear();
                AnsiConsole.Write(new FigletText("It's no fun you trying to break my game").Centered().Color(Color.Red));
                Thread.Sleep(2000);
                ClassofPlayer2(Ps,Ps2);
            }
            Console.WriteLine("Press any key to continue:" );
            Console.ReadKey(true);

        }

        public enum PlayerStats
        {
            Life = 90,
            Speed = 1,
            Skill = 2
        }

        public enum Player2Stats
        {
            Life = 90,
            Speed = 1,
            Skill = 2
        }
        public enum BoostedStats
        {
            Speed2 = (int)PlayerStats.Speed + 1
        }
        
    }
}
