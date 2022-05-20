using System;
using System.Windows.Controls;
using System.Windows.Media;
namespace MLTA_1_1
{
    /// <summary>
    /// Выводит результат (СДНФ, СКНФ, ПНФ)
    /// </summary>
    public partial class Result : Page
    {
        private readonly bool[] truthTable;
        /// <summary>
        /// Выводит результат (СДНФ, СКНФ, ПНФ)
        /// </summary>
        /// <param name="massive">Таблица истинности</param>
        public Result(bool[] massive)
        {
            InitializeComponent();
            truthTable = massive;
            Run();
        }
        private void Run()
        {
            PDNF p1 = new(truthTable);
            string result1 = p1.Run();
            labelPDNF.Content = result1;
            labelPDNF.FontSize = 16;
            labelPDNF.Foreground = Brushes.AliceBlue;

            PCNF p2 = new(truthTable);
            string result2 = p2.Run();
            labelPCNF.Content = result2;
            labelPCNF.FontSize = 16;
            labelPCNF.Foreground = Brushes.AliceBlue;

            PNF p3 = new(truthTable);
            string result3 = p3.Run();
            labelPNF.Content = result3;
            labelPNF.FontSize = 16;
            labelPNF.Foreground = Brushes.AliceBlue;

            result1 = String.Join("",result1.Split(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', '(', ')', '¬' }));
            result2 = String.Join("", result2.Split(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', '(', ')', '¬' }));
            result3 = String.Join("", result3.Split(new char[] { '1', ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', '(', ')', '¬' }));

            labelLeastCount.Content +=
                result1.Length <= result2.Length && result1.Length <= result3.Length && result1 != "Невозможно построить" ?
                "СДНФ " : "";
            labelLeastCount.Content +=
                result2.Length <= result3.Length && result2.Length <= result1.Length && result2 != "Невозможно построить" ?
                "СКНФ " : "";
            labelLeastCount.Content +=
                result3.Length <= result2.Length && result3.Length <= result1.Length?
                "ПНФ " : "";
            labelLeastCount.FontSize = 16;
            labelLeastCount.Foreground = Brushes.AliceBlue;
        }
    }
}