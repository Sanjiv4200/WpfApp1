/*using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExerciceApp
{
    public partial class MainWindow : Window
    {
        public int SelectedExercise { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExercisesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exercisesListBox.SelectedItem != null)
            {
                SelectedExercise = exercisesListBox.SelectedIndex + 1;
                string equation = GenerateRandomEquation();

                equationTextBlock.Text = $"Exercice {SelectedExercise}: Résolvez l'équation\n{equation}";
                answerTextBox.Text = string.Empty;
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
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
                string equation = equationTextBlock.Text.Split('\n')[1];
                string userAnswer = answerTextBox.Text;

                // Logique pour vérifier la réponse
                // Dans cet exemple, on suppose que l'utilisateur a correctement répondu à chaque fois
                MessageBox.Show($"Exercice {SelectedExercise} - Correct !\n{equation} = {userAnswer}", "Résultat");

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
                MessageBox.Show("La touche Entrée a été pressée !");
                CheckExercise();
                e.Handled = true;
            }
        }
    }
}
<Window x:Class="ExerciceApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Exercice App" Height="470" Width="736">
    <Grid>
        <ListBox x:Name="exercisesListBox" HorizontalAlignment="Left" VerticalAlignment="Top" Width="138" Height="308" SelectionChanged="ExercisesListBox_SelectionChanged" Margin="0,109,0,0">
            <ListBoxItem Width="130" Height="30">Exercice 1</ListBoxItem>
            <ListBoxItem Width="130" Height="30">Exercice 2</ListBoxItem>
            <ListBoxItem Width="130" Height="30">Exercice 3</ListBoxItem>
            <ListBoxItem Width="130" Height="30">Pythagore</ListBoxItem>
            <ListBoxItem Width="130" Height="30">Thales</ListBoxItem>
        </ListBox>
        <StackPanel x:Name="exercisePanel" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="150,0,0,0" Height="426" Width="556">
            <TextBox PreviewKeyDown="TextBox_PreviewKeyDown" />
            <TextBlock x:Name="equationTextBlock" Margin="0,0,0,10" />
            <StackPanel>
                <TextBlock Width="300" Height="20"/>
                <TextBox x:Name="answerTextBox" Width="301" Height="30" PreviewKeyDown="TextBox_PreviewKeyDown"/>
                <TextBlock Width="300" Height="100" x:Name="textBlock1"/>
            </StackPanel>
            <Border Background="#2ecc71" CornerRadius="5" Margin="0,10,0,0"/>
            <Button Content="Vérifier" Click="CheckButton_Click" Foreground="White" Padding="10" BorderThickness="0"/>
            <Polygon Points="100,0 100,40 60,40"
                     Stroke="Black"
                     StrokeThickness="2"
                     RenderTransformOrigin="500,20" Height="47" Width="162">
                <Polygon.RenderTransform>
                    <TransformGroup>
                        <ScaleTransform/>
                        <SkewTransform/>
                        <RotateTransform Angle="-0.094"/>
                        <TranslateTransform/>
                    </TransformGroup>
                </Polygon.RenderTransform>
                <Polygon.Fill>
                    <SolidColorBrush Color="White" Opacity="0.4"/>
                </Polygon.Fill>
            </Polygon>
        </StackPanel>
    </Grid>
</Window>
 */

using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;


namespace ExerciceApp
{
    public partial class MainWindow : Window
    {
        public int SelectedExercise { get; set; }
        public bool CalculatriceIsNotOpen = true;
        private float currentSolution;
        private int exerciseNumber;
        private float[] var = new float[20];
        private int taille;
        public MainWindow()
        {
            InitializeComponent();
        }








