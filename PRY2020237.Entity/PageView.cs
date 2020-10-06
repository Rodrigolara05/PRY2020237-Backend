using System;

namespace PRY2020237.Entity
{
    public class PageView
    {
        public int Id { get; set; }
        public string name { get; set; }        
        public string description { get; set; }
        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }
        public string img { get; set; }
        public string refHtml { get; set; }
        public int projectId { get; set; }
        public Project project { get; set; }
        
    }
}