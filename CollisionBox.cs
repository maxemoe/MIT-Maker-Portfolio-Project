using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace engine1.GameObjects
{
    public class CollisionBox
    {
        //use with square/rectangular objects/ships

        public Vector2 size; //x = width, y=height
        public Vector2 start; //coordinates of start of box relative to top left of object's texture
        public float rotation;
        public double angle1;
        public double angle2;
        public double square;
        public Vector2 topLeft;
        public Vector2 topRight;
        public Vector2 bottomLeft;
        public Vector2 bottomRight;

        public CollisionBox(float width, float height, Vector2 boxStart, float objRotation)
        {
            size.X = width;
            size.Y = height;
            start = boxStart;
            rotation = objRotation;

            square = Math.Sqrt(((size.X/2) * (size.X/2)) + ((size.Y/2) * (size.Y/2)));

            angle1 = RadianToDegree(Math.Asin(((double)size.Y / 2) / square));
            angle2 = 180 - angle1;

            topRight.X = (float)(Math.Cos(DegreeToRadian(angle1 + rotation)) * square);
            topRight.Y = (float)(Math.Sin(DegreeToRadian(angle1 + rotation)) * square);

            bottomLeft.X = (float)(Math.Cos(DegreeToRadian(angle1 + 180 + rotation)) * square);
            bottomLeft.Y = (float)(Math.Sin(DegreeToRadian(angle1 + 180 + rotation)) * square);

            bottomRight.X = (float)(Math.Cos(DegreeToRadian(angle2 + 180 + rotation)) * square);
            bottomRight.Y = (float)(Math.Sin(DegreeToRadian(angle2 + 180 + rotation)) * square);

            topLeft.X = (float)(Math.Cos(DegreeToRadian(angle2 + rotation)) * square);
            topLeft.Y = (float)(Math.Sin(DegreeToRadian(angle2 + rotation)) * square);
            


        }

        public bool CheckCollision(Vector2 obj1TopLeftCoordinate, Vector2 obj2TopLeftCoordinate, CollisionBox obj2CollisionBox)
        {

            Vector2 axis1 = new Vector2();
            Vector2 axis2 = new Vector2();
            Vector2 axis3 = new Vector2();
            Vector2 axis4 = new Vector2();

            Vector2 atr = this.topRight + obj1TopLeftCoordinate;
            Vector2 atl = this.topLeft + obj1TopLeftCoordinate;
            Vector2 abr = this.bottomRight + obj1TopLeftCoordinate;
            Vector2 abl = this.bottomLeft + obj1TopLeftCoordinate;

            Vector2 btr = obj2CollisionBox.topRight + obj2TopLeftCoordinate;
            Vector2 btl = obj2CollisionBox.topLeft + obj2TopLeftCoordinate;
            Vector2 bbr = obj2CollisionBox.bottomRight + obj2TopLeftCoordinate;
            Vector2 bbl = obj2CollisionBox.bottomLeft + obj2TopLeftCoordinate;


            axis1.X = atr.X - atl.X;
            axis1.Y = atr.Y - atl.Y;
            axis2.X = atr.X - abr.X;
            axis2.Y = atr.Y - abr.Y;
            axis3.X = btl.X - bbl.X;
            axis3.Y = btl.Y - bbl.Y;
            axis4.X = btl.X - btr.X;
            axis4.Y = btl.Y - btr.Y;

            Vector2 atrProjection1 = Project(axis1, atr);
            Vector2 atlProjection1 = Project(axis1, atl);
            Vector2 abrProjection1 = Project(axis1, abr);
            Vector2 ablProjection1 = Project(axis1, abl);
            Vector2 btrProjection1 = Project(axis1, btr);
            Vector2 btlProjection1 = Project(axis1, btl);
            Vector2 bbrProjection1 = Project(axis1, bbr);
            Vector2 bblProjection1 = Project(axis1, bbl);

            Vector2 atrProjection2 = Project(axis2, atr);
            Vector2 atlProjection2 = Project(axis2, atl);
            Vector2 abrProjection2 = Project(axis2, abr);
            Vector2 ablProjection2 = Project(axis2, abl);
            Vector2 btrProjection2 = Project(axis2, btr);
            Vector2 btlProjection2 = Project(axis2, btl);
            Vector2 bbrProjection2 = Project(axis2, bbr);
            Vector2 bblProjection2 = Project(axis2, bbl);

            Vector2 atrProjection3 = Project(axis3, atr);
            Vector2 atlProjection3 = Project(axis3, atl);
            Vector2 abrProjection3 = Project(axis3, abr);
            Vector2 ablProjection3 = Project(axis3, abl);
            Vector2 btrProjection3 = Project(axis3, btr);
            Vector2 btlProjection3 = Project(axis3, btl);
            Vector2 bbrProjection3 = Project(axis3, bbr);
            Vector2 bblProjection3 = Project(axis3, bbl);

            Vector2 atrProjection4 = Project(axis4, atr);
            Vector2 atlProjection4 = Project(axis4, atl);
            Vector2 abrProjection4 = Project(axis4, abr);
            Vector2 ablProjection4 = Project(axis4, abl);
            Vector2 btrProjection4 = Project(axis4, btr);
            Vector2 btlProjection4 = Project(axis4, btl);
            Vector2 bbrProjection4 = Project(axis4, bbr);
            Vector2 bblProjection4 = Project(axis4, bbl);

            if (CompareProjections(axis1, atrProjection1, atlProjection1, abrProjection1, ablProjection1, btrProjection1, btlProjection1, bbrProjection1, bblProjection1) &&
                CompareProjections(axis2, atrProjection2, atlProjection2, abrProjection2, ablProjection2, btrProjection2, btlProjection2, bbrProjection2, bblProjection2) &&
                CompareProjections(axis3, atrProjection3, atlProjection3, abrProjection3, ablProjection3, btrProjection3, btlProjection3, bbrProjection3, bblProjection3) &&
                CompareProjections(axis4, atrProjection4, atlProjection4, abrProjection4, ablProjection4, btrProjection4, btlProjection4, bbrProjection4, bblProjection4))
            {
                return true;
            }
            

            return false;
        }

        public void Update(float objRotation)
        {
            if (objRotation != rotation)
            {
                rotation = objRotation;

                topRight.X = (float)(Math.Cos(DegreeToRadian(angle1 + rotation)) * square);
                topRight.Y = (float)(Math.Sin(DegreeToRadian(angle1 + rotation)) * square);

                bottomLeft.X = (float)(Math.Cos(DegreeToRadian(angle1 + 180 + rotation)) * square);
                bottomLeft.Y = (float)(Math.Sin(DegreeToRadian(angle1 + 180 + rotation)) * square);

                bottomRight.X = (float)(Math.Cos(DegreeToRadian(angle2 + 180 + rotation)) * square);
                bottomRight.Y = (float)(Math.Sin(DegreeToRadian(angle2 + 180 + rotation)) * square);

                topLeft.X = (float)(Math.Cos(DegreeToRadian(angle2 + rotation)) * square);
                topLeft.Y = (float)(Math.Sin(DegreeToRadian(angle2 + rotation)) * square);
            }
        }

        public Vector2 Project(Vector2 axis, Vector2 cornerVector)
        {
            Vector2 projection = new Vector2();

            projection.X = ((cornerVector.X * axis.X + cornerVector.Y * axis.Y) / (axis.X * axis.X + axis.Y * axis.Y)) * axis.X;
            projection.Y = ((cornerVector.X * axis.X + cornerVector.Y * axis.Y) / (axis.X * axis.X + axis.Y * axis.Y)) * axis.Y;

            return projection;
        }

        public bool CompareProjections(Vector2 axis, Vector2 atrProjection, Vector2 atlProjection, Vector2 abrProjection, Vector2 ablProjection, Vector2 btrProjection, Vector2 btlProjection, Vector2 bbrProjection, Vector2 bblProjection)
        {
            float minA = atrProjection.X * axis.X + atrProjection.Y * axis.Y;
            float maxA = atrProjection.X * axis.X + atrProjection.Y * axis.Y;
            float minB = btrProjection.X * axis.X + btrProjection.Y * axis.Y;
            float maxB = btrProjection.X * axis.X + btrProjection.Y * axis.Y;

            if ((atlProjection.X * axis.X + atlProjection.Y * axis.Y) > maxA)
            {
                maxA = atlProjection.X * axis.X + atlProjection.Y * axis.Y;
            }
            else if ((atlProjection.X * axis.X + atlProjection.Y * axis.Y) < minA)
            {
                minA = atlProjection.X * axis.X + atlProjection.Y * axis.Y;
            }

            if ((abrProjection.X * axis.X + abrProjection.Y * axis.Y) > maxA)
            {
                maxA = abrProjection.X * axis.X + abrProjection.Y * axis.Y;
            }
            else if ((abrProjection.X * axis.X + abrProjection.Y * axis.Y) < minA)
            {
                minA = abrProjection.X * axis.X + abrProjection.Y * axis.Y;
            }

            if ((ablProjection.X * axis.X + ablProjection.Y * axis.Y) > maxA)
            {
                maxA = ablProjection.X * axis.X + ablProjection.Y * axis.Y;
            }
            else if ((ablProjection.X * axis.X + ablProjection.Y * axis.Y) < minA)
            {
                minA = ablProjection.X * axis.X + ablProjection.Y * axis.Y;
            }




            if ((btlProjection.X * axis.X + btlProjection.Y * axis.Y) > maxB)
            {
                maxB = btlProjection.X * axis.X + btlProjection.Y * axis.Y;
            }
            else if ((btlProjection.X * axis.X + btlProjection.Y * axis.Y) < minB)
            {
                minB = btlProjection.X * axis.X + btlProjection.Y * axis.Y;
            }

            if ((bbrProjection.X * axis.X + bbrProjection.Y * axis.Y) > maxB)
            {
                maxB = bbrProjection.X * axis.X + bbrProjection.Y * axis.Y;
            }
            else if ((bbrProjection.X * axis.X + bbrProjection.Y * axis.Y) < minB)
            {
                minB = bbrProjection.X * axis.X + bbrProjection.Y * axis.Y;
            }

            if ((bblProjection.X * axis.X + bblProjection.Y * axis.Y) > maxB)
            {
                maxB = bblProjection.X * axis.X + bblProjection.Y * axis.Y;
            }
            else if ((bblProjection.X * axis.X + bblProjection.Y * axis.Y) < minB)
            {
                minB = bblProjection.X * axis.X + bblProjection.Y * axis.Y;
            }

            
            if (minB <= maxA && maxB >= minA)
            {
                return true;
            }

            return false;


        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double RadianToDegree(double angle)
        {
            return 180 * angle / Math.PI;
        }
    }
}
