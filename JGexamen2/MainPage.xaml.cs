using Microsoft.Maui.Controls;
using System;

namespace JGexamen2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void JGOnConvertClicked(object sender, EventArgs e)
        {
            if (double.TryParse(JGInputEntry.Text, out double JGInputValue) &&
                JGFromUnitPicker.SelectedItem != null &&
                JGToUnitPicker.SelectedItem != null)
            {
                string JGFromUnit = JGFromUnitPicker.SelectedItem.ToString();
                string JGToUnit = JGToUnitPicker.SelectedItem.ToString();
                double JGResult = JGConvertUnits(JGInputValue, JGFromUnit, JGToUnit);
                JGResultLabel.Text = $"Resultado: {JGResult:F2} {JGToUnit}";
            }
            else
            {
                JGResultLabel.Text = "Ingrese un número válido y seleccione las unidades.";
            }
        }

        private double JGConvertUnits(double JGValue, string JGFromUnit, string JGToUnit)
        {
            if (JGFromUnit == JGToUnit)
                return JGValue;

            // Conversiones intermedias
            double JGValueInKg = JGFromUnit switch
            {
                "Libras" => JGValue * 0.453592,
                "Onzas" => JGValue * 0.0283495,
                _ => JGValue // Kilogramos
            };

            return JGToUnit switch
            {
                "Libras" => JGValueInKg / 0.453592,
                "Onzas" => JGValueInKg / 0.0283495,
                _ => JGValueInKg // Kilogramos
            };
        }
    }
}
