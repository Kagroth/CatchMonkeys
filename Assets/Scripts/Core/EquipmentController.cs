using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] private GameObject[] equipment;
    private EquipmentView equipmentView;
    public int currentEquipment;

    private void Awake() {
        equipmentView = GetComponent<EquipmentView>();
        SwitchEquipment(1);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SwitchEquipment(0);
        }        

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SwitchEquipment(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SwitchEquipment(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            SwitchEquipment(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            SwitchEquipment(4);
        }        
    }

    private void SwitchEquipment(int targetEq) {
        foreach (GameObject eq in equipment) {
            eq.SetActive(false);
        }

        equipment[targetEq].SetActive(true);
        currentEquipment = targetEq;
        equipmentView.HighlightIcon(currentEquipment);
    }
}
