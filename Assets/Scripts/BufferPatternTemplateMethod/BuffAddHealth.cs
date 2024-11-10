public class BuffAddHealth : GivesBuff
{
    private int _healtBuff = 20;

    protected override void Affect(IBuffPicker buffPicker) => buffPicker.AddHealth(_healtBuff);

    protected override void PlaySoundEffect(IBuffPicker audio) => audio.AudioEffectHealth();
}