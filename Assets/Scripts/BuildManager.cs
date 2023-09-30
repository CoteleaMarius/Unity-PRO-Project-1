using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color startColor;
    private GameObject _tempObj;
    [SerializeField] private GameObject[] turrets;
    
    private void Update()
    {
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.CompareTag("Node"))
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
            _tempObj.GetComponent<NodeBuildSetting>().StartBuild(turrets, 0, 0.35f);
        }
        
    }
}
