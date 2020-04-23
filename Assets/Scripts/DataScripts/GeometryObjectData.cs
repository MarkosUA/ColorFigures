using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "Data/GeometryObjectData")]
public class GeometryObjectData : ScriptableObject
{
    public List<ClickColorData> ClicksData;
}
