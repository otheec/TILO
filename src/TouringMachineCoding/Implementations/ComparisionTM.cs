using TouringMachineCoding.Models;

namespace TouringMachineCoding.Implementations;

public class ComparisionTM
{
    public static void Run()
    {
        Console.WriteLine("Enter you input");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Empty tape");
            return;
        }

        input = "_" + input + "_";
        Tape tape = new(input);

        List<TransitionRule> transitions = [
            //START
            new TransitionRule { State = State.START,  Read = "_", Move = 'R', NextState = State.FIND_START_OF_THE_NUMER_R },
            //ZMENSIT LEVE CISLO
            new TransitionRule { State = State.FIND_START_OF_THE_NUMER_R,  Read = "0", Move = 'R', NextState = State.FIND_START_OF_THE_NUMER_R },
            new TransitionRule { State = State.FIND_START_OF_THE_NUMER_R,  Read = "1", Move = 'R', NextState = State.FIND_START_OF_THE_NUMER_R },
            new TransitionRule { State = State.FIND_START_OF_THE_NUMER_R,  Read = "+", Move = 'L', NextState = State.FIND_1_R },

            new TransitionRule { State = State.FIND_1_R,  Read = "0", Move = 'L', NextState = State.FIND_1_R },
            new TransitionRule { State = State.FIND_1_R,  Read = "1", Write = '0', Move = 'R', NextState = State.DECREASE_R },
            new TransitionRule { State = State.FIND_1_R,  Read = "_", Move = 'R', NextState = State.TRAVERSE_0 },

            new TransitionRule { State = State.DECREASE_R,  Read = "0", Write = '1', Move = 'R', NextState = State.DECREASE_R },
            new TransitionRule { State = State.DECREASE_R,  Read = "+", Move = 'R', NextState = State.TRAVERSE_R },
            //PRESUN NA PRAVY ZACATEK
            new TransitionRule { State = State.TRAVERSE_R,  Read = "0", Move = 'R', NextState = State.TRAVERSE_R },
            new TransitionRule { State = State.TRAVERSE_R,  Read = "1", Move = 'R', NextState = State.TRAVERSE_R },
            new TransitionRule { State = State.TRAVERSE_R,  Read = "+", Move = 'R', NextState = State.TRAVERSE_R },
            new TransitionRule { State = State.TRAVERSE_R,  Read = "_", Move = 'L', NextState = State.FIND_1_L },
            //ZMENSIT PRAVE CISLO
            new TransitionRule { State = State.FIND_1_L,  Read = "0", Move = 'L', NextState = State.FIND_1_L },
            new TransitionRule { State = State.FIND_1_L,  Read = "1", Write = '0', Move = 'R', NextState = State.DECREASE_L },
            new TransitionRule { State = State.FIND_1_L,  Read = "+", Write = '0', Move = 'L', NextState = State.TRAVERSE_1 },

            new TransitionRule { State = State.DECREASE_L,  Read = "0", Write = '1', Move = 'R', NextState = State.DECREASE_L },
            new TransitionRule { State = State.DECREASE_L,  Read = "_", Move = 'L', NextState = State.FIND_PLUS },
            //NAJDI PLUS
            new TransitionRule { State = State.FIND_PLUS,  Read = "0", Move = 'L', NextState = State.FIND_PLUS },
            new TransitionRule { State = State.FIND_PLUS,  Read = "1", Move = 'L', NextState = State.FIND_PLUS },
            new TransitionRule { State = State.FIND_PLUS,  Read = "+", Move = 'L', NextState = State.FIND_1_R },
            //PRESUN NA PRAVY ZACATEK PRO MAZANI NA _
            new TransitionRule { State = State.TRAVERSE_0,  Read = "0", Write = '_', Move = 'R', NextState = State.TRAVERSE_0 },
            new TransitionRule { State = State.TRAVERSE_0,  Read = "1", Write = '_', Move = 'R', NextState = State.TRAVERSE_0 },
            new TransitionRule { State = State.TRAVERSE_0,  Read = "+", Write = '_', Move = 'R', NextState = State.TRAVERSE_0 },
            new TransitionRule { State = State.TRAVERSE_0,  Read = "_", Move = 'L', NextState = State.WRITE_0 },
            //ZAPIS 0
            new TransitionRule { State = State.WRITE_0,  Read = "_", Write = '0', Move = 'L', NextState = State.HALT },
            //PRESUN NA LEVY ZACATEK PRO MAZANI NA 0
            new TransitionRule { State = State.TRAVERSE_1,  Read = "0", Write = '0', Move = 'L', NextState = State.TRAVERSE_1 },
            new TransitionRule { State = State.TRAVERSE_1,  Read = "1", Write = '0', Move = 'L', NextState = State.TRAVERSE_1 },
            new TransitionRule { State = State.TRAVERSE_1,  Read = "+", Write = '0', Move = 'L', NextState = State.TRAVERSE_1 },
            new TransitionRule { State = State.TRAVERSE_1,  Read = "_", Move = 'R', NextState = State.TRAVERSE_11 },
            //PRESUN NA PRAVY ZACATEK PRO MAZANI NA _
            new TransitionRule { State = State.TRAVERSE_11,  Read = "0", Write = '_', Move = 'R', NextState = State.TRAVERSE_11 },
            new TransitionRule { State = State.TRAVERSE_11,  Read = "1", Write = '_', Move = 'R', NextState = State.TRAVERSE_11 },
            new TransitionRule { State = State.TRAVERSE_11,  Read = "+", Write = '_', Move = 'R', NextState = State.TRAVERSE_11 },
            new TransitionRule { State = State.TRAVERSE_11,  Read = "_", Move = 'L', NextState = State.WRITE_1 },
            //ZAPIS 1
            new TransitionRule { State = State.WRITE_1,  Read = "_", Write = '1', Move = 'L', NextState = State.HALT },

        ];

        TuringMachine tm = new(tape, transitions, endStates: [State.HALT]);

        tm.Run();

        Console.WriteLine("Final tape state:");
        Console.WriteLine(tape.ToString());

        Console.WriteLine(tape.Counter);
    }
}