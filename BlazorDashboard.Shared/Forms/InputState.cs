using BlazorDashboard.Shared.Enumerations;

namespace BlazorDashboard.Shared.Forms;

public class InputState
{
    private string _errorMessage;
    private Color? _originalBorderColor;
    private Color? _originalIconBgColor;
    private Color _borderColor;
    private Color _iconBgColor;

    public string Value { get; set; } = string.Empty;
    public string Identifier { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    
    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            _originalBorderColor ??= value;
        }
    }
    
    public Color IconBgColor
    {
        get => _iconBgColor;
        set
        {
            _iconBgColor = value;
            _originalIconBgColor ??= value;
        }
    }
    
    public string IconPointer { get; set; } = string.Empty;

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            _originalBorderColor ??= BorderColor;
            _originalIconBgColor ??= IconBgColor;

            if (!string.IsNullOrEmpty(value))
            {
                BorderColor = Color.Danger;
                IconBgColor = Color.Danger;
            }
            else
            {
                BorderColor = _originalBorderColor.Value;
                IconBgColor = _originalIconBgColor.Value;
            }
        }
    }

    public void Validate(string[] errors)
    {
        if (errors != null && errors.Length > 0)
        {
            ErrorMessage = errors[0];
        }
        else
        {
            ErrorMessage = string.Empty;
        }

    }
}
