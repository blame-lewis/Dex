using System;
using System.Collections.Generic;
using System.Text;

namespace Dex
{
    class Compressor
    {
        const int lookahead = 50;
        const float releaseFactor = 0.99999f;
        List<float> leftaheads = new List<float>();
        List<float> rightaheads = new List<float>();
        static float state = 1.0f;
        static float goalstate = 1.0f;

        public float[] compress(float left, float right)
        {
            leftaheads.Add(left);
            while (leftaheads.Count > lookahead)
                leftaheads.RemoveAt(0);
            rightaheads.Add(right);
            while (rightaheads.Count > lookahead)
                rightaheads.RemoveAt(0);

            if (Math.Abs(left) + Math.Abs(right) < 0.001f)
                return new float[] { 0.0f, 0.0f };

            float highest = 0.0f;
            foreach (float f in leftaheads)
            {
                float v1 = (float)Math.Abs(f);
                if (v1 > highest)
                    highest = v1;
            }
            foreach (float f in rightaheads)
            {
                float v1 = (float)Math.Abs(f);
                if (v1 > highest)
                    highest = v1;
            }
            if (highest >= state)
                goalstate = highest;
            else
                goalstate *= releaseFactor;
            if (goalstate < 0.5f)
                goalstate = 0.5f;

            state = goalstate;


            float leftOut = left / state;
            float rightOut = right / state;

            if (leftOut > 1.0f)
                leftOut = 1.0f;
            if (leftOut < -1.0f)
                leftOut = -1.0f;
            if (rightOut > 1.0f)
                rightOut = 1.0f;
            if (rightOut < -1.0f)
                rightOut = -1.0f;
            if(highest <= 0.01f)
                return new float[] { 0.0f, 0.0f };
            return new float[] { leftOut, rightOut };
        }
    }
}
