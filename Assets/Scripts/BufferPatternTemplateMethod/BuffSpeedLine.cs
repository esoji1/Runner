public class BuffSpeedLine : GivesBuff
{
    private float _speed = 10f;

    protected override void Affect(IBuffPicker buffPicker) => buffPicker.AddSpeed(_speed);

    protected override void PlaySoundEffect(IBuffPicker audio) => audio.AudioEffectSpeedLine();
}