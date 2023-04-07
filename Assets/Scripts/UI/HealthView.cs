using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private GameObject healthPointImageContainer; 
    [SerializeField] private GameObject healthPointImage;
    [SerializeField] private List<GameObject> healthPointImageList;

    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int health) {
        maxHealth = health;

        for (int i = 0; i < health; i++) {
            GameObject go = Instantiate(healthPointImage);
            go.transform.parent = healthPointImageContainer.transform;
            healthPointImageList.Add(go);
        }
    }

    public void SetHealth(int currentHealth) {
        if (currentHealth < 0) {
            return;
        }
        
        for (int i = 0; i < maxHealth; i++) {
            if (i < currentHealth) {
                continue;
            }

            healthPointImageList[i].SetActive(false);
        }
    }
}
