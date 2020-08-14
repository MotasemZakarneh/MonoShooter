using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Unit : GameObj
{
    public Vector2 pos;
    public string spritePath;
    public float rot;
    public Vector2 scale;

    public Vector2 offset;
    public string tag;
    public Texture2D sprite;

    public Color color;

    SpriteEffects se;
    
    public Unit()
    {
        pos = Vector2.Zero;
        scale = Vector2.Zero;
        rot = 0;
        spritePath = "";
        tag = "Untagged";
        color = Color.White;
        se = new SpriteEffects();
        
        sprite = null;
        offset = Vector2.Zero;
    }

    public Unit(Vector2 pos, string spritePath, float rot, Vector2 scale)
    {
        this.pos = pos;
        this.spritePath = spritePath;
        this.rot = rot;
        this.scale = scale;
        tag = "Untagged";
        color = Color.White;
        se = new SpriteEffects();
        
        if(!string.IsNullOrEmpty(spritePath))
            sprite = Global.content.Load<Texture2D>("Textures/"+spritePath);

        offset = Vector2.Zero;
    }

    public override void Draw()
    {
        if(sprite == null)
            return;
        
        Global.spriteBatch.Draw(sprite,pos,null,color,rot,offset,scale,se,0);
    }
}