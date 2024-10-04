namespace TuringMachineProject.Models;

class TuringMachine(Tape tape, List<TransitionRule> transitions, List<State> endStates)
{
    private readonly Tape Tape = tape;
    private readonly List<TransitionRule> Transitions = transitions;
    private readonly List<State> EndStates = endStates;
    private State CurrentState = State.START;

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

            Tape.PrintTape();
        }
    }

    private TransitionRule? FindTransition()
    {
        string currentSymbol = Tape.Read();
        foreach (var transition in Transitions)
        {
            if (transition.State.Equals(CurrentState) && transition.Read == currentSymbol)
            {
                return transition;
            }
        }
        return null;
    }

    private void ExecuteTransition(TransitionRule transition)
    {
        Tape.ExpandTapeIfNeeded(transition);

        if (transition.Write.HasValue)
        {
            Tape.Write(transition.Write.Value.ToString());
        }

        CurrentState = transition.NextState;

        if (transition.Move == 'R') Tape.MoveRight();
        else if (transition.Move == 'L') Tape.MoveLeft();

        Tape.Counter++;
    }
}

class TransitionRule
{
    public State State { get; init; }
    public string? Read { get; init; }
    public char? Write { get; init; }
    public required char Move { get; init; }
    public State NextState { get; init; }
}

enum State
{
    START,
    FIND_ONE,
    FIND_RIGHT_END,
    CHANGE_ZERO_TO_ONE,
    FIND_PLUS_TO_LEFT,
    INCREMENT,
    HALT
}

class Tape(string input)
{
    private List<string> Symbols = new(input.ToCharArray().Select(c => c.ToString()));
    private int Head = 1;

    public int Counter = 0;

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

    public void ExpandTapeIfNeeded(TransitionRule transition)
    {
        if (Head == 0 && transition.Move == 'L')
        {
            Head++;
            Symbols.Insert(0, "_");
        }
    }
}