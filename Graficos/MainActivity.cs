using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.CardView.Widget;
using AndroidX.RecyclerView.Widget;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using static Android.Security.Identity.CredentialDataResult;

namespace Graficos
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        readonly List<ChartEntry> entries = new List<ChartEntry>();

        private ChartView            chartView     = null;
        private System.Timers.Timer  meuTimer      = null;
        private HorizontalScrollView scrollView    = null;
        private BarChart             barras;
        private int                  valorAleatorio;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            chartView         = FindViewById<ChartView>            (Resource.Id.chartView);
            scrollView        = FindViewById<HorizontalScrollView> (Resource.Id.scrollView);

            meuTimer          = new System.Timers.Timer(1000);
            meuTimer.Elapsed += MeuTimer_Elapsed;

            valorAleatorio    = new Random().Next(0, 1000);
            entries.Add(
                new ChartEntry(valorAleatorio)
                {
                    Label      = "UWP",
                    ValueLabel = valorAleatorio.ToString(),
                    Color      = valorAleatorio < 500 ? SKColor.Parse("#FF6C6C") : SKColor.Parse("#D6D547")
                }
            );

            // grafico de barras
            barras = new BarChart
            {
                LabelOrientation = Microcharts.Orientation.Vertical,
                IsAnimated       = true,
                Entries          = entries,
                Margin           = 10
            };
            barras.IsAnimated    = false;

            chartView.Chart = barras;

            meuTimer.Start();
        }

        private void MeuTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {                
                ViewGroup.LayoutParams layoutParams = chartView.LayoutParameters;
                
                valorAleatorio = new Random().Next(0, 1000);

                entries.Add(
                    new ChartEntry(valorAleatorio)
                    {
                        Label      = "UWP",
                        ValueLabel = valorAleatorio.ToString(),
                        Color      = valorAleatorio < 500 ? SKColor.Parse("#FF6C6C") : SKColor.Parse("#D6D547")
                    }
                );

                EliminaPrimeiras(entries, 50);

                layoutParams.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, entries.Count * 15, Application.Context.Resources.DisplayMetrics);

                chartView.LayoutParameters = layoutParams;

                chartView.Chart    = null;
                chartView.Chart    = barras;

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