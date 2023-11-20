using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;
    private GameObject _tempObj;
    [SerializeField] private GameObject[] turrets;
    private bool _canBuild;
    private int _turretIndex;
    private int _cost;
    private void Update()
    {
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit))
            {
                if (raycastHit.collider.gameObject.CompareTag("Node") && _canBuild)
                {
                    _tempObj = raycastHit.collider.gameObject;
                    _tempObj.GetComponent<MeshRenderer>().material.color = hoverColor;
                }
                else
                {
                    if (_tempObj != null)
                    {
                        _tempObj.GetComponent<MeshRenderer>().material.color = startColor;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && _canBuild)
        {
            _tempObj.GetComponent<NodeBuildSetting>().StartBuild(turrets, _turretIndex, 0.35f, _cost);
            _canBuild = false;
        }
    }

    public void SetBuildTurret(int buildCost, int buildIndex)
    {
        _turretIndex = buildIndex;
        _cost = buildCost;
        _canBuild = true;
    }
    
}
