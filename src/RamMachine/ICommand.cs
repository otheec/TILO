namespace RamMachine;
internal interface ICommand
{
    CommandType Type { get; set; }
    void Parse(string line);
}
