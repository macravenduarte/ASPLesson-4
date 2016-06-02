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
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //Use EF to connect to the server
            using (ContosoEntities db = new ContosoEntities())
            {
                //Use the Student model to save a new record
                Student newStudent = new Student();

                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                db.Students.Add(newStudent);
                db.SaveChanges();

                //Redirect back to the updated students page
                Response.Redirect("~/Students.aspx");
            }

        }
    }
}