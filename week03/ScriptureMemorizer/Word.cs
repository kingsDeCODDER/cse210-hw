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
        if (_isHidden)
        {
            string hiddenText = "";

            foreach (char character in _text)
            {
                if (char.IsLetter(character))
                {
                    hiddenText += "_";
                }
                else
                {
                    hiddenText += character;
                }
            }

            return hiddenText;
        }

        return _text;
    }
}