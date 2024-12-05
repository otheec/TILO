namespace RamMachine;
public interface ICommand
{
    CommandType Type { get; set; }
    void Parse(string line);
}
