using TuringMachineProject.Models;

namespace TuringMachineProject.Implementations;

public class MultitapeMachine
{
    public static void Run()
    {

        string input = "*_" + "aabccaabcddacbad" + "______*";
        Tape tape = new(input);
        Tape tape2 = new("*_______________________*");

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
            new ReadWriteMove { Read = "_", Write = null, Move = null },
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS },

        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "a", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_1 },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "b", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_1 },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "c", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_1 },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "d", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_1 },

        new TransitionRule { State = State.COUNT_LETTERS_1, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_2 },

        new TransitionRule { State = State.COUNT_LETTERS_2, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = '1', Move = 'L' } ],
            NextState = State.COUNT_LETTERS_3 },


        new TransitionRule { State = State.COUNT_LETTERS_3, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_3 },
        new TransitionRule { State = State.COUNT_LETTERS_3, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "a", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_4 },
        new TransitionRule { State = State.COUNT_LETTERS_3, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "b", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_4 },
        new TransitionRule { State = State.COUNT_LETTERS_3, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "c", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_4 },
        new TransitionRule { State = State.COUNT_LETTERS_3, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "d", Write = '_', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_4 },


        new TransitionRule { State = State.COUNT_LETTERS_4, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_4 },
        new TransitionRule { State = State.COUNT_LETTERS_4, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_5 },

        new TransitionRule { State = State.COUNT_LETTERS_5, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_5 },
        new TransitionRule { State = State.COUNT_LETTERS_5, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = '0', Move = 'L' } ],
            NextState = State.COUNT_LETTERS_6 },
        new TransitionRule { State = State.COUNT_LETTERS_5, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "0", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_9 },

        new TransitionRule { State = State.COUNT_LETTERS_6, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = '0', Move = 'L' } ],
            NextState = State.COUNT_LETTERS_6 },
        new TransitionRule { State = State.COUNT_LETTERS_6, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_7 },

        new TransitionRule { State = State.COUNT_LETTERS_7, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "0", Write = '1', Move = 'L' } ],
            NextState = State.COUNT_LETTERS_8 },

        new TransitionRule { State = State.COUNT_LETTERS_8, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_3 },

        new TransitionRule { State = State.COUNT_LETTERS_9, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "0", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_9 },
        new TransitionRule { State = State.COUNT_LETTERS_9, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = null, Move = 'R' } ],
            NextState = State.COUNT_LETTERS_9 },
        new TransitionRule { State = State.COUNT_LETTERS_9, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_10 },

        new TransitionRule { State = State.COUNT_LETTERS_10, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_10 },
        new TransitionRule { State = State.COUNT_LETTERS_10, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "0", Write = '1', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_11 },

        new TransitionRule { State = State.COUNT_LETTERS_11, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = '0', Move = 'R' } ],
            NextState = State.COUNT_LETTERS_11 },
        new TransitionRule { State = State.COUNT_LETTERS_11, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_12 },

        new TransitionRule { State = State.COUNT_LETTERS_12, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "0", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_12 },
        new TransitionRule { State = State.COUNT_LETTERS_12, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "1", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_12 },
        new TransitionRule { State = State.COUNT_LETTERS_12, RWM = [
                new ReadWriteMove { Read = "_", Write = null, Move = null },
                new ReadWriteMove { Read = "_", Write = null, Move = 'L' } ],
            NextState = State.COUNT_LETTERS_3 },
        
        
        

        /*new TransitionRule { State = State.COUNT_LETTERS, RWM = [
            new ReadWriteMove { Read = "a", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = '1', } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
            new ReadWriteMove { Read = "b", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
            new ReadWriteMove { Read = "c", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
            new ReadWriteMove { Read = "d", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.COUNT_LETTERS, RWM = [
            new ReadWriteMove { Read = "_", Write = null, Move = 'L' },
            new ReadWriteMove { Read = "_", Write = null, } ],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', },
            new ReadWriteMove { Read = "a", Write = null, }],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', },
            new ReadWriteMove { Read = "b", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', },
            new ReadWriteMove { Read = "c", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "0", Write = '1', },
            new ReadWriteMove { Read = "d", Write = null, } ],
            NextState = State.COUNT_LETTERS },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L'},
            new ReadWriteMove { Read = "a", Write = null, }],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L'},
            new ReadWriteMove { Read = "b", Write = null, }],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L'},
            new ReadWriteMove { Read = "c", Write = null, }, ],
            NextState = State.INCREMENT },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', Move = 'L'},
            new ReadWriteMove { Read = "d", Write = null, },],
            NextState = State.INCREMENT },

        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', },
            new ReadWriteMove { Read = "a", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', },
            new ReadWriteMove { Read = "b", Write = null, } ],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', },
            new ReadWriteMove { Read = "c", Write = null, }],
            NextState = State.COUNT_LETTERS },
        new TransitionRule { State = State.INCREMENT, RWM = [
            new ReadWriteMove { Read = "1", Write = '0', },
            new ReadWriteMove { Read = "d", Write = null, }],
            NextState = State.COUNT_LETTERS },*/
        ];

        TuringMachine tm = new([tape, tape2], transitions, endStates: [State.HALT]);

        tm.Run();

        Console.WriteLine("Final tape states:");
        Console.WriteLine(tape.ToString());
        Console.WriteLine(tape2.ToString());

        Console.WriteLine(tm.Counter);
    }
}