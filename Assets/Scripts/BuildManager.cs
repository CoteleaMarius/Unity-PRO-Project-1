using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;
    private GameObject _tempObj;
    [SerializeField] private GameObject[] turrets;
    private bool canBuild = false;
    private int turretIndex;
    private int cost;
    
    private void Update()
    {
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.CompareTag("Node") && canBuild)
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

        if (Input.GetMouseButtonDown(0))
        {
            _tempObj.GetComponent<NodeBuildSetting>().StartBuild(turrets, 0, 0.35f, cost);
            canBuild = false;
        }
        
    }

    public void SetBuildTurret(int buildCost, int buildIndex)
    {
        turretIndex = buildIndex;
        cost = buildCost;
        canBuild = true;
    }
    
}
