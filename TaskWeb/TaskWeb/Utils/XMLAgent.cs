using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace TaskWeb.Utils
{
    public static class XMLAgent
    {
        public static string xmlpath = AppDomain.CurrentDomain.BaseDirectory + @"\SysConfig\SysConfig.xml";
        /// <summary>
        /// 获取当前节点的指定名称的子节点
        /// </summary>
        /// <param name="Node">当前节点</param>
        /// <param name="SubNodeName">需要取的子节点名</param>
        /// <returns></returns>
        public static XmlNode FindNextNode(XmlNode Node, string[] path, int depth)
        {
            foreach (XmlNode SubNode in Node.ChildNodes)
            {
                if (path[depth] == SubNode.Name)
                {
                    if (path.Length - 1 != depth)
                    {
                        depth++;
                        return FindNextNode(SubNode, path, depth);
                    }
                    else
                    {
                        return SubNode;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 路径访问XML节点
        /// </summary>
        /// <param name="xmlpath"></param>
        /// <param name="strpath"></param>
        /// <returns></returns>
        public static string GetNodeString(string strpath)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlpath);

            string[] path = strpath.Split('/');
            XmlNode node = FindNextNode(xdoc, path, 0);
            if (node != null)
            {
                return node.InnerText;
            }
            return null;
        }
    }
}