using TuringMachineProject.Models;

namespace TuringMachineProject.Implementations;

public class BinaryAdditionTuringMachine
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

        input = "_" + input;
        Tape tape = new(input);

        List<TransitionRule> transitions = [
        // #### Move to the most right
        new TransitionRule { State = State.START, Read = "+", Move = 'R', NextState = State.START },
        new TransitionRule { State = State.START, Read = "0", Move = 'R', NextState = State.START },
        new TransitionRule { State = State.START, Read = "1", Move = 'R', NextState = State.START },
        new TransitionRule { State = State.START, Read = "_", Move = 'L', NextState = State.FIND_ONE },

        // #### DECREASE
        // Move left until the first `1` is found
        new TransitionRule { State = State.FIND_ONE, Read = "0", Move = 'L', NextState = State.FIND_ONE },
        new TransitionRule { State = State.FIND_ONE, Read = "1", Write = '0', Move = 'R', NextState = State.CHANGE_ZERO_TO_ONE },
        new TransitionRule { State = State.FIND_ONE, Read = "+", Move = 'R' /* <-- place holder */, NextState = State.HALT },
        // Move one step to the right and change `0` to `1` if applicable
        new TransitionRule { State = State.CHANGE_ZERO_TO_ONE, Read = "0", Write = '1', Move = 'R', NextState = State.CHANGE_ZERO_TO_ONE },
        new TransitionRule { State = State.CHANGE_ZERO_TO_ONE, Read = "_", Move = 'L', NextState = State.FIND_PLUS_TO_LEFT },

        // #### Move to plus symbol to start increasement ####
        new TransitionRule { State = State.FIND_PLUS_TO_LEFT, Read = "0", Move = 'L', NextState = State.FIND_PLUS_TO_LEFT },
        new TransitionRule { State = State.FIND_PLUS_TO_LEFT, Read = "1", Move = 'L', NextState = State.FIND_PLUS_TO_LEFT },
        new TransitionRule { State = State.FIND_PLUS_TO_LEFT, Read = "+", Move = 'L', NextState = State.INCREMENT },

        // #### INCREASE ####
        // Perform the increment starting from the rightmost bit
        new TransitionRule { State = State.INCREMENT,  Read = "0", Write = '1', Move = 'R', NextState = State.START },
        new TransitionRule { State = State.INCREMENT,  Read = "1", Write = '0', Move = 'L', NextState = State.INCREMENT },
        // If the machine reaches the leftmost blank, add an additional `1`
        new TransitionRule { State = State.INCREMENT,  Read = "_", Write = '1', Move = 'R', NextState = State.START }
        ];

        TuringMachine tm = new(tape, transitions, endStates: [State.HALT]);

        tm.Run();

        Console.WriteLine("Final tape state:");
        Console.WriteLine(tape.ToString());

        Console.WriteLine(tape.Counter);
    }
}