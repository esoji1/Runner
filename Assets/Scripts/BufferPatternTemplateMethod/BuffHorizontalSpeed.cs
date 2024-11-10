public class BuffHorizontalSpeed : GivesBuff
{ 
    private float _speedHorizonal = 15;

    protected override void Affect(IBuffPicker buffPicker) => buffPicker.AddSpeedHorizonal(_speedHorizonal);

    protected override void PlaySoundEffect(IBuffPicker audio) => audio.AudioEffectHorizontalSpeed();
}