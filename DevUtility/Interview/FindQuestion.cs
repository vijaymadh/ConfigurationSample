using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ConfigurationValidation.Interview
{
   
    public partial class FindQuestion : Form
    {
        private Random rnd = new Random();

        List<QuestionAndAnswers> questionList = new List<QuestionAndAnswers>();
        public FindQuestion()
        {
            this.InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            this.questionList.Clear();
            var sqlConnection = new SqlConnection("Data Source=ILPT5388;Initial Catalog=Local;Integrated Security=SSPI");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = $"select id,Question,isnull(Answer,'') Answer,isnull(Category,'') Category,isnull(SubCategory,'') SubCategory from InterviewQuestions where [Question] like '%{txtSearch.Text}%' "
            };

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.questionList.Add(new QuestionAndAnswers
                    {
                        id = reader["id"].ToString(),
                        Question = reader["Question"].ToString(),
                        Answer = reader["Answer"].ToString(),
                        Category = reader["Category"].ToString(),
                        SubCategory = reader["SubCategory"].ToString()
                    });

                }

            }
            cmbQuestions.Items.Clear();
            foreach (var item in this.questionList)
            {
                if (item != null)
                {
                    cmbQuestions.Items.Add(item);
                }
            }

            //cmbQuestions.DataSource = this.questionList;
            cmbQuestions.DisplayMember = "Question";
            cmbQuestions.ValueMember = "id";
            //cmbQuestions.data
        }

  

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(lblId.Text))
            {
                MessageBox.Show("No question selected");
                return;
            }

            var sqlConnection = new SqlConnection("Data Source=ILPT547;Initial Catalog=LocalNeed;Integrated Security=SSPI;User ID=vijay;Password=vijay;");
            sqlConnection.Open();
            var cmd = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = $"Update InterviewQuestions set Answer='{txtAnswer.Text.Replace("'","''")}'" +
                $", Question='{txtQuestion.Text.Replace("'", "''")}'" +
                $" where id={lblId.Text.Replace("'", "''")}"
            };

            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");

        }

        private void txtExperience_TextChanged(object sender, EventArgs e)
        {
           

    

        }

        private void cmbQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedQuestion = cmbQuestions.Items[cmbQuestions.SelectedIndex] as QuestionAndAnswers;

            txtQuestion.Text = selectedQuestion.Question;
            txtAnswer.Text = selectedQuestion.Answer;
            txtId.Text = selectedQuestion.id;
        }
    }
}
