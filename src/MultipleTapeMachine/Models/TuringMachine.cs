namespace TuringMachineProject.Models;

class TuringMachine(List<Tape> tape, List<TransitionRule> transitions, List<State> endStates)
{
    private readonly List<Tape> Tapes = tape;
    private readonly List<TransitionRule> Transitions = transitions;
    private readonly List<State> EndStates = endStates;
    private State CurrentState = State.START;
    public int Counter = 0;

    public void Run()
    {
        while (!EndStates.Contains(CurrentState))
        {
            var transition = FindTransition();

            if (transition == null)
            {
                Console.WriteLine("No valid transition found. Halting.");
                break;
            }

            ExecuteTransition(transition);

            Counter++;

            foreach (Tape tape in Tapes) tape.PrintTape();
        }
    }

    private TransitionRule? FindTransition()
    {
        foreach (var transition in Transitions)
        {
            if (transition.State.Equals(CurrentState) && transition.RWM[0].Read == Tapes[0].Read() && transition.RWM[1].Read == Tapes[1].Read())
            {
                return transition;
            }
        }
        return null;
    }

    private void ExecuteTransition(TransitionRule transition)
    {
        //Tapes.ExpandTapeIfNeeded(transition);

        for (int i = 0; i < Tapes.Count; i++)
        {
            if (transition.RWM[i].Write.HasValue)
            {
                tape[i].Write(transition.RWM[i].Write.Value.ToString());
            }

            if (transition.RWM[i].Move == 'R') tape[i].MoveRight();
            else if (transition.RWM[i].Move == 'L') tape[i].MoveLeft();

        }

        CurrentState = transition.NextState;
    }
}

class TransitionRule()
{
    public State State { get; init; }
    public List<ReadWriteMove> RWM { get; init; } = [];
    public State NextState { get; init; }
}

class ReadWriteMove()
{
    public string? Read { get; init; }
    public char? Write { get; init; }
    public char? Move { get; init; }
}

enum State
{
    START,

    LICHY,
    SUDY,

    PREVODD,
    PREVODC,
    PREVODB,
    PREVODA,

    INCREMENT,
    TRANSFER_RIGHT_WHILE_COUNTING,

    MOVE_RIGHT_TO_COPPY_NUMBER,

    COPPY_NUMBER,

    HALT
}

class Tape(string input)
{
    private List<string> Symbols = new(input.ToCharArray().Select(c => c.ToString()));
    private int Head = 1;

    public string Read()
    {
        return Symbols[Head];
    }

    public void Write(string symbol)
    {
        Symbols[Head] = symbol;
    }

    public void MoveRight()
    {
        Head++;
        if (Head >= Symbols.Count)
        {
            Symbols.Add("_");
        }
    }

    public void MoveLeft()
    {
        if (Head > 0)
        {
            Head--;
        }
    }

    public override string ToString()
    {
        return string.Join("", Symbols);
    }

    public void PrintTape()
    {
        Console.WriteLine(string.Join("", Symbols));
    }

    /*public void ExpandTapeIfNeeded(TransitionRule transition)
    {
        if (Head == 0 && transition.Move == 'L')
        {
            Head++;
            Symbols.Insert(0, "_");
        }
    }*/
}