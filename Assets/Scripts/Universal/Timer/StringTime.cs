using System;

public static class StringTime
{
    public static string SecondToTimeString(float value)
    {
        return TimeSpan.FromSeconds(value).ToString(@"mm\:ss\.ff");
    }
}