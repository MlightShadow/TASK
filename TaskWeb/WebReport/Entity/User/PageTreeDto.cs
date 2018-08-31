using System;
using System.Collections.Generic;

namespace WebReport.Entity.User
{
    [Serializable]
    public class PageTreeDto
    {
        public int pageId { get; set; }
        public int roleId { get; set; }
        public int creator { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string controller { get; set; }
        public string param { get; set; }
        public int nodeId { get; set; }
        public int parentId { get; set; }
        public bool selectable { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string faicon { get; set; }
        
        /// <summary>
        /// 节点状态
        /// </summary>
        public PageTreeStateDto state = new PageTreeStateDto();

        /// <summary>
        /// 子节点
        /// </summary>
        public List<PageTreeMdDto> nodes = new List<PageTreeMdDto>();
    }

    [Serializable]
    public class PageTreeMdDto
    {
        public int pageId { get; set; }
        public int roleId { get; set; }
        public int creator { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string param { get; set; }
        public string controller { get; set; }
        public int nodeId { get; set; }
        public int parentId { get; set; }
        public bool selectable { get; set; }

        /// <summary>
        /// 节点状态
        /// </summary>
        public PageTreeStateDto state = new PageTreeStateDto();

        /// <summary>
        /// 子节点
        /// </summary>
        public List<PageTreeEndDto> nodes = new List<PageTreeEndDto>();
    }

    [Serializable]
    public class PageTreeEndDto
    {
        public int pageId { get; set; }
        public int roleId { get; set; }
        public int creator { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string param { get; set; }
        public string controller { get; set; }
        public int nodeId { get; set; }
        public int parentId { get; set; }
        public bool selectable { get; set; }

        /// <summary>
        /// 节点状态
        /// </summary>
        public PageTreeStateDto state = new PageTreeStateDto();
    }

    /// <summary>
    /// 节点状态Dto
    /// </summary>
    [Serializable]
    public class PageTreeStateDto
    {
        public bool @checked { get; set; }
        public bool disabled { get; set; }
        public bool expanded { get; set; }
        public bool selected { get; set; }
    }
}