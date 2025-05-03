namespace Lab_8;

public class Blue_1 : Blue
{
    private string[] _output;
    
    public string[] Output => _output;
    
    public Blue_1(string input): base(input)
    {
        this._output = null;
    }

    public override void Review()
    {
        if (string.IsNullOrEmpty(this.Input))
        {
            this._output = null;
            return;
        }

        string foo = "";
        string[] result = this.Input.Split(" ");

        int count = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (count + result[i].Length <= 50)
            {
                if (i != 0) foo += " ";
                count += result[i].Length + 1;
            }
            else
            {
                foo += "\n";
                count = result[i].Length + 1;
            }
            foo += result[i];
        }

        this._output = foo.Split("\n");
    }

    public override string ToString()
    {
        if (this._output == null) return null;
        return string.Join("\r\n", this._output);
    }
}