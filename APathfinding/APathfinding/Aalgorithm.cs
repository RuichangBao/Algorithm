using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APathfinding
{
    /// <summary>
    /// A*算法实现
    /// </summary>
    internal class Aalgorithm : Singleton<Aalgorithm>
    {
        private const int MAPNUM = 10;
        private Point[][] map;
        private List<Point> closePoints;
        private List<Point> openPoints;
        private Point endMapPoint;
        public Aalgorithm()
        {
            closePoints = new List<Point>();
            openPoints = new List<Point>();
            this.InitMap();
            Point startPoint = map[0][0];
            openPoints.Add(startPoint);
            PathFinding(startPoint);
        }
        /// <summary>
        /// 初始化地图
        /// </summary>
        private void InitMap()
        {
            string str =
                "0 0 0 0 | 0 0 0 0 0/n" +
                "0 | | | | 0 0 0 0 0/n" +
                "0 0 0 0 | 0 0 0 0 0/n" +
                "0 | | 0 0 0 | | | |/n" +
                "0 | 0 0 | 0 0 0 0 0/n" +
                "| | 0 0 | 0 0 0 0 0/n" +
                "0 0 0 0 | 0 0 0 0 0/n" +
                "0 0 0 0 | 0 0 0 0 0/n" +
                "0 0 0 0 | 0 0 0 0 0/n" +
                "| 0 0 0 0 0 0 0 0 0";
           
            map = new Point[MAPNUM][];
            for (int i = 0; i < MAPNUM; i++)
            {
                map[i] = new Point[MAPNUM];
                for (int j = 0; j < MAPNUM; j++)
                {
                    map[i][j] = new Point(i, j);
                }
            }
            string[] strMaps = str.Split(@"/n");
            for (int i = 0; i < strMaps.Length; i++)
            {
                Console.WriteLine(strMaps[i]);
                string[] points = strMaps[i].Split(" ");
                for (int j = 0; j < points.Length; j++)
                {
                    if (points[j].Equals("0"))
                    {
                        map[i][j].state = true;
                    }
                }
            }
            endMapPoint = map[MAPNUM - 1][MAPNUM - 1];
        }

        private void PathFinding(Point starMapFind)
        {
            List<Point> tagAroundPoint = FindAround(starMapFind);
            for (int i = 0; i < tagAroundPoint.Count; i++)
            {
                Point tarPoint = tagAroundPoint[i];
                if (!tarPoint.state)//未开放
                    continue;
                if (this.TarInList(tarPoint, closePoints))
                    continue;
                if (!this.TarInList(tarPoint, openPoints))//未在开放列表里边 直接放进去,并且更新 目标路径
                {
                    openPoints.Add(tarPoint);
                    tarPoint.UpdataPath(starMapFind);
                    tarPoint.UpdateScore(this.GetResidueLength(tarPoint, endMapPoint));
                    continue;
                }
                else
                {
                    //判断那条路径最近
                    int oldScore = tarPoint.path.Count + this.GetResidueLength(tarPoint, endMapPoint);
                    int newScore = starMapFind.score+1+this.GetResidueLength(tarPoint, endMapPoint);
                    if (newScore < oldScore)
                    {
                        tarPoint.UpdataPath(starMapFind);
                        tarPoint.UpdateScore(this.GetResidueLength(tarPoint, endMapPoint));
                        continue;
                    }
                }
            }
            closePoints.Add(starMapFind);
            bool isFind = CheckFindTarget();
            if (isFind)
                return;            
            openPoints.Remove(starMapFind);
            if (openPoints.Count <= 0)
            {
                Console.WriteLine("未找到路径");
                return;
            }

            openPoints.Sort();
            PathFinding(openPoints[0]);
        }

        private bool CheckFindTarget()
        {
            for (int i = 0; i < openPoints.Count; i++)
            {
                if (endMapPoint == openPoints[i])
                {
                    Console.WriteLine("找到路径:长度为："+ endMapPoint.path.Count);
                    for (int j = 0; j < map.Length; j++)
                    {
                        for (int k = 0; k < map[j].Length; k++)
                        {
                            if (TarInList(map[j][k], endMapPoint.path))
                            {
                                Console.Write("*");
                            }
                            else if (map[j][k].state)
                            {
                                Console.Write("0");
                            }
                            else
                            {
                                Console.Write("|");
                            }
                            Console.Write(" ");
                        }
                        Console.WriteLine();

                    }
                    return true;
                }
            }
            return false;
        }

        // 目标点周围的点
        List<Point> aroundPoint = new List<Point>();
        /// <summary>
        /// 寻找目标点周围的点
        /// </summary>
        private List<Point> FindAround(Point target)
        {
            aroundPoint.Clear();
            if (target.X - 1 > 0)
            {
                Point point = map[target.X - 1][target.Y];
                aroundPoint.Add(point);
            }
            if (target.X + 1 < MAPNUM)
            {
                Point point = map[target.X + 1][target.Y];
                aroundPoint.Add(point);
            }
            if (target.Y - 1 > 0)
            {
                Point point = map[target.X][target.Y - 1];
                aroundPoint.Add(point);
            }
            if (target.Y + 1 < MAPNUM)
            {
                Point point = map[target.X][target.Y + 1];
                aroundPoint.Add(point);
            }
            return aroundPoint;
        }
        private bool TarInList(Point target, List<Point> list)
        {
            foreach (Point point in list)
            {
                if (target == point)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 获取剩余路径
        /// </summary>
        private int GetResidueLength(Point startPoint, Point endPoint)
        {
            return Math.Abs(startPoint.X - endMapPoint.X) + Math.Abs(startPoint.Y - endPoint.Y);
        }
    }
}
/**
 * 参考博客
 * https://blog.csdn.net/m0_59330466/article/details/129328732
 */