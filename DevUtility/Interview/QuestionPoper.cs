using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ConfigurationValidation.Interview
{

    public partial class QuestionPoper : Form
    {
        private Random rnd = new Random();

        List<QuestionAndAnswers> questionList = new List<QuestionAndAnswers>();
        public QuestionPoper()
        {
            this.InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            var experienceFrom = 0;
            var experienceTo = 100;
            var experience = 100;

            var category = cbCategory.Text;
            var subCategory = cbSubCategory.Text;
            txtQuestion.Text = string.Empty;
            txtAnswer.Text = string.Empty;
            lblId.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(this.txtExperience.Text))
            {
                experience = int.Parse(txtExperience.Text);

                experience = experience > 15 ? 15 : experience;
            }

            var filter = this.questionList.Where(q => q.ExperienceFrom <= experience && q.ExperienceTo >= experience &&
            q.Category == (string.IsNullOrWhiteSpace(category) ? q.Category : category) &&
            q.SubCategory == (string.IsNullOrWhiteSpace(subCategory) ? q.SubCategory : subCategory)).ToList();

            var count = filter.Count();

            if (count <= 0)
            {
                return;
            }
            var index = rnd.Next(0, count);
            if (index == count)
            {
                index--;
            }

            var questionObject = filter[index];
            txtQuestion.Text = $"Question:- {questionObject.Question}";
            txtAnswer.Text = questionObject.Answer;
            txtQuestionId.Text = questionObject.id;
        }

        private void QuestionPoper_Load(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection("Data Source = ILPT5388; Initial Catalog = Local; Integrated Security = SSPI");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = "select id,Question,isnull(Answer,'') Answer,isnull([ExperienceFrom],2) [ExperienceFrom],isnull([ExperienceTo],100) [ExperienceTo],isnull(Category,'') Category,isnull(SubCategory,'') SubCategory from InterviewQuestions"
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
                        SubCategory = reader["SubCategory"].ToString(),
                        ExperienceFrom = Convert.ToInt32(reader["ExperienceFrom"].ToString()),
                        ExperienceTo = Convert.ToInt32(reader["ExperienceTo"].ToString())

                    });

                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblId.Text))
            {
                MessageBox.Show("No question selected");
                return;
            }

            var sqlConnection = new SqlConnection("Data Source=ILPT547;Initial Catalog=LocalNeed;Integrated Security=SSPI;User ID=vijay;Password=vijay;");
            sqlConnection.Open();
            var cmd = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = $"Update InterviewQuestions set Answer='{txtAnswer.Text.Replace("'", "''")}'" +
                $", Question='{txtQuestion.Text.Replace("'", "''")}'" +
                $" where id={lblId.Text.Replace("'", "''")}"
            };

            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");

        }
    }
}
