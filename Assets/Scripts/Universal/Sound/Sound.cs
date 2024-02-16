public enum Sound
{
    //Arrow = 0,
    //ArrowHit = 1,
    //Mage = 2,
    //MageUpgraded = 3,
    //MageHit = 4,
    //Fireball = 5,
    //Freeze = 6,
    //FireRangeAbility = 7,
    //SlowTimeAbility = 8,
    //EnemyDie = 9,
    //EnemyWin = 10,
    //PlayerWin = 11,
    //PlayerLose = 12,
    //NextWave = 13,
    //Coin = 14,
    //Button = 15,
    //Build = 16,
    //BGM = 17,
    //Empty = 18,
}

namespace SoundSystem
{
    public static class SoundExtensions
    {
        public static void Play(this Sound sound)
        {
            SoundPlayer.Instance.Play(sound);
        }
    }
}