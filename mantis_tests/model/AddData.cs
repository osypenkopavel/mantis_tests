using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AddData : IComparable<AddData>, IEquatable<AddData>
    {
        
        private string projectname;
        private string description;

        public AddData(string projectname)
        {
            this.projectname = projectname;            
        }

        public string ProjectName
        {
            get
            {
                return projectname;

            }

            set
            {
                projectname = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        public int CompareTo(AddData other)
        {
            return this.ProjectName.CompareTo(other.ProjectName);
        }

        public bool Equals(AddData other)
        {
            return this.ProjectName.Equals(other.ProjectName);
        }
    }
}
