using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlertBox_BaseState
{
    public abstract void EnterState(AlertBox alertBox, string message);
}

public class AlertBox_InActiveState : AlertBox_BaseState
{
    public override void EnterState(AlertBox alertBox,string message)
    {
        alertBox.Hide();
    }
}

public class AlertBox_DialogueOptionState : AlertBox_BaseState
{
    public override void EnterState(AlertBox alertBox, string message)
    {
        alertBox.ChangeImage(1);

        message = "Press [SPACE] to talk to " + message;
        alertBox.Show(message);
    }
}

public class AlertBox_ObjectiveCompleteState : AlertBox_BaseState
{
    public override void EnterState(AlertBox alertBox, string message)
    {
        alertBox.ChangeImage(3);
        alertBox.Show(message);
    }
}

public class AlertBox_NotificationState : AlertBox_BaseState
{
    public override void EnterState(AlertBox alertBox, string message)
    {
        alertBox.ChangeImage(4);
        alertBox.Show(message);
    }
}