using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostumeMenu : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI titleText;
    public List<CostumeSO> costumeList = new List<CostumeSO>();

    private GameObject player;
    public CostumeSO current;
    private int costumeIndex = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        RetrieveSoData();
    }

    private void RetrieveSoData()
    {
        current = costumeList[costumeIndex];
        
        image.sprite = current.image;
        titleText.text = current.title;
    }

    public void Next()
    {
        if (costumeIndex < costumeList.Count - 1)
            costumeIndex++;
        else 
            costumeIndex = 0;
        
        RetrieveSoData();
    }

    public void Previous()
    {
        if (costumeIndex > 0)
            costumeIndex--;
        else
            costumeIndex = costumeList.Count - 1;
        
        RetrieveSoData();
    }
    
    public void SelectCostume()
    {
        player.GetComponent<Animator>().runtimeAnimatorController = current.animation;
        player.layer = LayerMask.NameToLayer(current.layer);
        gameObject.SetActive(false);
    }
}
