using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetsBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}

