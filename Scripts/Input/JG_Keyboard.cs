using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

//Adding Helper Functions, for Keyboard of Monogame such that
//GetKeyUp returns true, the frame the Key is up
//GetKeyDown returns true, the frame the key is down
//GetKey returns true the entire duration, that the key is held.
public class JG_Keyboard : GameObj
{
    public KeyboardState keyboardState;

    List<Keys> downKeys = new List<Keys>();
    List<Keys> heldKeys = new List<Keys>();
    List<Keys> uppeKeys = new List<Keys>();

    public JG_Keyboard()
    {
        downKeys = new List<Keys>();
        heldKeys = new List<Keys>();
        uppeKeys = new List<Keys>();
    }

    public override void Update()
    {
        keyboardState = Keyboard.GetState();
        downKeys = keyboardState.GetPressedKeys().ToList();
    }
    public override void LateUpdate()
    {
        //Update Held, keys here, so GetKey can be used next frame.
        foreach (var k in downKeys)
        {
            if(IsKeyInList(k,heldKeys))
                continue;
            
            heldKeys.Add(k);
        }

        //Clear Up Keys
        uppeKeys.Clear();

        for (int i = 0; i < heldKeys.Count; i++)
        {
            Keys k = heldKeys[i];

            //If key is in downKeys meaning, its still pressed
            if(IsKeyInList(k,downKeys))
                continue;
            
            //if key is no longer pressed, then, remove it from down keys
            //and add it to upped keys, so they can be used in next frame's update.
            if(!IsKeyInList(k,uppeKeys))
                uppeKeys.Add(k);
            
            heldKeys[i] = Keys.None;
        }

        //Clear the held keys, empty indicies
        heldKeys.RemoveAll(k=>k == Keys.None);
    }
    
    public bool GetKeyDown(Keys key)
    {
        Keys newKey = downKeys.Find(k=>k==key);
        if(newKey == Keys.None)
            return false;

        return !IsKeyInList(newKey,heldKeys);
    }
    public bool GetKey(Keys key)
    {
        foreach (var jk in heldKeys)
        {
            if(jk == key)
                return true;
        }
        return false;
    }
    public bool GetKeyUp(Keys key)
    {
        foreach (var k in uppeKeys)
        {
            if(k==key)
                return true;
        }
        return false;
    }

    private bool IsKeyInList(Keys k,List<Keys> keys)
    {
        foreach (var key in keys)
        {
            if(key ==k)
                return true;
        }
        return false;
    }
    public void PrintCurrent()
    {
        if(heldKeys.Count == 0)
            return;
        
        string s = "";
        downKeys.ForEach(k=>s = s + k.ToString()+",");
        print(s);
    }
}