using UnityEngine;

public class PlayerReact : MonoBehaviour
{
    bool _inNeonPickingArea, _pickedNeonsWithElli;

    private void Update()
    {
        if (_inNeonPickingArea && Input.GetKeyDown(KeyCode.Space))
        {
            _pickedNeonsWithElli = true;
            Debug.Log("PICK IT");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if (item!= null)
        {
            PlayerInventory.Add(item.GetItem());
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("NeonPicking") && PlayerStats.GaveNeonToElli && !_pickedNeonsWithElli)
        {
            AlertBox.Static_NotificationAlert("Press [SPACE] to pick neons with ELLI");
            _inNeonPickingArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("NeonPicking"))
        {
            AlertBox.Static_Hide();
            _inNeonPickingArea = false;
        }
    }
}
