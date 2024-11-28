using TMPro;
using UnityEngine;

public class Exit : BaseAmimationMenuText
{
    [SerializeField] private TextMeshProUGUI _exitText;

    protected override TextMeshProUGUI Text => _exitText;
}