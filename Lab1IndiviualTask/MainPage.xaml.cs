
namespace Lab1IndiviualTask
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void clearingPreviousMatrix()
        {
            MatrixGrid.Children.Clear();
            MatrixGrid.RowDefinitions.Clear();
            MatrixGrid.ColumnDefinitions.Clear();
        }

        private void creatingNextMatrix(int matrixSize) 
        {
            for (int i = 0; i < matrixSize; i++)
            {
                MatrixGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                MatrixGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
        }

        private void fillingTheMatrixWithValues(int matrixSize)
        {
            for (int col = 0; col < matrixSize; col++)
            {
                int lowestValueInColumn = 101;
                for (int row = 0; row < matrixSize; row++)
                {
                    Random rand = new Random();
                    int valueInCell = rand.Next(100);

                    if(lowestValueInColumn > valueInCell)
                    {
                        lowestValueInColumn = valueInCell;
                    } 
                    var frame1 = cellInformation(valueInCell);
                    MatrixGrid.Add(frame1, col, row);
                }
                var frame = minimalValue(lowestValueInColumn);
                MatrixGrid.Add(frame, col, matrixSize +1 );
            }
        }

        private Frame cellInformation(int valueInCell)
        {
            var label = new Microsoft.Maui.Controls.Label
            {
                Text = $"{valueInCell}",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            return framing(label);
        }
        private Frame minimalValue(int minValue)
        {
            var minLabel = new Microsoft.Maui.Controls.Label
            {
                Text = minValue.ToString(),
                TextColor = Colors.Red, // Красный текст
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            return framing(minLabel);
        }

        private Frame framing(Microsoft.Maui.Controls.Label label)
        {
            var frame = new Frame
            {
                Content = label,
                BorderColor = Colors.Black,  // Цвет границы
                CornerRadius = 0,            // Без закругления углов
                Padding = 5,                 // Внутренние отступы
                Margin = 2                   // Внешние отступы (чтобы разделить элементы)
            };
            return frame;
        }
        

        private void OnShowMatrixButtonClicked(object sender, EventArgs e)
        {
            // Очистим предыдущую матрицу, если она была
            clearingPreviousMatrix();
            
            // Получаем размер матрицы
            if (int.TryParse(MatrixSizeEntry.Text, out int matrixSize) && matrixSize > 0)
            {
                creatingNextMatrix(matrixSize);
                // Заполняем матрицу
                fillingTheMatrixWithValues(matrixSize);
            }
            else
            {
                // Показываем ошибку, если введено неправильное значение
                DisplayAlert("Ошибка", "Введите корректный размер матрицы", "OK");
            }
        }
    }

}
