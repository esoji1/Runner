public class BuffIncreasingHorizontalSpeed : GivesBuff
{
    private float _speedHorizonal = 15;

    protected override void Affect(IBuffPicker buffPicker) => buffPicker.AddSpeedHorizonal(_speedHorizonal);
}
