using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace Graficos
{
    /// <summary>
    /// Implementa lógica com gráficos bonitos.
    /// Crédito: https://github.com/microcharts-dotnet/Microcharts
    /// Wiki:    https://github.com/microcharts-dotnet/Microcharts/wiki
    /// </summary>
    /// <remarks>Helberte Costa, 27/02/2024</remarks>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        readonly List<ChartEntry> entries = new List<ChartEntry>();

        private ChartView chartView = null;
        private System.Timers.Timer meuTimer = null;
        private HorizontalScrollView scrollView = null;
        private BarChart barras;
        private int valorAleatorio;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // obtém as referências do layout
            chartView = FindViewById<ChartView>(Resource.Id.chartView);
            scrollView = FindViewById<HorizontalScrollView>(Resource.Id.scrollView);

            // inicializa o timer
            meuTimer = new System.Timers.Timer(1000);
            meuTimer.Elapsed += MeuTimer_Elapsed;

            // gera valor randomico
            valorAleatorio = new Random().Next(500, 600);

            // adiciona um item que será uma barra no gráfico
            entries.Add(
                new ChartEntry(valorAleatorio)
                {
                    Label = "-",
                    ValueLabel = valorAleatorio.ToString(),
                    Color = valorAleatorio < 550 ? SKColor.Parse("#FF6C6C") : SKColor.Parse("#D6D547")
                }
            );

            // grafico de barras
            barras = new BarChart
            {
                LabelOrientation = Microcharts.Orientation.Vertical,
                IsAnimated = true,
                Entries = entries,
                Margin = 10,
                BackgroundColor = SKColor.Parse("#FFFFFF")
            };
            barras.IsAnimated = false;

            // seta propriedade com o gráfico no elemento de tela
            chartView.Chart = barras;

            // inicia o timer
            meuTimer.Start();
        }

        private void MeuTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // volta para a thread principal
            RunOnUiThread(() =>
            {
                ViewGroup.LayoutParams layoutParams = chartView.LayoutParameters;

                valorAleatorio = new Random().Next(500, 600);

                entries.Add(
                    new ChartEntry(valorAleatorio)
                    {
                        Label = "-",
                        ValueLabel = valorAleatorio.ToString(),
                        Color = valorAleatorio < 550 ? SKColor.Parse("#FF6C6C") : SKColor.Parse("#D6D547")
                    }
                );

                // elimina as primeiras caso a quantidade de barras ultrapasse o limite
                EliminaPrimeiras(entries, 50);

                // converte valor em dip, em pixels para aumentar a largura do componente de tela
                layoutParams.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, entries.Count * 15, Application.Context.Resources.DisplayMetrics);

                chartView.LayoutParameters = layoutParams;

                // reinicia a propriedade que contém o gráfico
                chartView.Chart = null;
                chartView.Chart = barras;

                // move o scroll para o fim do horizontalscroll
                scrollView.ScrollX = 16 * entries.Count;
            });
        }

        private void EliminaPrimeiras(List<ChartEntry> lista, int limite)
        {
            if (lista.Count > limite)
            {
                for (int i = 0; i <= lista.Count - limite; i++)
                    lista.RemoveAt(i);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}