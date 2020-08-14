using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class Player : Unit
{
    public float playerSpeed = 10;

    public Player(Vector2 pos, string sprite, float rot, Vector2 scale) : base(pos, sprite, rot, scale)
    {
        
    }
    public override void Update()
    {
        HandleMovement();
        HandleTurning();
    }

    private void HandleTurning()
    {
        rot = GameExtentions.GetTargetRot(pos,Global.mouse.GetMousePos(),270);
    }

    private void HandleMovement()
    {
        int xDir = 0;
        int yDir = 0;
        if(Global.keyboard.GetKey(Keys.D))
            xDir += 1;
        if(Global.keyboard.GetKey(Keys.A))
            xDir -=1;
        if(Global.keyboard.GetKey(Keys.S))
            yDir += 1;
        if(Global.keyboard.GetKey(Keys.W))
            yDir -=1;

        Vector2 dir = new Vector2(xDir,yDir);
        if(dir == Vector2.Zero)
            return;
        
        dir.Normalize();
        pos += dir * playerSpeed;
    }
}