        // choisit l'exo quand on click dessus
        private void ExercisesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exercisesListBox.SelectedItem != null)
            {
                exerciseNumber = exercisesListBox.SelectedIndex + 1;


                answerTextBox.Text = string.Empty;
                Cacher();

                ChoisiUnExo.Visibility = Visibility.Collapsed;
                if (exerciseNumber == 1)
                {
                    BoutonVerifier.Visibility = Visibility.Visible;
                    BoutonCorriger.Visibility = Visibility.Visible;
                    answerTextBox.Visibility = Visibility.Visible;
                    Exo_OperationSimple();
                }


                if (exerciseNumber == 2)
                {
                    BoutonVerifier.Visibility = Visibility.Visible;
                    BoutonCorriger.Visibility = Visibility.Visible;
                    answerTextBox.Visibility = Visibility.Visible;
                    Exo_Eveil();
                }


                if (exerciseNumber == 4)
                {
                    BoutonVerifier.Visibility = Visibility.Visible;
                    BoutonCorriger.Visibility = Visibility.Visible;
                    answerTextBox.Visibility = Visibility.Visible;
                    Exo_Pythagore();
                }
                if (exerciseNumber == 5)
                {
                    Exo_Probabilite();
                }


            }
        }
        public void Cacher()
        {
            // Trucs a virer pour Exo1
            if (exerciseNumber != 0)
            {
                equationTextBlock.Text = "";
            }


            // Trucs a virer pour Pythagore
            if (exerciseNumber != 4)
            {
                Triangle.Visibility = Visibility.Collapsed;
                SideA.Visibility = Visibility.Collapsed;
                SideB.Visibility = Visibility.Collapsed;
            }


            // Trucs a virer pour L'exo sur les proba
            if (exerciseNumber != 5)
            {
                reponse25_1.Visibility = Visibility.Collapsed;
                reponse25_2.Visibility = Visibility.Collapsed;
                reponse50.Visibility = Visibility.Collapsed;
                reponse75.Visibility = Visibility.Collapsed;
            }

        }




        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

            CheckExercise();
        }

        private (string, int) GenerateRandomEquation()
        {
            Random random = new Random();
            int operand1 = random.Next(1, 10);
            int operand2 = random.Next(1, 10);
            char[] operators = { '+', '-', '*' };
            char randomOperator = operators[random.Next(operators.Length)];

            int result;
            switch (randomOperator)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
                case '*':
                    result = operand1 * operand2;
                    break;
                default:
                    throw new InvalidOperationException("Opérateur inconnu");
            }
            return ($"{operand1} {randomOperator} {operand2}", result);
        }

        private void CheckExercise()
        {
            if (exercisesListBox.SelectedItem != null)
            {
                //exerciseNumber = exercisesListBox.SelectedIndex + 1;

                string userAnswer = answerTextBox.Text;
                bool isCorrect = false;
                // Logique pour vérifier la réponse

                if (exerciseNumber == 4) // Supposant que Pythagore est à l'index 3 
                {
                    // Ici, vous pouvez ajouter votre logique spécifique pour vérifier l'exercice Pythagore
                    // Par exemple:
                    isCorrect = Verif_Pythagore(userAnswer);
                }
                else
                {
                    // Vérification pour les opérations simples
                    isCorrect = int.TryParse(userAnswer, out int userSolution) && userSolution == currentSolution;
                }
                string message = isCorrect ? "Correct !" : "Incorrect. Essayez encore.";
                MessageBox.Show(message, "Résultat");

                if (isCorrect)
                {
                    PassToNextExercise();

                }
            }
        }


        private void PassToNextExercise()
        {
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
        private bool Verif_Pythagore(string userAnswer)
        {
            // Convertir la réponse de l'utilisateur en nombre et comparer avec la solution attendue
            return (int.TryParse(userAnswer, out int result) && result >= currentSolution - 0.5) && (int.TryParse(userAnswer, out result) && result <= currentSolution + 0.5);
        }










        //List de tout les Exos------------------------------------------------------------------------------

        public void Exo_OperationSimple()
        {

            var (equation, solution) = GenerateRandomEquation();
            currentSolution = solution; // Stockez la solution ici
            equationTextBlock.Text = $"Exercice : Résolvez l'équation\n{equation}";
        }



        public void Exo_Eveil()
        {



            equationTextBlock.Text = $"Exercice : ";
        }

        public void Exo_Pythagore()
        {
            Triangle.Visibility = Visibility.Visible;
            Random random = new Random();
            int a = random.Next(1, 10); // Génère un côté a
            var[1] = a;
            int b = random.Next(1, 10); // Génère un côté b
            var[2] = b;
            currentSolution = (float)Math.Sqrt(a * a + b * b); // Calcule l'hypoténuse et arrondit au nombre entier le plus proche pour simplifier
            var[0] = currentSolution;
            DefineTriangleSides(a, b);
            equationTextBlock.Text = $"Exercice Pythagore: Un triangle rectangle a des côtés de longueur {a} et {b}.\n      Calculez l'hypoténuse (arrondie au nombre entier le plus proche).";

            // Ouvrir la calculatrice windos
            Calculatrice();



        }


        public void Exo_Probabilite()
        {
            reponse25_1.Visibility = Visibility.Visible;
            reponse25_2.Visibility = Visibility.Visible;
            reponse50.Visibility = Visibility.Visible;
            reponse75.Visibility = Visibility.Visible;
            //code de l'exo (un QCM 25% 25% 50% 75%)
            equationTextBlock.Text = $"Exercice : Si vous en choisissez une au hasard \n Quelles sont les chances que vous choisissiez la bonne réponse ?";



        }
        // Quand on click sur une réponse =======================================================================================================================================================
        private void reponse25_1_Click(object sender, RoutedEventArgs e)
        {
            CheckExercise();
        }

        private void reponse25_2_Click(object sender, RoutedEventArgs e)
        {
            CheckExercise();
        }

        private void reponse75_Click(object sender, RoutedEventArgs e)
        {
            CheckExercise();
        }

        private void reponse50_Click(object sender, RoutedEventArgs e)
        {
            CheckExercise();
        }
        // Corrections ===========================================================================================================================================================================
        private void Corriger_Click(object sender, RoutedEventArgs e)
        {
            if (exerciseNumber == 1)
            {
                Corriger_OperationSimple();
            }
            else if (exerciseNumber == 2)
            {
                Corriger_Eveil();
            }
            else if (exerciseNumber == 3)
            {
                //Corriger_
            }
            else if (exerciseNumber == 4)
            {
                Corriger_Pythagore();
            }
            else if (exerciseNumber == 5)
            {
                MessageBox.Show("Pas de solution", "Erreur");
            }
        }

        private void Corriger_Pythagore()
        {
            MessageBox.Show(("D'après le théorème de Pythagore, on a :" + "\r\n" + var[1].ToString() + "² + " + var[2].ToString() + "² = S²" + "\r\n" + (var[1] * var[1]).ToString() + " + " + (var[2] * var[2]).ToString() + "² = S²" + "\r\n" + (var[1] * var[1] + var[2] * var[2]).ToString() + " = S²" + "\r\n" + "S = " + var[0].ToString()), "Correction");
        }
        private void Corriger_OperationSimple()
        {

        }
        private void Corriger_Eveil()
        {

        }

        //  FIN Quand on click sur une réponse =======================================================================================================================================================


        //FIN List de tout les Exos-------------------------------------------------------------------------










        // fonctions spécifiques aux exos
        public void DefineTriangleSides(int sideA, int sideB)
        {
            // Calculer l'hypoténuse pour déterminer le troisième point si nécessaire
            // C'est pour un triangle rectangle ; ajustez selon la forme de votre triangle
            double hypotenuse = Math.Sqrt(sideA * sideA + sideB * sideB);

            // Définir les points du triangle. Ajustez ces valeurs en fonction de l'orientation souhaitée du triangle.
            Triangle.Points.Clear(); // Nettoyer les points existants
            Triangle.Points.Add(new Point(300, 300)); // Point A (angle droit)
            Triangle.Points.Add(new Point(300, 300 - sideB * 30)); // Point B
            Triangle.Points.Add(new Point(300 + sideA * 30, 300)); // Point C

            // Si votre triangle n'est pas orienté comme vous le souhaitez, ajustez l'ordre des points ou leurs coordonnées.


            //on acctive les text box qui contiennent les valeur des cotés
            SideA.Visibility = Visibility.Visible;
            SideB.Visibility = Visibility.Visible;


            // Mise à jour des TextBlocks pour montrer les longueurs
            SideA.Text = sideA.ToString();
            SideB.Text = sideB.ToString();

            // Exemple de positionnement dynamique pour SideA
            Canvas.SetLeft(SideA, 300 + sideA * 30 / 2.0 - SideA.ActualWidth / 2);
            Canvas.SetTop(SideA, 300 + 5); // Juste en dessous du côté A, ajustez selon le besoin

            // Ajustements pour SideB (vertical)
            Canvas.SetLeft(SideB, 290 - SideB.ActualWidth / 2); // Centrer le texte à gauche du côté B
            Canvas.SetTop(SideB, 300 - sideB * 30 / 2.0 - SideB.ActualHeight / 2); // Positionner le long de la hauteur de SideB


        }











        //fonctions qui servent a lancer des poccessus Windows
        public void Calculatrice()
        {
            if (CalculatriceIsNotOpen)
            {
                System.Diagnostics.Process.Start("calc.exe");
                CalculatriceIsNotOpen = false;
            }
        }


    }
}