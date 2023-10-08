using UnityEngine;
using UnityEngine.UI;

public class ButtonShopSetting : MonoBehaviour
{
    [SerializeField] private Text costText;
    [Header("Setting")] [SerializeField] private int cost;
    [SerializeField] private int buildIndex;

    private void Awake()
    {
        costText.text = cost.ToString();
        BuildManager manager = FindObjectOfType<BuildManager>();
        GetComponent<Button>().onClick.AddListener(() => manager.SetBuildTurret(cost, buildIndex));
    }
}
