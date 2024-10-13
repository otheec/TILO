using TuringMachineProject.Models;

namespace TuringMachineProject.Implementations;

public class MultitapeMachine
{
    public static void Run()
    {

        string input = "__" + "aabccaabcddacbad" + "_______";
        Tape tape = new(input);
        Tape tape2 = new("_________________________");

        List<TransitionRule> transitions = [
        new TransitionRule { State = State.START, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.LICHY },

        new TransitionRule { State = State.LICHY, RWM = [
            new ReadWriteMove { Read = "a", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.SUDY },
        new TransitionRule { State = State.LICHY, RWM = [
            new ReadWriteMove { Read = "b", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.SUDY },
        new TransitionRule { State = State.LICHY, RWM = [
            new ReadWriteMove { Read = "c", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.SUDY },
        new TransitionRule { State = State.LICHY, RWM = [
            new ReadWriteMove { Read = "d", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.SUDY },

        new TransitionRule { State = State.SUDY, RWM = [
            new ReadWriteMove { Read = "a", Write = '0', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.LICHY },
        new TransitionRule { State = State.SUDY, RWM = [
            new ReadWriteMove { Read = "b", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.LICHY },
        new TransitionRule { State = State.SUDY, RWM = [
            new ReadWriteMove { Read = "c", Write = '0', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.LICHY },
        new TransitionRule { State = State.SUDY, RWM = [
            new ReadWriteMove { Read = "d", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.LICHY },

        new TransitionRule { State = State.LICHY, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODD },
        new TransitionRule { State = State.SUDY, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODD },

        new TransitionRule { State = State.PREVODD, RWM = [
            new ReadWriteMove { Read = "d", Write = '0', Move = 'L' },
            new ReadWriteMove { Read = "_", Write = 'd', Move = 'R' } ],
            NextState = State.PREVODD },
        new TransitionRule { State = State.PREVODD, RWM = [
            new ReadWriteMove { Read = "c", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODD },
        new TransitionRule { State = State.PREVODD, RWM = [
            new ReadWriteMove { Read = "b", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODD },
        new TransitionRule { State = State.PREVODD, RWM = [
            new ReadWriteMove { Read = "a", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODD },
        new TransitionRule { State = State.PREVODD, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODD },
        new TransitionRule { State = State.PREVODD, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODC },

        new TransitionRule { State = State.PREVODC, RWM = [
            new ReadWriteMove { Read = "c", Write = '0', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = 'c', Move = 'R' } ],
            NextState = State.PREVODC },
        new TransitionRule { State = State.PREVODC, RWM = [
            new ReadWriteMove { Read = "b", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODC },
        new TransitionRule { State = State.PREVODC, RWM = [
            new ReadWriteMove { Read = "a", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODC },
        new TransitionRule { State = State.PREVODC, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODC },
        new TransitionRule { State = State.PREVODC, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODB },

        new TransitionRule { State = State.PREVODB, RWM = [
            new ReadWriteMove { Read = "b", Write = '0', Move = 'L' },
            new ReadWriteMove { Read = "_", Write = 'b', Move = 'R' } ],
            NextState = State.PREVODB },
        new TransitionRule { State = State.PREVODB, RWM = [
            new ReadWriteMove { Read = "a", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODB },
        new TransitionRule { State = State.PREVODB, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODB },
        new TransitionRule { State = State.PREVODB, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODA },

        new TransitionRule { State = State.PREVODA, RWM = [
            new ReadWriteMove { Read = "a", Write = '_', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = 'a', Move = 'R' } ],
            NextState = State.PREVODA },
        new TransitionRule { State = State.PREVODA, RWM = [
            new ReadWriteMove { Read = "0", Write = '_', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = null } ],
            NextState = State.PREVODA },
        new TransitionRule { State = State.PREVODA, RWM = [
            new ReadWriteMove { Read = "_", Write = '0', Move = null },
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "a", Write = null, Move = 'L' } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L' },
            new ReadWriteMove { Read = "a", Write = null, Move =  null} ],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "_", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "a", Write = null, Move =  'L'} ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },

        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "a", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "a", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "a", Write = null, Move = null } ],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "b", Write = null, Move = 'L' } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L' },
            new ReadWriteMove { Read = "b", Write = null, Move =  null} ],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "_", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "b", Write = null, Move =  'L'} ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },

        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "b", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "b", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "b", Write = null, Move = null } ],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "c", Write = null, Move = 'L' } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L' },
            new ReadWriteMove { Read = "c", Write = null, Move =  null} ],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "_", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "c", Write = null, Move =  'L'} ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },

        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "c", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "c", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "c", Write = null, Move = null } ],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "d", Write = null, Move = 'L' } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L' },
            new ReadWriteMove { Read = "d", Write = null, Move =  null} ],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "_", Write = '1', Move = 'R' },
            new ReadWriteMove { Read = "d", Write = null, Move =  'L'} ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },

        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "d", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "d", Write = null, Move = null } ],
            NextState = State.TRANSFER_RIGHT_WHILE_COUNTING },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "d", Write = null, Move = null } ],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = null },
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.TRANSFER_RIGHT_WHILE_COUNTING, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = null },
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },

        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "d", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "d", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = null },
            new ReadWriteMove { Read = "d", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },

        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "c", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "c", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = null },
            new ReadWriteMove { Read = "c", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },

        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "b", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "b", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = null },
            new ReadWriteMove { Read = "b", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },

        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "0", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "a", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "1", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "a", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },
        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = null },
            new ReadWriteMove { Read = "a", Write = null, Move = 'R' } ],
            NextState = State.MOVE_RIGHT_TO_COPPY_NUMBER },

        new TransitionRule { State = State.MOVE_RIGHT_TO_COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.COPPY_NUMBER },

        new TransitionRule { State = State.COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "1", Write = '_', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = '1', Move = 'R' } ],
            NextState = State.COPPY_NUMBER },
        new TransitionRule { State = State.COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "0", Write = '_', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = '0', Move = 'R' } ],
            NextState = State.COPPY_NUMBER },
        new TransitionRule { State = State.COPPY_NUMBER, RWM = [
            new ReadWriteMove { Read = "_", Write = '_', Move = 'R' },
            new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.HALT },

        ];

        TuringMachine tm = new([tape, tape2], transitions, endStates: [State.HALT]);

        tm.Run();

        Console.WriteLine("Final tape states:");
        Console.WriteLine(tape.ToString());
        Console.WriteLine(tape2.ToString());

        Console.WriteLine(tm.Counter);
    }
}