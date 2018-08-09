using System;
using System.Xml;

namespace SampleUtils.XMLUtils
{
    public static class XMLHelper
    {
        /// <summary>
        /// 路径访问XML节点
        /// </summary>
        /// <param name="xmlpath"></param>
        /// <param name="strpath"></param>
        /// <returns></returns>
        public static string GetNodeString(string xmlpath, string strpath)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\SysConfig\" + xmlpath + ".xml");

            string[] path = strpath.Split('/');
            XmlNode node = FindNextNode(xdoc, path, 0);
            if (node != null)
            {
                return node.InnerText;
            }
            return null;
        }

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
    }
}