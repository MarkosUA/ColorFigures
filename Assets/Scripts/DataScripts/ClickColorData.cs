using UnityEngine;

[CreateAssetMenu(fileName = "ClickColorData", menuName = "Data/ClickColorData")]
public class ClickColorData : ScriptableObject
{
    public string ObjectType;
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color Color;
}