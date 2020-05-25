using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class Entity
    {
        public Physics myPhysics;
        public Image sprite;
        public Size mySize;
        int angle = 4;
        public Entity(Size size)
        {
            myPhysics = new Physics();
            sprite = new Bitmap("C:\\Users\\sodrk\\Desktop\\ball.png");
            mySize = size;
        }

        public void DrawSprite(Graphics g)
        {
            //sprite = new Bitmap(RotateImage(sprite));
            g.DrawImage(sprite, myPhysics.position.X, myPhysics.position.Y, mySize.Width, mySize.Height);
        }

        public Image RotateImage(Image img)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(170,170);
            
            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(angle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            //gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new PointF(0,0));
            
            //dispose of our Graphics object
            gfx.Dispose();
            //return the image
            return bmp;
        }
    }
}
