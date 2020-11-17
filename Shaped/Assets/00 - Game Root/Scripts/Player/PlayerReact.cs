using UnityEngine;

public class PlayerReact : MonoBehaviour
{
    readonly AlertBox_NotificationState _notificationState = new AlertBox_NotificationState();
    bool _inNeonPickingArea, _pickedNeonsWithElli;
    static bool _elliRanAway;
    public static bool ElliRanAway { get { return _elliRanAway; } }

    private void Start()
    {
        _elliRanAway = false;
    }
    private void Update()
    {
        if (_inNeonPickingArea && Input.GetKeyDown(KeyCode.Space))
        {
            _elliRanAway = true;
            GameManager.Static_IvokePickNeons();
        }

        GameManager.instance.PickNeons += ElliHasRanAway;
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
            AlertBox.Static_TransitionToState(_notificationState,"Press [SPACE] to pick neons with ELLI");
            _inNeonPickingArea = true;
        }            
    }

    void ElliHasRanAway()
    {
        _elliRanAway = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("NeonPicking"))
        {
            AlertBox.Deactivate();
            _inNeonPickingArea = false;
        }
    }
}
