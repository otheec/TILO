using TouringMachineCoding.Coding;
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

        input = '_' + input + '_';
        Tape tape = new(input);

        List<TransitionRule> transitions = [
            //START
            new TransitionRule { State = 0,  Read = '_', Move = 'R', NextState = 1 },
            //Decrease left number
            new TransitionRule { State = 1,  Read = '0', Move = 'R', NextState = 1 },
            new TransitionRule { State = 1,  Read = '1', Move = 'R', NextState = 1 },
            new TransitionRule { State = 1,  Read = '+', Move = 'L', NextState = 2 },

            new TransitionRule { State = 2,  Read = '0', Move = 'L', NextState = 2 },
            new TransitionRule { State = 2,  Read = '1', Write = '0', Move = 'R', NextState = 3 },
            new TransitionRule { State = 2,  Read = '_', Move = 'R', NextState = 8 },

            new TransitionRule { State = 3,  Read = '0', Write = '1', Move = 'R', NextState = 3 },
            new TransitionRule { State = 3,  Read = '+', Move = 'R', NextState = 4 },
            //Traverse to the start of right number
            new TransitionRule { State = 4,  Read = '0', Move = 'R', NextState = 4 },
            new TransitionRule { State = 4,  Read = '1', Move = 'R', NextState = 4 },
            new TransitionRule { State = 4,  Read = '+', Move = 'R', NextState = 4 },
            new TransitionRule { State = 4,  Read = '_', Move = 'L', NextState = 5 },
            //Decrease right number
            new TransitionRule { State = 5,  Read = '0', Move = 'L', NextState = 5 },
            new TransitionRule { State = 5,  Read = '1', Write = '0', Move = 'R', NextState = 6 },
            new TransitionRule { State = 5,  Read = '+', Write = '0', Move = 'L', NextState = 9},

            new TransitionRule { State = 6,  Read = '0', Write = '1', Move = 'R', NextState = 6 },
            new TransitionRule { State = 6,  Read = '_', Move = 'L', NextState = 7 },
            //Find plus sign (numbers separator)
            new TransitionRule { State = 7,  Read = '0', Move = 'L', NextState = 7 },
            new TransitionRule { State = 7,  Read = '1', Move = 'L', NextState = 7 },
            new TransitionRule { State = 7,  Read = '+', Move = 'L', NextState = 2 },
            //Traverse to the right side (0 output)
            new TransitionRule { State = 8,  Read = '0', Write = '_', Move = 'R', NextState = 8 },
            new TransitionRule { State = 8,  Read = '1', Write = '_', Move = 'R', NextState = 8 },
            new TransitionRule { State = 8,  Read = '+', Write = '_', Move = 'R', NextState = 8 },
            new TransitionRule { State = 8,  Read = '_', Move = 'L', NextState = 11 },
            //Write 0
            new TransitionRule { State = 11,  Read = '_', Write = '0', Move = 'L', NextState = 13 },
            //Traverse to the Left side (1 output)
            new TransitionRule { State = 9, Read = '0', Write = '0', Move = 'L', NextState = 9},
            new TransitionRule { State = 9, Read = '1', Write = '0', Move = 'L', NextState = 9},
            new TransitionRule { State = 9, Read = '+', Write = '0', Move = 'L', NextState = 9},
            new TransitionRule { State = 9, Read = '_', Move = 'R', NextState = 10},
            //Traverse to the right side (1 output)
            new TransitionRule { State = 10,  Read = '0', Write = '_', Move = 'R', NextState = 10},
            new TransitionRule { State = 10,  Read = '1', Write = '_', Move = 'R', NextState = 10},
            new TransitionRule { State = 10,  Read = '+', Write = '_', Move = 'R', NextState = 10},
            new TransitionRule { State = 10,  Read = '_', Move = 'L', NextState = 12 },
            //Write 1
            new TransitionRule { State = 12,  Read = '_', Write = '1', Move = 'L', NextState = 13 },

        ];

        TuringMachine tm = new(tape, transitions, endStates: [13]);

        tm.Run();

        Console.WriteLine("Final tape state:");
        Console.WriteLine(tape.ToString());
        Console.WriteLine("Steps count: " + tape.Counter);

        Console.WriteLine(Encoder.Encode(transitions));

        Decoder.Decode("", "");
    }
}