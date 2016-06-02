using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Required for connecting to Ef db
using ASPLesson_4.Models;
using System.Web.ModelBinding;

namespace ASPLesson_4
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If loading the page for the first time
            if(!IsPostBack)
            {
                //Get Students from EF db
                this.GetStudents();
            }
        }

        protected void GetStudents()
        {
            //Connect to EF
            using (ContosoEntities db = new ContosoEntities())
            {
                //Quesry the Students table using EF and LINQ
                //this behaves like a foreach loop
                var Students = (from allStudents in db.Students
                                select allStudents);

                //Bind the result to the Gridview
                StudentsGridView.DataSource = Students.ToList();
                StudentsGridView.DataBind();
            }
        }

    }
}