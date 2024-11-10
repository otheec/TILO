namespace TouringMachineCoding.Models;

class TuringMachine(Tape tape, List<TransitionRule> transitions, List<int> endStates)
{
    private readonly Tape _tape = tape;
    private readonly List<TransitionRule> _transitions = transitions;
    private readonly List<int> _endStates = endStates;

    private int CurrentState = 0;

    public void Run()
    {
        while (!_endStates.Contains(CurrentState))
        {
            var transition = FindTransition();

            if (transition == null)
            {
                Console.WriteLine("No valid transition found. Halting.");
                break;
            }

            ExecuteTransition(transition);

            _tape.PrintTape();
        }
    }

    private TransitionRule? FindTransition()
    {
        char currentSymbol = _tape.Read();
        foreach (var transition in _transitions)
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
        _tape.ExpandTapeIfNeeded(transition);

        if (transition.Write.HasValue)
        {
            _tape.Write(transition.Write.Value);
        }

        CurrentState = transition.NextState;

        if (transition.Move == 'R') _tape.MoveRight();
        else if (transition.Move == 'L') _tape.MoveLeft();

        _tape.Counter++;
    }
}

class TransitionRule
{
    public int State { get; init; }
    public char? Read { get; init; }
    public char? Write { get; init; }
    public char? Move { get; init; }
    public int NextState { get; init; }
}

/*

not using enum for states anymore, made it easier for encoding and decoding
left them there for debugging purposes

enum State
{
    START, 

    FIND_START_OF_THE_NUMER_R,
    FIND_1_R,
    DECREASE_R,

    TRAVERSE_R,

    FIND_1_L,
    DECREASE_L,

    FIND_PLUS,

    TRAVERSE_0,
    TRAVERSE_1,
    TRAVERSE_11,

    WRITE_0,
    WRITE_1,

    HALT
}*/

class Tape(string input)
{
    private List<char> Symbols = new(input.ToCharArray());
    private int Head = 0;

    public int Counter = 0;

    public char Read()
    {
        return Symbols[Head];
    }

    public void Write(char symbol)
    {
        Symbols[Head] = symbol;
    }

    public void MoveRight()
    {
        Head++;
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
            Symbols.Insert(0, '_');
        }
    }
}