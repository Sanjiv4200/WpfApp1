using ExerciceApp;
using System.Windows;

namespace WpfApp1
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Exercice1_Click(object sender, RoutedEventArgs e)
        {
            // Logique à exécuter lorsque l'exercice 1 est sélectionné
            // Par exemple, vous pouvez ouvrir la fenêtre MainWindow avec l'exercice 1 chargé
            MainWindow mainWindow = new MainWindow();
            mainWindow.SelectedExercise = 1; // Définir l'exercice sélectionné
            mainWindow.Show();
            this.Close(); // Fermer la fenêtre actuelle (Window1)
        }
    }
}