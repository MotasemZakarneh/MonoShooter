using Microsoft.Xna.Framework;

public class World :GameObj
{
    public Vector2 playerStartPos = new Vector2(300,300);
    public Vector2 playerStartScale = new Vector2(0.2f,0.2f);

    Player player = null;

    public void Build()
    {
        player = new Player(playerStartPos,"Player",0,playerStartScale);
    }

    public override void Update()
    {
        player.Update();
    }

    public override void Draw()
    {
        player.Draw();
    }
}