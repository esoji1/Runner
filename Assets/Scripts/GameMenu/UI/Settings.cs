using TMPro;
using UnityEngine;

public class Settings : BaseAmimationMenuText
{
    [SerializeField] private TextMeshProUGUI _settingsText;

    protected override TextMeshProUGUI Text => _settingsText;
}