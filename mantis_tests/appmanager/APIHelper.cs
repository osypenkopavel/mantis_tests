using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {

        public APIHelper(ApplicationManager manager) : base(manager) { }
        
        internal void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();

            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);            
        }

        public void CreateProject(AccountData account)
        {        
            var project = new Mantis.ProjectData();            
            project.name = "Mantis Project";
            project.id = "10";     
            Mantis.MantisConnectPortTypeClient projectsList = new Mantis.MantisConnectPortTypeClient();
            projectsList.mc_project_add(account.Name, account.Password, project);
        }

        public List<AddData> GetProjectsList(AccountData account)
        {
            List<AddData> projects = new List<AddData>();
            
            Mantis.MantisConnectPortTypeClient projectsList = new Mantis.MantisConnectPortTypeClient();
            var projectlist = projectsList.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach ( Mantis.ProjectData element in projectlist)
            {
                projects.Add(new AddData(element.name));
            }
            return projects;
        }
    }
}