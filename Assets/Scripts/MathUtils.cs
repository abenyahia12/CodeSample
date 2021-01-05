public static class MathUtils 
{

    public static float Interpolate(float value, float x1, float x2, float y1, float y2)
    {
        return y1 + (((value - x1) / (x2 - x1)) * (y2 - y1));
    }
}
