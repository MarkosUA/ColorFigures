using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FigureCreater _figureCreater;
    [SerializeField]
    private CheckManger _checkManger;
    [SerializeField]
    private Camera _camera;

    private Plane _plane;
    private Vector3 _distanceFromCamera;

    [SerializeField]
    private float _distanceZ;

    private void Start()
    {
        _distanceFromCamera = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z + _distanceZ);
        _plane = new Plane(Vector3.forward, _distanceFromCamera);
    }

    private void Update()
    {
        CheckClick();
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            var enter = 0.0f;

            if (Physics.Raycast(ray, out var hit))
            {
                for (int i = 0; i < _figureCreater.Figures.Count; i++)
                {
                    if (hit.collider.name == _figureCreater.Figures[i].name)
                    {
                        _checkManger.ColorCheck(_figureCreater.Figures[i]);
                    }
                }
            }
            else
            {
                if (_plane.Raycast(ray, out enter))
                {
                    _figureCreater.FigureMaker(ray.GetPoint(enter));
                }
            }
        }
    }
}