using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class UpgradingGG : MonoBehaviour
{
    private float armor;
    void Start()
    {
        armor = 1;
    }
    void Update()
    {
        
    }
    public float GetArmor()
    {
        return armor;
    }
}
