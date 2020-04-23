using UnityEngine;

public class CheckManger : MonoBehaviour
{
    [SerializeField]
    private GeometryObjectData _objectData;

    public void ColorCheck(GameObject figure)
    {
        var figureColor = figure.GetComponent<GeometryObjectModel>().CubeColor;

        figure.GetComponent<GeometryObjectModel>().ClickCount++;

        Color searchColor = SearchColor(figure, figureColor);

        if (figureColor != searchColor)
        {
            figure.GetComponent<Figure>().ChangeColor(searchColor);
        }

    }

    private Color SearchColor(GameObject figure, Color figureColor)
    {
        var figureType = figure.GetComponent<GeometryObjectModel>().FigureType;
        var clickCount = figure.GetComponent<GeometryObjectModel>().ClickCount;

        for (int i = 0; i < _objectData.ClicksData.Count; i++)
        {
            if (_objectData.ClicksData[i].ObjectType == figureType)
            {
                if (clickCount >= _objectData.ClicksData[i].MinClicksCount && clickCount <= _objectData.ClicksData[i].MaxClicksCount)
                {
                    return _objectData.ClicksData[i].Color;
                }
            }
        }
        return default;
    }
}

