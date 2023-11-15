﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APathfinding
{
    internal class Point :  IComparable<Point>
    {
        public int X;
        public int Y;
        public bool state;
        public List<Point> path;
        public int score;//路径评分
        public Point()
        {
                
        }
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            path = new List<Point>();
        }
        //计算当前点距离目标点的距离
        public double GetPointLength(Point targetPoint)
        {
            double length = Math.Pow((targetPoint.X - this.X), 2) + Math.Pow((targetPoint.Y - this.Y), 2);
            return Math.Sqrt(length);
        }
        /// <summary>
        /// 更新目标路径(从起点到该点的目标路径)
        /// </summary>
        /// <param name="endPoint"></param>
        public void UpdataPath(Point endPoint)
        {
            path.Clear();
            for (int i = 0; i < endPoint.path.Count; i++)
            {
                path.Add(endPoint.path[i]);
            }
            path.Add(endPoint);
        }
        //更新路径评分
        public void UpdateScore(int score)
        {
            this.score = path.Count + score;
        }
        public override string ToString()
        {
            return "x:" + X + "     y:" + Y;
        }

        public int CompareTo(Point? other)
        {
            return this.score.CompareTo(other?.score);
        }
    }
}