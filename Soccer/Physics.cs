using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class Physics
    {
        public PointF position;
        float gravity;
        float a;
        float impulse;

        public float dx;

        public Physics()
        {
            position = new PointF(100, 150);
            gravity = 0;
            a = 0.4f;
            impulse = -15;
            dx = -1;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        public void CalculatePhysics()
        {
            

            if (position.X > 750 && dx > 0)
            {
                dx /= 2;
                dx *= -1;
            }
            if (position.X < 0 && dx<0)
            {
                dx /= 2;
                dx *= -1;
            }
            position.X += dx;

            if (position.Y < 500 || a<0)
            {
                if (a != 0.4f)
                {
                    a += 0.05f;
                }
                position.Y += gravity;
                
                gravity += a;
            }
            else
            {
                if (position.Y >= 500)
                {
                    if (Math.Abs(impulse) > 0.1f)
                    {
                        impulse /= 2;
                        AddForce(a/2);
                    }
                }
            }
        }


        public void AddForce(float forceValue)
        {
            gravity=-gravity;
            gravity /= 2;
            a = -forceValue;
        }

        public void AddForceQuickly(float forceValue)
        {  
            gravity = forceValue*30;
            gravity *= -1;
            a = -forceValue;
            impulse = -15;
            dx += 5;
        }

    }
}
