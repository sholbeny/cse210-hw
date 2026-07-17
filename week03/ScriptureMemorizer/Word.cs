public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        string hiddenWord = "";

        foreach (char letter in _text)
        {
            if (char.IsLetterOrDigit(letter))
            {
                hiddenWord += "_";
            }
            else
            {
                // Keep punctuation such as commas, periods, and semicolons
                hiddenWord += letter;
            }
        }

        return hiddenWord;
    }
}