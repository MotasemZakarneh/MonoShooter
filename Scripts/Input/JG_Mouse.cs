using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class JG_Mouse : Unit
{
    MouseState newMouseState = new MouseState();

    public JG_ButtonState left,right;
    public Vector2 mousePos;

    public JG_Mouse()
    {
        left = new JG_ButtonState();
        right = new JG_ButtonState();
    }
    public JG_Mouse(Vector2 pos, string spritePath, float rot, Vector2 scale) : base(pos, spritePath, rot, scale)
    {
        left = new JG_ButtonState();
        right = new JG_ButtonState();
        MouseCursor cursor = MouseCursor.FromTexture2D(sprite,0,0);
        Mouse.SetCursor(cursor);
    }

    public override void Update()
    {
        newMouseState = Mouse.GetState();

        left.Update(newMouseState.LeftButton);
        right.Update(newMouseState.RightButton);

        mousePos.X = newMouseState.Position.X;
        mousePos.Y = newMouseState.Position.Y;

        pos = mousePos;
    }
    public override void Draw()
    {

    }

    public Vector2 GetMousePos()=>mousePos;
    public bool IsLeftUp()=>left.GetButtonUp();
    public bool IsLeftHeld()=>left.GetButton();
    public bool IsLeftDown()=>left.GetButtonDown();
    public bool IsRightUp()=>right.GetButtonUp();
    public bool IsRightHeld()=>right.GetButton();
    public bool IsRightDown()=>right.GetButtonDown();

    public void PrintPos()
    {
        print("("+mousePos.X+","+mousePos.Y+")");
    }
}