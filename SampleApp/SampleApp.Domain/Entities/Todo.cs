using SampleApp.Domain.Entities.Base;
using SampleApp.Domain.Entities.Enums;
using System;

namespace SampleApp.Domain.Entities
{
    public class Todo : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }

        public void ChangePriority(Priority newPriority)
        {
            this.Priority = newPriority;
        }
    }
}
