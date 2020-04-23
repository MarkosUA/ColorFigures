using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FigureCreater : MonoBehaviour
{
    [SerializeField]
    private GameData _gameData;

    private NamesData _prefabsNames;
    private List<GameObject> _prefabs = new List<GameObject>();
    private List<GameObject> _figures = new List<GameObject>();

    public List<GameObject> Figures
    {
        get { return _figures; }
    }

    Vector3 coordinates = new Vector3(0, 0, 0);

    private void Start()
    {
        LoadingData();
    }

    public void FigureMaker(Vector3 position)
    {
        var randName = NameSelection();
        for (int i = 0; i < _prefabs.Count; i++)
        {
            if (_prefabs[i].name == randName)
            {
                var newFigure = Instantiate(_prefabs[i], position, Quaternion.identity);
                newFigure.GetComponent<Figure>().Data = _gameData;
                newFigure.name += _figures.Count.ToString();
                _figures.Add(newFigure);
            }
        }
    }

    private void LoadingData()
    {
        _prefabsNames = PrefabNamesLoader.LoadNames<NamesData>();
        
        LoadAssetBundle();
    }

    private string NameSelection()
    {

        var rand = Random.Range(0, _prefabsNames.names.Length);
        return _prefabsNames.names[rand];
    }

    private void LoadAssetBundle()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/figureprefab"));

        if (myLoadedAssetBundle == null)
        {
            return;
        }

        for (int i = 0; i < _prefabsNames.names.Length; i++)
        {
            _prefabs.Add(myLoadedAssetBundle.LoadAsset<GameObject>(_prefabsNames.names[i]));
            _prefabs[i].GetComponent<GeometryObjectModel>().FigureType = _prefabsNames.names[i];
        }
    }
        
}
