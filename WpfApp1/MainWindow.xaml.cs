using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExerciceApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExercisesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exercisesListBox.SelectedItem != null)
            {
                int exerciseNumber = exercisesListBox.SelectedIndex + 1;
                string equation = GenerateRandomEquation();

                equationTextBlock.Text = $"Exercice {exerciseNumber}: Résolvez l'équation\n{equation}";
                answerTextBox.Text = string.Empty;
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            int exerciseNumber = exercisesListBox.SelectedIndex + 1;
            string equation = equationTextBlock.Text.Split('\n')[1];
            string userAnswer = answerTextBox.Text;
            // Logique pour vérifier la réponse
            // Dans cet exemple, on suppose que l'utilisateur a correctement répondu à chaque fois
            MessageBox.Show($"Exercice {exerciseNumber} - Correct !\n{equation} = {userAnswer}", "Résultat");
            CheckExercise();
        }

        private string GenerateRandomEquation()
        {
            Random random = new Random();
            int operand1 = random.Next(1, 10);
            int operand2 = random.Next(1, 10);
            char[] operators = { '+', '-', '*' };
            char randomOperator = operators[random.Next(operators.Length)];

            return $"{operand1} {randomOperator} {operand2}";
        }

        private void CheckExercise()
        {
            if (exercisesListBox.SelectedItem != null)
            {
                int exerciseNumber = exercisesListBox.SelectedIndex + 1;
                string equation = equationTextBlock.Text.Split('\n')[1];
                string userAnswer = answerTextBox.Text;

                // Logique pour vérifier la réponse
                // Dans cet exemple, on suppose que l'utilisateur a correctement répondu à chaque fois
                MessageBox.Show($"Exercice {exerciseNumber} - Correct !\n{equation} = {userAnswer}", "Résultat");

                // Sélectionner le prochain exercice
                int nextIndex = exercisesListBox.SelectedIndex + 1;
                if (nextIndex < exercisesListBox.Items.Count)
                {
                    exercisesListBox.SelectedIndex = nextIndex;
                }
                else
                {
                    MessageBox.Show("Félicitations, vous avez terminé tous les exercices !");
                }

                answerTextBox.Text = string.Empty; // Réinitialiser le TextBox après vérification
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Le code à exécuter lors de l'appui sur la touche Entrée
                MessageBox.Show("La touche Entrée a été pressée !");
                CheckExercise();
                e.Handled = true; // Pour éviter la propagation de l'événement
            }
        }
    }
}
