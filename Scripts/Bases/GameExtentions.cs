using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public static class GameExtentions
{
    public static List<T> DuplicateList<T> (List<T> ori)
    {
        List<T> t = new List<T>();
        ori.ForEach(o=>t.Add(o));
        return t;
    }

    public static float GetTargetRot(Vector2 from, Vector2 to, float degOffset)
    {
        Vector2 disp = to - from;
        disp.Normalize();
        float angle = MathF.Atan2(disp.Y,disp.X);

        float radOffset = Deg2Rad(degOffset);
        angle = angle + radOffset;
        return angle;
    }
    public static float Deg2Rad(float deg)
    {
        //180 = PI
        //x = ?
        //xpi = 180?
        //xpi/180 = ?
        float rad= (deg*MathF.PI)/180.0f;
        return rad;
    }
}