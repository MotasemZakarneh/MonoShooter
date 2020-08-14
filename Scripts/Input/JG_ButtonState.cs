using Microsoft.Xna.Framework.Input;

public class JG_ButtonState
{
    public ButtonState updateState = ButtonState.Released;

    bool isDown = false;
    bool isHeld = false;
    bool isUp = false;

    public void Update(ButtonState newState)
    {
        if(newState != updateState && newState == ButtonState.Pressed)
        {
            updateState = newState;
            isDown = true;
        }
        else if (newState == updateState && newState == ButtonState.Pressed)
        {
            isDown = false;
            isHeld = true;
        }
        else if(newState != updateState && newState == ButtonState.Released)
        {
            updateState = newState;
            isHeld = false;
            isUp = true;
        }
        else if(newState == updateState && newState == ButtonState.Released)
        {
            isUp = false;
        }
    }
    
    public bool GetButtonDown()=>isDown;
    public bool GetButton()=>isHeld;
    public bool GetButtonUp()=>isUp;
}