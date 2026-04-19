using EducationalInstituteManagementSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    public partial class TResult : Form
    {
        string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EIMSDB;Integrated Security=True;";

        int teacherID;
        bool isLoading = false;

        public TResult(int teacherID)
        {
            InitializeComponent();
            this.teacherID = teacherID;

            // ensure button click is wired (designer didn't assign it)
            this.btnAddResult.Click += this.btnAddResult_Click;
        }

        // ================= FORM LOAD =================
        private void TResult_Load(object sender, EventArgs e)
        {
            isLoading = true;

            cmbExamType.Items.AddRange(new string[]
            {
                "Mid Term", "Final Term", "Quiz", "Assignment"
            });
            cmbExamType.SelectedIndex = 0;

            LoadClassesForResults();

            isLoading = false;
        }

        // ================= LOAD CLASSES =================
        private void LoadClassesForResults()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT DISTINCT Class 
                                 FROM Subjects 
                                 WHERE TeacherID=@TeacherID 
                                 ORDER BY Class";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            cmbClasses.Items.Clear();

                            while (dr.Read())
                                cmbClasses.Items.Add(dr["Class"].ToString());

                            dr.Close();
                        }
                    }
                }

                // if classes were loaded, select first item while form load flag prevents triggering handlers
                if (cmbClasses.Items.Count > 0)
                    cmbClasses.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading classes: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOAD STUDENTS =================
        private void LoadStudentsForClass(string className)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT StudentID,
                         FullName + ' - ' + RegistrationNo AS DisplayName
                         FROM Students
                         WHERE Class = @Class
                         ORDER BY FullName";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Class", className);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbResultStudent.DataSource = null;
                    cmbResultStudent.Items.Clear();

                    if (dt.Rows.Count > 0)
                    {
                        cmbResultStudent.DataSource = dt;
                        cmbResultStudent.DisplayMember = "DisplayName";
                        cmbResultStudent.ValueMember = "StudentID";
                        cmbResultStudent.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbResultStudent.Text = "No students found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOAD SUBJECTS =================
        private void LoadSubjectsForClass(string className)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT SubjectID, SubjectName
                                 FROM Subjects
                                 WHERE Class=@Class AND TeacherID=@TeacherID
                                 ORDER BY SubjectName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Class", className);
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            cmbResultSubject.Items.Clear();

                            while (dr.Read())
                            {
                                cmbResultSubject.Items.Add(
                                    new SubjectItem(
                                        dr["SubjectID"].ToString(),
                                        dr["SubjectName"].ToString()
                                    )
                                );
                            }

                            dr.Close();
                        }
                    }
                }

                if (cmbResultSubject.Items.Count > 0)
                    cmbResultSubject.SelectedIndex = 0;
                else
                    cmbResultSubject.Text = "No subjects found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= ADD RESULT =================
        private void btnAddResult_Click(object sender, EventArgs e)
        {
            if (cmbClasses.SelectedItem == null ||
                cmbResultStudent.SelectedItem == null ||
                cmbResultSubject.SelectedItem == null)
            {
                MessageBox.Show("Please select Class, Student and Subject");
                return;
            }

            int obtained;
            int total;
            if (!int.TryParse(txtMarksObtained.Text, out obtained) ||
                !int.TryParse(txtTotalMarks.Text, out total))
            {
                MessageBox.Show("Please enter valid numeric marks", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (obtained > total)
            {
                MessageBox.Show("Marks obtained cannot exceed total marks");
                return;
            }

            SubjectItem subject = (SubjectItem)cmbResultSubject.SelectedItem;
            string grade = CalculateGrade(obtained, total);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Results
                (StudentID, SubjectID, Class, ExamType, MarksObtained, TotalMarks, Grade)
                VALUES
                (@StudentID,@SubjectID,@Class,@ExamType,@Obtained,@Total,@Grade)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", cmbResultStudent.SelectedValue);
                        cmd.Parameters.AddWithValue("@SubjectID", subject.ID);
                        cmd.Parameters.AddWithValue("@Class", cmbClasses.Text);
                        cmd.Parameters.AddWithValue("@ExamType", cmbExamType.Text);
                        cmd.Parameters.AddWithValue("@Obtained", obtained);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@Grade", grade);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Result Added Successfully");
                ClearFields();
                LoadResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving result: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOAD RESULTS =================
        private void LoadResults()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT s.FullName, s.RegistrationNo,
                       sub.SubjectName,
                       r.ExamType, r.MarksObtained,
                       r.TotalMarks, r.Grade
                FROM Results r
                JOIN Students s ON r.StudentID = s.StudentID
                JOIN Subjects sub ON r.SubjectID = sub.SubjectID
                WHERE r.Class=@Class";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Class", cmbClasses.Text);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dgvresults.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= GRADE =================
        private string CalculateGrade(int marks, int total)
        {
            double p = (marks * 100.0) / total;

            if (p >= 90) return "A+";
            if (p >= 80) return "A";
            if (p >= 70) return "B";
            if (p >= 60) return "C";
            if (p >= 50) return "D";
            return "F";
        }

        private void ClearFields()
        {
            txtMarksObtained.Clear();
            txtTotalMarks.Clear();
            cmbExamType.SelectedIndex = 0;
        }

        // ================= CLASS CHANGE =================
        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cmbClasses.SelectedIndex < 0) return;

            string cls = cmbClasses.SelectedItem.ToString();

            LoadStudentsForClass(cls);
            LoadSubjectsForClass(cls);
        }

        // Designer wires to this handler: ensure it performs the same work.
        private void cmbClasses_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cmbClasses.SelectedIndex < 0) return;

            string cls = cmbClasses.SelectedItem.ToString();

            LoadStudentsForClass(cls);
            LoadSubjectsForClass(cls);
            LoadResults();
        }


        // ================= SUBJECT ITEM =================
        private class SubjectItem
        {
            public string ID { get; }
            public string Name { get; }

            public SubjectItem(string id, string name)
            {
                ID = id;
                Name = name;
            }

            public override string ToString() => Name;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

                }
    }
}
