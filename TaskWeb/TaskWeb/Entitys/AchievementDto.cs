﻿using System;

namespace TaskWeb.Entitys
{
    public class AchievementDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string status { get; set; }
        public bool is_deleted { get; set; }
        public int creator { get; set; }
        public DateTime create_time { get; set; }
        public DateTime pass_time { get; set; }
    }
}