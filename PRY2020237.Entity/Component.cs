using System;

namespace PRY2020237.Entity
{
    public class Component
    {
        public int Id { get; set; }
        public string src { get; set; }        
        public string text { get; set; }
        public Double height { get; set; }
        public Double width { get; set; }
        public int componentTypeId { get; set; }
        public ComponentType componentType { get; set; }
        public int pageViewId { get; set; }
        public PageView pageView { get; set; }
        
    }
}