using UnityEngine;

[CreateAssetMenu(fileName = "CPrefs", menuName = "ScriptableObjects/ColorPrefs", order = 1)]
public class ColorPrefs : ScriptableObject
{
    public  Color   on=Color.white;
    public  Color   off=getColor(61,225,255);
    public  Color   backOn=Color.black;
    public  Color   backOff=new Color(0.1f,0.1f,0.1f);

    private static Color getColor(int r, int g, int b)
    {
        return new Color((float)r / 256.0f, (float)g / 255.0f, (float)b / 255.0f);
    }
}
