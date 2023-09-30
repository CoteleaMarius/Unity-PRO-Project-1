using UnityEngine;

public class NodeBuildSetting : MonoBehaviour
{
    private GameObject _structure;

    public GameObject StructureInfo()
    {
        return _structure;
    }
    
    public void StartBuild(GameObject[] structure, int structureIndex, float high)
    {
        if (this._structure == null)
        {
            var position1 = transform.position;
            Vector3 position = new Vector3(position1.x, position1.y + high, position1.z);
            this._structure = Instantiate(structure[structureIndex], position, Quaternion.identity);
        }
    }
    
}
