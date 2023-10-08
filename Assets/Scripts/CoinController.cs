using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int startCoin;
    private static int _coin;
    [SerializeField] private Text coinText;
    private void Awake()
    {
        _coin = startCoin;
    }

    public static int GetCoinValue()
    {
        return _coin;
    }

    public static void AddCoin(int value)
    {
        _coin += value;
    }

    public static bool SubtractCoin(int value)
    {
        if (value > _coin) return false;
        _coin -= value;
        return true;
    }

    private void LateUpdate()
    {
        coinText.text = _coin.ToString();
    }
    
}
