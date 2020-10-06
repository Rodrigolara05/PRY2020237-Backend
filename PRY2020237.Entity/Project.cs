using System;

namespace PRY2020237.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string name { get; set; }        
        public string description { get; set; }
        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        
    }
}