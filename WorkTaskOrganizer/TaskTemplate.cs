using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTaskOrganizer
{
    public class TaskTemplate
    {
        public TaskTemplate()
        {
            this.status = "";
            this.format = "";
            this.taskName = "";
            this.comment = "";
            this.linkToJira = "";
            this.createdDate = DateTime.Now;
            this.deadline = DateTime.Now;
            this.priority = 0;
            this.catalogName = "";
            this.catalogPath = "";
            this.workTime = new List<WorkProjectPrerioid>();

        }

        public int id { get; set; }
        public string status { get; set; }
        public string format { get; set; }
        public string taskName { get; set; }
        public string comment { get; set; }
        public string linkToJira { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime deadline { get; set; }
        public int priority { get; set; }
        public string catalogName { get; set; }
        public string catalogPath { get; set; }
        public List<WorkProjectPrerioid> workTime { get; set; }

    }
}
