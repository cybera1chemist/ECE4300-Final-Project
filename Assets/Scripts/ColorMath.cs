using UnityEngine;

public static class ColorMath
{
    public static Color Inverse(Color c)
    {
        // hue shifts 180 degrees, S and V preserved.
        Color.RGBToHSV(c, out float h, out float s, out float v);
        h = (h + 0.5f) % 1f;
        return Color.HSVToRGB(h, s, v);
    }

    public static float HueDistance(Color c1, Color c2)
    {
        Color.RGBToHSV(c1, out float h1, out _, out _);
        Color.RGBToHSV(c2, out float h2, out _, out _);
        float d = Mathf.Abs(h1 - h2);
        return Mathf.Min(d, 1f - d) * 2f; // scale to [0, 1]
    }
}
