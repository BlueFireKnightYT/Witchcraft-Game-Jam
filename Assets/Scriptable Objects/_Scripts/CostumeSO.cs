using UnityEngine;

[CreateAssetMenu(fileName = "CostumeSO", menuName = "Scriptable Objects/CostumeSO")]
public class CostumeSO : ScriptableObject
{
    public Sprite image;
    public string title;
    public RuntimeAnimatorController animation;
}
