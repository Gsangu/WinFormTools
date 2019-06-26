using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GsanPlayer
{
    class XMLHelper
    {
        XmlDocument xml;
        XmlNodeList xmllist ;
        XmlNodeList tempList;
        public XmlNodeList XmlList
        {
            get { return xmllist; }
        }
        public XMLHelper(string xml,string parent)
        {
            this.xml = new XmlDocument();
            this.xml.LoadXml(xml);
            xmllist = this.xml.SelectSingleNode(parent).ChildNodes;
            tempList = xmllist;
        }
        /// <summary>
        /// 遍历所有节点获取对应节点值
        /// </summary>
        /// <param name="childNode">节点名</param>
        /// <returns>节点对应值</returns>
        public string GetValue(string childNode)
        {
            foreach (XmlNode node in tempList)
            {
                if (node.Name == childNode && node.HasChildNodes)
                {
                    return node.InnerText;
                }
                if (node.NextSibling == null)
                {
                    tempList = node.ParentNode.ParentNode.ChildNodes;
                    tempList[0].RemoveAll();
                    return GetValue(childNode);
                }
                XmlElement xe = (XmlElement)node;
                if (xe.HasChildNodes)
                {
                    tempList = xe.ChildNodes;
                    return GetValue(childNode);
                }
            }
            return null;
        }
    }
}
