using TMPro;
using UnityEngine;

public class Play : BaseAmimationMenuText
{
    [SerializeField] private TextMeshProUGUI _playText;

    protected override TextMeshProUGUI Text => _playText;
}